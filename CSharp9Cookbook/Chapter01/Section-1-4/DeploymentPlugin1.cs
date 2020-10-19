using System;

namespace Section_1_4
{
    public class DeploymentPlugin1 : IDeploymentPlugin
    {
        public bool Validate()
        {
            Console.WriteLine("Validated Plugin 1");
            return true;
        }
    }
}
