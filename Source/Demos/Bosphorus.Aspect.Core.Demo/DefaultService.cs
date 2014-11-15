using System;
using System.Threading;

namespace Bosphorus.Aspect.Core.Demo
{
    public class DefaultService : IService
    {
        public void Do(int integerParameter1)
        {
            Console.WriteLine("Do...");
            //throw new System.Exception("Deneme");
        }
    }
}