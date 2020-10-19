namespace Section_1_4
{
    public class DeploymentManager2 : DeploymentManagementBase
    {
        protected override IDeploymentPlugin CreateDeploymentService()
        {
            return new DeploymentPlugin2();
        }
    }
}
