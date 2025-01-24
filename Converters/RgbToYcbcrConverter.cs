namespace ChromaSharp.Converters
{
    public static class RgbToYcbcrConverter
    {
        public static (double Y, double Cb, double Cr) Convert(int R, int G, int B)
        {
            double Y = 0.299 * R + 0.587 * G + 0.114 * B;
            double Cb = 128 + (-0.169 * R - 0.331 * G + 0.5 * B);
            double Cr = 128 + (0.5 * R - 0.419 * G - 0.081 * B);
            return (Y, Cb, Cr);
        }
    }
}
