namespace Section_1_10
{
    public class DeploymentBuilder
    {
        DeploymentService service = new DeploymentService();

        public DeploymentBuilder SetStartDelay(int delay)
        {
            service.StartDelay = delay;
            return this;
        }

        public DeploymentBuilder SetErrorRetries(int retries)
        {
            service.ErrorRetries = retries;
            return this;
        }

        public DeploymentBuilder SetReportFormat(string format)
        {
            service.ReportFormat = format;
            return this;
        }

        public DeploymentService Build()
        {
            return service;
        }
    }
}
