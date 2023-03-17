using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace pic_encrypter
{
    class Decrypter
    {
        static void ConvertToText()
        {
            Image Image = Image.FromFile("text_image.png");

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

            string Text = "";
            for (int ByteIndex = 0; ByteIndex < Binary_text.Length; ByteIndex += 8)
            {
                string ByteString = Binary_text.Substring(ByteIndex, 8);
                char Character = (char)Convert.ToInt32(ByteString, 2);
                Text += Character.ToString();
            }

            Console.WriteLine(Text);
        }
    }
}