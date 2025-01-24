namespace ChromaSharp.ColorSpaces
{
    public class Rgb
    {
        public int R { get; }
        public int G { get; }
        public int B { get; }

        public Rgb(int r, int g, int b)
        {
            R = r;
            G = g;
            B = b;
        }

        public Cmyk ToCmyk()
        {
            double r = R / 255.0, g = G / 255.0, b = B / 255.0;
            double K = 1 - Math.Max(r, Math.Max(g, b));
            double C = (1 - r - K) / (1 - K);
            double M = (1 - g - K) / (1 - K);
            double Y = (1 - b - K) / (1 - K);
            return new Cmyk(C, M, Y, K);
        }

        public Hsv ToHsv()
        {
            double r = R / 255.0, g = G / 255.0, b = B / 255.0;
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
                H /= 6;
            }
            return new Hsv(H * 360, S, V);
        }

        public Hsl ToHsl()
        {
            double r = R / 255.0, g = G / 255.0, b = B / 255.0;
            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double H = 0, S = 0, L = (max + min) / 2;

            if (delta != 0)
            {
                S = L < 0.5 ? delta / (max + min) : delta / (2 - max - min);
                if (max == r) H = (g - b) / delta + (g < b ? 6 : 0);
                else if (max == g) H = (b - r) / delta + 2;
                else if (max == b) H = (r - g) / delta + 4;
                H /= 6;
            }
            return new Hsl(H * 360, S, L);
        }

        public Ycbcr ToYcbcr()
        {
            double y = 0.299 * R + 0.587 * G + 0.114 * B;
            double cb = 128 + (-0.169 * R - 0.331 * G + 0.5 * B);
            double cr = 128 + (0.5 * R - 0.419 * G - 0.081 * B);
            return new Ycbcr(y, cb, cr);
        }

        public static Rgb FromCmyk(Cmyk cmyk)
        {
            int r = (int)(255 * (1 - cmyk.C) * (1 - cmyk.K));
            int g = (int)(255 * (1 - cmyk.M) * (1 - cmyk.K));
            int b = (int)(255 * (1 - cmyk.Y) * (1 - cmyk.K));
            return new Rgb(r, g, b);
        }

        public static Rgb FromHsv(Hsv hsv)
        {
            double h = hsv.H / 360.0;
            double s = hsv.S;
            double v = hsv.V;

            int i = (int)(h * 6);
            double f = h * 6 - i;
            double p = v * (1 - s);
            double q = v * (1 - f * s);
            double t = v * (1 - (1 - f) * s);

            double r = 0, g = 0, b = 0;

            switch (i % 6)
            {
                case 0: r = v; g = t; b = p; break;
                case 1: r = q; g = v; b = p; break;
                case 2: r = p; g = v; b = t; break;
                case 3: r = p; g = q; b = v; break;
                case 4: r = t; g = p; b = v; break;
                case 5: r = v; g = p; b = q; break;
            }

            return new Rgb((int)(r * 255), (int)(g * 255), (int)(b * 255));
        }

        public static Rgb FromHsl(Hsl hsl)
        {
            double h = hsl.H / 360.0;
            double s = hsl.S;
            double l = hsl.L;

            double c = (1 - Math.Abs(2 * l - 1)) * s;
            double x = c * (1 - Math.Abs((h * 6) % 2 - 1));
            double m = l - c / 2;

            double r = 0, g = 0, b = 0;

            if (h < 1.0 / 6) { r = c; g = x; b = 0; }
            else if (h < 2.0 / 6) { r = x; g = c; b = 0; }
            else if (h < 3.0 / 6) { r = 0; g = c; b = x; }
            else if (h < 4.0 / 6) { r = 0; g = x; b = c; }
            else if (h < 5.0 / 6) { r = x; g = 0; b = c; }
            else { r = c; g = 0; b = x; }

            return new Rgb((int)((r + m) * 255), (int)((g + m) * 255), (int)((b + m) * 255));
        }

        public static Rgb FromYcbcr(Ycbcr ycbcr)
        {
            int r = (int)(ycbcr.Y + 1.402 * (ycbcr.Cr - 128));
            int g = (int)(ycbcr.Y - 0.344136 * (ycbcr.Cb - 128) - 0.714136 * (ycbcr.Cr - 128));
            int b = (int)(ycbcr.Y + 1.772 * (ycbcr.Cb - 128));
            return new Rgb(r, g, b);
        }
    }
}
