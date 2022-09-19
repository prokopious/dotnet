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
            engine.StartProcess("notepad.exe");
            UIDA_Window window = engine.GetTopLevel("Untitled - Notepad");
            var btnOne = window.Button("Close", true);

            Thread.Sleep(2000);
            btnOne.Click();



            //get the first Frame Tab element found.
            Thread.Sleep(15000);

        }
    }
}
