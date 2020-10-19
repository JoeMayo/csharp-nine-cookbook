using System;

namespace EnterpriseApp.CmdLine.View
{
    public class SignIn
    {
        Greeting greeting = new Greeting();

        public void Greet()
        {
            Console.Write("Is this your first visit? (true/false): ");
            string newResponse = Console.ReadLine();

            bool.TryParse(newResponse, out bool isNew);

            string greetResponse = greeting.GetGreeting(isNew);

            Console.WriteLine($"\n*\n* {greetResponse} \n*\n");
        }
    }
}
