namespace Section_1_1
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var deployer = new DeploymentProcess())
            {
                deployer.CheckStatus();
            }
        }
    }
}
