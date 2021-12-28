using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Utils;

using HomeAutomation.Core.Contracts;
using HomeAutomation.Core.Entities;
using HomeAutomation.Persistence;
using HomeAutomation.Services.DataTransferObjects;

using Microsoft.EntityFrameworkCore;

using Serilog;

namespace HomeAutomation.Services
{
    public class MqttToSqlMapper : IMqttToSqlMapper
    {
        private readonly ConcurrentDictionary<String, Sensor> _sensors;
        private readonly ConcurrentDictionary<String, Thing> _things;

        private readonly IUnitOfWork _unitOfWork;

        public MqttToSqlMapper()
        {
            _unitOfWork = new UnitOfWork();
            _unitOfWork.DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            _sensors = new ConcurrentDictionary<string, Sensor>();
            _things = new ConcurrentDictionary<string, Thing>();
        }

        private static MqttMessageDto ParseMqttPayload(string payload)
        {
            var text = payload.RemoveChars("\"{}\\");
            var properties = text.ToString().Split(',');
            Dictionary<string, string> propertyValues = new Dictionary<string, string>();
            foreach (var property in properties)
            {
                var keyValuePairs = property.Split(':');
                propertyValues.Add(keyValuePairs[0].ToLower(), keyValuePairs[1]);
            }
            var mqttMessageDto = new MqttMessageDto();
            if (propertyValues.ContainsKey("timestamp"))
            {
                mqttMessageDto.Time = TimeConverters.UnixTimeStampToDateTime(double.Parse(propertyValues["timestamp"]));
            }
            if (propertyValues.ContainsKey("ip"))
            {
                mqttMessageDto.Ip = propertyValues["ip"];
            }
            if (propertyValues.ContainsKey("wifipower"))
            {
                var wifiPower = NumberConverters.ParseInvariantDouble(propertyValues["wifipower"]);
                if (wifiPower != null)
                {
                    mqttMessageDto.WifiPower = wifiPower.Value;
                }
                else
                {
                    Log.Error("MapMqttToMeasurement, WifiPower.TryParse: '{ValueString}', FormatException",
                            propertyValues["wifipower"]);
                }
            }
            if (propertyValues.ContainsKey("restarthours"))
            {
                mqttMessageDto.RestartHours = int.Parse(propertyValues["restarthours"]);
            }
            if (propertyValues.ContainsKey("appname"))
            {
                mqttMessageDto.AppName = propertyValues["appname"];
            }
            if (propertyValues.ContainsKey("appversion"))
            {
                mqttMessageDto.AppVersion = propertyValues["appversion"];
            }
            if (propertyValues.ContainsKey("operationhours"))
            {
                mqttMessageDto.OperationHours = int.Parse(propertyValues["operationhours"]);
            }
            if (propertyValues.ContainsKey("value"))
            {
                string valueString = propertyValues["value"];
                if (valueString == "CLOSED" || valueString == "OFF")
                {
                    mqttMessageDto.Value = 0.0;
                }
                else if (valueString == "OPEN" || valueString == "ON" || valueString == "TILTED")
                {
                    mqttMessageDto.Value = 1.0;
                }
                else if (valueString == "NaN")
                {
                    mqttMessageDto.Value = 0.0;
                }
                else
                {
                    var value = NumberConverters.ParseInvariantDouble(valueString);
                    if (value != null)
                    {
                        mqttMessageDto.Value = value.Value;
                    }
                    else
                    {
                        Log.Error("MapMqttToMeasurement, double.TryParse: '{ValueString}', Length: {Length}, FormatException",
                                valueString, valueString.Length);
                        return null;
                    }
                }
            }
            return mqttMessageDto;
        }

        public void MapMqttMessageToMeasurement(string topic, string payload, int qos, bool retained)
        {
            //return;
            Log.Information("MapMqttToMeasurement, topic: {Topic}, payload: {payload}", topic, payload);
            if (topic.StartsWith("shellies") || topic.StartsWith("tele"))
            {
                return;
            }
            if (!topic.EndsWith("/state")) // Messwerte enden auf state
            {
                Log.Error("MapMqttMessageToMeasurement, Topic {Topic} doesn't end with state", topic);
                return;
            }
            topic = topic[0..^6];  // state wegschneiden
            int lastSlashPos = topic.LastIndexOf('/');  // letzter String ist Sensorname
            string thingName = topic.Substring(0, lastSlashPos);
            if (thingName.Where(ch => ch == ':').Count() == 5)  // Mac-Adresse ==> Thingname ist Miflora und nur Macadresse
            {
                thingName = thingName.Substring(thingName.Length - 17);  // letzte 17 Zeichen bleiben (Macadresse)
            }
            string sensorName = topic.Substring(lastSlashPos + 1, topic.Length - lastSlashPos - 1);

            MqttMessageDto mqttMessageDto = ParseMqttPayload(payload);
            if (mqttMessageDto == null)
            {
                Log.Error("MapMqttMessageToMeasurement, Thing: {Thing}, Sensor: {Sensor}, Value not parsable: {Payload}", 
                        thingName, sensorName, payload);
                return;
            }
            _things.TryGetValue(thingName, out Thing thing);
            if (thing == null)  // Thing nicht in Cache verfügbar
            {
                thing = SynchronizeThing(thingName);
            }
            _sensors.TryGetValue(topic, out Sensor sensor);
            if (sensor == null)  // Sensor nicht in Cache verfügbar
            {
                sensor = SynchronizeSensor(thing, sensorName, topic);
            }

            var measurement = new Measurement
            {
                SensorId = sensor.Id,
                Time = mqttMessageDto.Time,
                Value = mqttMessageDto.Value,
                Retained = retained
            };
            if (sensorName == "rssi")  // ESP schickt IP, RSSI, OperationHours ...  ==>  Systemmonitor
            {
                var memory = GC.GetTotalMemory(true);
                Log.Information("MapMqttToMeasurement, Used Memory [MB]: {Memory}", memory / 1000000);
                AddEspMonitoringMessage(thing, mqttMessageDto);
            }
            SaveMeasurement(thing, sensor, measurement);
            measurement = null;
            
        }

        /// <summary>
        /// Messwert in die Datenbank speichern.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="sensor"></param>
        /// <param name="measurement"></param>
        private void SaveMeasurement(Thing thing, Sensor sensor, Measurement measurement)
        {
            try
            {
                //int count = AddMeasurementAsync(measurement).Result;
                //_unitOfWork.Measurements.Add(measurement);
                _unitOfWork.DbContext.Attach(measurement).State = EntityState.Added;
                int count = _unitOfWork.SaveChanges();
                _unitOfWork.DbContext.Entry(measurement).State = EntityState.Detached;

                if (count == 0)
                {
                    Log.Error("MapMqttToMeasurement, Measurement, SaveChanges(), Thing: {Thing}, Sensor: {Sensor}, Value: {Value}, Time: {Time} count ==0, NOT added",
                                thing.Name, sensor.Name, measurement.Value, measurement.Time.ToString());
                }
                else
                {
                    Log.Information("MapMqttToMeasurement, Measurement, SaveChanges(), Thing: {Thing}, Sensor: {Sensor}, Value: {Value}, Time: {Time} added",
                                thing.Name, sensor.Name, measurement.Value, measurement.Time.ToString());
                }
            }
            catch (Exception ex)
            {
                Log.Error("MapMqttToMeasurement, Measurement, SaveChanges(), Thing: {Thing}, Sensor: {Sensor}, Value: {Value}, Time: {Time} added, Exception: {Message}",
                            thing.Name, sensor.Name, measurement.Value, measurement.Time.ToString(), ex.Message);
                StringBuilder innerExceptionMessages = new StringBuilder();
                var innerEx = ex.InnerException;
                while (innerEx != null)
                {
                    innerExceptionMessages.Append(innerEx.Message);
                    innerExceptionMessages.Append('*');
                    innerEx = innerEx.InnerException;
                }
                Log.Error("MapMqttToMeasurement, Measurement, SaveChanges(), InnerExceptions: {InnerException}", innerExceptionMessages.ToString());
                //_measurementUnitOfWork.DbContext.Dispose();
                //_measurementUnitOfWork.Dispose();
                //_measurementUnitOfWork = new UnitOfWork();
                //_measurementUnitOfWork.DbContext.ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
            }
        }


        /// <summary>
        /// ESP-Monitoring-Message (Mqtt-Message für rssi mit IP-Adresse, Betriebsstunden, ....
        /// als aktuellen Status in das Thing schreiben.
        /// </summary>
        /// <param name="thing"></param>
        /// <param name="mqttMessageDto"></param>
        private void AddEspMonitoringMessage(Thing thing, MqttMessageDto mqttMessageDto)
        {
            thing.IpAddress = mqttMessageDto.Ip;
            thing.OperationHours = mqttMessageDto.OperationHours;
            var timeDifference = (int)(DateTime.Now - mqttMessageDto.Time).TotalSeconds;
            thing.RestartHours = mqttMessageDto.RestartHours;
            thing.AppNameAndVersion = mqttMessageDto.AppName + mqttMessageDto.AppVersion;
            thing.TimeDifference = timeDifference;
            _unitOfWork.DbContext.ChangeTracker.Clear();  // damit nicht gecachtes Thing gelesen wird??
            var dbThing = _unitOfWork.Things.GetById(thing.Id);
            Log.Information("Thing {Thing} read, App: {AppNameAndVersion}, TimeDiff {TimeDiff}, OperationHours: {OperationHours}, RestartHours: {RestartHours}, LastUpdate: {LastUpdate} ",
                dbThing.Name, thing.AppNameAndVersion, dbThing.TimeDifference, thing.OperationHours, thing.RestartHours, dbThing.LastUpdate.ToShortTimeString());
            dbThing.LastUpdate = DateTime.Now;
            thing.LastUpdate = dbThing.LastUpdate;
            dbThing.TimeDifference = thing.TimeDifference;
            dbThing.IpAddress = thing.IpAddress;
            dbThing.OperationHours = thing.OperationHours;
            dbThing.RestartHours = thing.RestartHours;
            dbThing.AppNameAndVersion = thing.AppNameAndVersion;
            _unitOfWork.DbContext.Attach(dbThing).State = EntityState.Modified;  //! war thing
            try
            {
                if (_unitOfWork.SaveChanges() > 0)
                {
                    Log.Information("Thing {Thing} updated, App: {AppNameAndVersion}, TimeDiff {TimeDiff}, OperationHours: {OperationHours}, RestartHours: {RestartHours},LastUpdate: {LastUpdate}  ", 
                        dbThing.Name, dbThing.AppNameAndVersion, dbThing.TimeDifference, dbThing.OperationHours, dbThing.RestartHours, dbThing.LastUpdate.ToShortTimeString());
                }
                else
                {
                    Log.Error("Thing {Thing}, TimeDiff {TimeDiff} updated", dbThing.Name, dbThing.TimeDifference);
                }
            }
            catch (Exception ex)
            {
                Log.Error("Thing Update Save Exception: {Exception}", ex.Message);
            }
        }

        private Sensor SynchronizeSensor(Thing thing, string sensorName, string topic)
        {
            var sensor = _unitOfWork
            .Sensors
            .GetByThingAndSensor(thing.Name, sensorName);
            if (sensor != null)  // In DB war Sensor schon enthalten, nicht aber in Cache
            {
                Log.Information("MapMqttMessageToMeasurement(); Sensor {Sensor} already in database", sensorName);
            }
            else
            {
                sensor = new Sensor { ThingId = thing.Id, Name = sensorName };
                _unitOfWork.DbContext.Attach(sensor).State = EntityState.Added;
                //_unitOfWork.Sensors.Add(sensor);
                try
                {
                    if (_unitOfWork.SaveChanges() > 0)
                    {
                        Log.Information("Sensor {Sensor} added", sensor.Name);
                    }
                    else
                    {
                        Log.Error("Sensor {Sensor} NOT added", sensor.Name);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("Sensors Save Exception: {Exception}", ex.Message);
                }
            }
            _sensors[topic] = sensor;
            return sensor;
        }


        /// <summary>
        /// Thing mit thingName wird in DB und in Cache angelegt und zurückgegeben.
        /// </summary>
        /// <param name="thingName"></param>
        /// <returns></returns>
        private Thing SynchronizeThing(string thingName)
        {
            var thing = _unitOfWork
            .Things
            .GetByName(thingName);
            if (thing != null)
            {
                Log.Information("MapMqttMessageToMeasurement(); Thing {Thing} already in database", thingName);
            }
            else
            {
                thing = new Thing { Name = thingName };
                //_unitOfWork.Things.Add(thing);
                _unitOfWork.DbContext.Attach(thing).State = EntityState.Added;
                try
                {
                    if (_unitOfWork.SaveChanges() > 0)
                    {
                        Log.Information("MapMqttMessageToMeasurement(); Thing {Thing} added", thing.Name);
                    }
                    else
                    {
                        Log.Error("MapMqttMessageToMeasurement(); Thing {Thing} NOT added", thing.Name);
                    }
                }
                catch (Exception ex)
                {
                    Log.Error("MapMqttMessageToMeasurement(); Things Save Exception: {Exception}", ex.Message);
                }
            }
            // nicht im DbContext verwalten
            //_thingUnitOfWork.DbContext.Entry(thing).State = EntityState.Detached;
            _things[thingName] = thing;
            return thing;
        }
    }
}
