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

   
            AutomationElement loginForm = aeDesktop.FindFirst(TreeScope.Children,
              new PropertyCondition(AutomationElement.AutomationIdProperty, "frmLogin"));
            Console.WriteLine("found login window");

            Thread.Sleep(1000);

            AutomationElement forkliftID = loginForm.FindFirst(TreeScope.Children,
            new PropertyCondition(AutomationElement.NameProperty, "Enter Forklift ID"));

            Console.WriteLine("found forklift id");

   

     





            Thread.Sleep(5000);




        }
    }
}