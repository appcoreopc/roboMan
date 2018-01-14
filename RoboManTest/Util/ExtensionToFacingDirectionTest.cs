using Microsoft.VisualStudio.TestTools.UnitTesting;
using RoboMan;
using RoboMan.Util;

namespace RoboManTest.Util
{
    [TestClass]
    public class ExtensionToFacingDirectionTest
    {

        [TestMethod]
        public void ConvertToValidDirectionTest()
        {
            var targetTestString = "North";

            var expectedResult = FaceDirection.NORTH;

            var targetSubject = targetTestString.ToDirection();

            Assert.IsNotNull(targetSubject);

            Assert.IsTrue(targetSubject.HasValue);

            Assert.AreEqual(expectedResult, targetSubject.Value);

        }


        [TestMethod]
        public void ConvertToValidDirectionLowercaseTest()
        {
            var targetTestString = "north";

            var expectedResult = FaceDirection.NORTH;

            var targetSubject = targetTestString.ToDirection();

            Assert.IsNotNull(targetSubject);

            Assert.IsTrue(targetSubject.HasValue);

            Assert.AreEqual(expectedResult, targetSubject.Value);

        }

        [TestMethod]
        public void ConvertToValidDirectionUppercaseTest()
        {
            var targetTestString = "NORTH";

            var expectedResult = FaceDirection.NORTH;

            var targetSubject = targetTestString.ToDirection();

            Assert.IsNotNull(targetSubject);

            Assert.IsTrue(targetSubject.HasValue);

            Assert.AreEqual(expectedResult, targetSubject.Value);

        }


        [TestMethod]
        public void ConvertToNorthTest()
        {
            var targetTestString = "NORTH";

            var expectedResult = FaceDirection.NORTH;

            var targetSubject = targetTestString.ToDirection();
            
            Assert.AreEqual(expectedResult, targetSubject.Value);

        }

        [TestMethod]
        public void ConvertToEastTest()
        {
            var targetTestString = "east";

            var expectedResult = FaceDirection.EAST;

            var targetSubject = targetTestString.ToDirection();

            Assert.AreEqual(expectedResult, targetSubject.Value);

        }

        [TestMethod]
        public void ConvertToWestTest()
        {
            var targetTestString = "west";

            var expectedResult = FaceDirection.WEST;

            var targetSubject = targetTestString.ToDirection();

            Assert.AreEqual(expectedResult, targetSubject.Value);

        }


        [TestMethod]
        public void ConvertToSouthest()
        {
            var targetTestString = "south";

            var expectedResult = FaceDirection.SOUTH;

            var targetSubject = targetTestString.ToDirection();

            Assert.AreEqual(expectedResult, targetSubject.Value);

        }
    }
}
