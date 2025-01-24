namespace ChromaSharp.ColorSpaces
{
    public class Rgb
    {
        public int R { get; }
        public int G { get; }
        public int B { get; }

        public Rgb(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        // Convert RGB to CMYK
        public Cmyk ToCmyk()
        {
            throw new NotImplementedException();
        }

        // Convert RGB to HSV
        public Hsv ToHsv()
        {
            throw new NotImplementedException();
        }

        // Convert RGB to HSL
        public Hsl ToHsl()
        {
            throw new NotImplementedException();
        }

        // Convert RGB to YCbCr
        public Ycbcr ToYcbcr()
        {
            throw new NotImplementedException();
        }
    }
}
