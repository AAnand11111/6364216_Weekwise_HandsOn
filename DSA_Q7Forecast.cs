using System;

public class Forecast
{
    // Recursive method to calculate future value
    public double CalculateFutureValue(double amount, double rate, int years)
    {
        if (years == 0)
            return amount;
        return CalculateFutureValue(amount * (1 + rate), rate, years - 1);
    }
}
