namespace CandyCrushConsole
{
    public class Game
    {
        private Board board;
        private InputHandler input;
        private int score = 0;
        private int moves = 0;
        private int level = 1;


        private int cursorX = 0;
        private int cursorY = 0;

        private bool firstSelected = false;
        private int selX, selY;

        public Game()
        {
            board = new Board();
            input = new InputHandler();
        }

        public void Start()
        {
            ConsoleKey key;

            do
            {
                board.Draw(cursorX, cursorY, score, moves, level);
                key = input.GetKey();

                HandleMovement(key);
                HandleSelection(key);

            } while (key != ConsoleKey.Q);
        }

        private void HandleMovement(ConsoleKey key)
        {
            if (key == ConsoleKey.UpArrow && cursorX > 0) cursorX--;
            if (key == ConsoleKey.DownArrow && cursorX < Constants.ROWS - 1) cursorX++;
            if (key == ConsoleKey.LeftArrow && cursorY > 0) cursorY--;
            if (key == ConsoleKey.RightArrow && cursorY < Constants.COLS - 1) cursorY++;
        }

        private void HandleSelection(ConsoleKey key)
        {
            if (key != ConsoleKey.Enter) return;

            if (!firstSelected)
            {
                selX = cursorX;
                selY = cursorY;
                firstSelected = true;
            }
            else
            {
                if (Math.Abs(selX - cursorX) + Math.Abs(selY - cursorY) == 1)
                {
                    board.Swap(selX, selY, cursorX, cursorY);

                    if (board.HasMatch())
                    {
                        moves++;
                        int removed;
                        while ((removed = board.RemoveMatches()) > 0)
                        {
                            score += removed * 10;
                            board.ApplyGravity();
                        }
                    }
                    else
                    {
                        board.Swap(selX, selY, cursorX, cursorY);
                    }
                }
                else
                {
                    Console.SetCursorPosition(0, Constants.ROWS + 5);
                    Console.WriteLine("You can only swap adjacent candies!");
                    Thread.Sleep(500);  
                }



                firstSelected = false;
                for (int i = 1; ; i++)   
                {
                    if (score >= 200 * i)
                    {
                        level = i + 1;  
                    }
                    else
                    {
                        break;          
                    }
                }

            }
        }
    }
}

