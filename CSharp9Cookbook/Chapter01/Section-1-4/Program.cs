using System;

namespace Section_1_4
{
    class Program
    {
        readonly DeploymentManagementBase[] deploymentManagers;

        public Program(DeploymentManagementBase[] deploymentManagers)
        {
            this.deploymentManagers = deploymentManagers;
        }

        static DeploymentManagementBase[] GetPlugins()
        {
            return new DeploymentManagementBase[]
                {
                    new DeploymentManager1(),
                    new DeploymentManager2()
                };
        }

        static void Main()
        {
            DeploymentManagementBase[] deploymentManagers = GetPlugins();

            var program = new Program(deploymentManagers);

            program.Run();
        }

        void Run()
        {
            foreach (var manager in deploymentManagers)
                manager.Validate();
        }
    }
}
