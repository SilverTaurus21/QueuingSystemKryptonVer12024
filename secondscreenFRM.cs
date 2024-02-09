using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;

namespace countersystemV1
{
    public partial class secondscreenFRM : KryptonForm
    {

        string[] Imgs_slider;
  
        public secondscreenFRM()
        {
            InitializeComponent();

            timer1.Interval = 2000; // Set the interval time to 2000 milliseconds = 2seconds
            timer1.Enabled = true;

        }


 /*METHODS ************/
        public static class Util // no conditions for today here .. extra code for effects 
        {
            public enum Effect { Roll, Slide, Center, Blend }

            public static void Animate(Control ctl, Effect effect, int msec, int angle)
            {
                int flags = effmap[(int)effect];

                if (ctl.Visible)
                {
                    flags |= 0x10000; angle += 180;
                }
                else
                {
                    if (ctl.TopLevelControl == ctl) flags |= 0x20000;
                    else if (effect == Effect.Blend) throw new ArgumentException();
                }

                flags |= dirmap[(angle % 360) / 45];
                bool ok = AnimateWindow(ctl.Handle, msec, flags);
                if (!ok) throw new Exception("Animation failed");
                ctl.Visible = !ctl.Visible;
            }

            private static int[] dirmap = { 1, 5, 4, 6, 2, 10, 8, 9 };
            private static int[] effmap = { 0, 0x40000, 0x10, 0x80000 };

            [DllImport("user32.dll")]
            private static extern bool AnimateWindow(IntPtr handle, int msec, int flags);
        } 


        static string[] LstImgs(string FilePath)
        {
            string Imagepaths = Application.StartupPath + @"\" + FilePath;
            DirectoryInfo d = new DirectoryInfo(Imagepaths);
            FileInfo[] Files = d.GetFiles(); // Getting Files

            string[] ret = new string[Files.Length];
            for (int x = 0; x < Files.Length; x++)
            {
                ret[x] = Files[x].Name;
            }
            return ret;

        }


        int cnt = 0;

        public void _condition()
        {

            if (Imgs_slider.Length != 0)
            {
                string file_extension = Path.GetExtension(Imgs_slider[cnt]);


                if (file_extension == ".jpeg" || file_extension == ".jpg" || file_extension == ".JPG" || file_extension == ".png" || file_extension == ".png" || file_extension == ".PNG")
                {
                    timer2.Interval = 5000;
                    pictureBox1.BringToFront();
                    pictureBox1.Image = Image.FromFile(Application.StartupPath + @"\Advertisement\" + Imgs_slider[cnt]);
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;

                }
                else
                {
                    axWindowsMediaPlayer1.BringToFront();

                    var clip = axWindowsMediaPlayer1.newMedia(string.Format(Application.StartupPath + @"\Advertisement\" + Imgs_slider[cnt]));
                    TimeSpan Duration = TimeSpan.FromSeconds(clip.duration);

                    Int32 hr_Duration = Duration.Hours * 60 * 60 * 1000;
                    Int32 Min_Duration = Duration.Minutes * 60 * 1000;
                    Int32 Sec_Duration = Duration.Seconds * 1000;
                    timer2.Interval = Sec_Duration + Min_Duration + hr_Duration;

                    axWindowsMediaPlayer1.URL = string.Format(Application.StartupPath + @"\Advertisement\" + Imgs_slider[cnt]);
                    axWindowsMediaPlayer1.Ctlcontrols.play();
                    axWindowsMediaPlayer1.settings.volume = 0;

                }

                cnt = cnt + 1;

                if (cnt == (Imgs_slider.Length))
                {
                    cnt = 0;
                }
            }
        }


        private void setFormLocation(Form form, Screen screen)
        {
            Rectangle bounds = screen.Bounds;
            form.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }

/* EVENTS ************/
        private void timer1_Tick(object sender, EventArgs e)
        {
            LBL_COUNTER1.Text = RelayTrigger.getcounter1;
            LBL_COUNTER2.Text = RelayTrigger.getcounter2;
        }

        // Method that stops the timer
        public void StopTimer()
        {
            timer1.Stop();
        }

        // Dispose method to clean up resources when the class instance is destroyed
        public void Dispose()
        {
            timer1.Dispose();
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            _condition();
        }

        private void secondscreenFRM_Load(object sender, EventArgs e)
        {
            Imgs_slider = LstImgs("Advertisement");// load all images names   

         // for video
            timer2.Start();
            timer2.Interval = 1000;
        }
    }

}

