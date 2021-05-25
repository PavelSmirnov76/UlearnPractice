using System;

namespace Percent
{
    class Program
    {
        //(double startSum, double percentRate,int depositDuration
        static double Calculate(string userInput)
        {
            var data = userInput.Split();
            var depositSum = double.Parse(data[0]);
            var percentRate = double.Parse(data[1]);
            var depositDuration = double.Parse(data[2]);

            return depositSum * Math.Pow(1 + (percentRate / (1200)), depositDuration);
        }


        static void Main(string[] args)
        {
            System.Threading.Thread.CurrentThread.CurrentCulture = new System.Globalization.CultureInfo("en-US");

            Console.WriteLine(Calculate(Console.ReadLine()));
        }
    }
}
