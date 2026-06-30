using Aspose.Drawing;

namespace _ImgProcessingBL
{
    public static class ImgFilters
    {
        public static byte[] GetPixels(Bitmap bitmap)
        {
         
            byte[] pixels = new byte[bitmap.Width * bitmap.Height * 3];
            int index = 0;

            for (int x = 0; x < bitmap.Width; x++)
            {
                for (int y = 0; y < bitmap.Height; y++)
                {
                    Color pixelColor = bitmap.GetPixel(x, y);
                    
                    pixels[index++] = pixelColor.R;
                    pixels[index++] = pixelColor.G;
                    pixels[index++] = pixelColor.B;
                }
            }

            return pixels;
        }

        public static Bitmap GetBitmap(byte[] pixels, int width, int height)
        {
            Bitmap bitmap = new Bitmap(width, height);
            int index = 0;
    
            for (int y = 0; y < height; y++)
            {
                for (int x = 0; x < width; x++)
                {
                    bitmap.SetPixel(x, y, Color.FromArgb(pixels[index++], pixels[index++], pixels[index++]));
                }
            }
            return bitmap;
        }


        public static byte[] GetConvertToGray(byte[] pixels)
        {
            // Step by 3 because each pixel contains 3 bytes (R, G, B)
            for (int i = 0; i < pixels.Length; i += 3)
            {
                byte r = pixels[i];
                byte g = pixels[i + 1];
                byte b = pixels[i + 2];

                // Apply grayscale formula using floating-point math
                byte gray = (byte)(0.299 * r + 0.587 * g + 0.114 * b);

                // Assign the calculated gray value to R, G, and B components
                pixels[i] = gray;
                pixels[i + 1] = gray;
                pixels[i + 2] = gray;
            }
    
            return pixels;
        }

        
        
    }
}