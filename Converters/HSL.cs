namespace ChromaSharp.ColorSpaces
{
    public static class Hsl
    {
        public static Rgb ToRgb(double H, double S, double L)
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

        public static Cmyk ToCmyk(double H, double S, double L)
        {
            Rgb rgb = ToRgb(H, S, L);
            return rgb.ToCmyk();
        }

        public static Hsv ToHsv(double H, double S, double L)
        {
            double v = L + S * Math.Min(L, 1 - L);
            double sv = v == 0 ? 0 : 2 * (1 - L / v);
            return new Hsv(H, sv, v);
        }

        public static Ycbcr ToYcbcr(double H, double S, double L)
        {
            Rgb rgb = ToRgb(H, S, L);
            return rgb.ToYcbcr();
        }

        public static (double H, double S, double L) FromRgb(Rgb rgb)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double H = 0, S = 0, L = (max + min) / 2;

            if (delta != 0)
            {
                S = delta / (1 - Math.Abs(2 * L - 1));
                if (max == r) H = (g - b) / delta + (g < b ? 6 : 0);
                else if (max == g) H = (b - r) / delta + 2;
                else if (max == b) H = (r - g) / delta + 4;
                H *= 60;
            }

            return (H, S, L);
        }

        public static (double H, double S, double L) FromCmyk(Cmyk cmyk)
        {
            Rgb rgb = Rgb.FromCmyk(cmyk);
            return FromRgb(rgb);
        }

        public static (double H, double S, double L) FromHsv(Hsv hsv)
        {
            double l = hsv.V * (1 - hsv.S / 2);
            double sl = l == 0 || l == 1 ? 0 : (hsv.V - l) / Math.Min(l, 1 - l);
            return (hsv.H, sl, l);
        }

        public static (double H, double S, double L) FromYcbcr(Ycbcr ycbcr)
        {
            Rgb rgb = Rgb.FromYcbcr(ycbcr);
            return FromRgb(rgb);
        }
    }
}
