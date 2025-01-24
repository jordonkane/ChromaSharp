namespace ChromaSharp.ColorSpaces
{
    public static class Cmyk
    {
        public static Rgb ToRgb(double C, double M, double Y, double K)
        {
            int r = (int)(255 * (1 - C) * (1 - K));
            int g = (int)(255 * (1 - M) * (1 - K));
            int b = (int)(255 * (1 - Y) * (1 - K));
            return new Rgb(r, g, b);
        }

        public static Hsv ToHsv(double C, double M, double Y, double K)
        {
            Rgb rgb = ToRgb(C, M, Y, K);
            return rgb.ToHsv();
        }

        public static Hsl ToHsl(double C, double M, double Y, double K)
        {
            Rgb rgb = ToRgb(C, M, Y, K);
            return rgb.ToHsl();
        }

        public static Ycbcr ToYcbcr(double C, double M, double Y, double K)
        {
            Rgb rgb = ToRgb(C, M, Y, K);
            return rgb.ToYcbcr();
        }

        public static (double C, double M, double Y, double K) FromRgb(Rgb rgb)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;

            double K = 1 - Math.Max(r, Math.Max(g, b));
            double C = (1 - r - K) / (1 - K);
            double M = (1 - g - K) / (1 - K);
            double Y = (1 - b - K) / (1 - K);

            return (C, M, Y, K);
        }

        public static (double C, double M, double Y, double K) FromHsv(Hsv hsv)
        {
            Rgb rgb = Rgb.FromHsv(hsv);
            return FromRgb(rgb);
        }

        public static (double C, double M, double Y, double K) FromHsl(Hsl hsl)
        {
            Rgb rgb = Rgb.FromHsl(hsl);
            return FromRgb(rgb);
        }

        public static (double C, double M, double Y, double K) FromYcbcr(Ycbcr ycbcr)
        {
            Rgb rgb = Rgb.FromYcbcr(ycbcr);
            return FromRgb(rgb);
        }
    }
}
