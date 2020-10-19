namespace Section_1_9
{
    public class DeploymentService
    {
        public void Validate()
        {
            throw new DeploymentValidationException(
                "Smoke test failed - check with qa@example.com.",
                null,
                ValidationFailureReason.SmokeTestFailed);
        }
    }
}
