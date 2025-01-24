using ChromaSharp.ColorSpaces;
using ChromaSharp.Utils;
using System;
using Xunit;

namespace ChromaSharp.Tests
{
    public class ColorUtilsTests
    {
        [Fact]
        public void UnsupportedObjectType_ShouldThrowArgumentException()
        {
            // Arrange: Create an unsupported object type
            var unsupportedObject = "NotAColor";

            // Act & Assert: Verify that an ArgumentException is thrown with the correct message
            var exception = Assert.Throws<ArgumentException>(() => ColorUtils.ToRgb(unsupportedObject));
            Assert.Equal("Unsupported color type: String", exception.Message);
        }

        [Fact]
        public void NullInput_ShouldThrowArgumentNullException()
        {
            // Act & Assert: Verify that null inputs throw ArgumentNullException for all conversions
            Assert.Throws<ArgumentNullException>(() => ColorUtils.ToRgb(null));
            Assert.Throws<ArgumentNullException>(() => ColorUtils.ToCmyk(null));
            Assert.Throws<ArgumentNullException>(() => ColorUtils.ToHsv(null));
            Assert.Throws<ArgumentNullException>(() => ColorUtils.ToHsl(null));
            Assert.Throws<ArgumentNullException>(() => ColorUtils.ToYcbcr(null));
        }

        [Fact]
        public void Constructor_ShouldClampExtremeValues()
        {
            // Arrange: Use extreme values for RGB color
            var color = new Rgb(int.MaxValue, int.MinValue, -500);

            // Assert: Verify that values are clamped correctly
            Assert.Equal(255, color.R); // Clamped to max
            Assert.Equal(0, color.G);  // Clamped to min
            Assert.Equal(0, color.B);  // Clamped to min
        }

        [Fact]
        public void Conversion_WithExtremeValues_ShouldHandleCorrectly()
        {
            // Arrange: Define a pure white RGB color
            var color = new Rgb(255, 255, 255);

            // Act: Convert to HSV and back to RGB
            var convertedToHsv = color.ToHsv();
            var convertedBackToRgb = convertedToHsv.ToRgb();

            // Assert: Ensure the round-trip conversion matches the original
            Assert.Equal(color, convertedBackToRgb);
        }

        [Fact]
        public void InvalidColorConversion_ShouldThrowArgumentException()
        {
            // Arrange: Define an invalid object type
            var invalidColor = new { Invalid = true };

            // Act & Assert: Verify that an ArgumentException is thrown with the correct message
            var exception = Assert.Throws<ArgumentException>(() => ColorUtils.ToCmyk(invalidColor));
            Assert.Contains("Unsupported color type", exception.Message);
        }

        [Fact]
        public void NullValues_InDataClasses_ShouldThrow()
        {
            // Act & Assert: Verify that null inputs in the constructor throw ArgumentNullException
            Assert.Throws<ArgumentNullException>(() => new Rgb(0, null, 255));
        }
    }
}
