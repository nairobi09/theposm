using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace thepos
{
    public partial class formMain : Form
    {
        public formMain()
        {
            InitializeComponent();
        }

        private void formMain_Resize(object sender, EventArgs e)
        {
            panelBack.Height = this.Height;
            panelBack.Width = this.Width;


        }

        private void panelBack_Resize(object sender, EventArgs e)
        {
            
        }
    }
}
