using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;
using System.Text.RegularExpressions;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;
using ZXing.QrCode.Internal;
using System.Drawing.Imaging;

namespace 二维码
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private BarCodeClass bcc = new BarCodeClass();
        private DocumentBase _document;
        //生成条形码
        private void button1_Click(object sender, EventArgs e)
        {
            bcc.CreateBarCode(pictureBox1, textBox1.Text);
        }

        //生成二维码
        private void button2_Click(object sender, EventArgs e)
        {
            bcc.CreateQuickMark(pictureBox1, textBox1.Text);
        }

        //解码
        private void button3_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image==null)
            {
                DialogResult IsOpenFloder = MessageBox.Show("没有二维码图片！\n是否从文件中选择？", "识别二维码", MessageBoxButtons.YesNo);
                if(IsOpenFloder.ToString() =="No")
                { return; }
                else
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = "PNG文件(*.png)|*.png|JPG文件(*.jpg)|*.jpg|所有文件(*.*)|*.*";
                    if(openFileDialog.ShowDialog()==DialogResult.OK)
                    {
                        string picturename = openFileDialog.FileName;
                        Image image = Image.FromFile(picturename);
                        pictureBox1.Image = image;
                    }
                }
            }
            Result result = bcc.Decode(pictureBox1);
            //MessageBox.Show(result.Text);
            ShowResult showresult = new ShowResult();
            showresult.result_textBox.Text = result.Text;
            showresult.ShowDialog();
        }

        //打印
        private void button4_Click(object sender, EventArgs e)
        {
            if(pictureBox1.Image==null)
            {
                MessageBox.Show("没有图片可供打印！");
            }
            else
            {
                _document = new ImageDocument(pictureBox1.Image);
            }
            _document.ShowPrintPreviewDialog();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            textBox1.Text = System.DateTime.Now.ToString("yyyyMMddhhmmss").Substring(0, 12);
            
        }
    }
}
