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

        public async Task<byte[]> ConvertToBytes(IRandomAccessStream s)
        {
            var dReader = new DataReader(s.GetInputStreamAt(0));
            var bytes = new byte[s.Size];
            await dReader.LoadAsync((uint)s.Size);
            dReader.ReadBytes(bytes);
            return bytes;
        }
    }
}
