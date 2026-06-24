using System.Drawing;
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
            // Assert
            Assert.Equal(pixelArray, result);
        }
    }
}