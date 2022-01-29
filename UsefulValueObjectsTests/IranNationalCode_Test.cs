using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UsefullValueObjectsTests
{
    [TestClass]
    public class IranNationalCode_Test
    {
        [TestMethod]
        public void Test_NullInput()
        {
            try
            {
                var inc = new IranNationalCode(null);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, IranNationalCode.NationalCodeIsNullMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Test_PersianInput()
        {
            new IranNationalCode("7491254713".ToPersian());
        }

        [TestMethod]
        public void Test_EmptyInput()
        {
            try
            {
                var inc = new IranNationalCode("");
            }
            catch (ApplicationException e)
            {
                StringAssert.Contains(e.Message, IranNationalCode.NationalCodeIsEmptyMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Test_LengthErrorInput()
        {
            try
            {
                var inc = new IranNationalCode("12345");
            }
            catch (ApplicationException e)
            {
                StringAssert.Contains(e.Message, IranNationalCode.NationalCodeLengthErrorMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Test_NotNumberErrorInput()
        {
            try
            {
                var inc = new IranNationalCode("1a34567890");
            }
            catch (ApplicationException e)
            {
                StringAssert.Contains(e.Message, IranNationalCode.NationalCodeNotNumberMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Test_AllDigitsEqualInput()
        {
            try
            {
                var inc = new IranNationalCode("1111111111");
            }
            catch (ApplicationException e)
            {
                StringAssert.Contains(e.Message, IranNationalCode.NationalCodeAllDigitsEqualMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Test_WrongInput()
        {
            try
            {
                var inc = new IranNationalCode("7491254712");
            }
            catch (ApplicationException e)
            {
                StringAssert.Contains(e.Message, IranNationalCode.NationalCodeIsWrongMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
