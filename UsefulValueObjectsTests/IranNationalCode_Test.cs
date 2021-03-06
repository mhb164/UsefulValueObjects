using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UsefullValueObjectsTests
{
    [TestClass]
    public class IranNationalCode_Test
    {
        [TestMethod]
        public void Same_values_are_equal_even_if_different_references()
        {
            var NationalCodeX = new IranNationalCode("7491254713");
            var NationalCodeY = new IranNationalCode("7491254713");
            var NationalCodeZ = new IranNationalCode(7491254713);
            Assert.AreEqual(NationalCodeX, NationalCodeY);
            Assert.AreEqual(NationalCodeX, NationalCodeZ);
        }

        [TestMethod]
        public void Check_get_formated()
        {
            Assert.AreEqual(new IranNationalCode("7491254713").GetFormated(), "749-125471-3");
            Assert.AreEqual(new IranNationalCode("7491254713").GetFormated(" "), "749 125471 3");
        }

        [TestMethod]
        public void Check_as_number()
        {
            Assert.AreEqual(new IranNationalCode("7491254713").AsNumber, 7491254713);
        }

        [TestMethod]
        public void Null_input()
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
        public void Persian_input()
        {
            new IranNationalCode("7491254713".ToPersian());
        }

        [TestMethod]
        public void Empty_input()
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
        public void Length_error_input()
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
        public void Not_number_error_input()
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
        public void All_digits_equal_input()
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
        public void Wrong_input()
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
