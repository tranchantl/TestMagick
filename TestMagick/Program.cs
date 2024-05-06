using ImageMagick;

var MediumSmallSize = 400;

var path = @"..\..\..\Images\base_image.png";
var inputFile = File.Open(path, FileMode.Open, FileAccess.Read);

var stream = new MemoryStream();
var _magickImage = new MagickImage();
_magickImage.Read(inputFile);

var mediumSmall = _magickImage.Clone();
mediumSmall.Format = MagickFormat.WebP;
mediumSmall.Resize(MediumSmallSize, 0);
mediumSmall.Write(stream);

inputFile.Position = 0;

var streamQuality = new MemoryStream();
var _magickImageQuality = new MagickImage();
_magickImageQuality.Quality = 100;
_magickImageQuality.Read(inputFile);

var mediumSmallQuality = _magickImageQuality.Clone();
mediumSmallQuality.Format = MagickFormat.WebP;
mediumSmallQuality.Resize(MediumSmallSize, 0);
mediumSmallQuality.Write(streamQuality);

using (var fileStream = File.Create(@"..\..\..\Images\medium.webp"))
{
    stream.Position = 0;
    stream.CopyTo(fileStream);
}

using (var fileStream = File.Create(@"..\..\..\Images\medium-quality.webp"))
{
    streamQuality.Position = 0;
    streamQuality.CopyTo(fileStream);
}