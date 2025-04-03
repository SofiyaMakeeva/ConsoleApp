namespace TestConsoleApp.Scripts
{
    public class CoordinatesController
    {
        public List<Coordinate> GetCoordinates(Database database, int count)
        {
            int minCount = 1;

            if (count < minCount)
            {
                Console.WriteLine("Ошибка ввода");
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    database.AddElement();
                }

                Console.WriteLine("Координаты добавлены");
            }

            return database.Coordinates;
        }

        public (double,double) CalculateDistance(Database database)
        {
            int minLength = 2;
            double distanceInMeters = 0;
            double degree = 1609.344;

            if (database != null)
            {
                if (database.Coordinates.Count >= minLength)
                {
                    for (int i = 0; i < database.Coordinates.Count - 1; i++)
                    {
                        distanceInMeters += CalculateDistance(database.Coordinates[i], database.Coordinates[i + 1]);
                    }
                }
            }

            double distanceInMiles = distanceInMeters / degree;

            Console.WriteLine($"Метров: {distanceInMeters}");
            Console.WriteLine($"Милей: {distanceInMiles}");

            return (distanceInMeters, distanceInMiles);
        }

        private double CalculateDistance(Coordinate coordinate1, Coordinate coordinate2)
        {
            int earthRadius = 6371000;
            double latitudeRadian1 = CalculateRadian(coordinate1.Latitude);
            double longitudeRadian1 = CalculateRadian(coordinate1.Longitude);

            double latitudeRadian2 = CalculateRadian(coordinate2.Latitude);
            double longitudeRadian2 = CalculateRadian(coordinate2.Longitude);

            double distance = (earthRadius * Math.Acos(Math.Cos(latitudeRadian1) * Math.Cos(latitudeRadian2)
                * Math.Cos(longitudeRadian2 - longitudeRadian1)
                + Math.Sin(latitudeRadian1) * Math.Sin(latitudeRadian2)));

            return distance;
        }

        private double CalculateRadian(double degree)
        {
            double maxDegree = 180;
            double numberPi = 3.14159265358979;
            double radian = (degree * numberPi) / maxDegree;
            return radian;
        }
    }
}
