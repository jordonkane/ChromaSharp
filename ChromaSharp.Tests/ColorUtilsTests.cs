using Xunit;
using ChromaSharp.ColorSpaces;

namespace ChromaSharp.Tests
{
    public class RgbTests
    {
        [Fact]
        public void Rgb_Constructor_ClampsValues()
        {
            // Arrange
            int r = 300; // Exceeds max
            int g = -50; // Below min
            int b = 128; // Within range

            // Act
            var rgb = new Rgb(r, g, b);

            // Assert
            Assert.Equal(255, rgb.R); // Clamped to max
            Assert.Equal(0, rgb.G);   // Clamped to min
            Assert.Equal(128, rgb.B); // Unchanged
        }
    }
}
