using Bosphorus.Assemble.BootStrapper.Runner.Console;
using Bosphorus.Common.Application;

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
            ConsoleRunner.Run<Program>(Environment.Local, Perspective.Debug, args, typeof(IDemoInstaller));
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
