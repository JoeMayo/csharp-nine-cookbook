using System;

namespace Section_1_10
{
    public class DeploymentService
    {
        public int StartDelay { get; set; } = 2000;
        public int ErrorRetries { get; set; } = 5;
        public string ReportFormat { get; set; } = "pdf";

        public void Start()
        {
            Console.WriteLine(
                $"Deployment started with:\n" +
                $"    Start Delay:   {StartDelay}\n" +
                $"    Error Retries: {ErrorRetries}\n" +
                $"    Report Format: {ReportFormat}");
        }
    }
}
