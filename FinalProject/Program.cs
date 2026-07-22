using System;
using System.Collections.Generic;

public class Term
{
    public double Coefficient { get; set; }
    public int Exponent { get; set; }

    public Term(double coefficient, int exponent)
    {
        Coefficient = coefficient;
        Exponent = exponent;
    }

    // Applies the power rule: d/dx(ax^b) = (a*b)x^(b-1)
    public Term GetDerivative()
    {
        if (Exponent == 0)
        {
            return new Term(0, 0); // Derivative of a constant is 0
        }
        return new Term(Coefficient * Exponent, Exponent - 1);
    }

    // Helper to print the term cleanly
    public void Print(bool isFirst)
    {
        if (Coefficient == 0) return;

        // Handle sign formatting
        if (!isFirst && Coefficient > 0) Console.Write(" + ");
        else if (Coefficient < 0) Console.Write(" - ");

        double absCoeff = Math.Abs(Coefficient);

        // Print coefficient if it's not 1, or if it's a constant term
        if (absCoeff != 1 || Exponent == 0)
        {
            Console.Write(absCoeff);
        }

        // Print variable and exponent
        if (Exponent > 0)
        {
            Console.Write("x");
            if (Exponent > 1)
            {
                Console.Write("^" + Exponent);
            }
        }
    }
}

// Class representing the entire polynomial equation
public class Polynomial
{
    private List<Term> _terms = new List<Term>();

    public void AddTerm(double coefficient, int exponent)
    {
        if (coefficient != 0)
        {
            _terms.Add(new Term(coefficient, exponent));
        }
    }

    // Computes the derivative of the entire polynomial
    public Polynomial GetDerivative()
    {
        Polynomial derivativePoly = new Polynomial();
        foreach (var term in _terms)
        {
            Term dTerm = term.GetDerivative();
            if (dTerm.Coefficient != 0)
            {
                derivativePoly.AddTerm(dTerm.Coefficient, dTerm.Exponent);
            }
        }
        return derivativePoly;
    }

    // Prints the full equation
    public void Display()
    {
        if (_terms.Count == 0)
        {
            Console.WriteLine("0");
            return;
        }

        for (int i = 0; i < _terms.Count; i++)
        {
            _terms[i].Print(i == 0);
        }
        Console.WriteLine();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Polynomial poly = new Polynomial();

        // Representing: 4x^3 - 3x^2 + 2x + 7
        poly.AddTerm(4, 3);
        poly.AddTerm(-3, 2);
        poly.AddTerm(2, 1);
        poly.AddTerm(7, 0);

        Console.Write("Original Function f(x)  = ");
        poly.Display();

        Polynomial derivative = poly.GetDerivative();

        Console.Write("Derivative        f'(x) = ");
        derivative.Display();
    }
}