namespace TestConsoleApp.Scripts
{
    public class Coordinate
    {
        public Coordinate()
        {
            int minLatitude = -90;
            int maxLatitude = 90;

            int minLongitude = -180;
            int maxLongitude = 180;

            Latitude = Math.Round(Utility.GetNumber(minLatitude, maxLatitude), 6);
            Longitude = Math.Round(Utility.GetNumber(minLongitude, maxLongitude), 6);
        }

        public double Latitude { get; private set; }
        public double Longitude { get; private set; }
    }
}
