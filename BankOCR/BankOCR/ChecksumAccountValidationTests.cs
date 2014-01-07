using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCR
{
    [TestClass]
    public class ChecksumAccountValidatorTests
    {
        private ChecksumAccountValidator _checksumValidator;

        private static int[] ValidAccountNo =  new int[]{
            4,5,7,5,0,8,0,0,0
        };
        private static int[] WrongAccountNo =  new int[]{
            6,6,4,3,7,1,4,9,5
        };

        [TestInitialize]
        public void BeforeEach()
        {
            _checksumValidator = new ChecksumAccountValidator();
        }

        [TestMethod]
        public void Validate_ShouldReturnTrue_WhenTheGivenAccountIsValid()
        {
            bool valid = _checksumValidator.Validate(ValidAccountNo);

            Assert.IsTrue(valid);
        }

        [TestMethod]
        public void Validate_ShouldReturnFalse_WhenTheGivenAccountIsWrong()
        {
            bool valid = _checksumValidator.Validate(WrongAccountNo);

            Assert.IsFalse(valid);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void Validate_ShouldThrowException_WhenInputIsNull()
        {
            _checksumValidator.Validate(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void Validate_ShouldThrowException_WhenInputLengthIsNotAsExpected()
        {
            _checksumValidator.Validate(new int[] { 0 });
        }
    }
}
