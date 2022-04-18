using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Exept
    {
        private static object sync = new object();
        public static string[] ReadConfig(string filename)
        {
            if (File.Exists(filename))
            {
                StreamReader sr = new StreamReader(filename);

                string line = sr.ReadLine();
                

                return line.Split(';');
                
            }
            else
            {
                return null;
            }


           
        }
        public static void Write(Exception ex)
        {
            string n = "exeptconfig.txt";
            string[] config = ReadConfig(n);
            try
            {
                
                // Путь .\\Log
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog); // Создаем директорию, если нужно
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                string fullText = string.Format("{4}[{0:dd.MM.yyy HH:mm:ss.fff}] {5} {6} [{1}.{2}()] {7}{3}\r\n",
                DateTime.Now, ex.TargetSite.DeclaringType, ex.TargetSite.Name, ex.Message, config[0], config[1], config[2], config[3]);
                lock (sync)
                {
                    File.AppendAllText(filename, fullText, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch
            {
                // Перехватываем все и ничего не делаем
            }
        }
    }
}
