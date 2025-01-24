namespace ChromaSharp.ColorSpaces
{
    public class Cmyk
    {
        public double C { get; }
        public double M { get; }
        public double Y { get; }
        public double K { get; }

        public Cmyk(double c, double m, double y, double k)
        {
            C = c;
            M = m;
            Y = y;
            K = k;
        }

        public Rgb ToRgb()
        {
            int r = (int)(255 * (1 - C) * (1 - K));
            int g = (int)(255 * (1 - M) * (1 - K));
            int b = (int)(255 * (1 - Y) * (1 - K));
            return new Rgb(r, g, b);
        }

        public Hsv ToHsv()
        {
            return ToRgb().ToHsv();
        }

        public Hsl ToHsl()
        {
            return ToRgb().ToHsl();
        }

        public Ycbcr ToYcbcr()
        {
            return ToRgb().ToYcbcr();
        }

        public static Cmyk FromRgb(Rgb rgb)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;

            double k = 1 - Math.Max(r, Math.Max(g, b));
            double c = (1 - r - k) / (1 - k);
            double m = (1 - g - k) / (1 - k);
            double y = (1 - b - k) / (1 - k);

            return new Cmyk(c, m, y, k);
        }

        public static Cmyk FromHsv(Hsv hsv)
        {
            return FromRgb(Rgb.FromHsv(hsv));
        }

        public static Cmyk FromHsl(Hsl hsl)
        {
            return FromRgb(Rgb.FromHsl(hsl));
        }

        public static Cmyk FromYcbcr(Ycbcr ycbcr)
        {
            return FromRgb(Rgb.FromYcbcr(ycbcr));
        }
    }
}
