using System;
using System.IO;

namespace Section_1_1
{
    public class DeploymentProcess : IDisposable
    {
        private bool disposed;

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
                    report?.Close();
                }

                // TODO: free unmanaged resources (unmanaged objects) and override finalizer
                // TODO: set large fields to null
                disposed = true;
            }
        }

        // // TODO: override finalizer only if 'Dispose(bool disposing)' has code to free unmanaged resources
        // ~DeploymentProcess()
        // {
        //     // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
        //     Dispose(disposing: false);
        // }

        public void Dispose()
        {
            // Do not change this code. Put cleanup code in 'Dispose(bool disposing)' method
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
