using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pic_encrypter
{
    internal class DocumentEncrypter: IStrategy
    {
        public void CreatePicture(string Path, string FilePath)
        {
            StringBuilder TextBuilder = new StringBuilder();
            byte[] bytes = Encoding.UTF8.GetBytes(File.ReadAllText(FilePath));
            foreach(byte b in bytes)
            {
                TextBuilder.Append(Convert.ToString(b, 2).PadLeft(8, '0'));
            }

            string BinaryText = TextBuilder.ToString();

            int ImageWidth = BinaryText.Length / 3 + 1;
            int ImageHeight = 3;

            Bitmap Image = new Bitmap(ImageWidth, ImageHeight);

            for (int YCoordinate = 0; YCoordinate < ImageHeight; YCoordinate++)
            {
                for (int XCoordinate = 0; XCoordinate < ImageWidth; XCoordinate++)
                {
                    Color Color;
                    if (BinaryText.Length > 0)
                    {
                        int Bit = int.Parse(BinaryText.Substring(0, 1));
                        BinaryText = BinaryText.Remove(0, 1);
                        if (Bit == 1)
                        {
                            Color = Color.FromArgb(new Random().Next(256), new Random().Next(256), new Random().Next(256));
                        }
                        else
                        {
                            Color = Color.FromArgb(255, 255, 255);
                        }
                    }
                    else
                    {
                        Color = Color.FromArgb(255, 255, 255);
                    }
                    Image.SetPixel(XCoordinate, YCoordinate, Color);
                }
            }

            Image.Save(Path + "\\" + "text_image.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
