using ChromaSharp.ColorSpaces;
using System;

namespace ChromaSharp.Utils
{
    public static class ColorUtils
    {
        private static int Clamp(int value) => Math.Max(0, Math.Min(255, value));
        private static double Clamp(double value, double min, double max) => Math.Max(min, Math.Min(max, value));

        public static Rgb ToRgb(Ycbcr ycbcr)
        {
            int r = (int)(ycbcr.Y + 1.402 * (ycbcr.Cr - 128));
            int g = (int)(ycbcr.Y - 0.344136 * (ycbcr.Cb - 128) - 0.714136 * (ycbcr.Cr - 128));
            int b = (int)(ycbcr.Y + 1.772 * (ycbcr.Cb - 128));
            return new Rgb(Clamp(r), Clamp(g), Clamp(b));
        }

        public static Rgb ToRgb(Cmyk cmyk)
        {
            int r = (int)((1 - cmyk.C) * (1 - cmyk.K) * 255);
            int g = (int)((1 - cmyk.M) * (1 - cmyk.K) * 255);
            int b = (int)((1 - cmyk.Y) * (1 - cmyk.K) * 255);
            return new Rgb(Clamp(r), Clamp(g), Clamp(b));
        }

        public static Rgb ToRgb(Hsv hsv)
        {
            double c = hsv.V * hsv.S;
            double x = c * (1 - Math.Abs((hsv.H / 60) % 2 - 1));
            double m = hsv.V - c;

            double rPrime, gPrime, bPrime;

            if (hsv.H >= 0 && hsv.H < 60)
            {
                rPrime = c; gPrime = x; bPrime = 0;
            }
            else if (hsv.H >= 60 && hsv.H < 120)
            {
                rPrime = x; gPrime = c; bPrime = 0;
            }
            else if (hsv.H >= 120 && hsv.H < 180)
            {
                rPrime = 0; gPrime = c; bPrime = x;
            }
            else if (hsv.H >= 180 && hsv.H < 240)
            {
                rPrime = 0; gPrime = x; bPrime = c;
            }
            else if (hsv.H >= 240 && hsv.H < 300)
            {
                rPrime = x; gPrime = 0; bPrime = c;
            }
            else
            {
                rPrime = c; gPrime = 0; bPrime = x;
            }

            int r = Clamp((int)((rPrime + m) * 255));
            int g = Clamp((int)((gPrime + m) * 255));
            int b = Clamp((int)((bPrime + m) * 255));

            return new Rgb(r, g, b);
        }

        public static Rgb ToRgb(Hsl hsl)
        {
            double c = (1 - Math.Abs(2 * hsl.L - 1)) * hsl.S;
            double x = c * (1 - Math.Abs((hsl.H / 60) % 2 - 1));
            double m = hsl.L - c / 2;

            double rPrime, gPrime, bPrime;

            if (hsl.H >= 0 && hsl.H < 60)
            {
                rPrime = c; gPrime = x; bPrime = 0;
            }
            else if (hsl.H >= 60 && hsl.H < 120)
            {
                rPrime = x; gPrime = c; bPrime = 0;
            }
            else if (hsl.H >= 120 && hsl.H < 180)
            {
                rPrime = 0; gPrime = c; bPrime = x;
            }
            else if (hsl.H >= 180 && hsl.H < 240)
            {
                rPrime = 0; gPrime = x; bPrime = c;
            }
            else if (hsl.H >= 240 && hsl.H < 300)
            {
                rPrime = x; gPrime = 0; bPrime = c;
            }
            else
            {
                rPrime = c; gPrime = 0; bPrime = x;
            }

            int r = Clamp((int)((rPrime + m) * 255));
            int g = Clamp((int)((gPrime + m) * 255));
            int b = Clamp((int)((bPrime + m) * 255));

            return new Rgb(r, g, b);
        }

        public static Cmyk ToCmyk(Rgb rgb)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;

            double k = 1 - Math.Max(r, Math.Max(g, b));
            double c = (1 - r - k) / (1 - k);
            double m = (1 - g - k) / (1 - k);
            double y = (1 - b - k) / (1 - k);

            return new Cmyk(
                Clamp(c, 0, 1),
                Clamp(m, 0, 1),
                Clamp(y, 0, 1),
                Clamp(k, 0, 1)
            );
        }

        public static Hsv ToHsv(Rgb rgb)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double h = 0;
            if (delta > 0)
            {
                if (max == r) h = 60 * (((g - b) / delta) % 6);
                else if (max == g) h = 60 * (((b - r) / delta) + 2);
                else h = 60 * (((r - g) / delta) + 4);
            }

            if (h < 0) h += 360;

            double s = max == 0 ? 0 : delta / max;
            double v = max;

            return new Hsv(h, s, v);
        }

        public static Hsl ToHsl(Rgb rgb)
        {
            double r = rgb.R / 255.0;
            double g = rgb.G / 255.0;
            double b = rgb.B / 255.0;

            double max = Math.Max(r, Math.Max(g, b));
            double min = Math.Min(r, Math.Min(g, b));
            double delta = max - min;

            double h = 0;
            if (delta > 0)
            {
                if (max == r) h = 60 * (((g - b) / delta) % 6);
                else if (max == g) h = 60 * (((b - r) / delta) + 2);
                else h = 60 * (((r - g) / delta) + 4);
            }

            if (h < 0) h += 360;

            double l = (max + min) / 2;
            double s = delta == 0 ? 0 : delta / (1 - Math.Abs(2 * l - 1));

            return new Hsl(h, s, l);
        }

        public static Ycbcr ToYcbcr(Rgb rgb)
        {
            double y = 0.299 * rgb.R + 0.587 * rgb.G + 0.114 * rgb.B;
            double cb = 128 + (-0.168736 * rgb.R - 0.331264 * rgb.G + 0.5 * rgb.B);
            double cr = 128 + (0.5 * rgb.R - 0.418688 * rgb.G - 0.081312 * rgb.B);

            return new Ycbcr(y, cb, cr);
        }
    }
}
