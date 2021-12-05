using System;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading;

namespace Ja_proj_cs
{
    public partial class kompresja : Form
    {
        [DllImport(@"C:\Users\piotr\OneDrive\Pulpit\Ja_project\Ja_proj_cs\x64\Debug\JAAsm.dll")]
        
        static extern int MyProc1(int a, int b);

        int isAssembler, sizeBeforeCompression, sizeAfterCompression, threads = 1;
        String imageLocation;
        Bitmap bmp;
        public kompresja(){

            InitializeComponent();
        }

        private void Button1_Click(object sender, EventArgs e){
            
            Compression compression = new Compression();
            bmp = compression.Preparation(imageLocation);
            Stopwatch stopwatch = new Stopwatch();
            
            sizeBeforeCompression = compression.sizeOfString(bmp).Length;
            Size.Text = sizeBeforeCompression.ToString();
            
            Thread.Sleep(10);

            stopwatch.Start();
            if (isAssembler == 0)
            {
                String afterCompressionString = compression.startCompression(bmp, threads);
                sizeAfterCompression = afterCompressionString.Length;
                Size1.Text = sizeAfterCompression.ToString();
                AfterCompression.Image = compression.convertStringToBitmap(afterCompressionString);
            }
            else
            {
                int[] arrayOfColorIngredients = new int[bmp.Width * bmp.Height * 3];
                arrayOfColorIngredients = compression.convertToIntArray(bmp);



                int x = 5, y = 7;
                int retVal = MyProc1(x, y);
                Console.WriteLine(retVal);

                AfterCompression.Image = null;
            }
            stopwatch.Stop();
            float cRatio = (float)sizeAfterCompression  / (float)sizeBeforeCompression * 100;
            cr.Text = cRatio.ToString();
            
            Tom.Text = stopwatch.ElapsedMilliseconds.ToString();
            stopwatch = null;
            bmp = null;
            compression = null;

        }

        private void UploadButton_Click(object sender, EventArgs e){
            try{
                OpenFileDialog dialog = new OpenFileDialog();
                Compression compression = new Compression();
                dialog.Filter = "PNG files(.*png)|*.png| jpg files(.*jpg)|*.jpg|  All Files(*.*)|*.*";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK){
                    imageLocation = dialog.FileName;
                    BeforeCompression.ImageLocation = imageLocation;
                    bmp = compression.Preparation(imageLocation);
                    
                }
                if (BeforeCompression != null || BeforeCompression.Image != null){
                    CompressButton.Enabled = true;
                    
                }
            }catch (Exception){
                MessageBox.Show("An error occured during upload image", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            threads = Threads.Value;
            thred.Text = threads.ToString();
        }

        private void kompresja_Load(object sender, EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged_1(object sender, EventArgs e)
        {
            if(checkBox1.Checked)
            {
                isAssembler = 1;
            }
            else
            {
                isAssembler = 0;
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveImage = new SaveFileDialog();
                saveImage.Filter = "jpg files(.*jpg) | *.jpg | PNG files(.*png) | *.png | All Files(*.*) | *.*";
                
            }
            catch (Exception)
            {
                MessageBox.Show("An error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BeforeCompression_Click(object sender, EventArgs e)
        {

        }

        private void AfterCompression_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void ratio_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click_1(object sender, EventArgs e)
        {

        }

        private void Size_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }
    }
}
