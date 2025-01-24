using Xunit;
using ChromaSharp.ColorSpaces;

namespace ChromaSharp.Tests
{
    public class RgbTests
    {
        [Fact]
        public void Rgb_ToCmyk_Should_ConvertCorrectly()
        {
            var rgb = new Rgb(255, 0, 0);
            var cmyk = rgb.ToCmyk();
            Assert.Equal(0, cmyk.C, precision: 2);
            Assert.Equal(1, cmyk.M, precision: 2);
            Assert.Equal(1, cmyk.Y, precision: 2);
            Assert.Equal(0, cmyk.K, precision: 2);
        }

        [Fact]
        public void Rgb_ToHsv_Should_ConvertCorrectly()
        {
            var rgb = new Rgb(0, 255, 0);
            var hsv = rgb.ToHsv();
            Assert.Equal(120, hsv.H, precision: 2);
            Assert.Equal(1, hsv.S, precision: 2);
            Assert.Equal(1, hsv.V, precision: 2);
        }
    }
}
