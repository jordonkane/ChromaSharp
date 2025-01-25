# ChromaSharp - .NET Color Space Conversion Library
ChromaSharp is a lightweight and efficient C# library for converting between various color spaces, including RGB, YCbCr, HSL, HSV, and CMYK. Designed for simplicity, precision, and easy integration, it serves as a robust foundation for image processing, graphics rendering, and other color manipulation tasks.

## How it Works
With ChromaSharp, you can seamlessly convert colors between multiple color spaces. Here's an example of converting an RGB color to CMYK and then to HSV.
#### Color Space Representation:
![10_](https://github.com/user-attachments/assets/9034a350-47dc-4906-bc84-4ed2c3d882f4)
#### Library Usage Example:
```csharp
using ChromaSharp.Utils;
using ChromaSharp.ColorSpaces;

// Step 1: Define an RGB color
var rgb = new Rgb(128, 64, 32);

// Step 2: Convert RGB to CMYK
var cmyk = ColorUtils.ToCmyk(rgb);
Console.WriteLine($"CMYK: (C: {cmyk.C:F2}, M: {cmyk.M:F2}, Y: {cmyk.Y:F2}, K: {cmyk.K:F2})");

// Step 3: Convert RGB to HSV
var hsv = ColorUtils.ToHsv(rgb);
Console.WriteLine($"HSV: (H: {hsv.H:F2}, S: {hsv.S:F2}, V: {hsv.V:F2})");
```

## Requirements
1. `.NET 7.0`
2. `NUnit` v3.13.3
3. `NUnit3TestAdapter` v4.6.0
4. `NUnit.Analyzers` v4.6.0
5. `coverlet.collector` v6.0.2

## Installation
1. Clone the repository
```
git clone https://github.com/jordonkane/ChromaSharp.git
```
3. Add ChromaSharp to your .NET project.
4. Import `ChromaSharp.Utils` and `ChromaSharp.ColorSpaces`.
5. Use the `ColorUtils` class for your desired color space conversions.

## How to Contribute
If you would like to contribute to ChromaSharp, feel free to fork the repository and submit a pull request. Contributions for new features like new color conversion types are welcome!
1. Fork the repository.
2. Create a feature branch.
3. Push your changes.
4. Submit a pull request.

## License
This project is licensed under the MIT License. See the LICENSE file for details.

## Credits
Developed by Jordon Kane
