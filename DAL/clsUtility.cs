using System;
using System.Collections.Generic;
using System.Configuration;
using System.IO;
using System.Reflection;
using System.Text;

namespace DAL
{
    public class clsUtility
    {
        public static Configuration GetConfiguration()
        {
            Assembly executingAssembly = Assembly.GetAssembly(typeof(DatabaseContext));
            string targetDir = executingAssembly.Location;
            Configuration config = ConfigurationManager.OpenExeConfiguration(targetDir);
            return config;
        }
        public static string StatusLogFile()
        {
            return GetConfiguration().AppSettings.Settings["ErrorLogFile"].Value;
        }

        public static bool WriteToFile(string fileName, string message)
        {
            try
            {
                using (StreamWriter writer = new StreamWriter(fileName, true))
                {
                    writer.WriteLine(string.Format($"* {DateTime.Now}: {message}\n"));
                    writer.Close();
                }
            }
            catch
            {
                return false;
            }

            return true;
        }
    }
}
