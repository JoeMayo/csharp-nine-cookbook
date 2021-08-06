using System;
using System.IO;

namespace Section_1_1
{
    public class DeploymentProcess : IDisposable
    {
        bool disposed;

        readonly StreamWriter report = new StreamWriter("DeploymentReport.txt");

        public bool CheckStatus()
        {
            report.WriteLine($"{DateTime.Now} Application Deployed.");

            return true;
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    // disposal of purely managed resources goes here
                }

                report?.Close();
                disposed = true;
            }
        }

        ~DeploymentProcess()
        {
            Dispose(disposing: false);
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
