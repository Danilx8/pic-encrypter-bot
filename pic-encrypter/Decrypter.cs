using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace pic_encrypter
{
    class Decrypter
    {
        static void ConvertToText()
        {
            Image image = Image.FromFile("text_image.png");

            Bitmap bitmap = new Bitmap(image);
            Color color;

            string binary_text = "";
            for (int y = 0; y < bitmap.Height; y++)
            {
                for (int x = 0; x < bitmap.Width; x++)
                {
                    color = bitmap.GetPixel(x, y);
                    if (color.R == 255 && color.G == 255 && color.B == 255)
                    {
                        binary_text += "0";
                    }
                    else
                    {
                        binary_text += "1";
                    }
                }
            }

            string text = "";
            for (int i = 0; i < binary_text.Length; i += 8)
            {
                string byteStr = binary_text.Substring(i, 8);
                char c = (char)Convert.ToInt32(byteStr, 2);
                text += c.ToString();
            }

            Console.WriteLine(text);
        }
    }
}