using System;

namespace Section_1_8
{
    public class DeploymentService1 : IDeploymentService
    {
        public void Validate()
        {
            Console.WriteLine("Deployment Service 1 Validated");
        }
    }
}
