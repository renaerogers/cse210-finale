using System; 

public abstract class Operation
{
    // The info is protected for Encapsulation -rar
    public double Number1 { get; protected set; }
    public double? Number2 { get; protected set; }
    public double Result { get; protected set; }
    public string Symbol { get; protected set; }

    public Operation(double num1, double? num2, string symbol)
    {
        Number1 = num1;
        Number2 = num2;
        Symbol = symbol;
    }

    // Child classes will override this with Polymorphism -rar
    public abstract void Execute();

    // All child classes inherit this display method -rar
    public virtual void Display()
    {
        string num1Formatted = Number1.ToString("0.####");
        string resultFormatted = Result.ToString("0.####");
        if (Number2.HasValue)
        {
            string num2Formatted = Number2.Value.ToString("0.####");
            Console.WriteLine($"[Equation]: {num1Formatted} {Symbol} {num2Formatted} = {resultFormatted}");
        }
        else
        {
            Console.WriteLine($"[Equation]: {Symbol} {num1Formatted} = {resultFormatted}");
        }
    }
}