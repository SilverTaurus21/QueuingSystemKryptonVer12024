/*

date: feb 02,2024 - BY erj.a: https://github.com/SilverTaurus21
methods :  

GET_COUNTER - triggers only in RESET_DATA AND BUTTON EVENTS OR KEYS - will pass string data
RESET_DATA - Will delete current file in the .json and reset the deafault strings assign / static to two counters 
REFRESH_DATA - Will occured during RESET and FORM_LOAD initialize();
SettingJsonActive - retrieve and read .json file
RESET_BUTTON_STAT - read if the dafaut string is made and it will disable the RESET BUTTON , trigger on reset and btn_
COUNTER1 - for btn event counter1
COUNTER2 - for btn event counter2



 */


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton;
using ComponentFactory.Krypton.Toolkit;
using Newtonsoft.Json;
using System.Media;
using System.Speech.Synthesis;
using System.Speech.Recognition;
using System.Globalization;

namespace countersystemV1
{
    public partial class Form1 : KryptonForm
    {
        int num = 1, c1=1, c2=1;
        string lastInput = string.Empty;
        bool EXIT = false;
        bool firstTrigger = true;
        bool isConnectToTV;

        public Form1()
        {
            InitializeComponent();  


            clock();
            SettingJsonActive();
            REFRESH_DATA();
            RESET_BUTTON_STAT();

            GET_COUNTER(); // initial Form1_Load temporary code here

        }

/* *****************  FORMLOAD ******************/
        private void Form1_Load(object sender, EventArgs e)
        {
            if (Screen.AllScreens.Length > 1)
            {
                BTN_CONNECTTV.Visible = true;
                isConnectToTV = RelayTrigger.gettrigger;
            }
            else
            {
                BTN_CONNECTTV.Visible = false;
                isConnectToTV = false;
            }
        }

        /* *****************  METHOD SECTION ONLY  ******************/

        private void setFormLocation(Form form, Screen screen)
        {
            Rectangle bounds = screen.Bounds;
            form.SetBounds(bounds.X, bounds.Y, bounds.Width, bounds.Height);
        }

        public void DETECT_SCREEN()
        {

            do
            {
                if (Screen.AllScreens.Length > 1)
                {
                    GET_COUNTER();

                    // will set second screen in default screen 1 - you can edit this dynamically if you want by user - ff

                    secondscreenFRM frm = new secondscreenFRM();
                    Screen[] screens = Screen.AllScreens;
                    setFormLocation(frm, screens[1]);
                    frm.Show();
                }
                else
                {
                    BTN_CONNECTTV.Visible = false;
                    isConnectToTV = false;
                }
            }
            while (!isConnectToTV);

            // Load the image from the file
        
            BTN_CONNECTTV.Enabled = false;
            isConnectToTV = false;

        }

        public void clock()
        {
            Timer timer1 = new Timer();
            timer1.Interval = 1000; // 1 second interval
            timer1.Tick += new EventHandler(timer1_Tick);
            timer1.Start();
        }

        public void SettingJsonActive()
        {
            if (File.Exists("counter.json"))
            {
                string json = File.ReadAllText("counter.json");
                dynamic data = JsonConvert.DeserializeObject(json);

                c1 = (int)data.c1;
                c2 = (int)data.c2;
            }
            else
            {
                c1 = 1;
                c2 = 1;
            }
        }

        public void REFRESH_DATA(){

            string json = File.ReadAllText("counter.json");
            dynamic data = JsonConvert.DeserializeObject(json);

            TXT_COUNTER1.Text = Convert.ToString(data.c1);
            TXT_COUNTER2.Text= Convert.ToString(data.c2);

        }

        public void RESET_BUTTON_STAT(){

            if (TXT_COUNTER1.Text.Equals("1") && TXT_COUNTER2.Text.Equals("2"))
            {
                BTN_TRIGGER_RESET.Enabled = false;
            }
            else
            {
                BTN_TRIGGER_RESET.Enabled = true;
            }
        }

        public void COUNTER_1()
        {
            c1 = Convert.ToInt32(TXT_COUNTER1.Text);
            c2 = Convert.ToInt32(TXT_COUNTER2.Text);

            if (c1 == 0 || c2 == 0) {
                c1++;
                c2 = 2;
            }

            else {
                if (c1 > c2)
                {
                    c1++;
                    c2 = c2;
                }
                else if (c1 < c2)
                {
                    c1 = c2;
                    c1++;
                    c2 = c2;
                }
            }

            dynamic data = new
            {
                c1 = c1,
                c2 = c2
            };

            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText("counter.json", json);

            TXT_COUNTER1.Text = Convert.ToString(c1);

            RESET_BUTTON_STAT();
        }

        public void COUNTER_2()
        {
           
            c1 = Convert.ToInt32(TXT_COUNTER1.Text);
            c2 = Convert.ToInt32(TXT_COUNTER2.Text);

            if (c2 == 0 || c1 == 0)
            {
                c2++;
                c1 = 2;
            }
            else {
                if (c2 > c1)
                {
                    c2++;
                    c1 = c1;
                }
                else if (c2 < c1) {
                    c2 = c1;
                    c2++;
                    c1 = c1;
                }
            }
        
            dynamic data = new
            {
                c1 = c1,
                c2 = c2,
            };
            string json = JsonConvert.SerializeObject(data);
            File.WriteAllText("counter.json", json);

            TXT_COUNTER2.Text = Convert.ToString(c2);

            RESET_BUTTON_STAT();
        }

        public void GET_COUNTER(){

            try
            {
                RelayTrigger.getcounter1 = TXT_COUNTER1.Text;
                RelayTrigger.getcounter2 = TXT_COUNTER2.Text;
            }
            catch(Exception e){ }
                
        }

        public void RESET_DATA(){

            DialogResult result = MessageBox.Show("are you sure you want to RESET?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check the user's input
            if (result == DialogResult.Yes)
            {

                File.Delete("counter.json");
                if (!File.Exists("counter.json"))
                {
                    dynamic data = new
                    {

                    // THIS DATA WILL ASSIGN STATIC VALUES TO EACH COUNTER 
                        c1 = 1,
                        c2 = 2,
                    };
                    string json = JsonConvert.SerializeObject(data);
                    File.WriteAllText("counter.json", json);


                    // c1 and c2 

                    TXT_COUNTER1.Text = Convert.ToString(c1);
                    TXT_COUNTER2.Text = Convert.ToString(c2);

                    REFRESH_DATA();
                    RESET_BUTTON_STAT();
                   
                    // The user clicked 'Yes'
                    MessageBox.Show("Data Been RESET");

                 
                    GET_COUNTER(); // temp
                }
                else if (result == DialogResult.No)
                {
                    // The user clicked 'No'
                    MessageBox.Show("Cancelled");
                }

            }
        }


        public void RECALL_VOICE(){

            if (TXT_COUNTER1.Text != "")
            {
                SpeechSynthesizer synthesizer = new SpeechSynthesizer();
                synthesizer.Volume = 100;


                // Get the installed voices
                foreach (InstalledVoice voice in synthesizer.GetInstalledVoices())
                {
                    VoiceInfo info = voice.VoiceInfo;
                    Console.WriteLine("Name: {0}, Culture: {1}, Gender: {2}",
                                      info.Name, info.Culture, info.Gender);
                }

                // Set the voice to be used by the synthesizer
                synthesizer.SelectVoiceByHints(VoiceGender.Female, VoiceAge.Senior, 0, new CultureInfo("en-US"));


                // Generate speech from text here.. waaaaaaaah!

                synthesizer.SpeakAsync("Calling Counter one, number " + TXT_COUNTER1.Text + ", and Calling Counter two, number " + TXT_COUNTER2.Text);
            }
        }

/* *****************  EVENT SECTION ONLY  ******************/

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime currentTime = DateTime.Now;

            if (currentTime.Hour >= 12)
            {
                currentDateTime.Text = $"{currentTime.Hour % 12:00}:{currentTime.Minute:00}:{currentTime.Second:00} PM";
            }
            else
            {
                currentDateTime.Text = $"{currentTime.Hour:00}:{currentTime.Minute:00}:{currentTime.Second:00} AM";
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            splashFRM sp = new splashFRM();
            sp.Show();
        }

        private void BTN_COUNTER1_Click(object sender, EventArgs e)
        {
            COUNTER_1();
            GET_COUNTER();
        
        }

        private void BTN_COUNTER2_Click(object sender, EventArgs e)
        {
            COUNTER_2();
            GET_COUNTER();
       
        }

        private void BTN_SETTINGS_Click(object sender, EventArgs e)
        {
            settingsFRM setFRM = new settingsFRM();
            setFRM.ShowDialog();
        }

        private void BTN_RECALL_Click(object sender, EventArgs e)
        {
            RECALL_VOICE();
        }

        private void BTN_TRIGGER_RESET_Click(object sender, EventArgs e)
        {
            RESET_DATA(); 
        }

        private void BTN_CONNECTTV_Click_1(object sender, EventArgs e)
        {
            DETECT_SCREEN();
        }



    }
}
