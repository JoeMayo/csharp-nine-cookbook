using System;

namespace Section_1_4
{
    public class DeploymentPlugin2 : IDeploymentPlugin
    {
        public bool Validate()
        {
            Console.WriteLine("Validated Plugin 2");
            return true;
        }
    }
}
