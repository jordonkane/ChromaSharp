namespace ChromaSharp.ColorSpaces
{
    public static class Ycbcr
    {
        public static Rgb ToRgb(double Y, double Cb, double Cr)
        {
            int r = Clamp((int)(Y + 1.402 * (Cr - 128)));
            int g = Clamp((int)(Y - 0.344136 * (Cb - 128) - 0.714136 * (Cr - 128)));
            int b = Clamp((int)(Y + 1.772 * (Cb - 128)));

            return new Rgb(r, g, b);
        }

        public static Cmyk ToCmyk(double Y, double Cb, double Cr)
        {
            Rgb rgb = ToRgb(Y, Cb, Cr);
            return rgb.ToCmyk();
        }

        public static Hsv ToHsv(double Y, double Cb, double Cr)
        {
            Rgb rgb = ToRgb(Y, Cb, Cr);
            return rgb.ToHsv();
        }

        public static Hsl ToHsl(double Y, double Cb, double Cr)
        {
            Rgb rgb = ToRgb(Y, Cb, Cr);
            return rgb.ToHsl();
        }

        public static (double Y, double Cb, double Cr) FromRgb(Rgb rgb)
        {
            double y = 0.299 * rgb.R + 0.587 * rgb.G + 0.114 * rgb.B;
            double cb = 128 + (-0.169 * rgb.R - 0.331 * rgb.G + 0.5 * rgb.B);
            double cr = 128 + (0.5 * rgb.R - 0.419 * rgb.G - 0.081 * rgb.B);
            return (y, cb, cr);
        }

        public static (double Y, double Cb, double Cr) FromCmyk(Cmyk cmyk)
        {
            Rgb rgb = Rgb.FromCmyk(cmyk);
            return FromRgb(rgb);
        }

        public static (double Y, double Cb, double Cr) FromHsv(Hsv hsv)
        {
            Rgb rgb = Rgb.FromHsv(hsv);
            return FromRgb(rgb);
        }

        public static (double Y, double Cb, double Cr) FromHsl(Hsl hsl)
        {
            Rgb rgb = Rgb.FromHsl(hsl);
            return FromRgb(rgb);
        }

        private static int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }
    }
}
