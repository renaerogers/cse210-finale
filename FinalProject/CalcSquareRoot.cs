using System;

public class CalcSquareRoot : Operation
{
    // Square Root -rar
    public CalcSquareRoot(double num) : base(num, null, "-/") { }

    public override void Execute()
    {
        if (Number1 < 0)
        {
            throw new InvalidOperationException("Error: Cannot calculate the square root of a negative number.");
        }
        Result = Math.Sqrt(Number1);
    }
}