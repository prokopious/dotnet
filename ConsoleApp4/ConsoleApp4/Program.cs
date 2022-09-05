using System;
using System.Windows.Automation;
using System.Diagnostics;
using System.Threading;
namespace TestScenario
{
    class Program
    {
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

                AutomationElement menuTab = aeForm.FindFirst(TreeScope.Children,
                new PropertyCondition(AutomationElement.AutomationIdProperty, "MenuBar"));

                AutomationElement file = menuTab.FindFirst(TreeScope.Children,
                new PropertyCondition(AutomationElement.NameProperty, "File"));
                
                Thread.Sleep(5000);
                Console.WriteLine("Selecting File");
                ExpandCollapsePattern ipClickButton1 = (ExpandCollapsePattern)file.GetCurrentPattern(ExpandCollapsePattern.Pattern);
                ipClickButton1.Expand();
             
                Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error: " + ex.Message);
            }
        }
    }
}