using System;
using UIAutomationClient;
using System.Threading;
using System.Xml.Linq;

namespace TestScenario
{
    class Program
    {

        static void Main(string[] args)
        {
            try
            {

                Thread.Sleep(5000);
                IUIAutomation uiAutomation = new CUIAutomation();
                Thread.Sleep(3000);
                IUIAutomationElement rootElement = uiAutomation.GetRootElement();


                int propertyIdControlType = 30003; // UIA_ControlTypePropertyId
                int propertyIdName = 30005; // UIA_NamePropertyId
                int propertyIdAutomationId = 30011; // UIA_AutomationIdPropertyId
                int propertyIdClassName = 30012; // UIA_ClassNamePropertyId
                int controlTypeIdDataItem = 50029; // UIA_DataItemControlTypeId

                IUIAutomationCondition mainWindowCondition =
                uiAutomation.CreatePropertyCondition(
                propertyIdClassName, "Notepad");

                IUIAutomationElement mainWindow =
                rootElement.FindFirst(
                TreeScope.TreeScope_Children,
                mainWindowCondition);

                IUIAutomationCondition textEditorCondition =
                uiAutomation.CreatePropertyCondition(
                propertyIdAutomationId, "15");

                IUIAutomationElement editor =
                mainWindow.FindFirst(
                TreeScope.TreeScope_Children,
                textEditorCondition);

                Thread.Sleep(5000);
                if (editor != null)
                {
                    Console.WriteLine(editor.CurrentClassName.ToString());
                }
                Thread.Sleep(5000);

            }
            catch (Exception ex)

            {
                Console.WriteLine("Fatal error: " + ex.Message);
            }
        }
    }
}