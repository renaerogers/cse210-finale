using System;

public class CalcExponent : Operation
{
    // Exponents -rar
    public CalcExponent(double num1, double num2) : base(num1, num2, "^") { }

    public override void Execute()
    {
        Result = Math.Pow(Number1, Number2!.Value);
    }
}