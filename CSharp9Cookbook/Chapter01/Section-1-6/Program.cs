using System;

namespace Section_1_6
{
    class Program
    {
        readonly DeploymentService deployment = new DeploymentService();
        static void Main(string[] args)
        {
            new Program().Start();
        }

        void Start()
        {
            (bool deployed, bool smokeTest, bool artifacts) =
                deployment.PrepareDeployment();

            Console.WriteLine(
                $"\nDeployment Status:\n\n" +
                $"Is Previous Deployment Complete? {deployed}\n" +
                $"Is Previous Smoke Test Complete? {smokeTest}\n" +
                $"Are artifacts for this deployment ready? {artifacts}\n\n" +
                $"Can deploy: {deployed && smokeTest && artifacts}");
        }
    }
}
