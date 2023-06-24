namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = 1e-9;
        
        if (-eps < a && a < eps || double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c) || double.IsInfinity(a) || double.IsInfinity(b) || double.IsInfinity(c))
        {
            throw new ArgumentException();
        }

        double discriminant = b * b - 4 * a * c;

        if (discriminant <= -eps)
        {
            return new double[] { };
        }
        else
        {
            if (-eps < discriminant && discriminant < eps)
            {
                double[] root = new double[1];
                root[0] = (-b) / 2 * a;
                return root;
            }
            else
            {
                double[] roots = new double[2];
                roots[0] = -(b + Math.Sign(b) * Math.Sqrt(discriminant)) / 2;
                roots[1] = c / roots[0];
                return roots;
            }
        }
    }
}
