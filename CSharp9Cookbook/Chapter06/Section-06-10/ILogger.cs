using System.Threading.Tasks;

namespace Section_06_10
{
    public interface ILogger
    {
        Task<string> WriteAsync(string message);
    }
}
