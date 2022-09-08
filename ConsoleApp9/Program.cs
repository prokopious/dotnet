using System;
using System.Windows.Forms;
using Interop.UIAutomationClient;
using System.Threading;





namespace PrintDesktopUiaElementNameViaCom
{

    class PrintDesktopUiaElementNameViaComProgram    {

        static void Main(string[] args)
        {
            string testAppName = "Text Editor";
            int propertyIdName = 30005;
            string className = "Notepad";
            int propertyIdClassName = 30012;
            IUIAutomation uiautomation = new CUIAutomation();
            IUIAutomationElement rootElement = uiautomation.GetRootElement();
            Thread.Sleep(2000);
            IUIAutomationCondition notepadName =
 uiautomation.CreatePropertyCondition(
     propertyIdClassName, className);
            Thread.Sleep(2000);
            IUIAutomationElement mainDialog =
                rootElement.FindFirst(
                    TreeScope.TreeScope_Children,
                    notepadName);
            Thread.Sleep(2000);
            IUIAutomationCondition conditionTestAppName =
    uiautomation.CreatePropertyCondition(
        propertyIdName, testAppName);
            Thread.Sleep(2000);
            IUIAutomationElement esditor =
                mainDialog.FindFirst(
                    TreeScope.TreeScope_Children,
                    conditionTestAppName);
            Thread.Sleep(2000);
            SendKeys.SendWait("Here is some text");
            Thread.Sleep(2000);

        }
    } 
        
    
}