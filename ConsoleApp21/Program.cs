using System;

using System.Threading;
using System.Windows.Automation;

using System.Diagnostics;


namespace TestScenario
{
    class Program
    {

        static void Main(string[] args) {
            //  Process p = Process.Start("C:\\Windows\\notepad.exe");
           // Process p = Process.Start("C:\\Windows\\notepad.exe");
            Thread.Sleep(5000);
            AutomationElement aeDesktop = AutomationElement.RootElement;
      
            AutomationElement continueButton = aeDesktop.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Microsoft .NET Framework"));

            Console.WriteLine(continueButton.Current.ClassName);
           // InvokeControl(continueButton);
            Thread.Sleep(5000);

        }


        private static void InvokeControl(AutomationElement targetControl)
        {
            InvokePattern invokePattern = null;

            try
            {
                invokePattern =
                    targetControl.GetCurrentPattern(InvokePattern.Pattern)
                    as InvokePattern;
            }
            catch (ElementNotEnabledException)
            {
                // Object is not enabled
                return;
            }
            catch (InvalidOperationException)
            {
                // object doesn't support the InvokePattern control pattern
                return;
            }

            invokePattern.Invoke();
        }




    }



}
