using Xunit;
using ChromaSharp.ColorSpaces;

namespace ChromaSharp.Tests
{
    public class CmykTests
    {
        [Fact]
        public void Cmyk_ToRgb_Should_ConvertCorrectly()
        {
            var cmyk = new Cmyk(0, 1, 1, 0);
            var rgb = cmyk.ToRgb();
            Assert.Equal(255, rgb.R);
            Assert.Equal(0, rgb.G);
            Assert.Equal(0, rgb.B);
        }
    }
}
