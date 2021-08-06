namespace Section_1_4
{
    public abstract class DeploymentManagementBase
    {
        IDeploymentPlugin deploymentService;

        protected abstract IDeploymentPlugin CreateDeploymentService();

        public bool Validate()
        {
            if (deploymentService == null)
                deploymentService = CreateDeploymentService();

            return deploymentService.Validate();
        }
    }
}
