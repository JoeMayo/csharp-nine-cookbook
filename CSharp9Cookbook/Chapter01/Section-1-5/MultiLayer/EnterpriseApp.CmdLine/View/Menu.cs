using System;
using System.Collections.Generic;
using System.Text;

namespace EnterpriseApp.CmdLine.View
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
