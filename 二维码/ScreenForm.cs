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
    public partial class ScreenForm : Form
    {
        public ScreenForm()
        {
            InitializeComponent();
        }

        //截屏完毕后交给父窗体处理截图
        //public event copyToFatherTextBox copyToFather;
        //是否开始截屏
        public bool IsBegin = false;
        //是否双击
        public bool IsDoubleClick = false;
        //鼠标第一点
        public Point firstPoint_Mouse = new Point(0, 0);
        //鼠标第二点
        public Point secondPoint_Mouse = new Point(0, 0);
        //缓存截获的屏幕
        public Image cacheImage = null;
        //保存屏幕一半的宽度
        public int halfWidth = 0;
        //保存屏幕一般的高度
        public int halfHeight = 0;


        private void ScreenForm_Load(object sender, EventArgs e)
        {
            CopyScreen();
        }




        /// <summary>
        /// 复制整个屏幕，并让窗体填充屏幕
        /// </summary>
        public void CopyScreen()
        {
            Rectangle rectangle = Screen.PrimaryScreen.Bounds;
            Image img = new Bitmap(rectangle.Width, rectangle.Height);
            Graphics g = Graphics.FromImage(img);
            g.CopyFromScreen(new Point(0, 0), new Point(0, 0),rectangle.Size);

            //窗口最大化，及相关处理
            this.Width = rectangle.Width;
            this.Height = rectangle.Height;
            this.Left = 0;
            this.Top = 0;

            pictureBox1.Width = rectangle.Width;
            pictureBox1.Height = rectangle.Height;
            pictureBox1.BackgroundImage = img;

            cacheImage = img;

            halfHeight = rectangle.Height / 2;
            halfWidth = rectangle.Width / 2;

            //this.Cursor = new Cursor(GetType(), "MyCuror.cur");
        }

        //鼠标按下时开始截图
        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if(!IsDoubleClick)
            {
                IsBegin = true;
                firstPoint_Mouse = new Point(e.X, e.Y);
                changePoint(e.X, e.Y);
                msg.Visible = true;
            }
        }

        //鼠标移动时显示截取区域的边框
        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if(IsBegin)
            {
                //获取新的右下角坐标
                secondPoint_Mouse = new Point(e.X, e.Y);
                int minX = Math.Min(firstPoint_Mouse.X, secondPoint_Mouse.X);
                int minY = Math.Min(firstPoint_Mouse.Y, secondPoint_Mouse.Y);
                int maxX = Math.Max(firstPoint_Mouse.X, secondPoint_Mouse.X);
                int maxY = Math.Max(firstPoint_Mouse.Y, secondPoint_Mouse.Y);

                //重新画背景图
                Image tempimage = new Bitmap(cacheImage);
                Graphics g = Graphics.FromImage(tempimage);

                //画裁剪框
                g.DrawRectangle(new Pen(Color.Red), minX, minY, maxX - minX, maxY - minY);
                pictureBox1.Image = tempimage;

                //计算坐标信息
                msg.Text = "左上角坐标：（" + minX.ToString() + "，" + minY.ToString() + "）\r\n";
                msg.Text += "右下角坐标：（" + maxX.ToString() + "，" + maxY.ToString() + "）\r\n";
                msg.Text += "截图大小：" + (maxX - minX) + "x" + (maxY - minY) + "\r\n";
                msg.Text += "双击任意地方结束截屏";
                changePoint((minX + maxX) / 2, (minY + maxY) / 2);
            }
        }
        
        //动态调整显示信息的位置，输入参数为当前截屏鼠标位置
        public void changePoint(int x,int y)
        {
            if(x<halfWidth)
            {
                if(y<halfHeight)
                {
                    msg.Top = halfHeight;
                    msg.Left = halfWidth;
                }
                else
                {
                    msg.Top = 0;
                    msg.Left = halfWidth;
                }
            }
            else
            {
                if(y<halfHeight)
                {
                    msg.Top = halfHeight;
                    msg.Left = 0;
                }
                else
                {
                    msg.Top = 0;
                    msg.Left = 0;
                }
            }
        }

        //鼠标放开时截图操作完成
        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            IsBegin = false;
            IsDoubleClick = true;
        }

        //双击截图时，通知父窗体完成截图操作，同时关闭本窗体
        private void pictureBox1_DoubleClick(object sender, EventArgs e)
        {
            if(firstPoint_Mouse!=secondPoint_Mouse)
            {
                int minX = Math.Min(firstPoint_Mouse.X, secondPoint_Mouse.X);
                int minY = Math.Min(firstPoint_Mouse.Y, secondPoint_Mouse.Y);
                int maxX = Math.Max(firstPoint_Mouse.X, secondPoint_Mouse.X);
                int maxY = Math.Max(firstPoint_Mouse.Y, secondPoint_Mouse.Y);
                Rectangle r = new Rectangle(minX, minY, maxX - minX, maxY - minY);
                //copytoFather(r);
            }
            this.Close();
        }
    }
}
