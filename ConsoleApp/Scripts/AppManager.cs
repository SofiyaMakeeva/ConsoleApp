namespace TestConsoleApp.Scripts
{
    internal class AppManager
    {
        private Dictionary<string, Action> _actions;
        private List<string> _commands;
        private bool _isWork = true;
        private int _index = 0;
        private string _key;

        private CoordinatesController _controller;
        private Database _database;

        public AppManager()
        {
            _actions = new Dictionary<string, Action>()
            {
                { "Сформировать координаты",CreateCoordinates },
                { "Вывести координаты на экран", ShowCoordinates},
                { "Посчитать расстояние", CalculateDistance },
                { "Выйти", Exit }
            };

            _commands = _actions.Keys.ToList();
            _key = _commands[0];
            _controller = new CoordinatesController();
            _database = new Database();
        }

        public void Work()
        {
            while (_isWork)
            {
                Draw();

                if (IsEnterPress())
                {
                    _actions[_key].Invoke();
                }

                Console.Clear();
            }
        }

        private void Draw()
        {
            Console.CursorVisible = false;

            for (int i = 0; i < _index; i++)
            {
                Console.WriteLine(_commands[i]);
            }

            Console.BackgroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Black;
            Console.WriteLine(_commands[_index]);
            Console.ResetColor();

            for (int i = _index + 1; i < _commands.Count; i++)
            {
                Console.WriteLine(_commands[i]);
            }

            Console.Write("\n\n                                    ");
            Console.CursorLeft = 0;
        }

        private bool IsEnterPress()
        {
            const ConsoleKey DownArrow = ConsoleKey.DownArrow;
            const ConsoleKey UpArrow = ConsoleKey.UpArrow;
            const ConsoleKey Enter = ConsoleKey.Enter;

            switch (Console.ReadKey().Key)
            {
                case DownArrow:
                    _index++;
                    break;

                case UpArrow:
                    _index--;
                    break;

                case Enter:
                    _key = _actions.Keys.ToList()[_index];
                    return true;
            }

            if (_index < 0 || _index >= _actions.Count)
            {
                _index = 0;
            }

            return false;
        }

        private void ShowCoordinates()
        {
            Console.Clear();
            _controller.ShowCoordinates(_database);
            Console.ReadKey(true);
        }

        private void CreateCoordinates()
        {
            string message = "Введите количество новых координат";

            Console.Clear();

            int count = Utility.ReadInt(message);
            _controller.GetCoordinates(_database, count);

            Console.ReadKey();
        }

        private void CalculateDistance()
        {
            Console.Clear();
            _controller.CalculateDistance(_database);
            Console.ReadKey();
        }

        private void Exit()
        {
            _isWork = false;
        }
    }
}
