using System;
using System.Drawing;
using System.Text;

namespace pic_encrypter
{
    class Encrypter
    {
        static void ConvertToPic(string text)
        {
            string binary_text = "";
            foreach (char c in text)
            {
                string binary_char = Convert.ToString(c, 2).PadLeft(8, '0');
                binary_text += binary_char;
            }

            int image_width = binary_text.Length / 3 + 1;
            int image_height = 3;

            Bitmap image = new Bitmap(image_width, image_height);

            for (int y = 0; y < image_height; y++)
            {
                for (int x = 0; x < image_width; x++)
                {
                    Color color;
                    if (binary_text.Length > 0)
                    {
                        int bit = int.Parse(binary_text.Substring(0, 1));
                        binary_text = binary_text.Remove(0, 1);
                        if (bit == 1)
                        {
                            color = Color.FromArgb(new Random().Next(256), new Random().Next(256), new Random().Next(256));
                        }
                        else
                        {
                            color = Color.FromArgb(255, 255, 255);
                        }
                    }
                    else
                    {
                        color = Color.FromArgb(255, 255, 255);
                    }
                    image.SetPixel(x, y, color);
                }
            }

            image.Save("text_image.png", System.Drawing.Imaging.ImageFormat.Png);
        }
    }
}
