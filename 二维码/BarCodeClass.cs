using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using ZXing;
using ZXing.Common;
using ZXing.QrCode;

namespace 二维码
{
    class BarCodeClass
    {
        /// <summary>
        /// 生成条形码
        /// </summary>
        /// <param name="pictureBox1"></param>
        /// <param name="contents"></param>
        public void CreateBarCode(PictureBox pictureBox1,string contents)
        {
            Regex rg = new Regex("^[0-9]{12}$");
            if(!rg.IsMatch(contents))
            {
                MessageBox.Show("此程序采用EAN_13编码，需要输入12位数字");
                return;
            }
            EncodingOptions options = null;
            BarcodeWriter writer = null;
            options = new EncodingOptions
            {
                Width = pictureBox1.Width,
                Height = pictureBox1.Height
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.ITF;
            writer.Options = options;

            Bitmap bitmap = writer.Write(contents);
            pictureBox1.Image = bitmap;
        }

        /// <summary>
        /// 生成二维码
        /// </summary>
        /// <param name="pictureBox1"></param>
        /// <param name="contents"></param>
        public void CreateQuickMark(PictureBox pictureBox1,string contents)
        {
            if(contents==string.Empty)
            {
                MessageBox.Show("输入的内容不能为空！");
                return;
            }
            EncodingOptions options = null;
            BarcodeWriter writer = null;

            options = new QrCodeEncodingOptions
            {
                DisableECI = true,
                CharacterSet = "UTF-8",
                Width = pictureBox1.Width,
                Height = pictureBox1.Height
            };
            writer = new BarcodeWriter();
            writer.Format = BarcodeFormat.QR_CODE;
            writer.Options = options;

            Bitmap bitmap = writer.Write(contents);
            pictureBox1.Image = bitmap;
        }

        /// <summary>
        /// 解码
        /// </summary>
        /// <param name="pictureBox1"></param>
        public Result Decode(PictureBox pictureBox1)
        {
            BarcodeReader reader = new BarcodeReader();
            Result result = reader.Decode((Bitmap)pictureBox1.Image);
            return result;
        }
    }
}
