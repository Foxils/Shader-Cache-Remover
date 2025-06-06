// See https://aka.ms/new-console-template for more information

namespace Shader_Cache_Remover
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Shader Cache Remover\n");
            Console.WriteLine("All temporary shader cache files from graphics drivers and game engines will be removed.");

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nATTENTION: While removing the cache is usually safe, this action cannot be reversed!");
            Console.ResetColor();

            Console.Write("\nPress Enter to begin cleanup or Esc to exit...");

            while (true)
            {
                ConsoleKeyInfo key = Console.ReadKey(intercept: true);

                if (key.Key == ConsoleKey.Enter)
                {
                    Console.Clear();
                    Console.WriteLine("Starting cleanup...\n");
                    Cleaner.BeginClean();
                    Console.WriteLine("\nCleanup complete.");
                    break;
                }
                else if (key.Key == ConsoleKey.Escape)
                {
                    Console.WriteLine("\nOperation cancelled. Exiting...");
                    break;
                }
                else
                {
                    Console.WriteLine("\nInvalid key. Press Enter to clean or Esc to exit.");
                }
            }

            Console.WriteLine("\nPress any key to exit...");
            Console.ReadKey();
        }
    }
}
