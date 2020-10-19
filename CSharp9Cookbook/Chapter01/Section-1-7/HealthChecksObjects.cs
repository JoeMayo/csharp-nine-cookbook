using Section_1_7.Objects;

namespace Section_1_7
{
    public class HealthChecksObjects
    {
        public void PerformHealthChecks(int cycles)
        {
            CircularQueue checks = Configure();

            for (int i = 0; i < cycles; i++)
            {
                Deployment deployment = (Deployment)checks.Next();
                deployment.PerformHealthCheck();
            }
        }

        private CircularQueue Configure()
        {
            var queue = new CircularQueue(5);

            queue.Add(new Deployment("a"));
            queue.Add(new Deployment("b"));
            queue.Add(new Deployment("c"));

            return queue;
        }
    }
}
