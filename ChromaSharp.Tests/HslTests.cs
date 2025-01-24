using Xunit;
using ChromaSharp.ColorSpaces;

namespace ChromaSharp.Tests
{
    public class HslTests
    {
        [Fact]
        public void Hsl_ToRgb_Should_ConvertCorrectly()
        {
            var hsl = new Hsl(240, 1, 0.5);
            var rgb = hsl.ToRgb();
            Assert.Equal(0, rgb.R);
            Assert.Equal(0, rgb.G);
            Assert.Equal(255, rgb.B);
        }
    }
}
