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

namespace ImageProcessorActivity
{
    public partial class Form2 : Form
    {
        private Device[] devices = DeviceManager.GetAllDevices();
        public object ClosingSender { get; private set; }
        public EventArgs ClosingEventArgs { get; private set; }

        public Form2()
        {
            InitializeComponent();
        }
        private void EnableCamera()
        {
            devices[0].ShowWindow(pbSrc);
        }

        private void DisableCamera()
        {
            devices[0].Stop();
        }

        private void ProcessSubtraction(object sender, EventArgs e)
        {
            if (rbCamSrc.Checked)
            {
                devices[0].Sendmessage();
                pbSrc.Image = new Bitmap(Clipboard.GetImage(), new Size(360, 360));
            }

            if (pbSrc.Image == null || pbFore.Image == null)
            {
                MessageBox.Show("No Source or Foreground Image Defined!");
                return;
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

            pbOut.Image = resultImage;
        }

        private void UpdateSourcePictureBox(Image img)
        {
            if (img == null) return;
            pbSrc.Image = img;
            pbSrc.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void ChangeSourceImage(object sender, EventArgs e)
        {
            if (rbImgSrc.Checked)
            {
                DisableCamera();
                UpdateSourcePictureBox(GetImageFromFile());
            }
            else
            {
                EnableCamera();
            }

        }

        private void ChangeForegroundImage(object sender, EventArgs e)
        {
            pbFore.Image = GetImageFromFile();
        }

        private void DisableSubtractionInterface(object sender, EventArgs e)
        {
            this.ClosingSender = sender;
            this.ClosingEventArgs = e;
            this.DialogResult = DialogResult.OK;
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
