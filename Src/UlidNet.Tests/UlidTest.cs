using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UlidNet.Tests
{
    [TestClass]
    public class UlidTest
    {
        private const long Time = 1469918176385;

        [TestMethod]
        public void EncodeTimeShouldReturnExpectedEncodedResult()
        {
            // Act
            var result = Ulid.EncodeTime(Time, 10);

            // Assert
            Assert.AreEqual("01ARYZ6S41", result);
        }

        [TestMethod]
        public void EncodeTimeShouldChangeLenghtProperly()
        {
            // Act
            var result = Ulid.EncodeTime(Time, 12);

            // Assert
            Assert.AreEqual("0001ARYZ6S41", result);
        }

        [TestMethod]
        public void EncodeTimeShouldTruncateTimeIfNotEnoughLength()
        {
            // Act
            var result = Ulid.EncodeTime(Time, 8);

            // Assert
            Assert.AreEqual("ARYZ6S41", result);
        }

        [TestMethod]
        public void EncodeRandomShouldReturnCorrectLength()
        {
            // Arrange
            const int length = 12;

            // Act
            var result = Ulid.EncodeRandom(length);

            // Assert
            Assert.AreEqual(length, result.Length);
        }

        [TestMethod]
        public void NewUlidShouldReturnCorrectLength()
        {
            // Act
            var result = Ulid.NewUlid();

            // Assert
            Assert.AreEqual(26, result.Length);
        }
    }
}
