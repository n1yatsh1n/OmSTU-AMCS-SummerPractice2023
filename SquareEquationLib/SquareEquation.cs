namespace SquareEquationLib;

public class SquareEquation
{
    public static double[] Solve(double a, double b, double c)
    {
        double eps = 1e-9;
        
        if (a < Math.Abs(eps) || double.IsNaN(a) || double.IsNaN(b) || double.IsNaN(c) || double.IsInfinity(a) || double.IsInfinity(b) || double.IsInfinity(c))
        {
            throw new ArgumentException();
        }

        double discriminant = b * b - 4 * a * c;

        if (discriminant <= -eps)
        {
            return new double[] { };
        }
        else if (discriminant < Math.Abs(eps))
        {
                double[] root = new double[1];
                root[0] = (-b) / 2 * a;
                return root;
        }
        else{
            double x1;
            double x2;
            if (c <= eps)
            {
                x1 = Math.Pow(Math.Abs(c),0.5);
                x2 = -Math.Pow(Math.Abs(c),0.5);
            }
            else {
                x1 = (-b + Math.Sign(b) * Math.Sqrt(discriminant)) / 2;
                x2 = c / x1;
            }
            return new double[] {x1, x2};
        }
    }
}
