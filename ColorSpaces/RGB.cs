using ChromaSharp.Utils;

namespace ChromaSharp.ColorSpaces
{
    public class Rgb
    {
        public int R { get; }
        public int G { get; }
        public int B { get; }

        public Rgb(int r, int g, int b)
        {
            R = Utils.Clamp(r, 0, 255);
            G = Utils.Clamp(g, 0, 255);
            B = Utils.Clamp(b, 0, 255);
        }

        public override string ToString() => $"Rgb({R}, {G}, {B})";

        public override bool Equals(object? obj)
        {
            if (obj is not Rgb other) return false;
            return R == other.R && G == other.G && B == other.B;
        }

        public override int GetHashCode() => HashCode.Combine(R, G, B);
    }
}
