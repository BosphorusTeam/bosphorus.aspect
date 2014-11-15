using System;
using System.Threading;
using System.Threading.Tasks;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner;
using Environment = Bosphorus.BootStapper.Common.Environment;

namespace Bosphorus.Aspect.Core.Demo
{
    class Program: IProgram
    {
        private readonly IService service;

        public Program(IService service)
        {
            this.service = service;
        }

        static void Main(string[] args)
        {
            try
            {
                ConsoleRunner.Run<Program>(Environment.Local, Perspective.Debug, new[] {"Onur", "Eker"});
            }
            catch (System.Exception exception)
            {
                Console.WriteLine(exception);
            }
        }

        public void Run(string[] args)
        {
            CallService();
        }

        private void CallService()
        {
            service.Do(7);
        }
    }
}
