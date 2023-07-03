using Xunit;
using System;
using SquareEquationLib;

namespace SquareEquation.Tests;

public class SquareEquationLib_isUnite
{
    [Theory]
    [InlineData(0, 1, 1)]
    [InlineData(double.NaN, 1, 1)]
    [InlineData(1, double.NaN, 1)]
    [InlineData(1, 1, double.NaN)]
    [InlineData(double.NegativeInfinity, 1, 1)]
    [InlineData(1, double.NegativeInfinity, 1)]
    [InlineData(1, 1, double.NegativeInfinity)]
    [InlineData(double.PositiveInfinity, 1, 1)]
    [InlineData(1, double.PositiveInfinity, 1)]
    [InlineData(1, 1, double.PositiveInfinity)]
    public void catchingExceptions(double a, double b, double c)
    {
        try
        {
            SquareEquationLib.SquareEquation.Solve(a, b, c);
        }
        catch (Exception exception)
        {
            Assert.Equal(exception.GetType(), new ArgumentException().GetType());
        }
    }

    [Theory]
    [InlineData(1, 4, 3, new double[]{-1, -3})]
    [InlineData(1, -8, 12, new double[]{2, 6})]
    public void CheckingTwoRoots(double a, double b, double c, double[] roots)
    {
        double[] actual = SquareEquationLib.SquareEquation.Solve(a, b, c);

        Assert.Equal(roots, actual);
    }

    [Theory]
    [InlineData(1, 2, 1, new double[]{-1})]
    [InlineData(1, 6, 9, new double[]{-3})]
    public void CheckingOneRoot(double a, double b, double c, double[] roots)
    {
        double[] actual = SquareEquationLib.SquareEquation.Solve(a, b, c);

        Assert.Equal(roots, actual);
    }

    [Theory]
    [InlineData(1, 2, 3)]
    [InlineData(1, 1, 1)]
    public void CheckinNoRoot(double a, double b, double c)
    {
        Assert.True(SquareEquationLib.SquareEquation.Solve(a, b, c).Length == 0);
    }

}
