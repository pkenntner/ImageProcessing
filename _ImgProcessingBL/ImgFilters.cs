using System.Drawing;

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
    }
}