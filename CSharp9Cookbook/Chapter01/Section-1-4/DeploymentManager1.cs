namespace Section_1_4
{
    public class DeploymentManager1 : DeploymentManagementBase
    {
        protected override IDeploymentPlugin CreateDeploymentService()
        {
            return new DeploymentPlugin1();
        }
    }
}
