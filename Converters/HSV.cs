namespace ChromaSharp.ColorSpaces
{
    public class Hsv
    {
        public double H { get; }
        public double S { get; }
        public double V { get; }

        public Hsv(double h, double s, double v)
        {
            H = h;
            S = s;
            V = v;
        }

        public Rgb ToRgb()
        {
            double h = H / 360.0;
            int i = (int)(h * 6);
            double f = h * 6 - i;
            double p = V * (1 - S);
            double q = V * (1 - f * S);
            double t = V * (1 - (1 - f) * S);

            double r = 0, g = 0, b = 0;
            switch (i % 6)
            {
                case 0: r = V; g = t; b = p; break;
                case 1: r = q; g = V; b = p; break;
                case 2: r = p; g = V; b = t; break;
                case 3: r = p; g = q; b = V; break;
                case 4: r = t; g = p; b = V; break;
                case 5: r = V; g = p; b = q; break;
            }

            return new Rgb(
                (int)(r * 255),
                (int)(g * 255),
                (int)(b * 255)
            );
        }

        public Cmyk ToCmyk()
        {
            return ToRgb().ToCmyk();
        }

        public Ycbcr ToYcbcr()
        {
            return ToRgb().ToYcbcr();
        }

        public Hsl ToHsl()
        {
            double l = V * (1 - S / 2);
            double sl = l == 0 || l == 1 ? 0 : (V - l) / Math.Min(l, 1 - l);
            return new Hsl(H, sl, l);
        }

        public static Hsv FromRgb(Rgb rgb)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double h = 0, s = 0, v = max;

            if (delta != 0)
            {
                s = delta / max;
                if (max == r) h = (g - b) / delta + (g < b ? 6 : 0);
                else if (max == g) h = (b - r) / delta + 2;
                else if (max == b) h = (r - g) / delta + 4;
                h *= 60;
            }

            return new Hsv(h, s, v);
        }

        public static Hsv FromCmyk(Cmyk cmyk)
        {
            return FromRgb(cmyk.ToRgb());
        }

        public static Hsv FromYcbcr(Ycbcr ycbcr)
        {
            return FromRgb(ycbcr.ToRgb());
        }

        public static Hsv FromHsl(Hsl hsl)
        {
            double s = hsl.S;
            double l = hsl.L;
            double v = l + s * Math.Min(l, 1 - l);
            double sv = v == 0 ? 0 : 2 * (1 - l / v);
            return new Hsv(hsl.H, sv, v);
        }
    }
}
