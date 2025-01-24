namespace ChromaSharp.Utils
{
    public static class Utils
    {
        public static int Clamp(int value)
        {
            return Math.Max(0, Math.Min(255, value));
        }
    }
}
