namespace Section_1_2
{
    public class DeploymentService : IDeploymentService
    {
        readonly DeploymentArtifacts artifacts;
        readonly DeploymentRepository repository;

        public DeploymentService(
            DeploymentArtifacts artifacts, 
            DeploymentRepository repository) 
        {
            this.artifacts = artifacts;
            this.repository = repository;
        }

        public void PerformValidation()
        {
            artifacts.Validate();
            repository.SaveStatus("status");
        }
    }
}
