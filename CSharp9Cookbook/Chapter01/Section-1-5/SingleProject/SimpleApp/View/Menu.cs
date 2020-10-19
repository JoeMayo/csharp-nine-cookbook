using System;

namespace SimpleApp.View
{
    public class Menu
    {
        public void Show()
        {
            Console.WriteLine(
                "*------*\n" +
                "* Menu *\n" +
                "*------*\n" +
                "\n" +
                "1. ...\n" +
                "2. ...\n" +
                "3. ...\n" +
                "\n" +
                "Choose: ");
        }
    }
}
