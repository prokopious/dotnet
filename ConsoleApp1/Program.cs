using System;
using System.Threading;
using UIDeskAutomationLib;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {

            var engine = new Engine();
            Thread.Sleep(7000);
            UIDA_Window window = engine.GetTopLevel("Microsoft .NET Framework");
            var btnOne = window.Button("Close", true);

            Thread.Sleep(2000);
            btnOne.Click();



            //get the first Frame Tab element found.
            Thread.Sleep(15000);

        }
    }
}
