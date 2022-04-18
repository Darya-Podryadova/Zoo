using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zoo
{
    public class Log
    {
        public string Info { get; set; }

        public delegate void Logger();
        public event Logger WriteLogs;

        public void Eve()
        {
            WriteLogs();
        }
    }
    public class Write
    {
        
        private static object sync = new object();
        //public static void WriteLog<T>(ref T lg, string info)
        //{
        //    try
        //    {
        //        // Путь .\\Log
        //        string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
        //        if (!Directory.Exists(pathToLog))
        //            Directory.CreateDirectory(pathToLog); // Создаем директорию, если нужно
        //        string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
        //        AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
        //        string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}]  {1}\r\n",
        //        DateTime.Now,  lg);
        //        lock (sync)
        //        {
        //            File.AppendAllText(filename, fullText, Encoding.GetEncoding("Windows-1251"));
        //        }
        //    }
        //    catch
        //    {
        //        // Перехватываем все и ничего не делаем
        //    }
        //}

        public void LogInfoCons<T>( T mes )
        {
            string LogInfo = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] Info: {1}\r\n", DateTime.Now, mes);

          
            Console.WriteLine(LogInfo);
            try
            {
                // Путь .\\Log
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog); // Создаем директорию, если нужно
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                //string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}]  {1}\r\n",
                //DateTime.Now, lg);
                lock (sync)
                {
                    File.AppendAllText(filename, LogInfo, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch
            {
                // Перехватываем все и ничего не делаем
            }

        }

        public void LogDebugCons<T>(ref T mes, string name)
        {
            string LogDebug = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] Debug: Значение {1} = {2}\r\n", DateTime.Now, name ,mes);

            Console.WriteLine(LogDebug);

           

            try
            {
                // Путь .\\Log
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog); // Создаем директорию, если нужно
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                //string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}]  {1}\r\n",
                //DateTime.Now, lg);
                lock (sync)
                {
                    File.AppendAllText(filename, LogDebug, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch
            {
                // Перехватываем все и ничего не делаем
            }
        }

        

        public void LogErrorCons<T>( T mes)
        {
            string LogError = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}] Error: {1}\r\n", DateTime.Now, mes);
            
            Console.WriteLine(LogError);

            

            try
            {
                // Путь .\\Log
                string pathToLog = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Log");
                if (!Directory.Exists(pathToLog))
                    Directory.CreateDirectory(pathToLog); // Создаем директорию, если нужно
                string filename = Path.Combine(pathToLog, string.Format("{0}_{1:dd.MM.yyy}.log",
                AppDomain.CurrentDomain.FriendlyName, DateTime.Now));
                //string fullText = string.Format("[{0:dd.MM.yyy HH:mm:ss.fff}]  {1}\r\n",
                //DateTime.Now, lg);
                lock (sync)
                {
                    File.AppendAllText(filename, LogError, Encoding.GetEncoding("Windows-1251"));
                }
            }
            catch
            {
                // Перехватываем все и ничего не делаем
            }
        }
    }
    


}

