using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BankOCR
{
    internal class Parser
    {

        const int EndOfLineWidth = 2;//\n \r
        const int LineWidth = 27 + EndOfLineWidth;

        private string _accounts;
        private int[] _acceptedRange;

        public Parser()
        {
            _acceptedRange = Enumerable.Range(0, 10).ToArray();
        }

        internal int[] Process(string accounts)
        {
            _accounts = accounts;
            int[] result = new int[9];

            for (int position = 0; position < 27; position += 3)
            {
                var numberMap = MapNumberAt(position);
                var matchedRepresentation = _acceptedRange
                    .Where(value =>
                            Match(numberMap,
                            NumberRepresentations.GetRepresentationOf(value)))
                    .First();

                var resultIndex = position / 3;
                result[resultIndex] = matchedRepresentation;
            }

            return result;
        }

        private bool Match(char[,] numberMap, char[,] mapFor)
        {
            bool mapsMatch = true;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    var areSame = numberMap[i, j] == mapFor[i, j];
                    if (!areSame) mapsMatch = false;
                }
            }
            return mapsMatch;
        }

        private char[,] MapNumberAt(int position)
        {
            char[,] map = new char[,]{
                {_accounts[position]                , _accounts[position+1],              _accounts[position +2]},
                {_accounts[position + LineWidth]    , _accounts[position+1+LineWidth]   , _accounts[position + 2 + LineWidth]},
                {_accounts[position + 2*LineWidth]  , _accounts[position+1+2*LineWidth] , _accounts[position + 2 + 2*LineWidth]},
            };

            return map;
        }
    }
}
