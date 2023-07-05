﻿namespace spaceBattle
{
    public class SpaceShip
    {
        private double[]? startCoordinates;
        private double[]? speedCoordinates;
        private bool abilityToMove = true;

        private double? fuel;
        private double? fuelRate;
        private bool possibilityOfRotation = true;
        private int? rotationAngle;
        private int? instantaneousAngularVelocity;

        public void SetCoordinates(double x, double y)
        {
            startCoordinates = new double[] { x, y };
        }

        public void SetSpeedCoordinates(double x, double y)
        {
            speedCoordinates = new double[] { x, y };
        }

         public void SetFuel(double fuel)
        {
            this.fuel = fuel;
        }

        public void SetFuelRate(double fuelСonsumption)
        {
            this.fuelRate = fuelСonsumption;
        }

        public void SetRotationAngle(int? rotateAngle)
        {
            this.rotationAngle = rotateAngle;
        }

        public void SetInstantaneousAngularVelocity(int? angleSpeed)
        {
            this.instantaneousAngularVelocity = angleSpeed;
        }

        public void NotMoving()
        {
            abilityToMove = false;
        }

        public double[] MovingAction()
        {
            if (startCoordinates == null || speedCoordinates == null || !abilityToMove)
            {
                throw new Exception("some values are null!");
            }

            else 
            { 
                return new double[] { startCoordinates[0] + speedCoordinates[0], startCoordinates[1] +speedCoordinates[1] }; 
            }
        }

         public double? remainingFuel()
        {
            if (fuel == null || fuelRate == null)
            {
                throw new Exception("some values are null!");
            }
            else if(fuel < fuelRate)
            {
                throw new Exception("Not enougt fuel");
            }
            else 
            {
                return fuel - fuelRate;
            }
        }

        public void CannotAngleAction()
        {
            possibilityOfRotation = false;
        }

        public int? AngleCalculation()
        {
            if (rotationAngle == null || instantaneousAngularVelocity == null || !possibilityOfRotation)
            {
                throw new Exception("some values are null!");
            }
            else
            {
                 return rotationAngle + instantaneousAngularVelocity;
            }
        }
    }
}
