namespace TestConsoleApp.Scripts
{
    public class Database
    {
        private List<Coordinate> _coordinates = new List<Coordinate>();

        public List<Coordinate> Coordinates => _coordinates.ToList();

        public void AddElement()
        {
            _coordinates.Add(new Coordinate());
        }

        public void ShowCoordinates()
        {
            Console.WriteLine("Координаты");
            Console.WriteLine();

            foreach (Coordinate coordinate in _coordinates)
            {
                Console.WriteLine($"Широта: {coordinate.Latitude}");
                Console.WriteLine($"Долгота: {coordinate.Longitude}");
                Console.WriteLine();
            }
        }
    }
}
