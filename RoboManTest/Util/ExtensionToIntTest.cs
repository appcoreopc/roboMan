using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboMan.Util;

namespace RoboManTest.Util
{
    [TestClass]
    public class ExtensionToIntTest
    {
        
        [TestMethod]
        public void ValidIntegerConvertionTest()
        {
            var targetTestString = "100";

            var expectedResult = 100;

            var targetSubject = targetTestString.ToInt();

            Assert.IsNotNull(targetSubject);

            Assert.IsTrue(targetSubject.HasValue);

            Assert.AreEqual(expectedResult, targetSubject.Value);
            
        }


        [TestMethod]
        public void NotVaidIntegerConversionTest()
        {
            var targetTestString = "blah";

            var expectedResult = 100;

            var targetSubject = targetTestString.ToInt();

            Assert.IsNull(targetSubject);

        }

        [TestMethod]
        public void EmptyStringIntegerConversionTest()
        {
            var targetTestString = string.Empty;
                       
            var targetSubject = targetTestString.ToInt();

            Assert.IsNull(targetSubject);
            
        }
    }
}
