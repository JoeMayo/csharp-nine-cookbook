using System.Collections.Generic;

namespace Section_1_8
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Start();
        }

        void Start()
        {
            List<IDeploymentService> services = Configure();

            foreach (var svc in services)
                svc.Validate();
        }

        List<IDeploymentService> Configure()
        {
            return new List<IDeploymentService>
            {
                new DeploymentService1(),
                new DeploymentService2(),
                new ThirdPartyDeploymentAdapter()
            };
        }
    }
}
