using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoL_Guide
{
    public partial class ChampInfo : Form
    {
        public string champName;
        public ChampInfo()
        {
            InitializeComponent();
        }

        private void ChampInfo_Load(object sender, EventArgs e)
        {
            label1.Text = champName;
      
            this.BackColor = Color.FromArgb(28, 33, 35);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
