namespace TestConsoleApp.Scripts
{
    static class Utility
    {
        private static Random s_random = new Random();

        public static double GetNumber(int minNumber, int maxNumber)
        {
            return s_random.Next(minNumber, maxNumber) + s_random.NextDouble();
        }

        public static int ReadInt(string message)
        {
            bool isWork = true;
            int number = 0;

            while (isWork)
            {
                Console.WriteLine(message);

                if (int.TryParse(Console.ReadLine(), out number))
                {
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Ошибка ввода");
                    Console.ReadKey(true);
                }

                Console.Clear();
            }

            return number;
        }
    }
}
