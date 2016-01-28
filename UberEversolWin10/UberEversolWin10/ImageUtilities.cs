using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.UI.Xaml.Media.Imaging;
using Windows.Storage.Streams;
using Windows.Storage;
using System.IO;
using Windows.Graphics.Imaging;

namespace UberEversol
{
    class ImageUtilities
    {

        private WriteableBitmap wrBMImage;

        /// <summary>
        /// Changes image to string
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public string ImageToBase64(BitmapImage image)
        {
            //string result;
            
            //byte[] imagebytes = ConvertToBytes(image);      // Convert BitmapImage to byte array
            //result = Convert.ToBase64String(imagebytes);    // Convert to base64 string

            return null;
        }

        /// <summary>
        /// Converts image to string
        /// </summary>
        /// <param name="bitmapImage"></param>
        /// <returns></returns>
        private async void ConvertToBytes(StorageFile file)
        {
            //byte[] data = null;
            //using (MemoryStream stream = new MemoryStream())
            //{
            //    WriteableBitmap wBitmap = new WriteableBitmap(bitmapImage);
            //    wBitmap.SaveJpeg(stream, wBitmap.PixelWidth, wBitmap.PixelHeight, 0, 100);
            //    stream.Seek(0, SeekOrigin.Begin);
            //    data = stream.GetBuffer();
            //}






            // Ensure a file was selected
            //if (file != null)
            //{
            //    using (IRandomAccessStream fileStream = await file.OpenAsync(Windows.Storage.FileAccessMode.Read))
            //    {
            //        BitmapDecoder decoder = await BitmapDecoder.CreateAsync(fileStream);

            //        // Scale image to appropriate size
            //        BitmapTransform transform = new BitmapTransform()
            //        {
            //            ScaledWidth = Convert.ToUInt32(200),
            //            ScaledHeight = Convert.ToUInt32(200)
            //        };

            //        PixelDataProvider pixelData = await decoder.GetPixelDataAsync(
            //                   BitmapPixelFormat.Bgra8,    // WriteableBitmap uses BGRA format
            //                   BitmapAlphaMode.Straight,
            //                   transform,
            //                   ExifOrientationMode.IgnoreExifOrientation, // This sample ignores Exif orientation
            //                   ColorManagementMode.DoNotColorManage);

            //        // An array containing the decoded image data, which could be modified before being displayed
            //        byte[] sourcePixels = pixelData.DetachPixelData();

            //        // Open a stream to copy the image contents to the WriteableBitmap's pixel buffer
            //        using (Stream stream = wrBMImage.PixelBuffer.AsStream())
            //        {
            //            await stream.WriteAsync(sourcePixels, 0, sourcePixels.Length);
            //        }
            //    }

            //    // Redraw the WriteableBitmap
            //    //Scenario4WriteableBitmap.Invalidate();
            //}

        }
    }
}
