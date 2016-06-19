using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace 二维码
{
    public partial class ShowResult : Form
    {
        public ShowResult()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            result_textBox.Copy();
        }

        private void ShowResult_Load(object sender, EventArgs e)
        {
            if(result_textBox.Text.Substring(0,7).ToLower()=="http://"||result_textBox.Text.Substring(0,8).ToLower()=="https://")
            {
                openwebsite_button.Enabled = true;
            }
            else
            {
                openwebsite_button.Enabled = false;
            }
        }

        private void openwebsite_button_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start(result_textBox.Text);
        }
    }
}
