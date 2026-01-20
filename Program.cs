using System;
using System.Threading;

namespace CandyCrushConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            Game game = new Game();
            Console.Clear();
            Console.Title = "Candy Crush Saga";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\n\n\n");

            Console.WriteLine("  ██████╗ █████╗ ███╗   ██╗██████╗ ██╗   ██╗");
            Console.WriteLine(" ██╔════╝██╔══██╗████╗  ██║██╔══██╗╚██╗ ██╔╝");
            Console.WriteLine(" ██║     ███████║██╔██╗ ██║██║  ██║ ╚████╔╝ ");
            Console.WriteLine(" ██║     ██╔══██║██║╚██╗██║██║  ██║  ╚██╔╝  ");
            Console.WriteLine(" ╚██████╗██║  ██║██║ ╚████║██████╔╝   ██║   ");
            Console.WriteLine("  ╚═════╝╚═╝  ╚═╝╚═╝  ╚═══╝╚═════╝    ╚═╝   ");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;

            Console.WriteLine("  ██████╗██████╗ ██╗   ██╗███████╗██╗  ██╗");
            Console.WriteLine(" ██╔════╝██╔══██╗██║   ██║██╔════╝██║  ██║");
            Console.WriteLine(" ██║     ██████╔╝██║   ██║███████╗███████║");
            Console.WriteLine(" ██║     ██╔══██╗██║   ██║╚════██║██╔══██║");
            Console.WriteLine(" ╚██████╗██║  ██║╚██████╔╝███████║██║  ██║");
            Console.WriteLine("  ╚═════╝╚═╝  ╚═╝ ╚═════╝ ╚══════╝╚═╝  ╚═╝");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("  ███████╗ █████╗  ██████╗  █████╗ ");
            Console.WriteLine("  ██╔════╝██╔══██╗██╔════╝ ██╔══██╗");
            Console.WriteLine("  ███████╗███████║██║  ███╗███████║");
            Console.WriteLine("  ╚════██║██╔══██║██║   ██║██╔══██║");
            Console.WriteLine("  ███████║██║  ██║╚██████╔╝██║  ██║");
            Console.WriteLine("  ╚══════╝╚═╝  ╚═╝ ╚═════╝ ╚═╝  ╚═╝");
            Console.WriteLine();

            Console.ResetColor();

            Console.CursorVisible = false;
            Console.ForegroundColor = ConsoleColor.Gray;

            string loadingText = "Loading your sweet adventure";
            int dotCount = 0;
            int loadingTime = 3000; 
            int elapsed = 0;

            Console.WriteLine();

            while (elapsed < loadingTime)
            {
                Console.Write("\r" + loadingText + new string('.', dotCount) + "   "); 
                dotCount = (dotCount + 1) % 4;
                Thread.Sleep(500);
                elapsed += 500;
            }

            Console.WriteLine(); 
            Console.CursorVisible = true; 
            Console.ResetColor();

            string rep = "";
            while (rep != "yes" && rep != "no")
            {
                Console.WriteLine("Do you want to play Candy Crush game? (yes/no)");
                rep = Console.ReadLine()?.Trim().ToLower();
            }

            if (rep == "yes")
            {
                game.Start();
            }
            else
            {
                Console.WriteLine("Thanks for visiting...");
            }
        }
    }
}
