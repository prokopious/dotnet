using System;
using UIAutomationClient;
using System.Threading;
using System.Windows.Automation;

using System.Diagnostics;

namespace TestScenario
{
    class Program
    {

        static void Main(string[] args) {
          //  Process p = Process.Start("C:\\Windows\\notepad.exe");
            Thread.Sleep(5000);
            // Instantiate the UIA object:
            IUIAutomation _automation = new CUIAutomation();
            // Get the root element
            IUIAutomationElement rootElement = _automation.GetRootElement();
            // Get its name
            Console.WriteLine("got the root element");
            IUIAutomationCondition condition = _automation.CreatePropertyCondition(UIA_PropertyIds.UIA_NamePropertyId, "Microsoft .NET Framework");
          
            IUIAutomationElement dialog = rootElement.FindFirst(TreeScope.TreeScope_Children, condition);

            Console.WriteLine(dialog.CurrentName);

            IUIAutomationCondition condition2 = _automation.CreatePropertyCondition(UIA_PropertyIds.UIA_NamePropertyId, "Continue");

            IUIAutomationElement continueButton = dialog.FindFirst(TreeScope.TreeScope_Children, condition2);

            Console.WriteLine(continueButton.CurrentName);
            Thread.Sleep(2000);
            IUIAutomationInvokePattern invokePatternFileTab = (IUIAutomationInvokePattern)continueButton.GetCurrentPattern(10000);
            Console.WriteLine(invokePatternFileTab.ToString());
            Thread.Sleep(2000);
            invokePatternFileTab.Invoke();

            Thread.Sleep(10000);

        }







    }



}
