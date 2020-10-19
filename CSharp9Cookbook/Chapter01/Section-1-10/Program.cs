using System;

namespace Section_1_10
{
    class Program
    {
        static void Main()
        {
            DeploymentService service =
                new DeploymentBuilder()
                    .SetStartDelay(3000)
                    .SetErrorRetries(3)
                    .SetReportFormat("html")
                    .Build();

            service.Start();
        }
    }
}
