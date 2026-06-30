using Aspose.Drawing;
using _ImgProcessingBL;
using Xunit.Abstractions;

namespace ImgProcessingBL.Test
{
    public class ImgFiltersTest
    {
        private readonly ITestOutputHelper _testOutputHelper;

        public ImgFiltersTest(ITestOutputHelper testOutputHelper)
        {
            _testOutputHelper = testOutputHelper;
        }

        [Fact]
        public void GetPixels_ReturnCorrectColor()
        {
            // Arrange
            var image = new Bitmap(2, 2);
            image.SetPixel(0, 0, Color.Gray);
            image.SetPixel(0, 1, Color.Lime);

            // Acts
            byte[] result = {0x80, 0x80, 0x80, 0x00, 0xFF, 0x00, 0x00, 0x00, 0x00, 0x00,0x00, 0x00};
            byte[] pixelArray = ImgFilters.GetPixels(image);
            _testOutputHelper.WriteLine(ImgFilters.GetPixels(image).ToString());
            // Assertbyte[] result = {0x80, 0x80, 0x80, 0x00, 0xFF, 0x00, 0x00, 0x00, 0
            Assert.Equal(pixelArray, result);
        }
        [Fact]
        public void GetBitmap_ReturnCorrectBitmap()
        {
            var expectedImage = new Bitmap(2, 2);
            for (int y = 0; y < 2; y++)
            {
                for (int x = 0; x < 2; x++)
                {
                    expectedImage.SetPixel(x, y, Color.FromArgb(255, 0, 0, 0)); 
                }
            }
            
            expectedImage.SetPixel(0, 0, Color.FromArgb(255, 128, 128, 128));
            
            byte[] result = [128, 128, 128,  0,   0,   0,   0,   0,   0,   0,   0,   0];
    
            
            var actualBitmap = ImgFilters.GetBitmap(result, 2, 2);
    
            
            Assert.Equal(expectedImage.Width, actualBitmap.Width);
            Assert.Equal(expectedImage.Height, actualBitmap.Height);
    
           
            for (int y = 0; y < expectedImage.Height; y++)
            {
                for (int x = 0; x < expectedImage.Width; x++)
                {
                    int expectedToArgb = expectedImage.GetPixel(x, y).ToArgb();
                    int actualToArgb = actualBitmap.GetPixel(x, y).ToArgb();
            
                    Assert.Equal(expectedToArgb, actualToArgb);
                }
            }
        }
        
        [Fact]
        public void ConvertToGray_ReturnCorrectBitmap()
        {
            byte[] inputPixels = [0xFF, 0x00, 0x00,  0,   0,   0,   0,   0,   0,   0,   0,   0];
    
        
            byte[] actualPixels = ImgFilters.GetConvertToGray(inputPixels);
    
          
            byte[] expectedPixels = [76, 76, 76,  0,   0,   0,   0,   0,   0,   0,   0,   0];
   
            Assert.Equal(expectedPixels, actualPixels);
        }

    }
}