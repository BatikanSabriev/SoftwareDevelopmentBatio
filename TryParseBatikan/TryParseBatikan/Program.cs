namespace TryParseBatikan
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== РЕГИСТРАЦИЯ НА УЧЕНИК===");

            Console.Write("Въведете име:");
            string name = Console.ReadLine();


            int age;

            while (true)
            {
                Console.Write("Възраст:");

                if (int.TryParse(Console.ReadLine(), out age))
                {
                    break;
                }

                Console.WriteLine("\nНевалидна възраст. Въведете цяло число.");
            }

            byte grade;

            while (true)
            {
                Console.Write("Клас:");

                if (byte.TryParse(Console.ReadLine(), out grade))
                {
                    break;
                }
                Console.WriteLine("\nГрешен клас");
            }

            double score;

            while (true)
            {
                Console.Write("Оценка");

                if (double.TryParse(Console.ReadLine(), out score))
                {
                    break;
                }
                Console.WriteLine("\nГрешна оценка");
            }
        }
    }
}
