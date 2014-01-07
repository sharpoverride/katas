using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;

namespace Args
{
    [TestClass]
    public class ArgumentsParserTests
    {
        private string[] _args;
        private ArgsParser _parser;
        private Dictionary<string, Type> _schema;
        private string[] _emptyArguments;

        [TestInitialize]
        public void BeforeEach()
        {
            _args = new string[]{
                "-i",
                "-p",
                "8000",
                "-d",
                "/usr/logs"
            };

            _emptyArguments = new string[0];

            _schema = new Dictionary<string, Type>
            {
                {"-i", typeof(bool)},
                {"-p", typeof(int)},
                {"-d", typeof(string)}
            };

            _parser = new ArgsParser(_schema);
        }

        [TestMethod]
        public void GetValue_ReturnsTrueForParameterTypeSpecifiedAsBooleanInTheSchema_WhenTheParameterIsPresent()
        {
            _parser.Process(_args);
            Assert.AreEqual( true, _parser.GetValue<bool>("-i"));
        }

        [TestMethod]
        public void GetValue_ReturnsTheIntegerValueForParameterSpecifiedAsInteger_WhenTheParameterIsPresent()
        {
            _parser.Process(_args);

            Assert.AreEqual(8000, _parser.GetValue<int>("-p"));
        }

        [TestMethod]
        public void GetValue_ReturnsStringValueForParameterSpecifiedAsString_WhenTheParameterIsPresent()
        {
            _parser.Process(_args);

            Assert.AreEqual("/usr/logs", _parser.GetValue<string>("-d"));
        }

        [TestMethod]
        public void GetValue_ReturnsFalseForParameterTypeSpecifiedAsBooleanInTheSchema_WhenTheParameterIsMissing()
        {
            _parser.Process(_emptyArguments);

            Assert.AreEqual(false, _parser.GetValue<bool>("-i"));
        }

        [TestMethod]
        public void GetValue_ReturnsTheDefaultIntegerValueForParameterSpecifiedAsInteger_WhenTheParameterIsMissing()
        {
            _parser.Process(_emptyArguments);

            Assert.AreEqual(0, _parser.GetValue<int>("-p"));
        }

        [TestMethod]
        public void GetValue_ReturnsEmptyStringForParameterSpecifiedAsString_WhenTheParameterIsMissing()
        {
            _parser.Process(_emptyArguments);

            Assert.AreEqual(string.Empty, _parser.GetValue<string>("-d"));
        }
    }
}
