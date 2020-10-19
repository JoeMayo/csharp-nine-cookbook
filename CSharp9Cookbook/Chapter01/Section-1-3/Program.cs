namespace Section_1_3
{
    public class Program
    {
        ThirdPartyDeploymentService service;

        public Program(IValidatorFactory factory)
        {
            service = factory.CreateDeploymentService();
        }

        static void Main()
        {
            var factory = new ValidatorFactory();
            var program = new Program(factory);
            program.PerformValidation();
        }

        void PerformValidation()
        {
            service.Validate();
        }
    }
}
