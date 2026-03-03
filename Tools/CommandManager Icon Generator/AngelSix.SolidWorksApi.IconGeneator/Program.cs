using SkiaSharp;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using Svg.Skia;

namespace AngelSix.SolidWorksApi.IconGeneator
{
    class Program
    {
        private const string s_ScaleImagesModeArgument = "/ScaleImages";
        private const string s_ContactBitmapsModeArgument = "/ContactBitmaps";
        private const string s_FileNamePrepend = "/FileNamePrepend";
        private static readonly List<int> s_possibleSizes = [20, 32, 40, 64, 96, 128];

        /// <summary>
        /// Drag and drop images onto the exe to generate SolidWorks toolbar sprites 
        /// or open by double clicking to interactively select files and an output name
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            // The filename to prepend to the output files
            var filenamePrepend = "icons";

            Console.WriteLine("");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("   AngelSix SolidWorks Icon Generator   ");
            Console.WriteLine("----------------------------------------");
            Console.WriteLine("");

            var paths = args.Select(x => x.Trim('"')).ToList();

            // Extract FileNamePrepend
            if (paths.Contains(s_FileNamePrepend))
            {
                var index = paths.IndexOf(s_FileNamePrepend);
                // Remove argument name
                paths.RemoveAt(index);
                filenamePrepend = paths[index];
                // Remove argument value
                paths.RemoveAt(index);
            }

            _ = paths.Remove(s_ScaleImagesModeArgument);
            _ = paths.Remove(s_ContactBitmapsModeArgument);

            if (args.Contains(s_ScaleImagesModeArgument))
            {
                ScaleImages(paths.ToArray(), filenamePrepend);
                return;
            }
            if (args.Contains(s_ContactBitmapsModeArgument))
            {
                ContactBitmaps(paths.ToArray(), filenamePrepend);
                return;
            }

            // 
            //   NOTE: 
            //
            //   We expect a list of images or path patterns in, and a name to prepend the filename as the last argument
            //
            //   From that we will combine them into lists and resize them 
            //   from the top size down to the smallest size
            //
            Console.WriteLine($"Entering icon generation mode.");
            Console.WriteLine($"Press 1 for ScaleImages mode (High-resolution images to batch of downscaled images)");
            Console.WriteLine($"Press 2 for ContactBitmaps mode (Pack of correctly sized images to batch of same-sized images)");
            var mode = Console.ReadKey().Key;
            Console.WriteLine();
            if (mode == ConsoleKey.D1 || mode == ConsoleKey.NumPad1)
            {
                // All output sizes
                ScaleImages(paths.ToArray(), filenamePrepend);
            }
            else if (mode == ConsoleKey.D2 || mode == ConsoleKey.NumPad2)
            {
                ContactBitmaps(paths.ToArray(), filenamePrepend);
            }
            else
            {
                Console.WriteLine("Unsupported mode selected.");
            }
        }

        private static void ScaleImages(string[] args, string filenamePrepend)
        {

            // Add any command line args
            var images = new List<FileInfo>();
            if (args?.Length > 0)
                images.AddRange(args.Select(x => new FileInfo(x)));

            // If we have no images then simply ask the user to start specifying the image paths
            if (images.Count < 1)
            {
                // Wipe any previous data
                images = [];

                // Start asking user to enter image paths
                var result = " ";
                while (!string.IsNullOrEmpty(result))
                {
                    Console.ResetColor();
                    Console.WriteLine($"Enter the path to the {NthNumber(images.Count + 1)}. Once done press enter");
                    result = Console.ReadLine();

                    // Check if done
                    if (string.IsNullOrEmpty(result))
                        break;

                    // Make sure the file exists
                    if (!File.Exists(result))
                    {
                        // Try and find it with .png to the name
                        if (!result.Contains('.'))
                            result += ".png";

                        // Check if it exists again
                        if (!File.Exists(result))
                        {
                            // Let user know file not found
                            Console.ForegroundColor = ConsoleColor.Red;
                            Console.WriteLine($"Image not found '{result}'");
                        }
                        else
                        {
                            // Add this to the list and carry on
                            images.Add(new(result));
                        }
                    }
                    else
                    {
                        // Add this to the list and carry on
                        images.Add(new(result));
                    }
                }

                filenamePrepend = GetFileNamePrepend();
            }

            if (images.Count == 0)
            {
                Console.WriteLine("Specify at least one image pattern");
                return;
            }

            // Now create an image from each of the images, for each file size
            s_possibleSizes.ForEach(size =>
            {
                // Check all files exist
                if (images.Any(image => !image.Exists))
                {
                    Console.WriteLine("One or more of the files do not exist. Press enter to exit");
                    Console.ReadLine();
                    return;
                }

                // Combine all bitmaps
                using var combinedImage = CombineBitmap(images, size);
                if (combinedImage == null)
                    return;
                combinedImage.Save($"{filenamePrepend}{size}.png");
            });
        }

        private static string GetFileNamePrepend()
        {
            string filenamePrepend;
            // Get filename to append
            Console.ResetColor();
            Console.WriteLine("Enter the name to prepend to the output files");
            filenamePrepend = Console.ReadLine();
            return filenamePrepend;
        }

        class MultiSizeImage
        {
            public FileInfo[] Sizes { get; set; } = [];
        }

        private static void ContactBitmaps(string[] args, string filenamePrepend)
        {
            var images = new List<MultiSizeImage>();

            var patterns = args.Length == 0 ? GetPatternsFromInput() : args;

            foreach (var imagePattern in patterns)
            {
                var files = new List<FileInfo>();
                foreach (var size in s_possibleSizes)
                {
                    var fileName = string.Format(imagePattern, size);

                    if (File.Exists(fileName) == false)
                    {
                        Console.ForegroundColor = ConsoleColor.Red;
                        Console.WriteLine("Image not found");
                        throw new FileNotFoundException();
                    }

                    files.Add(new FileInfo(fileName));
                }
                images.Add(new MultiSizeImage() { Sizes = files.ToArray() });
            }

            if(images.Count == 0)
            {
                Console.WriteLine("Specify at least one pattern");
                return;
            }

            filenamePrepend = GetFileNamePrepend();

            var index = 0;
            foreach (var size in s_possibleSizes)
            {
                var indexedImages = images.Select(x => x.Sizes[index]);

                // Combine all bitmaps
                using (var combinedImage = CombineBitmap(indexedImages.ToList(), size))
                {
                    if (combinedImage == null)
                        return;
                    combinedImage.Save($"{filenamePrepend}{size}.png");
                }
                index++;
            }
        }

        private static IEnumerable<string> GetPatternsFromInput()
        {
            var count = 0;
            foreach (var item in s_possibleSizes)
            {
                Console.WriteLine($"Enter the pattern to the {NthNumber(count + 1)}. Once done press enter");
                while (true)
                {
                    var pattern = Console.ReadLine();

                    if (string.IsNullOrEmpty(pattern))
                        yield break;

                    if (pattern.Contains("{0}") == false)
                    {
                        Console.WriteLine(@"Pattern must contain ""{0}"" placeholder.");
                        continue;
                    }
                    else
                    {
                        yield return pattern;
                        break;
                    }
                }


                count++;
            }
        }

        /// <summary>
        /// Adds the "st", "nd" etc... to a number, such as 1st, 6th, 23rd
        /// </summary>
        /// <param name="number">The number to use</param>
        /// <returns></returns>
        private static string NthNumber(int number)
        {
            // Base10 the number
            number %= 10;

            return number switch
            {
                1 => $"{number}st",
                2 => $"{number}nd",
                3 => $"{number}rd",
                _ => $"{number}th",
            };
        }

        /// <summary>
        /// Combines images into a sprite horizontally
        /// </summary>
        /// <param name="files">The files to combine</param>
        /// <param name="iconSize">The sprite size</param>
        /// <returns></returns>
        private static Bitmap CombineBitmap(List<FileInfo> files, int iconSize)
        {
            // Read all images into memory
            Bitmap? finalImage = null;
            var images = new List<Bitmap>();

            try
            {
                // Get size
                var width = iconSize * files.Count;
                var height = iconSize;

                // Create a bitmap to hold the combined image
                finalImage = new Bitmap(width, height);

                // Get a graphics object from the image so we can draw on it
                using (var g = Graphics.FromImage(finalImage))
                {
                    // Set background color
                    g.Clear(Color.Transparent);

                    // Go through each image and draw it on the final image
                    var offset = 0;
                    files.ForEach(file =>
                    {
                        // Read this image
                        var bitmap = file.Extension.ToLower() == ".svg" ? ConvertSvgToBitmap(file, iconSize) : new Bitmap(file.FullName);
                        images.Add(bitmap);

                        // Scale it to the sprite size
                        var scaleFactor = (float)iconSize / Math.Max(bitmap.Width, bitmap.Height);

                        // Draw it onto the new image
                        g.DrawImage(bitmap, new Rectangle(offset, 0, (int)(scaleFactor * bitmap.Width), (int)(scaleFactor * bitmap.Height)));

                        // Move offset to next position
                        offset += iconSize;

                    });
                }

                // Return the final image
                return finalImage;
            }
            catch (Exception)
            {
                // Cleanup
                finalImage?.Dispose();
                throw;
            }
            finally
            {
                // Cleanup
                images.ForEach(image => image?.Dispose());
            }
        }

        /// <summary>
        /// Converts SVG to bitmap using Svg.Skia (SkiaSharp) for better quality at low resolutions (e.g. 20x20).
        /// Renders at exact size with scale-to-fit and center; no supersampling to avoid blur.
        /// </summary>
        private static Bitmap ConvertSvgToBitmap(FileInfo svgFile, int size)
        {
            using var svg = new SKSvg();
            if (svg.Load(svgFile.FullName) is null || svg.Picture is null)
                throw new InvalidOperationException($"Failed to load SVG: {svgFile.FullName}");

            var picture = svg.Picture;
            var bounds = picture.CullRect;
            var imageInfo = new SKImageInfo(size, size, SKColorType.Rgba8888, SKAlphaType.Premul);
            using var surface = SKSurface.Create(imageInfo);
            var canvas = surface.Canvas;
            canvas.Clear(SKColors.Transparent);

            var scale = Math.Min((float)size / bounds.Width, (float)size / bounds.Height);
            var dx = (size - (bounds.Width * scale)) / 2f;
            var dy = (size - (bounds.Height * scale)) / 2f;
            canvas.Scale(scale);
            canvas.Translate(dx / scale, dy / scale);
            canvas.DrawPicture(picture);

            using var image = surface.Snapshot();
            using var data = image.Encode(SKEncodedImageFormat.Png, 100);
            using var stream = new MemoryStream();
            data.SaveTo(stream);
            stream.Position = 0;
            return new Bitmap(stream);
        }
    }
}
