/* Image.cs
 * Author: Merijn Hendriks
 * License: NCSA
 */

using System;
using System.Windows.Media.Imaging;

namespace Automata.Models
{
    public class Image
    {
        public BitmapImage Source { get; private set; }
        public string Filepath { get; private set; }

        public int Width
        {
            get
            {
                return Source.PixelWidth;
            }
        }

        public int Height
        {
            get
            {
                return Source.PixelHeight;
            }
        }

        public Image(string filepath)
        {
            // set metadata
            Filepath = filepath;

            // get image
            Source = new BitmapImage();
            Source.BeginInit();
            Source.UriSource = new Uri(filepath, UriKind.RelativeOrAbsolute);
            Source.EndInit();
        }
    }
}
