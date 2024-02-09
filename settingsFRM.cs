using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton;
using ComponentFactory.Krypton.Ribbon;
using ComponentFactory.Krypton.Toolkit;


namespace countersystemV1
{
    public partial class settingsFRM : KryptonForm
    {
        public settingsFRM()
        {
            InitializeComponent();
        }

        private void settingsFRM_Load(object sender, EventArgs e)
        {
            string Imagepaths = Application.StartupPath + @"\" + "Advertisement";
            DirectoryInfo d = new DirectoryInfo(Imagepaths);
            TXT_LOCATION.Text = d.ToString();
        }

        private void BTN_FIND_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", TXT_LOCATION.Text);

        }
    }
}
