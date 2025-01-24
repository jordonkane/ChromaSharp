namespace ChromaSharp.ColorSpaces
{
    public class Hsl
    {
        public double H { get; }
        public double S { get; }
        public double L { get; }

        public Hsl(double h, double s, double l)
        {
            H = h;
            S = s;
            L = l;
        }

        public Rgb ToRgb()
        {
            double c = (1 - Math.Abs(2 * L - 1)) * S;
            double x = c * (1 - Math.Abs((H / 60) % 2 - 1));
            double m = L - c / 2;

            double r = 0, g = 0, b = 0;

            if (H >= 0 && H < 60) { r = c; g = x; b = 0; }
            else if (H >= 60 && H < 120) { r = x; g = c; b = 0; }
            else if (H >= 120 && H < 180) { r = 0; g = c; b = x; }
            else if (H >= 180 && H < 240) { r = 0; g = x; b = c; }
            else if (H >= 240 && H < 300) { r = x; g = 0; b = c; }
            else if (H >= 300 && H < 360) { r = c; g = 0; b = x; }

            return new Rgb(
                (int)((r + m) * 255),
                (int)((g + m) * 255),
                (int)((b + m) * 255)
            );
        }

        public Cmyk ToCmyk()
        {
            return ToRgb().ToCmyk();
        }

        public Hsv ToHsv()
        {
            double v = L + S * Math.Min(L, 1 - L);
            double sv = v == 0 ? 0 : 2 * (1 - L / v);
            return new Hsv(H, sv, v);
        }

        public Ycbcr ToYcbcr()
        {
            return ToRgb().ToYcbcr();
        }

        public static Hsl FromRgb(Rgb rgb)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double h = 0, s = 0, l = (max + min) / 2;

            if (delta != 0)
            {
                s = delta / (1 - Math.Abs(2 * l - 1));
                if (max == r) h = (g - b) / delta + (g < b ? 6 : 0);
                else if (max == g) h = (b - r) / delta + 2;
                else if (max == b) h = (r - g) / delta + 4;
                h *= 60;
            }

            return new Hsl(h, s, l);
        }

        public static Hsl FromCmyk(Cmyk cmyk)
        {
            return FromRgb(cmyk.ToRgb());
        }

        public static Hsl FromHsv(Hsv hsv)
        {
            double l = hsv.V * (1 - hsv.S / 2);
            double sl = l == 0 || l == 1 ? 0 : (hsv.V - l) / Math.Min(l, 1 - l);
            return new Hsl(hsv.H, sl, l);
        }

        public static Hsl FromYcbcr(Ycbcr ycbcr)
        {
            return FromRgb(ycbcr.ToRgb());
        }
    }
}
