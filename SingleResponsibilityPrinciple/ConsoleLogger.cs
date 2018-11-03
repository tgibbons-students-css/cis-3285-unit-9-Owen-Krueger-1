using System;
using System.IO;
using SingleResponsibilityPrinciple.Contracts;

namespace SingleResponsibilityPrinciple
{
    public class ConsoleLogger : ILogger
    {
        public void LogWarning(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("WARN: ", message), args);
            using (StreamWriter w = File.AppendText("log.xml")) //Log information to an xml file
            {
                w.WriteLine("<log><type>WARN</type><message>" + message + "</message>", args); //message to write out
            }
        }

        public void LogInfo(string message, params object[] args)
        {
            Console.WriteLine(string.Concat("INFO: ", message), args);
            using (StreamWriter w = File.AppendText("log.xml")) //Log information to an xml file
            {
                w.WriteLine("<log><type>INFO</type><message>" + message + "</message>", args); //message to write out
            }
        }
    }
}
