using SquareEquationLib;
using TechTalk.SpecFlow;
namespace XUnit.Tests
{
    [Binding]
    public class findRoots
    {
        private readonly ScenarioContext scenario_Context;
        private double a, b, c;
        private double[] result = new double[2];
        public findRoots(ScenarioContext scenarioContext)
        {
            scenario_Context = scenarioContext;
        }

        [When(@"вычисляются корни квадратного уравнения")]
        public void calculationOfRoots()
        {
            try{
            result = SquareEquation.Solve(a, b, c);
            }
            catch{}
        }
       [Then(@"квадратное уравнение имеет два корня \((.*), (.*)\) кратности один")]
        public void twoRootsOfMultiplicityOne(double a1, double b1)
        {
            double[] expected = {a1, b1};
            Array.Sort(expected);
            Array.Sort(result);
            Assert.Equal(expected, result);
        }

        [Then(@"квадратное уравнение имеет один корень (.*) кратности два")]
         public void oneRootOfMultiplicityTwo(double a1)
         {
            double[] expected = {a1};
            Assert.Equal(expected, result);
         }

         [Then(@"множество корней квадратного уравнения пустое")]
         public void noRoots()
         {
            double[] expected = {};
            Assert.Equal(expected, result);
         }


        [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), (.*)\)")]
         public void normalСoefficients (double a1,double b1, double c1 )
         {
             a = a1;
             b = b1;
             c = c1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \(NaN, (.*), (.*)\)")]
         public void aIsNan (double b1, double c1)
         {
             a = double.NaN;
             b = b1;
             c = c1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), NaN, (.*)\)")]
         public void bIsNan (double a1, double b1)
         {
             a = a1;
             b = double.NaN;
             c = b1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), NaN\)")]
         public void cIsNan (double a1, double b1)
         {
             a = a1;
             b = b1;
             c = double.NaN;
         }

         [Given(@"Квадратное уравнение с коэффициентами \(Double\.NegativeInfinity, (.*), (.*)\)")]
         public void aIsNegativeInfinity(int b1, int c1)
         {
             a = double.NegativeInfinity;
             b = b1;
             c = c1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.NegativeInfinity, (.*)\)")]
         public void bIsNegativeInfinity(int a1, int c1)
         {
             a = a1;
             b = double.NegativeInfinity;
             c = c1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.NegativeInfinity\)")]
         public void cIsNegativeInfinity(int a1, int b1)
         {
             a = a1;
             b = b1;
             c = double.NegativeInfinity;
         }

         [Given(@"Квадратное уравнение с коэффициентами \(Double\.PositiveInfinity, (.*), (.*)\)")]
         public void aIsPositiveInfinity(int b1, int c1)
         {
             a = double.PositiveInfinity;
             b = b1;
             c = c1;
         }
         
         [Given(@"Квадратное уравнение с коэффициентами \((.*), Double\.PositiveInfinity, (.*)\)")]
         public void bIsPositiveInfinity(int a1, int c1)
         {
             a = a1;
             b = double.PositiveInfinity;
             c = c1;
         }

         [Given(@"Квадратное уравнение с коэффициентами \((.*), (.*), Double\.PositiveInfinity\)")]
         public void cIsPositiveInfinity(int a1, int b1)
         {
             a = a1;
             b = b1;
             c = double.PositiveInfinity;
         }

         [Then(@"выбрасывается исключение ArgumentException")]
         public void throwArgumentException()
         {
            var Exception= new ArgumentException();

            try
            {
                var result = SquareEquation.Solve(a,b,c);
            }
            catch (Exception ex)
            {
                Assert.Equal(ex.GetType(), Exception.GetType());
            }
         }
    }
}
