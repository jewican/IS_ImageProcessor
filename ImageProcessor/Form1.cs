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
using ImageProcessorLib;

namespace ImageProcessorActivity
{
    public partial class Form1 : Form
    {
        private Device[] devices = DeviceManager.GetAllDevices();
        private ProcessingMode currentMode;

        public Form1()
        {
            InitializeComponent();
            comboBox1.SelectedIndex = 0;
        }

        private void ProcessImage(object sender, EventArgs e)
        {
            Bitmap b = new Bitmap(pbSrc.Image);

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
                    UpdateOutputPictureBox(ImageProcessor.ProcessBasicCopy(pbSrc.Image));
                    return;
                case ProcessingMode.Greyscale:
                    UpdateOutputPictureBox(ImageProcessor.ProcessGreyscale(pbSrc.Image));
                    return;
                case ProcessingMode.ColorInversion:
                    UpdateOutputPictureBox(ImageProcessor.ProcessColorInversion(pbSrc.Image));
                    return;
                case ProcessingMode.Histogram:
                    UpdateOutputPictureBox(ImageProcessor.ProcessHistogram(pbSrc.Image, chart1));
                    return;
                case ProcessingMode.Sepia:
                    UpdateOutputPictureBox(ImageProcessor.ProcessSepia(pbSrc.Image));
                    return;
                case ProcessingMode.Subtraction:
                    if (rbCamSrc.Checked)
                    {
                        devices[0].Sendmessage();
                        pbSrc.Image = new Bitmap(Clipboard.GetImage(), new Size(360, 360));
                    }
                    UpdateOutputPictureBox(ImageProcessor.ProcessSubtraction(pbFore.Image, pbSrc.Image));
                    return;
                case ProcessingMode.Smoothing:
                    ImageProcessor.ProcessSmoothing(b, 1);
                    break;
                case ProcessingMode.GaussianBlur:
                    ImageProcessor.ProcessGaussianBlur(b, 4);
                    break;
                case ProcessingMode.Sharpen:
                    ImageProcessor.ProcessSharpen(b, 11);
                    break;
                case ProcessingMode.MeanRemoval:
                    ImageProcessor.ProcessMeanRemoval(b, 9);
                    break;
                case ProcessingMode.EmbossLaplascian:
                    ImageProcessor.ProcessEmbossLaplascian(b, 4);
                    break;
                case ProcessingMode.HorizontalAndVertical:
                    ImageProcessor.ProcessHorizontalVertical(b, 4);
                    break;
                case ProcessingMode.AllDirections:
                    ImageProcessor.ProcessAllDirections(b, 8);
                    break;
                case ProcessingMode.Lossy:
                    ImageProcessor.ProcessLossy(b, 4);
                    break;
                case ProcessingMode.Horizontal:
                    ImageProcessor.ProcessHorizontal(b, 2);
                    break;
                case ProcessingMode.Vertical:  
                    ImageProcessor.ProcessVertical(b, 0);
                    break;
                default:
                    MessageBox.Show("No Processing Mode Selected!");
                    break;
            }
            UpdateOutputPictureBox(b);
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
                    break;
                case "Greyscale":
                    currentMode = ProcessingMode.Greyscale;
                    break;
                case "Color Inversion":
                    currentMode = ProcessingMode.ColorInversion;
                    break;
                case "Histogram":
                    currentMode = ProcessingMode.Histogram;
                    chart1.Show();
                    break;
                case "Sepia":
                    currentMode = ProcessingMode.Sepia;
                    break;
                case "Subtraction":
                    currentMode = ProcessingMode.Subtraction;
                    EnableSubtractionInterface();
                    return;
                case "Smoothing":
                    currentMode = ProcessingMode.Smoothing;
                    break;
                case "Gaussian Blur":
                    currentMode = ProcessingMode.GaussianBlur;
                    break;
                case "Sharpen":
                    currentMode = ProcessingMode.Sharpen;
                    break;
                case "Mean Removal":
                    currentMode = ProcessingMode.MeanRemoval;
                    break;
                case "Emboss Laplascian":
                    currentMode = ProcessingMode.EmbossLaplascian;
                    break;
                case "Horizontal and Vertical":
                    currentMode = ProcessingMode.HorizontalAndVertical;
                    break;
                case "All Directions":
                    currentMode = ProcessingMode.AllDirections;
                    break;
                case "Lossy":
                    currentMode = ProcessingMode.Lossy;
                    break;
                case "Horizontal":
                    currentMode = ProcessingMode.Horizontal;
                    break;
                case "Vertical":   
                    currentMode = ProcessingMode.Vertical;
                    break;
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

        private void ProcessModeChange(object sender, EventArgs e)
        {
            ComboBox cmb = sender as ComboBox;
            if (cmb.SelectedIndex == 0)
            {
                groupBox1.Show();
                groupBox3.Hide();
            }
            else
            {
                groupBox1.Hide();
                groupBox3.Show();
            }
        }
    }
}

enum ProcessingMode
{
    None,
    BasicCopy,
    Greyscale,
    ColorInversion,
    Histogram,
    Sepia,
    Subtraction,
    Smoothing,
    GaussianBlur,
    Sharpen,
    MeanRemoval,
    EmbossLaplascian,
    HorizontalAndVertical,
    AllDirections,
    Lossy,
    Horizontal,
    Vertical
}
