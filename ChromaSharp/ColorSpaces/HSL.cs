using ChromaSharp.Utils;

namespace ChromaSharp.ColorSpaces
{
    public class Hsl
    {
        public double H { get; }
        public double S { get; }
        public double L { get; }

        public Hsl(double h, double s, double l)
        {
            H = ChromaSharp.Utils.Utils.Clamp(h, 0.0, 360.0);
            S = ChromaSharp.Utils.Utils.Clamp(s, 0.0, 1.0);
            L = ChromaSharp.Utils.Utils.Clamp(l, 0.0, 1.0);
        }

        public override string ToString() => $"Hsl({H:F2}, {S:F2}, {L:F2})";

        public override bool Equals(object? obj)
        {
            if (obj is not Hsl other) return false;
            return H == other.H && S == other.S && L == other.L;
        }

        public override int GetHashCode() => HashCode.Combine(H, S, L);
    }
}
