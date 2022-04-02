using System;
using System.Net;
using System.IO;
using Microsoft.Extensions.Configuration;
using SnQPoolIot.Logic.Entities.Business.Logging;

namespace SnQPoolIot.WebApi
{
    /// <summary>
    /// Notification per TelegramBot. Die entsprechenden Konfigurationen (apiToken, und Chatid) werden aus den appsettings ausgelesen
    /// </summary>
    public class MessageNotification
    {
        /// <summary>
        /// Die Notification wird an Telegram übertragen.
        /// </summary>
        /// <param name="notification"></param>
        /// <returns></returns>
        public static bool SendMessageByTelegram(string notification)
        {
            var configuration = new ConfigurationBuilder()
                .AddJsonFile("appsettings.Development.json")
                .Build();
            string apiToken = configuration.GetValue<string>("Telegram:apiToken");
            string chatId = configuration.GetValue<string>("Telegram:chatId");          
            string urlString = "https://api.telegram.org/bot{0}/sendMessage?chat_id={1}&text={2}";
            string messageText = notification;
            urlString = String.Format(urlString, apiToken, chatId, messageText);

            try
            {
                WebRequest request = WebRequest.Create(urlString);
                WebResponse response = request.GetResponse();
                string responseStatus = ((HttpWebResponse)response).StatusDescription;
                if (responseStatus == "OK")
                {
                    using Stream dataStream = response.GetResponseStream();
                    using StreamReader reader = new(dataStream);
                    string responseFromServer = reader.ReadToEnd();
                    if (responseFromServer.Contains("\"ok\":true"))
                    {
                        LogWriter.Instance.LogWrite("Message text was successfully sent to Telegram");
                    }
                    else
                    {
                        LogWriter.Instance.LogWrite("Failed to send the message text to Telegram");
                    }
                    LogWriter.Instance.LogWrite(responseFromServer);
                }
                else
                {
                    LogWriter.Instance.LogWrite("Failed to send the message text to Telegram");
                    LogWriter.Instance.LogWrite("Response status: " + responseStatus);
                }
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                LogWriter.Instance.LogWrite("Failed to send the message text to Telegram");
                Console.Write(Environment.NewLine);
                Console.WriteLine(ex.ToString());

                return false;
            }
        }
    }
}
