using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace CandyCrushConsole
{
    public class InputHandler
    {
        public ConsoleKey GetKey()
        {
            return Console.ReadKey(true).Key;
        }
    }
}

