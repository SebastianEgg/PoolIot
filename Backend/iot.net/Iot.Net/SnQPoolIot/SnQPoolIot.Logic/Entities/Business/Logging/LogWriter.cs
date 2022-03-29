using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace SnQPoolIot.Logic.Entities.Business.Logging
{
    public class LogWriter
    {
        private string m_exePath = string.Empty;
        private static LogWriter _instance = null;

        public static LogWriter Instance
        {
            get
            {
                if(_instance == null)
                {
                    _instance = new LogWriter();
                }
                return _instance;
            }
        }

        private LogWriter()
        {

        }
        //Diese Methode bekommt eine Fehlermeldungen als Parameter mit und ruft die Methode Log auf.
        public void LogWrite(string logMessage)
        {
            m_exePath = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            try
            {
                using StreamWriter w = File.AppendText(m_exePath + "\\" + "log.txt");
                Log(logMessage, w);
            }
            catch (Exception)
            {
            }
        }

        public static void Log(string logMessage, TextWriter txtWriter)
        {
            try
            {
                txtWriter.Write("\r\nLog Entry : ");
                txtWriter.WriteLine("{0} {1}", DateTime.Now.ToLongTimeString(),
                    DateTime.Now.ToLongDateString());
                txtWriter.WriteLine("  :{0}", logMessage);
                txtWriter.WriteLine("-------------------------------");
            }
            catch (Exception )
            {
            }
        }
    }
}