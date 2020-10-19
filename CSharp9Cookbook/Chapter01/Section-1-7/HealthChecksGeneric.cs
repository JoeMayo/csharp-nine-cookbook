using Section_1_7.Generic;

namespace Section_1_7
{
    public class HealthChecksGeneric
    {
        public void PerformHealthChecks(int cycles)
        {
            CircularQueue<Deployment> checks = Configure();

            for (int i = 0; i < cycles; i++)
            {
                Deployment deployment = checks.Next();
                deployment.PerformHealthCheck();
            }
        }

        private CircularQueue<Deployment> Configure()
        {
            var queue = new CircularQueue<Deployment>(5);

            queue.Add(new Deployment("a"));
            queue.Add(new Deployment("b"));
            queue.Add(new Deployment("c"));

            return queue;
        }
    }
}
