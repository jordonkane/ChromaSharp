using ChromaSharp.Utils;

namespace ChromaSharp.Converters
{
    public static class YcbcrToRgbConverter
    {
        public static (int R, int G, int B) Convert(double Y, double Cb, double Cr)
        {
            int R = Utils.Clamp((int)(Y + 1.402 * (Cr - 128)));
            int G = Utils.Clamp((int)(Y - 0.344136 * (Cb - 128) - 0.714136 * (Cr - 128)));
            int B = Utils.Clamp((int)(Y + 1.772 * (Cb - 128)));
            return (R, G, B);
        }
    }
}
