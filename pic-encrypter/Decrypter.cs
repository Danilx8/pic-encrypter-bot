using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Text;

namespace pic_encrypter
{
    class Decrypter
    {
        public static void ConvertToText(string PicturePath)
        {
            Image Image = Image.FromFile(PicturePath);

            Bitmap Bitmap = new Bitmap(Image);
            Color Color;

            StringBuilder TextBuilder = new StringBuilder();
            for (int YCoordinate = 0; YCoordinate < Bitmap.Height; YCoordinate++)
            {
                for (int XCoordinate = 0; XCoordinate < Bitmap.Width; XCoordinate++)
                {
                    Color = Bitmap.GetPixel(XCoordinate, YCoordinate);
                    if (Color.R == 255 && Color.G == 255 && Color.B == 255)
                    {
                        TextBuilder.Append("0");
                    }
                    else
                    {
                        TextBuilder.Append("1");
                    }
                }
            }

            string BinaryText = TextBuilder.ToString();

            byte[] bytes = new byte[(BinaryText.Length + 7) / 8];
            for (int i = 0; i < bytes.Length; ++i)
            {
                string byteString = BinaryText.Substring(i * 8, Math.Min(8, BinaryText.Length - i * 8));
                bytes[i] = Convert.ToByte(byteString, 2);
            }


            string Text = Encoding.UTF8.GetString(bytes);

            string TextFilePath = Path.GetDirectoryName(PicturePath) + "\\" + Path.GetFileNameWithoutExtension(PicturePath)
                + ".txt";

            using (StreamWriter Writer = File.CreateText(TextFilePath))
            {
                Writer.WriteLine(Text);
            }

            Console.WriteLine("File created: " + TextFilePath + "\n" + Text);
        }
    }
}
