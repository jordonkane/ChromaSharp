namespace ChromaSharp.ColorSpaces
{
    public static class Hsv
    {
        public static Rgb ToRgb(double H, double S, double V)
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

        public static Cmyk ToCmyk(double H, double S, double V)
        {
            Rgb rgb = ToRgb(H, S, V);
            return rgb.ToCmyk();
        }

        public static Ycbcr ToYcbcr(double H, double S, double V)
        {
            Rgb rgb = ToRgb(H, S, V);
            return rgb.ToYcbcr();
        }

        public static Hsl ToHsl(double H, double S, double V)
        {
            double l = V * (1 - S / 2);
            double sl = l == 0 || l == 1 ? 0 : (V - l) / Math.Min(l, 1 - l);
            return new Hsl(H, sl, l);
        }

        public static (double H, double S, double V) FromRgb(Rgb rgb)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double H = 0, S = 0, V = max;

            if (delta != 0)
            {
                S = delta / max;
                if (max == r) H = (g - b) / delta + (g < b ? 6 : 0);
                else if (max == g) H = (b - r) / delta + 2;
                else if (max == b) H = (r - g) / delta + 4;
                H *= 60;
            }

            return (H, S, V);
        }

        public static (double H, double S, double V) FromCmyk(Cmyk cmyk)
        {
            Rgb rgb = Rgb.FromCmyk(cmyk);
            return FromRgb(rgb);
        }

        public static (double H, double S, double V) FromYcbcr(Ycbcr ycbcr)
        {
            Rgb rgb = Rgb.FromYcbcr(ycbcr);
            return FromRgb(rgb);
        }

        public static (double H, double S, double V) FromHsl(Hsl hsl)
        {
            double s = hsl.S;
            double l = hsl.L;
            double v = l + s * Math.Min(l, 1 - l);
            double sv = v == 0 ? 0 : 2 * (1 - l / v);
            return (hsl.H, sv, v);
        }
    }
}
