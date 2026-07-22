using System;

public class CalcDivision : Operation
{
    // Division -rar
    public CalcDivision(double num1, double num2) : base(num1, num2, "/") { }

    public override void Execute()
    {
        if (Number2!.Value == 0)
        {
            throw new DivideByZeroException("Error: Cannot divide by zero.");
        }
        Result = Number1 / Number2.Value;
    }
}