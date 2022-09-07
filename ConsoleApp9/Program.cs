using System;
using System.Windows.Automation;
using System.Diagnostics;
using System.Threading;
using System.Xml.Linq;
using System.Windows.Forms;
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




  
                AutomationElement editBox = aeForm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.NameProperty, "Edit"));
              
                Thread.Sleep(2000);

            
                SendKeys.SendWait("Hello World");








                Thread.Sleep(5000);

            }
            catch (Exception ex)
            {
                Console.WriteLine("Fatal error: " + ex.Message);
            }
        }
        private static void InsertText(AutomationElement targetControl,
                                    string value)
        {
            // Validate arguments / initial setup
            if (value == null)
                throw new ArgumentNullException(
                    "String parameter must not be null.");

            if (targetControl == null)
                throw new ArgumentNullException(
                    "AutomationElement parameter must not be null");

            // A series of basic checks prior to attempting an insertion.
            //
            // Check #1: Is control enabled?
            // An alternative to testing for static or read-only controls 
            // is to filter using 
            // PropertyCondition(AutomationElement.IsEnabledProperty, true) 
            // and exclude all read-only text controls from the collection.
            if (!targetControl.Current.IsEnabled)
            {
                throw new InvalidOperationException(
                    "The control is not enabled.\n\n");
            }

            // Check #2: Are there styles that prohibit us 
            //           from sending text to this control?
            if (!targetControl.Current.IsKeyboardFocusable)
            {
                throw new InvalidOperationException(
                    "The control is not focusable.\n\n");
            }

            // Once you have an instance of an AutomationElement,  
            // check if it supports the ValuePattern pattern.
            object valuePattern = null;

            if (!targetControl.TryGetCurrentPattern(
                ValuePattern.Pattern, out valuePattern))
            {
                // Elements that support TextPattern 
                // do not support ValuePattern and TextPattern
                // does not support setting the text of 
                // multi-line edit or document controls.
                // For this reason, text input must be simulated.
            }
            // Control supports the ValuePattern pattern so we can 
            // use the SetValue method to insert content.
            else
            {
                if (((ValuePattern)valuePattern).Current.IsReadOnly)
                {
                    throw new InvalidOperationException(
                        "The control is read-only.");
                }
                else
                {
                    ((ValuePattern)valuePattern).SetValue(value);
                }
            }
        }
    }

}
