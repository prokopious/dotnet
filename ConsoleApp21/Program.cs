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

            IUIAutomationCondition condition = _automation.CreatePropertyCondition(UIA_PropertyIds.UIA_NamePropertyId, "eDock.exe - .NET Framework Initialization Error");
          
            IUIAutomationElement e = rootElement.FindFirst(TreeScope.TreeScope_Children, condition);

            Console.WriteLine(e.CurrentClassName);

            IUIAutomationCondition condition2 = _automation.CreatePropertyCondition(UIA_PropertyIds.UIA_AutomationIdPropertyId, "65535");

            IUIAutomationElement e2 = e.FindFirst(TreeScope.TreeScope_Children, condition2);

            Console.WriteLine(e2.CurrentName);



            // IUIAutomationCondition condition2 = _automation.CreatePropertyCondition(UIA_PropertyIds.UIA_AutomationIdPropertyId, "15");
            // IUIAutomationElement e2 = e.FindFirst(TreeScope.TreeScope_Children, condition2);
            // Console.WriteLine(e2.CurrentName);
            Thread.Sleep(10000);

        }







    }



}
