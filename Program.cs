// See https://aka.ms/new-console-template for more information

using System;
namespace Shader_Cache_Remover;

class Program
{
    static void Main(string[] args)
    {

        Console.WriteLine("Shader Cache remover\n\nAll temporary shader cache files from graphics drivers and game engines will be removed.");
        Console.ForegroundColor = ConsoleColor.Red;
        Console.WriteLine("\nATTENTION: Whilst removing the cache is usually safe this action can not be reversed!");
        Console.ResetColor();
        Console.Write("\nPress enter to clear the cache.");        


        while (true)
        {
            var key = Console.ReadKey(intercept: true);

            if (key.Key == ConsoleKey.Enter)
            {
                Console.Clear();
                Cleaner.BeginClean();
                Console.Write("\nComplete.");
            }
            else
                Console.WriteLine("\nPress enter to begin.");
            
        }  
       
        }
    }
