using System;
using UIAutomationClient;
using System.Threading;
using System.Windows.Automation;

namespace TestScenario
{
    class Program
    {

        static void Main(string[] args) {

            // Instantiate the UIA object:
            IUIAutomation _automation = new CUIAutomation();
            // Get the root element
            IUIAutomationElement rootElement = _automation.GetRootElement();
            // Get its name
            string rootName = rootElement.CurrentName;
            Console.WriteLine(
                "The root automation element's name should be 'Desktop'.");
            Console.WriteLine("The actual value is: '{0}'", rootName);

        
            IUIAutomationCondition condition = _automation.CreatePropertyCondition(UIA_PropertyIds.UIA_IsKeyboardFocusablePropertyId, true);
          
            IUIAutomationElement e = rootElement.FindFirst(TreeScope.TreeScope_Children, condition);

            Console.WriteLine(e.CurrentName);
            

            Thread.Sleep(10000);

        }







    }



}
