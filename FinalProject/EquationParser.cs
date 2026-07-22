using System; 
using System.Text.RegularExpressions;

public class EquationParser
{
    // Error handling and using Operation to send the equations off to be solved -rar
    public Operation Parse(string input)
    {
        if (string.IsNullOrWhiteSpace(input))
            throw new ArgumentException("Input equation cannot be empty.");

        // Throw error if variables (letters) are present -used AI to help me with this
        if (Regex.IsMatch(input, @"[a-zA-Z]"))
            throw new FormatException("Variables (letters) are not allowed in the equation.");

        // Throw error if unexpected symbols are present -used AI to help me with thisb
        if (Regex.IsMatch(input, @"[^0-9\s\+\-\*\/\^\.]"))
            throw new FormatException("Input contains unexpected or unsupported characters.");

        string cleaned = input.Replace(" ", "");

        // Square Root (-/)
        if (cleaned.StartsWith("-/"))
        {
            string numberPart = cleaned.Substring(2);
            if (double.TryParse(numberPart, out double num))
            {
                return new CalcSquareRoot(num);
            }
            throw new FormatException("Invalid number format following square root.");
        }

        // Math Calculations (+, -, *, /, ^)
        string binaryPattern = @"^(-?\d+(?:\.\d+)?)\s*([\+\-\*\/\^])\s*(-?\d+(?:\.\d+)?)$"; // AI helped me with this too 
        Match match = Regex.Match(cleaned, binaryPattern);

        if (match.Success)
        {
            double num1 = double.Parse(match.Groups[1].Value);
            string op = match.Groups[2].Value;
            double num2 = double.Parse(match.Groups[3].Value);

            return op switch
            {
                "+" => new CalcAddition(num1, num2),
                "-" => new CalcSubtraction(num1, num2),
                "*" => new CalcMultiplication(num1, num2),
                "/" => new CalcDivision(num1, num2),
                "^" => new CalcExponent(num1, num2),
                _ => throw new InvalidOperationException("Unsupported operator.")
            };
        }

        throw new FormatException("Invalid equation syntax. Example: '12 + 4' or '-/ 16'.");
    }
}