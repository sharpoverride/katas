using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;

namespace BankOCR
{
    [TestClass]
    public class ParserTests
    {
        Parser _parser;

        [TestInitialize]
        public void BeforeEach()
        {
            _parser = new Parser();
        }

        [TestMethod]
        public void Parser_ShouldCorrectlyMatchTheSequence()
        {
            // Arrange
            var expectedResult = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 };

            // Act
            int[] result = _parser.Process(InputData.OneAccount);

            // Assert
            CollectionAssert.AreEqual(expectedResult, result);
        }

        [TestMethod]
        public void Parser_ShouldCorrectlyMatchTheFirstNumber()
        {
            // Arrange
            var expectedResult = 1;

            // Act
            int[] result = _parser.Process(InputData.OneAccount);

            // Assert
            Assert.AreEqual(expectedResult, result[0]);
        }

        [TestMethod]
        public void ParserShouldCorrectlyMatchAllZeroes()
        {
            // Arrange
            var allZeros = Enumerable.Repeat(0, 9).ToArray();

            // Act
            int[] result = _parser.Process(InputData.AllZero);

            //Assert
            CollectionAssert.AreEqual(allZeros, result);
        }

        [TestMethod]
        public void DebugNumberOutput()
        {
            var x = InputData.OneAccount;
            int i = 1;
            for (int position = 0; position < 27; position += 3)
            {
                var map = MapNumberAt(position, x);

                Console.Write("{0}{1}{2}\n", map[0, 0], map[0, 1], map[0, 2]);
                Console.Write("{0}{1}{2}\n", map[1, 0], map[1, 1], map[1, 2]);
                Console.Write("{0}{1}{2}\n", map[2, 0], map[2, 1], map[2, 2]);

                map = NumberRepresentations.GetRepresentationOf(i);

                Console.Write("{0}{1}{2}\n", map[0, 0], map[0, 1], map[0, 2]);
                Console.Write("{0}{1}{2}\n", map[1, 0], map[1, 1], map[1, 2]);
                Console.Write("{0}{1}{2}\n", map[2, 0], map[2, 1], map[2, 2]);

                i++;
            }
        }

        private char[,] MapNumberAt(int position, string _accounts)
        {
            const int EndOfLineWidth = 2;//\n \r
            const int LineWidth = 27 + EndOfLineWidth;

            char[,] map = new char[3,3]{
                {_accounts[position]                , _accounts[position+1],              _accounts[position +2]},
                {_accounts[position + LineWidth]    , _accounts[position+1+LineWidth]   , _accounts[position + 2 + LineWidth]},
                {_accounts[position + 2*LineWidth]  , _accounts[position+1+2*LineWidth] , _accounts[position + 2 + 2*LineWidth]},
            };

            return map;
        }
    }
}
