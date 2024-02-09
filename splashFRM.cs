using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace countersystemV1
{
    public partial class splashFRM : Form
    {
        public splashFRM()
        {
            InitializeComponent();
        }

        private void BTN_TRIGGER_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
