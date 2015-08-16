using System;
using Bosphorus.Aspect.Log;
using Bosphorus.Logging.Core;
using Bosphorus.Logging.Core.Logger;

namespace Bosphorus.Aspect.Core.Demo
{
    public class DemoLogger : ILogger<ServiceLog>
    {
        public void Log(ServiceLog log)
        {
            
            string message = string.Format("InvocationId: {0}, Method: {1}, LogData: {2}, Level: {3}, DateTime: {4}", log.InvocationId, log.Method, log.LogData, log.Level, log.DateTime);
            Console.WriteLine(message);

        }
    }
}