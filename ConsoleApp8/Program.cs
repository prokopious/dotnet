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

   
            AutomationElement dotnet = aeDesktop.FindFirst(TreeScope.Children,
              new PropertyCondition(AutomationElement.NameProperty, "Microsoft .NET Framework"));
            Console.WriteLine("found edock");



            AutomationElement cont = dotnet.FindFirst(TreeScope.Children,
            new PropertyCondition(AutomationElement.NameProperty, "Continue"));

            Console.WriteLine("found continue");





            Thread.Sleep(5000);




        }
    }
}