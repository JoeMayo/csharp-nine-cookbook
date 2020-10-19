namespace Section_1_3
{
    public class ValidatorFactory : IValidatorFactory
    {
        public ThirdPartyDeploymentService CreateDeploymentService()
        {
            return new ThirdPartyDeploymentService();
        }
    }
}
