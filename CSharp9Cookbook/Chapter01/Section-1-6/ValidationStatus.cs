namespace Section_1_6
{
    public class ValidationStatus
    {
        public bool Deployment { get; set; }
        public bool SmokeTest { get; set; }
        public bool Artifacts { get; set; }

        public void Deconstruct(
            out bool isPreviousDeploymentComplete,
            out bool isSmokeTestComplete,
            out bool areArtifactsReady)
        {
            isPreviousDeploymentComplete = Deployment;
            isSmokeTestComplete = SmokeTest;
            areArtifactsReady = Artifacts;
        }
    }
}
