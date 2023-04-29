using System;
using System.Drawing;
using System.Text;

namespace pic_encrypter
{
    class MessageEncrypter : IStrategy
    {
        public void CreatePicture(string Path, string Text)
        {
            byte[] bytes = Encoding.UTF8.GetBytes(Text);
            string BinaryText = "";
            foreach (byte b in bytes)
            {
                string BinaryCharacter = Convert.ToString(b, 2).PadLeft(8, '0');
                BinaryText += BinaryCharacter;
            }

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
