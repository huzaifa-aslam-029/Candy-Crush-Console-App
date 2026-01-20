using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CandyCrushConsole
{
    public class Board
    {
        public char[,] Grid { get; private set; }
        private Random rand = new Random();

        private ConsoleColor GetColor(char candy)
        {
            return candy switch
            {
                '@' => ConsoleColor.Red,
                '#' => ConsoleColor.Yellow,
                '$' => ConsoleColor.Green,
                '%' => ConsoleColor.Blue,
                '&' => ConsoleColor.Cyan,
                '*' => ConsoleColor.Magenta,
                _ => ConsoleColor.White
            };
        }

        public Board()
        {
            Grid = new char[Constants.ROWS, Constants.COLS];
            Fill();
        }

        public void Fill()
        {
            for (int i = 0; i < Constants.ROWS; i++)
                for (int j = 0; j < Constants.COLS; j++)
                    Grid[i, j] = Constants.Candies[rand.Next(Constants.Candies.Length)];
        }

        public void Draw(int curX, int curY, int score, int moves, int level)
        {
            Console.Clear();
            Console.WriteLine($"SCORE: {score} | MOVES: {moves} | LEVEL: {level}");
            Console.WriteLine("------------------");

            for (int i = 0; i < Constants.ROWS; i++)
            {
                for (int j = 0; j < Constants.COLS; j++)
                {
                    ConsoleColor candyColor = GetColor(Grid[i, j]);

                    if (i == curX && j == curY)
                    {
                        Console.BackgroundColor = ConsoleColor.DarkGray;
                        Console.ForegroundColor = candyColor;
                        Console.Write($" {Grid[i, j]} ");
                        Console.ResetColor();

                    }
                    else
                    {
                        Console.ForegroundColor = candyColor;
                        Console.Write($" {Grid[i, j]} ");
                        Console.ResetColor();

                    }
                }
                Console.WriteLine();
            }

            Console.WriteLine("\nArrow Keys: Move | ENTER: Select | Q: Quit");
        }

        public void Swap(int x1, int y1, int x2, int y2)
        {
            char temp = Grid[x1, y1];
            Grid[x1, y1] = Grid[x2, y2];
            Grid[x2, y2] = temp;
        }

        public int RemoveMatches()
        {
            int removed = 0;

            for (int i = 0; i < Constants.ROWS; i++)
            {
                for (int j = 0; j <= Constants.COLS - 3; j++)
                {
                    char c = Grid[i, j];

                    if (c != ' ' &&
                        c == Grid[i, j + 1] &&
                        c == Grid[i, j + 2])
                    {
                        Grid[i, j] = ' ';
                        Grid[i, j + 1] = ' ';
                        Grid[i, j + 2] = ' ';
                        removed += 3;
                    }
                }
            }

            for (int j = 0; j < Constants.COLS; j++)
            {
                for (int i = 0; i <= Constants.ROWS - 3; i++)
                {
                    char c = Grid[i, j];

                    if (c != ' ' &&
                        c == Grid[i + 1, j] &&
                        c == Grid[i + 2, j])
                    {
                        Grid[i, j] = ' ';
                        Grid[i + 1, j] = ' ';
                        Grid[i + 2, j] = ' ';
                        removed += 3;
                    }
                }
            }

            return removed;
        }


        public void ApplyGravity()
        {
            for (int j = 0; j < Constants.COLS; j++)
            {
                for (int i = Constants.ROWS - 1; i >= 0; i--)
                {
                    if (Grid[i, j] == ' ')
                    {
                        for (int k = i; k > 0; k--)
                            Grid[k, j] = Grid[k - 1, j];

                        Grid[0, j] = Constants.Candies[rand.Next(Constants.Candies.Length)];
                    }
                }
            }
        }


        public bool HasMatch()
        {
            for (int i = 0; i < Constants.ROWS; i++)
                for (int j = 0; j < Constants.COLS - 2; j++)
                    if (Grid[i, j] == Grid[i, j + 1] &&
                        Grid[i, j] == Grid[i, j + 2])
                        return true;

            for (int j = 0; j < Constants.COLS; j++)
                for (int i = 0; i < Constants.ROWS - 2; i++)
                    if (Grid[i, j] == Grid[i + 1, j] &&
                        Grid[i, j] == Grid[i + 2, j])
                        return true;

            return false;
        }
    }
}

