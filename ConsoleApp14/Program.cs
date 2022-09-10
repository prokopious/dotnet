using System;
using System.Windows.Automation;
using System.Diagnostics;
using System.Threading;
using System.Windows.Forms;


namespace TestScenario
{
    class Program
    {
        public static object SendKeys { get; private set; }

        static void Main(string[] args)
        {
            try
            {
                Process p = Process.Start("C:\\Windows\\notepad.exe");
                Thread.Sleep(5000);
                AutomationElement aeDesktop = AutomationElement.RootElement;
                AutomationElement aeForm = null;
                int numWaits = 0;
                do
                {
                    Console.WriteLine("Looking for Notepad");
                    aeForm = aeDesktop.FindFirst(TreeScope.Children,
                      new PropertyCondition(AutomationElement.ClassNameProperty, "Notepad"));
                    ++numWaits;
                    Thread.Sleep(100);
                } while (aeForm == null && numWaits < 50);
                if (aeForm == null) Console.WriteLine("Did not find it");
                else Console.WriteLine("Found it!");
                Thread.Sleep(5000);



                AutomationElement textField = null;
                int numWaits2 = 0;
                do
                {
                    Console.WriteLine("Looking for Text Editor");
                    textField = aeForm.FindFirst(TreeScope.Children,
                      new PropertyCondition(AutomationElement.NameProperty, "Application"));
                    ++numWaits;
                    Thread.Sleep(100);
                } while (textField == null && numWaits2 < 50);
                if (textField == null) Console.WriteLine("Did not find it");
                else Console.WriteLine("Found it!");
                Thread.Sleep(5000);
                


            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error: " + ex.Message);
            }
        }
    }
}