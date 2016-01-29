using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Windows.Graphics.Imaging;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;

namespace UberEversol
{
    class ImageTools
    {
        public ImageTools() { }

        /// <summary>
        /// Convert Image to Byte array
        /// </summary>
        /// <param name="s"></param>
        /// <returns></returns>
        public static async Task<byte[]> StreamToBytes(IRandomAccessStream s)
        {
            var dReader = new DataReader(s.GetInputStreamAt(0));
            var bytes = new byte[s.Size];
            await dReader.LoadAsync((uint)s.Size);
            dReader.ReadBytes(bytes);
            return bytes;
        }

        /// <summary>
        /// Convert Byte array to Image
        /// </summary>
        /// <param name="src"></param>
        /// <returns></returns>
        public static async Task<BitmapImage> BytesToImage(byte[] src)
        {
            BitmapImage img = new BitmapImage();

            if (src != null && src.Length != 0)
            {
                using (InMemoryRandomAccessStream ms = new InMemoryRandomAccessStream())
                {
                    using (DataWriter writer = new DataWriter(ms.GetOutputStreamAt(0)))
                    {
                        writer.WriteBytes(src);
                        await writer.StoreAsync();
                    }

                    await img.SetSourceAsync(ms);
                }
            }

            return img;
        }
    }
}
