using SystemApp.Console.Model;

namespace SystemApp.Console.View
{
    public class SignIn
    {
        Greeting greeting = new Greeting();

        public void Greet()
        {
            System.Console.Write("Is this your first visit? (true/false): ");
            string newResponse = System.Console.ReadLine();

            bool.TryParse(newResponse, out bool isNew);

            string greetResponse = greeting.GetGreeting(isNew);

            System.Console.WriteLine($"\n*\n* {greetResponse} \n*\n");
        }
    }
}
