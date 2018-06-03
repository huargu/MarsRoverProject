using System;
using Xunit;

namespace mars.tests
{
    public class RoverTest
    {
        [Theory, InlineData(new object[] { "5 5", "1 2 N", "LMLMLMLMM" })]
        public void FirstRoverTest(string landsize, string landingpoint, string operations)
        {
            Direction startDirection = Direction.South;
            string[] maxCoordinates = landsize.Split(' ');

            int maxX = Convert.ToInt32(maxCoordinates[0]);
            int maxY = Convert.ToInt32(maxCoordinates[1]);
            Plateau plateau = new Plateau(new Point(maxX, maxY));

            string[] startCoordinates = landingpoint.Split(' ');
            int startY = Convert.ToInt32(startCoordinates[1]);
            int startX = Convert.ToInt32(startCoordinates[0]);
            startDirection = (Direction)startDirection.ParseByDescription(startCoordinates[2]);

            Rover vehicle = new Rover();
            vehicle.Landing(new Point(startX, startY), startDirection, plateau);

            vehicle.Move(operations);

            Assert.Equal("1 3 N", vehicle.GetPosition());
            Assert.NotEqual("1 4 N", vehicle.GetPosition());
        }

        [Theory, InlineData(new object[] { "5 5", "3 3 E", "MMRMMRMRRM" })]
        public void SecondRoverTest(string landsize, string landingpoint, string operations)
        {
            Direction startDirection = Direction.South;
            string[] maxCoordinates = landsize.Split(' ');

            int maxX = Convert.ToInt32(maxCoordinates[0]);
            int maxY = Convert.ToInt32(maxCoordinates[1]);
            Plateau plateau = new Plateau(new Point(maxX, maxY));

            string[] startCoordinates = landingpoint.Split(' ');
            int startY = Convert.ToInt32(startCoordinates[1]);
            int startX = Convert.ToInt32(startCoordinates[0]);
            startDirection = (Direction)startDirection.ParseByDescription(startCoordinates[2]);

            Rover vehicle = new Rover();
            vehicle.Landing(new Point(startX, startY), startDirection, plateau);

            vehicle.Move(operations);

            Assert.Equal("5 1 E", vehicle.GetPosition());
            Assert.NotEqual("1 4 N", vehicle.GetPosition());
        }
    }
}
