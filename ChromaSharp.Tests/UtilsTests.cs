using NUnit.Framework;

namespace ChromaSharp.Tests
{
    [TestFixture]
    public class UtilsTests
    {
        [Test]
        public void Clamp_WithinRange_ReturnsSameValue()
        {
            int value = 50;
            int min = 0;
            int max = 100;
            int result = ChromaSharp.Utils.Utils.Clamp(value, min, max);
            Assert.That(result, Is.EqualTo(50));
        }

        [Test]
        public void Clamp_BelowRange_ReturnsMin()
        {
            int value = -10;
            int min = 0;
            int max = 100;
            int result = ChromaSharp.Utils.Utils.Clamp(value, min, max);
            Assert.That(result, Is.EqualTo(0));
        }
    }
}
