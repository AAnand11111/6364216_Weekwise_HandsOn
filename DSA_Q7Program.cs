using System;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter initial amount (e.g., 10000):");
        double amount = Convert.ToDouble(Console.ReadLine());

        Console.WriteLine("Enter annual growth rate in % (e.g., 10 for 10%):");
        double rate = Convert.ToDouble(Console.ReadLine()) / 100;

        Console.WriteLine("Enter number of years:");
        int years = Convert.ToInt32(Console.ReadLine());

        Forecast forecast = new Forecast();
        double futureValue = forecast.CalculateFutureValue(amount, rate, years);

        Console.WriteLine($"Future Value after {years} years = {futureValue:F2}");
    }
}
