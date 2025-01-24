namespace ChromaSharp.ColorSpaces
{
    public class Ycbcr
    {
        public double Y { get; }
        public double Cb { get; }
        public double Cr { get; }

        public Ycbcr(double y, double cb, double cr)
        {
            Y = y;
            Cb = cb;
            Cr = cr;
        }

        public Rgb ToRgb()
        {
        }

        public Cmyk ToCmyk()
        {
        }

        public Hsv ToHsv()
        {
        }

        public Hsl ToHsl()
        {
        }

        public static Ycbcr FromRgb(Rgb rgb)
        {
        }

        public static Ycbcr FromCmyk(Cmyk cmyk)
        {
        }

        public static Ycbcr FromHsv(Hsv hsv)
        {
        }

        public static Ycbcr FromHsl(Hsl hsl)
        {
        }
    }
}
