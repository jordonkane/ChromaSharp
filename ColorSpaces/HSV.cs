using ChromaSharp.Utils;

namespace ChromaSharp.ColorSpaces
{
    public class Hsv
    {
        public double H { get; }
        public double S { get; }
        public double V { get; }

        public Hsv(double h, double s, double v)
        {
            H = ChromaSharp.Utils.Utils.Clamp(h, 0.0, 360.0);
            S = ChromaSharp.Utils.Utils.Clamp(s, 0.0, 1.0);
            V = ChromaSharp.Utils.Utils.Clamp(v, 0.0, 1.0);
        }

        public override string ToString() => $"Hsv({H:F2}, {S:F2}, {V:F2})";

        public override bool Equals(object? obj)
        {
            if (obj is not Hsv other) return false;
            return H == other.H && S == other.S && V == other.V;
        }

        public override int GetHashCode() => HashCode.Combine(H, S, V);
    }
}
