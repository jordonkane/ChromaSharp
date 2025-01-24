namespace ChromaSharp.Utils
{
    public static class ColorParser
    {
        private static readonly Dictionary<(ColorSpace, ColorSpace), Func<object, object>> ConversionMap =
            new Dictionary<(ColorSpace, ColorSpace), Func<object, object>>
            {
                // Rgb to others
                { (ColorSpace.Rgb, ColorSpace.Cmyk), input => Rgb.ToCmyk((Rgb)input) },
                { (ColorSpace.Rgb, ColorSpace.Hsv), input => Rgb.ToHsv((Rgb)input) },
                { (ColorSpace.Rgb, ColorSpace.Hsl), input => Rgb.ToHsl((Rgb)input) },
                { (ColorSpace.Rgb, ColorSpace.Ycbcr), input => Rgb.ToYcbcr((Rgb)input) },

                // Others to Rgb
                { (ColorSpace.Cmyk, ColorSpace.Rgb), input => Cmyk.ToRgb((Cmyk)input) },
                { (ColorSpace.Hsv, ColorSpace.Rgb), input => Hsv.ToRgb((Hsv)input) },
                { (ColorSpace.Hsl, ColorSpace.Rgb), input => Hsl.ToRgb((Hsl)input) },
                { (ColorSpace.Ycbcr, ColorSpace.Rgb), input => Ycbcr.ToRgb((Ycbcr)input) },

                // Cross-conversions via Rgb
                { (ColorSpace.Cmyk, ColorSpace.Hsv), input => Rgb.ToHsv(Cmyk.ToRgb((Cmyk)input)) },
                { (ColorSpace.Hsv, ColorSpace.Hsl), input => Rgb.ToHsl(Hsv.ToRgb((Hsv)input)) },
                { (ColorSpace.Hsl, ColorSpace.Ycbcr), input => Rgb.ToYcbcr(Hsl.ToRgb((Hsl)input)) },
                // Add more combinations as needed
            };

        public static object Convert(ColorSpace source, ColorSpace target, object value)
        {
            if (source == target)
                throw new ArgumentException("Source and target color spaces must be different.");

            if (ConversionMap.TryGetValue((source, target), out var converter))
            {
                return converter(value);
            }

            throw new NotSupportedException($"Conversion from {source} to {target} is not supported.");
        }
    }
}