using System;

public class AmountConverter
{
    public static decimal ConvertToDecimal(string amount, int decimals)
    {
        if (string.IsNullOrEmpty(amount))
        {
            throw new ArgumentException("Amount değeri boş olamaz.");
        }

        if (decimals < 0)
        {
            throw new ArgumentException("Decimals negatif olamaz.");
        }

        // Ondalık bölme işlemi
        decimal divisor = (decimal)Math.Pow(10, decimals);
        decimal amountValue = decimal.Parse(amount);
        return amountValue / divisor;
    }
}
