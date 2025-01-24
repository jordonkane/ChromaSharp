using NUnit.Framework;

namespace ChromaSharp.Tests
{
    public class UtilsTests
    {
        [Test]
        public void Clamp_WithinRange_ReturnsSameValue()
        {
            // Arrange
            int value = 50;
            int min = 0;
            int max = 100;

            // Act
            int result = ChromaSharp.Utils.Utils.Clamp(value, min, max);

            // Assert
            Assert.AreEqual(50, result);
        }

        [Test]
        public void Clamp_BelowRange_ReturnsMin()
        {
            // Arrange
            int value = -10;
            int min = 0;
            int max = 100;

            // Act
            int result = ChromaSharp.Utils.Utils.Clamp(value, min, max);

            // Assert
            Assert.AreEqual(0, result);
        }
    }
}
