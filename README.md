# ChromaSharp
ChromaSharp is a lightweight and efficient C# library for converting between various color spaces, including RGB, YCbCr, HSL, HSV, and CMYK. Designed for simplicity, precision, and easy integration, it serves as a robust foundation for image processing, graphics rendering, and other color manipulation tasks.

## How it Works
#### The color spaces being converted:
![10_](https://github.com/user-attachments/assets/9034a350-47dc-4906-bc84-4ed2c3d882f4)

## Requirements
1. `.NET 7.0`
2. `NUnit` v3.13.3
3. `NUnit3TestAdapter` v4.6.0
4. `NUnit.Analyzers` v4.6.0
5. `coverlet.collector` v6.0.2

## Installation

### Example for C#:
1. Clone the repository
``` git clone https://github.com/jordonkane/ChromaSharp.git ```
2. Add ChromaSharp to your .NET project.
3. Import `ChromaSharp.Utils` and `ChromaSharp.ColorSpaces`.
4. Use the `ColorUtils` class for your desired color space conversions.

### Example Usage
```markdown
using ChromaSharp.Utils;
using ChromaSharp.ColorSpaces;

var rgb = new Rgb(100, 150, 200);
var ycbcr = ColorUtils.ToYcbcr(rgb);
Console.WriteLine($"YCbCr: ({ycbcr.Y}, {ycbcr.Cb}, {ycbcr.Cr})");
```

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
