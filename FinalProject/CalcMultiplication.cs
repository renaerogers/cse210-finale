using System; 

public class CalcMultiplication : Operation
{
    // Multiplication -rar
    public CalcMultiplication(double num1, double num2) : base(num1, num2, "*") { }

    public override void Execute()
    {
        Result = Number1 * Number2!.Value;
    }
}