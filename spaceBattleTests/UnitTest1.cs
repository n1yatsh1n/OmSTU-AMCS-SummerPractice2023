using spaceBattle;
using FluentAssertions;
using TechTalk.SpecFlow;

namespace spaceBattleTests
{
    [Binding]
    public class SpaceShipMoving
    {
        private readonly ScenarioContext scenario_Context;
        SpaceShip spaceShip = new SpaceShip();
        double[]? actualCoordinates;
        int? actualAngle;
        double? remainingFuel;
        Exception exception = new Exception();

        public SpaceShipMoving(ScenarioContext scenarioContext)
        {
            scenario_Context = scenarioContext;
        }

        [Given(@"космический корабль находится в точке пространства с координатами \((.*), (.*)\)")]
        public void GivenCoordinates(double p0, double p1)
        {
            spaceShip.SetCoordinates(p0, p1);
        }

        [Given(@"имеет мгновенную скорость \((.*), (.*)\)")]
        public void GivenSpeedVector(double p0, double p1)
        {
            spaceShip.SetSpeedCoordinates(p0, p1);
        }

        [Given(@"космический корабль, положение в пространстве которого невозможно определить")]
        public void GivenImpossibleCoordinates()
        {
        }

        [Given(@"скорость корабля определить невозможно")]
        public void GivenImpossibleSpeedVector()
        {
        }

        [Given(@"изменить положение в пространстве космического корабля невозможно")]
        public void GivenImpossibleAction()
        {
            spaceShip.NotMoving();
        }

        [Given(@"космический корабль, угол наклона которого невозможно определить")]
        public void GivenImpossibleAngle()
        {
        }

        [Given(@"мгновенную угловую скорость невозможно определить")]
        public void GivenImpossibleAngleSpeed()
        {
        }

        [Given(@"невозможно изменить уголд наклона к оси OX космического корабля")]
        public void GivenImpossibleAngleCalculation()
        {
            spaceShip.CannotAngleAction();
        }

        [Given(@"космический корабль имеет топливо в объеме (.*) ед")]
        public void GivenFuelCount(double f)
        {
            spaceShip.SetFuel(f);
        }

        [Given(@"имеет скорость расхода топлива при движении (.*) ед")]
        public void GivenFuelRate(double f)
        {
            spaceShip.SetFuelRate(f);
        }

        [Given(@"космический корабль имеет угол наклона (.*) град к оси OX")]
        public void GivenRotationAngle(int angle)
        {
            spaceShip.SetRotationAngle(angle);
        }

        [Given(@"имеет мгновенную угловую скорость (.*) град")]
        public void GivenInstantaneousAngularVelocity(int angularVelocity)
        {
            spaceShip.SetInstantaneousAngularVelocity(angularVelocity);
        }

        [When(@"происходит прямолинейное равномерное движение без деформации")]
        public void WhenMovingAction()
        {
            try
            {
                actualCoordinates = spaceShip.MovingAction();
                remainingFuel = spaceShip.remainingFuel();
            }
            catch (Exception exc)
            {
                exception = exc;
            }
        }

        [When(@"происходит вращение вокруг собственной оси")]
        public void WhenMovingActionAngleCheckOnle()
        {
            try
            {
                actualAngle = spaceShip.AngleCalculation();
            }
            catch (Exception ex)
            {
                exception = ex;
            }
        }

        [Then(@"космический корабль перемещается в точку пространства с координатами \((.*), (.*)\)")]
        public void ThenSpaceshipMovingToCoordinates(double p0, double p1)
        {
            spaceShip.MovingAction().Should().BeEquivalentTo(new double[] { p0, p1 });
        }

        [Then(@"возникает ошибка Exception")]
        public void ThenThrowsException()
        {
            Assert.IsType<Exception>(exception);
        }
         [Then(@"новый объем топлива космического корабля равен (.*) ед")]
        public void ThenSpaceshipHaveThisCountFuel(double fuel)
        {
            Double.Equals(remainingFuel, fuel);
        }

        [Then(@"угол наклона космического корабля к оси OX составляет (.*) град")]
        public void ThenSpaceshipNowThisAngle(int angle)
        {
            Assert.Equal(angle, actualAngle);
        }
    }
}

