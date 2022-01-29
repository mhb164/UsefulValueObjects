using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace UsefullValueObjectsTests
{
    [TestClass]
    public class MobileNumber_Test
    {
        [TestMethod]
        public void Same_values_are_equal_even_if_different_references()
        {
            var MobileNumberX = new MobileNumber("+989123456789");
            var MobileNumberY = new MobileNumber("+989123456789");
            Assert.AreEqual(MobileNumberX, MobileNumberY);
        }

        [TestMethod]
        public void Check_get_formated()
        {
            Assert.AreEqual(new MobileNumber("+989123456789").GetFormated(), "+98-912-345-6789");
            Assert.AreEqual(new MobileNumber("+989123456789").GetFormated(" "), "+98 912 345 6789");
        }

        [TestMethod]
        public void Check_as_number()
        {
            Assert.AreEqual(new MobileNumber("+989123456789").AsNumber, 989123456789);
        }

        [TestMethod]
        public void Null_input()
        {
            try
            {
                var inc = new MobileNumber(null);
            }
            catch (ArgumentNullException e)
            {
                StringAssert.Contains(e.Message, MobileNumber.MobileNumberIsNullMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Persian_input()
        {
            new MobileNumber("+989123456789".ToPersian());
        }

        [TestMethod]
        public void Empty_input()
        {
            try
            {
                var inc = new MobileNumber("");
            }
            catch (ApplicationException e)
            {
                StringAssert.Contains(e.Message, MobileNumber.MobileNumberIsEmptyMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Not_number_error_input()
        {
            try
            {
                var inc = new MobileNumber("+98912345678a");
            }
            catch (ApplicationException e)
            {
                StringAssert.Contains(e.Message, MobileNumber.MobileNumberNotNumberMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Not_start_with_plus_input()
        {
            try
            {
                var inc = new MobileNumber("09123456789");
            }
            catch (ApplicationException e)
            {
                StringAssert.Contains(e.Message, MobileNumber.MobileNumberNotStartWithPlusMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }

        [TestMethod]
        public void Not_implemented_input()
        {
            try
            {
                var inc = new MobileNumber("+19123456789");
            }
            catch (NotImplementedException e)
            {
                StringAssert.Contains(e.Message, MobileNumber.MobileNumberNotImplementedMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }


        [TestMethod]
        public void Wrong_input()
        {
            try
            {
                var inc = new MobileNumber("+98912345678");
            }
            catch (ApplicationException e)
            {
                StringAssert.Contains(e.Message, MobileNumber.MobileNumberIsWrongMessage);
                return;
            }
            Assert.Fail("The expected exception was not thrown.");
        }
    }
}
