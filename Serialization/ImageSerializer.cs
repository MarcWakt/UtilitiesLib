using System.Drawing;
using System.Drawing.Imaging;

namespace UtilitiesLib.Serialization
{
    /// <summary>
    /// For serialization and deserialization of Image files
    /// Only works on Windows 6.1 and later
    /// </summary>
    public static class ImageSerializer
    {
        /// <summary>
        /// Saves image data to Base64 encoding. UNDER DEVELOPMENT
        /// </summary>
        /// <param name="imageToSave">Image file</param>
        /// <param name="format">Image file format, if unknown use ImageSerializer.GetImageFormat(imageToSave) to get</param>
        /// <returns>Base 64 string data of image</returns>
        public static string ImageToBase64(Image imageToSave, ImageFormat format)
        {
            using (MemoryStream ms = new MemoryStream())
            {
                imageToSave.Save(ms, format);
                byte[] data = ms.ToArray();
                return Convert.ToBase64String(data);
            }
        }

        /// <summary>
        /// Get image format
        /// </summary>
        public static ImageFormat GetImageFormat(Image image)
        {
            return new ImageFormat(image.RawFormat.Guid);
        }

        /// <summary>
        /// Saves Base64 data to Image. UNDER DEVELOPMENT
        /// </summary>
        /// <param name="imageData">Image information as supplied by the method ImageToBase64</param>
        /// <returns>Image in format saved by method ImageToBase64</returns>
        public static Image Base64ToImage(string imageData)
        {
            byte[] data = Convert.FromBase64String(imageData);
            using (var ms = new MemoryStream(data, 0, data.Length))
            {
                return Image.FromStream(ms, true);
            }
        }
    }
}
