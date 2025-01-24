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
            Rgb rgb = ToRgb();
            return rgb.ToHsv();
        }

        public Hsl ToHsl()
        {
            Rgb rgb = ToRgb();
            return rgb.ToHsl();
        }

        public static Ycbcr FromRgb(Rgb rgb)
        {
            double y = 0.299 * rgb.R + 0.587 * rgb.G + 0.114 * rgb.B;
            double cb = 128 + (-0.169 * rgb.R - 0.331 * rgb.G + 0.5 * rgb.B);
            double cr = 128 + (0.5 * rgb.R - 0.419 * rgb.G - 0.081 * rgb.B);
            return new Ycbcr(y, cb, cr);
        }

        public static Ycbcr FromCmyk(Cmyk cmyk)
        {
            Rgb rgb = Rgb.FromCmyk(cmyk);
            return FromRgb(rgb);
        }

        public static Ycbcr FromHsv(Hsv hsv)
        {
            Rgb rgb = Rgb.FromHsv(hsv);
            return FromRgb(rgb);
        }

        public static Ycbcr FromHsl(Hsl hsl)
        {
            Rgb rgb = Rgb.FromHsl(hsl);
            return FromRgb(rgb);
        }
    }
}
