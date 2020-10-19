using System;

namespace Section_1_9
{
    class Program
    {
        static void Main()
        {
            try
            {
                new DeploymentService().Validate();
            }
            catch (DeploymentValidationException ex)
            {
                Console.WriteLine(
                    $"Message: {ex.Message}\n" +
                    $"Reason: {ex.Reason}\n" +
                    $"Full Description: \n {ex}");
            }
        }
    }
}
