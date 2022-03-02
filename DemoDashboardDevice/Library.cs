using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace DemoDashboardDevice
{
    public static class Library
    {
        public static DateTime ultimo { get; set; }

        public static void WriteErrorLog(Exception ex)
        {
            StreamWriter sw = null;
            try
            {
                ultimo = DateTime.Now;
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/LogErrorFile.txt", true);
                sw.WriteLine(ultimo.ToString() + ": " + ex.Source.ToString().Trim() + "; " + ex.Message.ToString().Trim());
                sw.Flush();
                sw.Close();
            }
            catch { }
        }
        public static void WriteErrorLog(String Message)
        {
            StreamWriter sw = null;
            try
            {
                ultimo = DateTime.Now;
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/LogErrorFile.txt", true);
                sw.WriteLine(ultimo.ToString() + ": " + Message);
                sw.Flush();
                sw.Close();
            }
            catch { }
        }
        public static void WriteInfoLog(String Message)
        {
            StreamWriter sw = null;
            try
            {
                ultimo = DateTime.Now;
                sw = new StreamWriter(AppDomain.CurrentDomain.BaseDirectory + "/LogInfoFile.txt", true);
                sw.WriteLine(ultimo.ToString() + ": " + Message);
                sw.Flush();
                sw.Close();
            }
            catch { }
        }
    }
}
