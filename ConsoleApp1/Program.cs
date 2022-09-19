using System;
using System.Threading;
using System.Windows.Forms;
using UIAutomationClient;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            IUIAutomation automation = new CUIAutomation();
            IUIAutomationElement desktop = automation.GetRootElement();

            IUIAutomationCondition processIdCondition = automation.CreatePropertyCondition(30005, "Untitled - Notepad");
            IUIAutomationElement e = desktop.FindFirst(TreeScope.TreeScope_Children, processIdCondition);
        

            Console.WriteLine(e.CurrentClassName);
            //get the first Frame Tab element found.
            Thread.Sleep(15000);

        }
    }
}
