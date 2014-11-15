using System;
using System.Collections.Generic;
using System.Reflection;
using Castle.DynamicProxy;

namespace Bosphorus.Aspect.Core.Aspect
{
    public static class IInvocationExtensions
    {
        public static IDictionary<string, object> GetInputs(this IInvocation extended)
        {
            ParameterInfo[] parameterInfos = extended.Method.GetParameters();

            IDictionary<string, object> inputValues = new Dictionary<string, object>();
            for (int parameterIndex = 0; parameterIndex < parameterInfos.Length; parameterIndex++)
            {
                ParameterInfo parameterInfo = parameterInfos[parameterIndex];
                object value = extended.Arguments[parameterIndex];

                inputValues.Add(parameterInfo.Name, value);
            }

            return inputValues;
        }

        public static Tuple<string, object> GetOutput(this IInvocation extended)
        {
            ParameterInfo returnParameter = extended.Method.ReturnParameter;
            if (returnParameter.ParameterType == typeof(void))
            {
                return null;
            }

            Tuple<string, object> result = new Tuple<string, object>("return", extended.ReturnValue);
            return result;
        }
    }
}
