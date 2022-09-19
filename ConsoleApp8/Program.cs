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

            //Process p = Process.Start("C:\\Windows\\notepad.exe");
            Thread.Sleep(5000);
            AutomationElement aeDesktop = AutomationElement.RootElement;
            Console.WriteLine("found desktop");

            //find login window for edock
            AutomationElement loginWindow = aeDesktop.FindFirst(TreeScope.Children,
            new PropertyCondition(AutomationElement.AutomationIdProperty, "frmLogin"));
            Console.WriteLine("found login window");

            AutomationElement loginForm = loginWindow.FindFirst(TreeScope.Children,
            new PropertyCondition(AutomationElement.AutomationIdProperty, "pnlLogin"));
            Console.WriteLine("found login form");


            //find forklift id field
            AutomationElement loginButton = loginForm.FindFirst(TreeScope.Children,
            new PropertyCondition(AutomationElement.NameProperty, "Log In"));
            Console.WriteLine("found login button");
            Thread.Sleep(1000);

            //click login button
            InvokePattern invokePattern =
                   loginButton.GetCurrentPattern(InvokePattern.Pattern)
                   as InvokePattern;

            invokePattern.Invoke();

            Console.WriteLine("clicked login button");

            Thread.Sleep(5000);




        }
    }
    }
