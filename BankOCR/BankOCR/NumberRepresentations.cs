using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCR
{
    internal static class NumberRepresentations
    {
        const char Underscore = '_';
        const char Space = ' ';
        const char Pipe = '|';

        static NumberRepresentations()
        {
            _numbersMap = new Dictionary<int, char[,]>()
            {
                {0, mapFor0},
                {1, mapFor1},
                {2, mapFor2},
                {3, mapFor3},
                {4, mapFor4},
                {5, mapFor5},
                {6, mapFor6},
                {7, mapFor7},
                {8, mapFor8},
                {9, mapFor9}
            };
        }

        public static char[,] GetRepresentationOf(int number)
        {
            char[,] result = null;
            _numbersMap.TryGetValue(number, out result);

            return result;
        }


        static Dictionary<int, char[,]> _numbersMap = null;

        // _ 
        //| |
        //|_|
        static char[,] mapFor0 = new char[,]{  
            {Space, Underscore, Space},
            {Pipe, Space, Pipe},
            {Pipe, Underscore, Pipe}
        };
        //    
        //  |
        //  |
        static char[,] mapFor1 = new char[,]{  
            {Space, Space, Space},
            {Space, Space, Pipe},
            {Space, Space, Pipe}
        };
        // _ 
        // _|
        //|_ 
        static char[,] mapFor2 = new char[,]{  
            {Space, Underscore, Space},
            {Space, Underscore, Pipe},
            {Pipe, Underscore, Space}
        };
        // _ 
        // _|
        // _|
        static char[,] mapFor3 = new char[,]{  
            {Space, Underscore, Space},
            {Space, Underscore, Pipe},
            {Space, Underscore, Pipe}
        };
        //   
        //|_|
        //  |
        static char[,] mapFor4 = new char[,]{  
            {Space, Space, Space},
            {Pipe, Underscore, Pipe},
            {Space, Space, Pipe}
        };
        // _ 
        //|_ 
        // _|
        static char[,] mapFor5 = new char[,]{  
            {Space, Underscore, Space},
            {Pipe, Underscore, Space},
            {Space, Underscore, Pipe}
        };
        // _ 
        //|_ 
        //|_|
        static char[,] mapFor6 = new char[,]{  
            {Space, Underscore, Space},
            {Pipe, Underscore, Space},
            {Pipe, Underscore, Pipe}
        };
        // _ 
        //  |
        //  |
        static char[,] mapFor7 = new char[,]{  
            {Space, Underscore, Space},
            {Space, Space, Pipe},
            {Space, Space, Pipe}
        };
        // _ 
        //|_|
        //|_|
        static char[,] mapFor8 = new char[,]{  
            {Space, Underscore, Space},
            {Pipe, Underscore, Pipe},
            {Pipe, Underscore, Pipe}
        };
        // _ 
        //|_|
        // _|
        static char[,] mapFor9 = new char[,]{  
            {Space, Underscore, Space},
            {Pipe, Underscore, Pipe},
            {Space, Underscore, Pipe}
        };
    }
}
