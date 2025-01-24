using ChromaSharp.Utils;

namespace ChromaSharp.ColorSpaces
{
    public class Ycbcr
    {
        public double Y { get; }
        public double Cb { get; }
        public double Cr { get; }

        public Ycbcr(double y, double cb, double cr)
        {
            Y = ChromaSharp.Utils.Utils.Clamp(y, 0.0, 255.0);
            Cb = ChromaSharp.Utils.Utils.Clamp(cb, 0.0, 255.0);
            Cr = ChromaSharp.Utils.Utils.Clamp(cr, 0.0, 255.0);
        }

        public override string ToString() => $"Ycbcr({Y:F2}, {Cb:F2}, {Cr:F2})";

        public override bool Equals(object? obj)
        {
            if (obj is not Ycbcr other) return false;
            return Y == other.Y && Cb == other.Cb && Cr == other.Cr;
        }

        public override int GetHashCode() => HashCode.Combine(Y, Cb, Cr);
    }
}
