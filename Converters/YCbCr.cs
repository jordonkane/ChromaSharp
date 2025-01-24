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
            int r = (int)(Y + 1.402 * (Cr - 128));
            int g = (int)(Y - 0.344136 * (Cb - 128) - 0.714136 * (Cr - 128));
            int b = (int)(Y + 1.772 * (Cb - 128));
            return new Rgb(
                Math.Max(0, Math.Min(255, r)),
                Math.Max(0, Math.Min(255, g)),
                Math.Max(0, Math.Min(255, b))
            );
        }

        public Cmyk ToCmyk()
        {
            Rgb rgb = ToRgb();
            return rgb.ToCmyk();
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
