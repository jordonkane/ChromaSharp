using ChromaSharp.ColorSpaces;
using ChromaSharp.Utils;
using System;
using Xunit;

namespace ChromaSharp.Tests
{
    public class ColorUtilsTests
    {
        [Fact]
        public void Rgb_Constructor_ClampsValues()
        {
            // Arrange
            int r = 300, g = -50, b = 128;

            // Act
            var rgb = new Rgb(r, g, b);

            // Assert
            Assert.Equal(255, rgb.R); // Clamped to max
            Assert.Equal(0, rgb.G);   // Clamped to min
            Assert.Equal(128, rgb.B); // Unchanged
        }
    }
}
