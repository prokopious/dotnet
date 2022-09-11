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
                Thread.Sleep(2000);

                AutomationElement textField = aeForm.FindFirst(TreeScope.Children,
                    new PropertyCondition(AutomationElement.ClassNameProperty, "Edit"));

                Thread.Sleep(2000);

                Console.WriteLine(textField.Current.AutomationId);

                Thread.Sleep(2000);



            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error: " + ex.Message);
            }
        }

  




    }
}