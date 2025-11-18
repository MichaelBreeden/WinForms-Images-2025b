using ImageMagick;
using System;
using System.Drawing;

using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

//using System.Linq;
//using System.Security.Cryptography;
using System.Text;
//using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Net.Mime.MediaTypeNames;

/* 
# This is cloned as WinForms-Images-2025b to make it capable of sizing multiple 
images at a time, mostly to a smaller size to optimize storage when image size 
downloaded from a camera is excessive.

11/14/2025 - Copy of original project - WinForms-Images-2025a.
... This seems to work pretty good...

This is code from CoPilot was to enlarge a single image... hopefully to keep the quality. 
It was an experiment to make larger, high quality images from small ones, for use in videos.
I think this is working just like programming paint.net, but it may have more capability.
You can tweak this to preserve aspect ratio, add drag-and-drop, or batch-resize folders 
of images—whatever suits your workflow. Want to add padding with black bars to avoid 
distortion? 
*/
namespace WinForms_Images_2025a
{

    public partial class Form1 : Form
    {
        private MagickImage loadedImage;
        private List<string> lststrSelectedFiles = new List<string>();
        private StringBuilder sbErrors = new StringBuilder();
        private string sAbout;
        private string sWorkingImagePath;
        private int iDesiredHeight;
        private int iDesiredWidth;
        private int iDesiredPercent;

        public Form1()
        {
            InitializeComponent();
            sAbout = "About and Useage. "
                + "\r\nThis is for resizing a group of images that do not need to be so large."
                + "\r\nIt will convert all selected files to a width, a height, or a percent."
                + "\r\nIt automatically will sharpen and correct the images."
                + "\r\nIf the Rename Checkbox is checked, it will save the smaller file with a sequence number appended to the name, else it will save the file by the same name."
                + "\r\nThis doesn't do any cropping or other fixes, so don't run it on an image you plan to edit."
                + "\r\nIt took about 3 seconds per image."
                + "\r\nThe reduction in size I saw was about 6 to 1. Obviously, that will vary."
                ;

            textBoxMessages.Text = sAbout;

        }

        private void buttonClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void buttonAbout_Click(object sender, EventArgs e)
        {
            textBoxMessages.Text = sAbout;
        }

        private void textBoxByPercent_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the input
            }
        }

        private void textBoxByHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the input
            }
        }

        private void textBoxByWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Allow control keys like Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Block the input
            }
        }
       
        // Now this will be mutliple Images
        private void buttonLoadImage_Click(object sender, EventArgs e)
        {
            //MessageBox.Show("buttonLoadImage_Click().");
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Multiselect = true;
                openFileDialog.Title = "Select Files";
                openFileDialog.Filter = "All Files (*.*)|*.*";

                string strCaution = "This is going to make copies of the files.";
                if(checkBoxRenameFile.Checked == false)
                    strCaution = "This is going to overwrite the files. Be careful that this is what you want.";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Check file type. ... JPG or PNG?
                    // Includes full path
                    lststrSelectedFiles.AddRange(openFileDialog.FileNames);
                    textBoxMessages.Text = "Files to convert:" + lststrSelectedFiles.Count.ToString() + ". " + strCaution;
                    //loadedImage = new MagickImage(openFileDialog.FileName);
                    //pictureBox1.Image = loadedImage.ToBitmap();
                }
            }
        }

        private void buttonResizeImage_Click(object sender, EventArgs e)
        {
            string strError = string.Empty;

            // Move this up above where it is called...... Validate these
            int.TryParse(textBoxByHeight.Text, out iDesiredHeight);
            int.TryParse(textBoxByWidth.Text, out iDesiredWidth);
            int.TryParse(textBoxByPercent.Text, out iDesiredPercent);

            if (iDesiredHeight + iDesiredWidth + iDesiredPercent == 0)
            {
                MessageBox.Show("No New Size Was Entered. Enter it and hit Resize again.", "Error...", MessageBoxButtons.OK, MessageBoxIcon.Error, MessageBoxDefaultButton.Button1);
                return;
            }

            int iCount = 0;
            foreach (var file in lststrSelectedFiles)
            {
                strError = string.Empty;
                iCount++;
                try
                {
                    bool bIsLastImage = false;
                    if (iCount == lststrSelectedFiles.Count)
                    {
                        bIsLastImage = true;
                    }
                    resizeImage(file, bIsLastImage, out strError);
                }
                catch (Exception ex)
                {
                    strError = ex.ToString(); // .Message?
                    sbErrors.Append("At image:" + iCount.ToString() + ". " + strError);
                }
            }
            if (sbErrors.ToString() == String.Empty)
                sbErrors.Append("None.");
            textBoxMessages.Text = "Files converted:" + lststrSelectedFiles.Count.ToString()
                + "\r\n Errors:" + sbErrors.ToString();
                ;

        }
        private void buttonResizeImage_Click_0ld(object sender, EventArgs e)
        {
            if (loadedImage != null)
            {
                //loadedImage.Resize(1920, 1080);
                // OR Instead of enlarging post-conversion, upscale directly in Magick.NET
                // using a high-quality filter:
                loadedImage.FilterType = FilterType.Lanczos;
                loadedImage.Resize(1920, 1080);

                // 3. Enhance with Contrast & Levels - Give the image more depth:
                loadedImage.Contrast(); // apply contrast tweak
                loadedImage.AutoLevel(); // auto-correct brightness and contrast

                // 4. Apply Unsharp Mask - For precise edge enhancement:
                // This sharpens only specific areas (great for keeping noise in check).
                //loadedImage.UnsharpMask(1.0, 1.0, 0.5, 0.05);
                // OR
                //loadedImage.Sharpen();
                // OR
                loadedImage.Sharpen(1.0, 0.5);

                /* Adaptive thresholding is powerful for sharpening contrast and edges, 
                 * but it’s inherently aggressive—especially on natural or detailed 
                 * images—so it's great for bold line art but can make photos look 
                 * like retro 8-bit sprites if overdone.

                The two parameters you added are the width and height of the local area being analyzed. 
                Smaller values cause more aggressive pixelation, while larger values 
                smooth things out by analyzing a wider neighborhood.

                Try using values around 64, 64 or higher... 128:

                Less Destructive Enhancement Techniques:
                Use AutoLevel or AutoGamma instead:
                loadedImage.AutoLevel();
                loadedImage.AutoGamma();

                Try mild UnsharpMask (great for photos):
                loadedImage.UnsharpMask(0.5, 1.0, 0.5, 0.05);

                */
                // If you're dealing with text or line art, applying a mild thresholding
                // effect can clean up edges:
                //loadedImage.AdaptiveThreshold(2, 2);   // (10); // value may vary based on image - pixilated
                //loadedImage.AdaptiveThreshold(10, 10, 0.0);   // pixilated
                //loadedImage.AdaptiveThreshold(64, 64);   //  pixilated
                //loadedImage.AdaptiveThreshold(128, 128);   //   pixilated

#if AVAILABLE_SETTINGS
🧠 Smart Enhancement Techniques
loadedImage.AutoLevel();
loadedImage.AdaptiveThreshold(loadedImage.AutoLevel();  

🔹 Unsharp Masking
Boosts edge contrast without affecting overall brightness
Ideal for landscapes or architectural shots
Example: loadedImage.UnsharpMask(0.5, 1.0, 0.5, 0.05);

🔹 Histogram Equalization
Redistributes brightness levels for better contrast
Great for underexposed or flat images
Magick.NET equivalent: loadedImage.Equalize();

🔹 Noise Reduction
Removes grain or digital artifacts
Use ReduceNoise() or apply a Gaussian blur with care:
loadedImage.GaussianBlur(1.0);

🔹 Color Correction
Adjusts hue, saturation, and brightness
Try:
loadedImage.Modulate(brightness: 100, saturation: 110, hue: 100);

🔹 Gamma Adjustment
Controls midtone brightness without blowing out highlights
Example: loadedImage.GammaCorrect(1.2);
#endif


                using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "JPEG Image|*.jpg";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        loadedImage.Format = MagickFormat.Jpeg;
                        loadedImage.Write(sfd.FileName);
                        MessageBox.Show("Image saved!");
                    }
                }

                pictureBox1.Image = loadedImage.ToBitmap();
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void resizeImage(string strFileName, bool bIsLastImage, out string strError)
        {
            strError = string.Empty;
            uint iStartHeight = 0;
            uint iStartWidth = 0;
            uint iNewHeight = 0;
            uint iNewWidth = 0;
            Double dPercentage = 0;

            loadedImage = new MagickImage(strFileName);
            pictureBox1.Image = loadedImage.ToBitmap();

            if (loadedImage != null)
            {
                //loadedImage.Resize(1920, 1080);
                // OR Instead of enlarging post-conversion, upscale directly in Magick.NET
                // using a high-quality filter:
                loadedImage.FilterType = FilterType.Lanczos;

                // Irrlevnt .. I think...
                iStartHeight = loadedImage.Height;
                iStartWidth = loadedImage.Width;

                if(radioButtonByHeight.Checked == true)
                {
                    dPercentage = (double)iDesiredHeight/iStartHeight;
                }
                else if (radioButtonByWidth.Checked == true)
                {
                    dPercentage = (double)iDesiredWidth/ iStartWidth;
                }
                else if (radioButtonByPercent.Checked == true)
                {
                    dPercentage = (double)iDesiredPercent/100;
                }

                iNewHeight = (uint)Convert.ToInt32(dPercentage * iStartHeight);
                iNewWidth = (uint)Convert.ToInt32(dPercentage * iStartWidth);

                loadedImage.Resize(iNewWidth, iNewHeight);

                // 3. Enhance with Contrast & Levels - Give the image more depth:
                loadedImage.Contrast(); // apply contrast tweak
                loadedImage.AutoLevel(); // auto-correct brightness and contrast

                // 4. Apply Unsharp Mask - For precise edge enhancement:
                // This sharpens only specific areas (great for keeping noise in check).
                //loadedImage.UnsharpMask(1.0, 1.0, 0.5, 0.05);
                // OR
                //loadedImage.Sharpen();
                // OR
                loadedImage.Sharpen(1.0, 0.5);

                /* Adaptive thresholding is powerful for sharpening contrast and edges, 
                 * but it’s inherently aggressive—especially on natural or detailed 
                 * images—so it's great for bold line art but can make photos look 
                 * like retro 8-bit sprites if overdone.

                The two parameters you added are the width and height of the local area being analyzed. 
                Smaller values cause more aggressive pixelation, while larger values 
                smooth things out by analyzing a wider neighborhood.

                Try using values around 64, 64 or higher... 128:

                Less Destructive Enhancement Techniques:
                Use AutoLevel or AutoGamma instead:
                loadedImage.AutoLevel();
                loadedImage.AutoGamma();

                Try mild UnsharpMask (great for photos):
                loadedImage.UnsharpMask(0.5, 1.0, 0.5, 0.05);

                */
                // If you're dealing with text or line art, applying a mild thresholding
                // effect can clean up edges:
                //loadedImage.AdaptiveThreshold(2, 2);   // (10); // value may vary based on image - pixilated
                //loadedImage.AdaptiveThreshold(10, 10, 0.0);   // pixilated
                //loadedImage.AdaptiveThreshold(64, 64);   //  pixilated
                //loadedImage.AdaptiveThreshold(128, 128);   //   pixilated

#if AVAILABLE_SETTINGS
🧠 Smart Enhancement Techniques
loadedImage.AutoLevel();
loadedImage.AdaptiveThreshold(loadedImage.AutoLevel();  

🔹 Unsharp Masking
Boosts edge contrast without affecting overall brightness
Ideal for landscapes or architectural shots
Example: loadedImage.UnsharpMask(0.5, 1.0, 0.5, 0.05);

🔹 Histogram Equalization
Redistributes brightness levels for better contrast
Great for underexposed or flat images
Magick.NET equivalent: loadedImage.Equalize();

🔹 Noise Reduction
Removes grain or digital artifacts
Use ReduceNoise() or apply a Gaussian blur with care:
loadedImage.GaussianBlur(1.0);

🔹 Color Correction
Adjusts hue, saturation, and brightness
Try:
loadedImage.Modulate(brightness: 100, saturation: 110, hue: 100);

🔹 Gamma Adjustment
Controls midtone brightness without blowing out highlights
Example: loadedImage.GammaCorrect(1.2);
#endif

                /* using (SaveFileDialog sfd = new SaveFileDialog())
                {
                    sfd.Filter = "JPEG Image|*.jpg";
                    if (sfd.ShowDialog() == DialogResult.OK)
                    {
                        loadedImage.Format = MagickFormat.Jpeg;
                        loadedImage.Write(sfd.FileName);
                        MessageBox.Show("Image saved!");
                    }
                }*/

                string strNewFileName = strFileName;
                if(checkBoxRenameFile.Checked == true)
                   strNewFileName = GetNextAvailableFilename(strFileName);

                loadedImage.Format = MagickFormat.Jpeg;
                loadedImage.Write(strNewFileName);

                if (bIsLastImage == true)
                {
                    //  700 x 400
                    loadedImage.Resize(700, 400);
                    pictureBox1.Image = loadedImage.ToBitmap();
                }
            }
        }


        public static string GetNextAvailableFilename(string path)
        {
            if (!File.Exists(path))
                return path;

            string directory = Path.GetDirectoryName(path);
            string filename = Path.GetFileNameWithoutExtension(path);
            string extension = Path.GetExtension(path);

            int count = 1;
            string newPath;
            do
            {
                string newFileName = $"{filename} ({count}){extension}";
                newPath = Path.Combine(directory, newFileName);
                count++;
            } while (File.Exists(newPath));

            return newPath;
        }
    } // End partial class Form1

    public static class MagickImageExtensions
    {
        public static Bitmap ToBitmap(this MagickImage image)
        {
            using (var memStream = new MemoryStream())
            {
                image.Format = MagickFormat.Bmp; // Save as Bitmap format
                image.Write(memStream);
                memStream.Position = 0;
                return new Bitmap(memStream);
            }
        }
    }
}
