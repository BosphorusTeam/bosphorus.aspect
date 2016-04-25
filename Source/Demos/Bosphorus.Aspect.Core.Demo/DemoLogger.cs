using System;
using System.Collections.Generic;
using Bosphorus.Aspect.Log;
using Bosphorus.Logging.Core.Logger;

namespace Bosphorus.Aspect.Core.Demo
{
    public class DemoLogger : ILogger<ServiceLog>
    {
        public void Log(ServiceLog log)
        {
            
            string message = $"InvocationId: {log.InvocationId}, Method: {log.Method}, LogData: {log.LogData}, Level: {log.Level}, DateTime: {log.DateTime}";
            Console.WriteLine(message);

        }

        public void Log(IEnumerable<ServiceLog> logs)
        {
            foreach (var log in logs)
            {
                Log(log);
            }
        }
    }
}