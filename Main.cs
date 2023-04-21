using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DotNet_Autocad
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DBLoadUtil dbload = new DBLoadUtil();
            string result = dbload.LoadLines();
            lblInfo.Text = result;
        }

        private void BtnLoadMText_Click(object sender, EventArgs e)
        {
            DBLoadUtil dbload = new DBLoadUtil();
            string result = dbload.LoadMTexts();
            lblInfo.Text = result;
        }

        private void BtnLoadPolylines_Click(object sender, EventArgs e)
        {
            DBLoadUtil dbload = new DBLoadUtil();
            string result = dbload.LoadPolylines();
            lblInfo.Text = result;
        }

        private void BtnLoadBlocksWithNoAttribute_Click(object sender, EventArgs e)
        {
            DBLoadUtil dbload = new DBLoadUtil();
            string result = dbload.LoadBlocksNoAttribute();
            lblInfo.Text = result;
        }

        private void BtnLoadBlocksWithAttribute_Click(object sender, EventArgs e)
        {
            DBLoadUtil dbload = new DBLoadUtil();
            string result = dbload.LoadBlocksWithAttribute();
            lblInfo.Text = result;

        }
    }
}
