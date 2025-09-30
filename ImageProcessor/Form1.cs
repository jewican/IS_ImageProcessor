using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WebCamLib;

namespace ImageProcessor
{
    public partial class Form1 : Form
    {
        private Device[] devices = DeviceManager.GetAllDevices();
        private ProcessingMode currentMode;

        public Form1()
        {
            InitializeComponent();
        }

        private void ProcessImage(object sender, EventArgs e)
        {
            if (rbCamSrc.Checked)
            {
                devices[0].Sendmessage();
                pbSrc.Image = new Bitmap(Clipboard.GetImage(), new Size(360, 360));
            } 

            if (pbSrc.Image == null)
            {
                MessageBox.Show("No Source Image Defined!");
                return;
            }

            switch (currentMode)
            {
                case ProcessingMode.BasicCopy:
                    UpdateOutputPictureBox(ProcessBasicCopy(pbSrc.Image));
                    break;
                case ProcessingMode.Greyscale:
                    UpdateOutputPictureBox(ProcessGreyscale(pbSrc.Image));
                    break;
                case ProcessingMode.ColorInversion:
                    UpdateOutputPictureBox(ProcessColorInversion(pbSrc.Image));
                    break;
                case ProcessingMode.Histogram:
                    UpdateOutputPictureBox(ProcessHistogram(pbSrc.Image));
                    break;
                case ProcessingMode.Sepia:
                    UpdateOutputPictureBox(ProcessSepia(pbSrc.Image));
                    break;
                case ProcessingMode.Subtraction:
                    UpdateOutputPictureBox(ProcessSubtraction());
                    break;
            }
        }

        private Bitmap ProcessBasicCopy(Image img)
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

        private Bitmap ProcessGreyscale(Image img)
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

        private Bitmap ProcessColorInversion(Image img)
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

        private Image ProcessHistogram(Image img)
        {
            Bitmap greyscale = ProcessGreyscale(img);
            int[] histogram = new int[256];

            for (int i = 0; i < greyscale.Width; i++)
            {
                for(int j = 0; j < greyscale.Height; j++)
                {
                    histogram[greyscale.GetPixel(i, j).R]++;
                }
            }

            // make histogram
            chart1.Series[0].Points.DataBind(histogram, "", "", "");
            chart1.Update();

            return null;
        }

        private Image ProcessSepia(Image img)
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

        private Bitmap ProcessSubtraction()
        {
            if (rbCamSrc.Checked)
            {
                devices[0].Sendmessage();
                pbSrc.Image = new Bitmap(Clipboard.GetImage(), new Size(360, 360));
            }

            if (pbSrc.Image == null || pbFore.Image == null)
            {
                MessageBox.Show("No Source or Foreground Image Defined!");
                return null;
            }

            Bitmap imageB = pbFore.Image as Bitmap;
            Bitmap imageA = pbSrc.Image as Bitmap;

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

        private void UpdateSourcePictureBox(Image img)
        {
            if (img == null) return;
            pbSrc.Image = img;
            pbSrc.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void UpdateOutputPictureBox(Image img)
        {
            if (img == null) return;
            pbOut.Image = img;
            pbOut.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private Image GetImageFromFile()
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
            if (ofd.ShowDialog() == DialogResult.OK)
            {
                return new Bitmap(Image.FromFile(ofd.FileName), new Size(360, 360));
            }
            return null;
        }

        private void EnableCamera(PictureBox box)
        {
            devices[0].ShowWindow(box);
        }

        private void DisableCamera()
        {
            devices[0].Stop();
        }

        private void ChangeSourceImage(object sender, EventArgs e)
        {
            if (rbImgSrc.Checked)
            {
                DisableCamera();
                UpdateSourcePictureBox(GetImageFromFile());
            }
            else
            {
                EnableCamera(pbSrc);
            }

            //ProcessImage(sender, e);
        }

        private void ExportProcessedImage(object sender, EventArgs e)
        {
            if (pbOut.Image == null)
            {
                MessageBox.Show("No Processed Image to Save!");
                return;
            }
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PNG Image|*.png|JPEG Image|*.jpg;*.jpeg|Bitmap Image|*.bmp|GIF Image|*.gif";
            sfd.Title = "Save Processed Image";
            sfd.FileName = "processed_image";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                string ext = System.IO.Path.GetExtension(sfd.FileName).ToLower();
                System.Drawing.Imaging.ImageFormat format = System.Drawing.Imaging.ImageFormat.Png;
                switch (ext)
                {
                    case ".jpg":
                    case ".jpeg":
                        format = System.Drawing.Imaging.ImageFormat.Jpeg;
                        break;
                    case ".bmp":
                        format = System.Drawing.Imaging.ImageFormat.Bmp;
                        break;
                    case ".gif":
                        format = System.Drawing.Imaging.ImageFormat.Gif;
                        break;
                }
                pbOut.Image.Save(sfd.FileName, format);
            }
        }

        private void EnableSubtractionInterface() 
        {
            this.Size = new Size(1390, 530);
            this.CenterToScreen();
            // Processing Buttons
            button2.Location = new Point(1026, 424);
            button3.Location = new Point(1184, 425);
            // Foreground PictureBox
            pbFore.Show();
            // Existing PictureBoxes
            pbSrc.Location = new Point(632, 45);
            pbOut.Location = new Point(995, 44);
            // Foreground Source Controls
            button4.Show();
            // Background Source Controls
            groupBox2.Location = new Point(629, 411);
            button1.Location = new Point(881, 425);
            // Labels
            label1.Text = "Foreground";
            label2.Text = "Background";
        }

        private void DisableSubtractionInterface(object sender, EventArgs e)
        {
            this.Size = new Size(1030, 530);
            this.CenterToScreen();
            // Processing Buttons
            button2.Location = new Point(663, 425);
            button3.Location = new Point(821, 426);
            // Foreground PictureBox
            pbFore.Hide();
            pbFore.Image = null;
            // Existing PictureBoxes
            pbSrc.Location = new Point(266, 45);
            pbOut.Location = new Point(632, 45);
            // Foreground Source Controls
            button4.Hide();
            // Background Source Controls
            groupBox2.Location = new Point(266, 411);
            button1.Location = new Point(516, 425);
            // Labels
            label1.Text = "Source";
            label2.Text = "Output";
        }

        private void ChangeProcessingMode(object sender, EventArgs e)
        {
            pbOut.Image = null;
            chart1.Hide();
            DisableSubtractionInterface(sender, e);
            switch (((RadioButton)sender).Text)
            {
                case "Basic Copy":
                    currentMode = ProcessingMode.BasicCopy;
                    radioButton1.Checked = true;
                    break;
                case "Greyscale":
                    currentMode = ProcessingMode.Greyscale;
                    radioButton2.Checked = true;
                    break;
                case "Color Inversion":
                    currentMode = ProcessingMode.ColorInversion;
                    radioButton3.Checked = true;
                    break;
                case "Histogram":
                    currentMode = ProcessingMode.Histogram;
                    radioButton4.Checked = true;
                    chart1.Show();
                    break;
                case "Sepia":
                    currentMode = ProcessingMode.Sepia;
                    radioButton5.Checked = true;
                    break;
                case "Subtraction":
                    currentMode = ProcessingMode.Subtraction;
                    EnableSubtractionInterface();
                    return;
            }
            //ProcessImage(sender, e);
        }

        private void ChangeForegroundImage(object sender, EventArgs e)
        {
            pbFore.Image = GetImageFromFile();
        }

        private void ImgSrcBtn_Checked(object sender, EventArgs e)
        {
            pbSrc.Image = null;
            DisableCamera();
            button1.Text = "Load Image";
        }

        private void CamSrcBtn_Checked(object sender, EventArgs e)
        {
            button1.Text = "Select Camera";
        }
    }
}

enum ProcessingMode
{
    BasicCopy,
    Greyscale,
    ColorInversion,
    Histogram,
    Sepia,
    Subtraction
}
