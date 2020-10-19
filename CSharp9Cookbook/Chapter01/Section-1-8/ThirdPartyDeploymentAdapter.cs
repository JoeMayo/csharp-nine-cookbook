namespace Section_1_8
{
    public class ThirdPartyDeploymentAdapter : IDeploymentService
    {
        ThirdPartyDeploymentService service = new ThirdPartyDeploymentService();

        public void Validate()
        {
            service.PerformValidation();
        }
    }
}
