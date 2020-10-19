using System;

namespace Section_1_7
{
    public class Deployment
    {
        string config;

        public Deployment(string config)
        {
            this.config = config;
        }

        public bool PerformHealthCheck()
        {
            Console.WriteLine($"Performed health check for config {config}.");
            return true;
        }
    }
}
