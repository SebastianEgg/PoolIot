﻿using System;
using System.Net;
using System.IO;
using Microsoft.Extensions.Configuration;

namespace SnQPoolIot.WebApi
{
    public class MessageNotification
    {
        public static bool MessageTelegramm(string notification)
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
                    using (Stream dataStream = response.GetResponseStream())
                    {
                        using (StreamReader reader = new StreamReader(dataStream))
                        {
                            string responseFromServer = reader.ReadToEnd();
                            if (responseFromServer.Contains("\"ok\":true"))
                            {
                                Console.WriteLine("Message text was successfully sent to Telegram :-)");
                            }
                            else
                            {
                                Console.WriteLine("Failed to send the message text to Telegram :-(");
                            }
                            Console.Write(Environment.NewLine);
                            Console.WriteLine(responseFromServer);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Failed to send the message text to Telegram :-(");
                    Console.Write(Environment.NewLine);
                    Console.WriteLine("Response status: " + responseStatus);
                }
                response.Close();
                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Failed to send the message text to Telegram :-(");
                Console.Write(Environment.NewLine);
                Console.WriteLine(ex.ToString());

                return false;
            }
        }
    }
}
