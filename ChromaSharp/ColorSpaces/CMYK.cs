using ChromaSharp.Utils;

namespace ChromaSharp.ColorSpaces
{
    public class Cmyk
    {
        public double C { get; }
        public double M { get; }
        public double Y { get; }
        public double K { get; }

        public Cmyk(double c, double m, double y, double k)
        {
            C = ChromaSharp.Utils.Utils.Clamp(c, 0.0, 1.0);
            M = ChromaSharp.Utils.Utils.Clamp(m, 0.0, 1.0);
            Y = ChromaSharp.Utils.Utils.Clamp(y, 0.0, 1.0);
            K = ChromaSharp.Utils.Utils.Clamp(k, 0.0, 1.0);
        }

        public override string ToString() => $"Cmyk({C:F2}, {M:F2}, {Y:F2}, {K:F2})";

        public override bool Equals(object? obj)
        {
            if (obj is not Cmyk other) return false;
            return C == other.C && M == other.M && Y == other.Y && K == other.K;
        }

        public override int GetHashCode() => HashCode.Combine(C, M, Y, K);
    }
}
