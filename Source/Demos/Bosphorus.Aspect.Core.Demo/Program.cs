using System;
using Bosphorus.BootStapper.Runner;
using Bosphorus.BootStapper.Runner.Console;
using Bosphorus.Common.Core.Application;
using Environment = Bosphorus.Common.Core.Application.Environment;

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
            ConsoleRunner.Run<Program>(Environment.Local, Perspective.Debug, "Onur", "Eker");
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
