using Autofac;
using System;

namespace Section_1_2
{
    class Program
    {
        readonly IDeploymentService service;

        public Program(IDeploymentService service)
        {
            this.service = service;
        }

        public static IContainer container;

        static void Main()
        {
            var builder = new ContainerBuilder();

            builder.RegisterType<DeploymentArtifacts>();
            builder.RegisterType<DeploymentRepository>();
            builder.RegisterType<DeploymentService>().As<IDeploymentService>();

            container = builder.Build();

            var program = new Program(container.Resolve<IDeploymentService>());

            program.StartDeployment();
        }

        public void StartDeployment()
        {
            service.PerformValidation();
            Console.WriteLine("Validation complete - continuing...");
        }
    }
}
