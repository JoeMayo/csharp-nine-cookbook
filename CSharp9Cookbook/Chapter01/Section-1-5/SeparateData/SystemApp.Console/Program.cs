using SystemApp.Console.View;

namespace SystemApp.Console
{
    class Program
    {
        SignIn signIn = new SignIn();
        Menu menu = new Menu();

        static void Main()
        {
            new Program().Start();
        }

        void Start()
        {
            signIn.Greet();
            menu.Show();
        }
    }
}
