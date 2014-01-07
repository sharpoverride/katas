using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankOCR
{
    internal class ChecksumAccountValidator
    {
        const int AccountNoLength = 9;

        internal bool Validate(int[] accountNo)
        {
            if (accountNo == null) throw new ArgumentNullException("accountNo should not be null");
            if (accountNo.Length != AccountNoLength) throw new ArgumentOutOfRangeException("accountNo", "should be of fixed length 9");

            var position = AccountNoLength;
            var sum = 0;

            for (int i = 0; i < AccountNoLength; i++)
            {
                sum += position * accountNo[i];
                position--;
            }

            var checksumIsValid = sum % 11 == 0;
            return checksumIsValid;
        }
    }
}
