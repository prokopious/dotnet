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

            //Process p = Process.Start("C:\\Windows\\notepad.exe");
            Thread.Sleep(5000);
            AutomationElement aeDesktop = AutomationElement.RootElement;
            Console.WriteLine("found desktop");
            Thread.Sleep(1000);
            //find login window for edock
            AutomationElement loginWindow = aeDesktop.FindFirst(TreeScope.Children,
            new PropertyCondition(AutomationElement.AutomationIdProperty, "frmLogin"));
            Console.WriteLine("found login window");
            Thread.Sleep(1000);
            AutomationElement loginForm = loginWindow.FindFirst(TreeScope.Children,
            new PropertyCondition(AutomationElement.AutomationIdProperty, "pnlLogin"));
            Console.WriteLine("found login form");
            Thread.Sleep(1000);
      
            //find forklift id field
            AutomationElement operIdField = loginForm.FindFirst(TreeScope.Children, new PropertyCondition(AutomationElement.AutomationIdProperty, "txtOperID")
            );
            Console.WriteLine("found operator id field");
            Thread.Sleep(1000);

            //click login button
      
            Thread.Sleep(1000);
            SendKeys.SendWait("23423");
            Thread.Sleep(1000);
            //SendKeys.SendWait("23423");
            Thread.Sleep(1000);
            Console.WriteLine("set operator id value");

            Thread.Sleep(5000);




        }
    }
    }
