using System.Collections.Generic;
using Bosphorus.Aspect.Core.Aspect;
using Bosphorus.Common.Core.Application;
using Bosphorus.Common.Core.Context;
using Bosphorus.Common.Core.Context.Application;
using Bosphorus.Common.Core.Context.Call;
using Bosphorus.Common.Core.Context.Invocation;
using Bosphorus.Logging.Core;
using Bosphorus.Logging.Core.Logger;
using Bosphorus.Logging.Model;
using Bosphorus.Serialization.Core;
using Bosphorus.Serialization.Core.Serializer.Json;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Log
{
    //http://james.newtonking.com/archive/2009/07/10/ado-net-entity-framework-support-accidently-added-to-json-net
    //http://james.newtonking.com/json
    //http://stackoverflow.com/questions/17986193/json-mapping-and-serializing-in-c-sharp
    public class LogAspect<TService> : AbstractAspect<TService>, ILogAspect<TService>
    {
        private readonly ILogger<ServiceLog> logger;
        private readonly GenericJsonSerializer jsonSerializer;

        public LogAspect(GenericContextProvider genericContextProvider, ILogger<ServiceLog> logger, GenericJsonSerializer jsonSerializer) 
            : base(genericContextProvider)
        {
            this.logger = logger;
            this.jsonSerializer = jsonSerializer;
        }

        protected override void Intercept(ApplicationContext applicationContext, CallContext callContext, InvocationContext invocationContext, IInvocation invocation)
        {
            try
            {
                LogInput(invocationContext, invocation);
                invocation.Proceed();
                LogOutput(invocationContext, invocation);
            }
            catch (System.Exception exception)
            {
                LogException(invocationContext, invocation, exception);
                throw;
            }
        }

        private void LogInput(InvocationContext invocationContext, IInvocation invocation)
        {
            IDictionary<string, object> inputs = invocation.GetInputs();
            string logData = jsonSerializer.Serialize(inputs);
            LogInfo(invocationContext, invocation, "Service input received", logData);
        }

        private void LogOutput(InvocationContext invocationContext, IInvocation invocation)
        {
            object output = invocation.GetOutput();
            string logData = output == null ? null : jsonSerializer.Serialize(output);
            LogInfo(invocationContext, invocation, "Service output sent", logData);
        }

        private void LogException(InvocationContext invocationContext, IInvocation invocation, System.Exception exception)
        {
            string logData = exception.ToString();
            LogError(invocationContext, invocation, "Service execution failed", logData);
        }

        private void LogInfo(InvocationContext invocationContext, IInvocation invocation, string logMessage, string logData)
        {
            Log(invocationContext, invocation, LogLevel.Info, logMessage, logData);
        }

        private void LogError(InvocationContext invocationContext, IInvocation invocation, string logMessage, string logData)
        {
            Log(invocationContext, invocation, LogLevel.Error, logMessage, logData);
        }

        private void Log(InvocationContext invocationContext, IInvocation invocation, LogLevel logLevel, string logMessage, string logData)
        {
            ServiceLog serviceLog = new ServiceLog();
            serviceLog.Class = invocation.TargetType.FullName;
            serviceLog.InvocationId = invocationContext.Id.GetValueOrDefault();
            serviceLog.Method = invocation.Method.ToString();
            serviceLog.Message = logMessage;
            serviceLog.Level = logLevel;
            serviceLog.LogData = logData;

            logger.Log(serviceLog);
        }

    }
}
