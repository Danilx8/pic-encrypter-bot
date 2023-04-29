using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.Text;

namespace pic_encrypter
{
    class Decrypter
    {
        public static void ConvertToText(string Path)
        {
            Image Image = Image.FromFile(Path + "\\" + "text_image.png");

            Bitmap Bitmap = new Bitmap(Image);
            Color Color;

            string Binary_text = "";
            for (int YCoordinate = 0; YCoordinate < Bitmap.Height; YCoordinate++)
            {
                for (int XCoordinate = 0; XCoordinate < Bitmap.Width; XCoordinate++)
                {
                    Color = Bitmap.GetPixel(XCoordinate, YCoordinate);
                    if (Color.R == 255 && Color.G == 255 && Color.B == 255)
                    {
                        Binary_text += "0";
                    }
                    else
                    {
                        Binary_text += "1";
                    }
                }
            }

            byte[] bytes = new byte[Binary_text.Length / 8];
            for (int i = 0; i < Binary_text.Length; i += 8)
            {
                string byteString = Binary_text.Substring(i, 8);
                bytes[i / 8] = Convert.ToByte(byteString, 2);
            }

            string Text = Encoding.UTF8.GetString(bytes);

            Console.WriteLine(Text);
        }
    }
}
