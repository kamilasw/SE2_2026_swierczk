using System;
using TDDCodeKata;
using static System.Net.Mime.MediaTypeNames;

namespace Tests
{
    [TestClass]
    public class CalculateTests
    {
        [TestMethod]
        public void EmptyString()
        {
            StringCalculator stringCalculator = new StringCalculator();
            int result = stringCalculator.Calculate("");
            Assert.AreEqual(0, result);

        }

        [TestMethod]
        public void DoubleString()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int result = 0;

            result = stringCalculator.Calculate("13");
            Assert.AreEqual(13, result);

            result = stringCalculator.Calculate("007");
            Assert.AreEqual(7, result);
            result = stringCalculator.Calculate(" 81 ");
            Assert.AreEqual(81, result);
            result = stringCalculator.Calculate("  ");
            Assert.AreEqual(0, result);

        }

        [TestMethod]
        public void TwoNumbersWithComma()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int result = 0;

            result = stringCalculator.Calculate("13,34");
            Assert.AreEqual(47, result);
            result = stringCalculator.Calculate(" 43 , 03  ");
            Assert.AreEqual(46, result);
            result = stringCalculator.Calculate("043 ,  0003  ");
            Assert.AreEqual(46, result);
        }


        [TestMethod]
        public void TwoNumbersWithNewLine()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int result = 0;

            result = stringCalculator.Calculate("13\n34");
            Assert.AreEqual(47, result);
            result = stringCalculator.Calculate("   54 \n 34");
            Assert.AreEqual(88, result);
            result = stringCalculator.Calculate("43\n  3");
            Assert.AreEqual(46, result);
            result = stringCalculator.Calculate(" 43 \n 3  ");
            Assert.AreEqual(46, result);
            result = stringCalculator.Calculate("043 \n  0003  ");
            Assert.AreEqual(46, result);


        }

        [TestMethod]
        public void ThreeNumbers()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int result = 0;

            result = stringCalculator.Calculate("13\n34\n3");
            Assert.AreEqual(50, result);
            result = stringCalculator.Calculate("54\n34\n 3");
            Assert.AreEqual(91, result);
            result = stringCalculator.Calculate("43\n03\n 4");
            Assert.AreEqual(50, result);
            result = stringCalculator.Calculate(" 43 \n 3  \n0003");
            Assert.AreEqual(49, result);
            result = stringCalculator.Calculate("043 \n  0003  \n   02");
            Assert.AreEqual(48, result);
        }

        [TestMethod]
        public void NegativeNumbers()
        {
            StringCalculator stringCalculator = new StringCalculator();

            Assert.ThrowsException<Exception>(() => stringCalculator.Calculate("-14,2"));
            Assert.ThrowsException<Exception>(() => stringCalculator.Calculate("-14,  2"));
            Assert.ThrowsException<Exception>(() => stringCalculator.Calculate("-14\n  2"));

        }

        [TestMethod]
        public void IgnoreBigNumbers()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int result = 0;

            result = stringCalculator.Calculate("13\n34\n 1300");
            Assert.AreEqual(47, result);
            result = stringCalculator.Calculate("54\n 4343\n34");
            Assert.AreEqual(88, result);
            result = stringCalculator.Calculate("43\n 34322   \n03");
            Assert.AreEqual(46, result);
            result = stringCalculator.Calculate(" 43 \n 23423 \n 3 ");
            Assert.AreEqual(46, result);
            result = stringCalculator.Calculate("043 \n 342423 \n  0003  ");
            Assert.AreEqual(46, result);
        }

        [TestMethod]
        public void SingleDelimiter()
        {
            StringCalculator stringCalculator = new StringCalculator();

            int result = 0;

            result = stringCalculator.Calculate("#13#34#3");
            Assert.AreEqual(50, result);
            result = stringCalculator.Calculate("$54$34$ 3");
            Assert.AreEqual(91, result);
            result = stringCalculator.Calculate("*43*03* 4");
            Assert.AreEqual(50, result);
            result = stringCalculator.Calculate("+ 43 + 3  +0003");
            Assert.AreEqual(49, result);
            result = stringCalculator.Calculate("/043 /  0003  /   02");
            Assert.AreEqual(48, result);
        }

    }
}