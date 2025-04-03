using System.Web.Mvc;
using TestConsoleApp.Scripts;

namespace ConsoleAppTest
{
    public class UnitTest1
    {
        [Fact]
        public void TryAddNegativeNumber()
        {
            CoordinatesController controller = new CoordinatesController();
            Database database = new Database();
            int count = -1;
            int expectedNumber = 0;

            List<Coordinate> actualCoordinates = controller.GetCoordinates(database,count);

            Assert.Equal(expectedNumber, actualCoordinates.Count);
        }

        [Fact]
        public void TryAddMultiplierNumber()
        {
            CoordinatesController controller = new CoordinatesController();
            Database database = new Database();
            int count = 3;

            List<Coordinate> actualCoordinates = controller.GetCoordinates(database, count);

            Assert.True(actualCoordinates.Count >= count);
        }

        [Fact]
        public void TryCalculateDistanceOfElements()
        {
            CoordinatesController controller = new CoordinatesController();
            Database database = new Database();
            database.AddElement();
            database.AddElement();
            database.AddElement();

            (double meters, double mele) expectedDistance = (0, 0);
            (double meters, double mele) actualDistance = controller.CalculateDistance(database);

            Assert.True(expectedDistance != actualDistance);
        }

        [Fact]
        public void TryCalculateDistanceWithoutElements()
        {
            CoordinatesController controller = new CoordinatesController();
            Database database = new Database();

            (double, double) expectedDistance = (0, 0);

            (double, double) actualDistance1 = controller.CalculateDistance(null);
            (double, double) actualDistance2 = controller.CalculateDistance(database);

            database.AddElement();
            (double, double) actualDistance3 = controller.CalculateDistance(database);

            bool isEqual = expectedDistance == actualDistance1 && expectedDistance == actualDistance2 && expectedDistance == actualDistance3;

            Assert.True(isEqual);
        }
    }
}
