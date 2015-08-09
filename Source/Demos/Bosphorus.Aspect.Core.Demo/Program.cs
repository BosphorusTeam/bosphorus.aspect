using System;
using Bosphorus.BootStapper.Common;
using Bosphorus.BootStapper.Program;
using Bosphorus.BootStapper.Runner;
using Bosphorus.BootStapper.Runner.Console;
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
            ConsoleRunner.Run<Program>(Environment.Local, Perspective.Debug, new[] {"Onur", "Eker"});
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
