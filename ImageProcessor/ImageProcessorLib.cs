using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace ImageProcessorLib
{
    class ImageProcessor
    {
        public static Bitmap ProcessBasicCopy(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Bitmap src = img as Bitmap;
            Color color;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    color = src.GetPixel(i, j);
                    bmp.SetPixel(i, j, color);
                }
            }

            return bmp;
        }

        public static Bitmap ProcessGreyscale(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Bitmap src = img as Bitmap;
            byte avg;
            Color color;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    color = src.GetPixel(i, j);
                    avg = (byte)((color.R + color.G + color.B) / 3);
                    bmp.SetPixel(i, j, Color.FromArgb(color.A, avg, avg, avg));
                }
            }

            return bmp;
        }

        public static Bitmap ProcessColorInversion(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Bitmap src = img as Bitmap;
            byte r, g, b;
            Color color;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    color = src.GetPixel(i, j);
                    r = (byte)(255 - color.R);
                    g = (byte)(255 - color.G);
                    b = (byte)(255 - color.B);
                    bmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            return bmp;
        }

        public static Image ProcessHistogram(Image img, Chart chart1)
        {
            Bitmap greyscale = ProcessGreyscale(img);
            int[] histogram = new int[256];

            for (int i = 0; i < greyscale.Width; i++)
            {
                for (int j = 0; j < greyscale.Height; j++)
                {
                    histogram[greyscale.GetPixel(i, j).R]++;
                }
            }

            // make histogram
            chart1.Series[0].Points.DataBind(histogram, "", "", "");
            chart1.Update();

            return null;
        }

        public static Image ProcessSepia(Image img)
        {
            Bitmap bmp = new Bitmap(img.Width, img.Height);
            Bitmap src = img as Bitmap;
            byte r, g, b;
            Color color;
            for (int i = 0; i < img.Width; i++)
            {
                for (int j = 0; j < img.Height; j++)
                {
                    color = src.GetPixel(i, j);
                    r = (byte)Math.Min((0.393 * color.R + 0.769 * color.G + 0.189 * color.B), 255);
                    g = (byte)Math.Min((0.349 * color.R + 0.686 * color.G + 0.168 * color.B), 255);
                    b = (byte)Math.Min((0.272 * color.R + 0.534 * color.G + 0.131 * color.B), 255);
                    bmp.SetPixel(i, j, Color.FromArgb(r, g, b));
                }
            }

            return bmp;
        }

        public static Bitmap ProcessSubtraction(Image B, Image A)
        {
            Bitmap imageB = B as Bitmap;
            Bitmap imageA = A as Bitmap;
            Bitmap resultImage = new Bitmap(imageA.Width, imageA.Height);

            Color mygreen = Color.FromArgb(0, 255, 0);
            int greygreen = (mygreen.R + mygreen.G + mygreen.B) / 3;
            int threshold = 5;

            for (int i = 0; i < imageB.Width; i++)
            {
                for (int j = 0; j < imageB.Height; j++)
                {
                    Color pixel = imageB.GetPixel(i, j);
                    Color backpixel = imageA.GetPixel(i, j);
                    int grey = (pixel.R + pixel.G + pixel.B) / 3;
                    int subtractvalue = Math.Abs(grey - greygreen);
                    if (subtractvalue > threshold)
                    {
                        resultImage.SetPixel(i, j, pixel);
                    }
                    else
                    {
                        resultImage.SetPixel(i, j, backpixel);
                    }
                }
            }

            return resultImage;
        }
    }
}
