using SimpleApp.Data;

namespace SimpleApp.Model
{
    public class Greeting
    {
        GreetingRepository greetRep = new GreetingRepository();

        public string GetGreeting(bool isNew) =>
            isNew ? greetRep.GetNewGreeting() : greetRep.GetVisitGreeting();
    }
}
