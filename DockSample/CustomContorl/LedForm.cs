using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Windows.Forms;
using BusinessLogic.DisplayBoards;
using DevComponents.DotNetBar;
using BusinessLogic.Search;
using System.Configuration;
using PlcContract;
using System.Collections.Generic;
using AppUtility;
using System.Threading;

namespace HDWLogic
{
    
    public partial class LedForm : Office2007Form
    {
        private byte[,] PictBuf = new byte[512,256];

        
		int _MAXHEIGHT=512;
        private int _MAXWIDTH = 2048;

        const int CardType1 = 1;         //控制卡类型,2型卡
        const int CardType2 = 2;         //控制卡类型,2型卡
        public short ComPort1 = 1;   //串口1
        public short ComPort2 = 2;   //串口2
        public short ComPort3 = 3;   //串口3
        public short ComPort4 = 4;   //串口1
        public short ComPort5 = 5;   //串口2
        
        const int ComBaudRate = 38400;   //通讯速率
        private const int ComDelay = 1500;       //延时
        public short LedNum0 = 0;         //屏号
        public short LedNum1 = 1;         //屏号
        public short LedNum2 = 2;         //屏号
        private const int LedWidth = 640;       //屏宽
        const int LedHeight64 = 64;       //屏高
        const int LedHeight192 = 192;       //屏高
        private const int LedColor = 0;          //双色屏

        public LedForm()
        {
            InitializeComponent();
            
        }


        public void PictToBuff(Bitmap bitmap, byte[,] PictBuf, int PictWidth, int PictHeight, Int32 Width, Int32 Height,byte Color)
        {
            int x, y, z, EndX, EndY, vC;
            byte v;
            byte[] _ROLE=
            {
                0x80,
                0x40,
                0x20,
                0x10,
                0x08,
                0x04,
                0x02,
                0x01
            }
            ;

            // 先清除缓冲区
            for (x = 0; x < _MAXWIDTH/8; ++x)
                for (y = 0; y < _MAXHEIGHT; ++y) PictBuf[y,x] = 0;

            // 根据图片和屏体的宽高决定截取图片的宽高,保证数据不越界
            if (PictWidth > Width) EndX = Width;
            else EndX = PictWidth;
            if (PictHeight > Height) EndY = Height;
            else EndY = PictHeight;

            // 遍历高度和宽度
            // 先截取红色
            for (y = 0; y < EndY; ++y)
                for (x = 0; x < (EndX + 7)/8; ++x)
                {
                    v = 0;
                    for (z = 0; z < 8; ++z)
                    {
                        vC = bitmap.GetPixel(x * 8 + z, y).ToArgb();
                        if ((vC & RGB(0xff, 0, 0)) > RGB(0x20, 0, 0)) v |= _ROLE[z];
                    }
                    PictBuf[y,x] = v;
                }
            // 双色屏再截取绿色
            if (Color != 0)
            {
                for (y = 0; y < EndY; ++y)
                    for (x = 0; x < (EndX + 7)/8; ++x)
                    {
                        v = 0;
                        for (z = 0; z < 8; ++z)
                        {
                            vC = bitmap.GetPixel(x * 8 + z, y).ToArgb();
                            if ((vC & RGB(0, 0xff, 0)) > RGB(0, 0x20, 0)) v |= _ROLE[z];
                        }
                        PictBuf[y + Height,x] = v;
                    }
            }
        }

        public int RGB(int r, int g, int b)
        {
            return r*65536 + g*256 + b;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            try
            {
                //荆州使用了5块LED屏
                //串口1-5
                Stream path = new FileStream("Led1.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
                Image img = new Bitmap(path);
                pictureBox1.Image = img;
                path.Close();
                path.Dispose();


                path = new FileStream("Led3.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
                img = new Bitmap(path);
                pictureBox2.Image = img;
                path.Close();
                path.Dispose();


                path = new FileStream("Led5.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
                img = new Bitmap(path);
                pictureBox3.Image = img;
                path.Close();
                path.Dispose();


                path = new FileStream("Led2.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
                img = new Bitmap(path);
                pictureBox4.Image = img;
                path.Close();
                path.Dispose();

                path = new FileStream("Led4.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
                img = new Bitmap(path);
                pictureBox5.Image = img;
                path.Close();
                path.Dispose();

                button2_Click(null, null);
            
            }
            catch (Exception)
            {
                
                //throw;
            }
            
        }

        /// <summary>
        /// 获取字符串的地址位
        /// </summary>
        /// <param name="e"></param>
        /// <returns></returns>
        int VarPtr(object e)
        {
            System.Runtime.InteropServices.GCHandle gh = System.Runtime.InteropServices.GCHandle.Alloc(e, System.Runtime.InteropServices.GCHandleType.Pinned);
            int gc = gh.AddrOfPinnedObject().ToInt32();
            gh.Free();
            return gc;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                Bitmap bitmap;
                bool bOK;

                bitmap = new Bitmap(pictureBox1.Image);
                Array.Clear(PictBuf, 0, PictBuf.Length);
                PictToBuff(bitmap, PictBuf, pictureBox1.Width, pictureBox1.Height, LedWidth, LedHeight192, 0);

                bOK = axCL2005Ocx2.ComInitial(ComPort1, ComBaudRate, ComDelay);
                if (bOK)
                {
                    bOK = axCL2005Ocx2.SetLEDProperty(CardType2, LedNum0, LedWidth, LedHeight192, 0, 0);                    
                }
                if (bOK)
                {
                    bOK = axCL2005Ocx2.ShowPicture(0, VarPtr(PictBuf));   
                    
                }
                if (bOK)
                {
                    bOK = axCL2005Ocx2.SwitchToBank(0);
                }
                axCL2005Ocx2.CloseCL2005();


                bitmap = new Bitmap(pictureBox4.Image);
                Array.Clear(PictBuf, 0, PictBuf.Length);
                PictToBuff(bitmap, PictBuf, pictureBox4.Width, pictureBox4.Height, LedWidth, LedHeight64, 0);

                bOK = axCL2005Ocx2.ComInitial(ComPort4, ComBaudRate, ComDelay);
                if (bOK)
                    bOK = axCL2005Ocx2.SetLEDProperty(CardType1, LedNum0, LedWidth, LedHeight64, LedColor, 0);
                if (bOK)
                    bOK = axCL2005Ocx2.ShowPicture(0, VarPtr(PictBuf));
                if (bOK)
                {
                    bOK = axCL2005Ocx2.SwitchToBank(0);
                }
                axCL2005Ocx2.CloseCL2005();


                bitmap = new Bitmap(pictureBox2.Image);
                Array.Clear(PictBuf, 0, PictBuf.Length);
                PictToBuff(bitmap, PictBuf, pictureBox2.Width, pictureBox2.Height, LedWidth, LedHeight192, 0);

                bOK = axCL2005Ocx2.ComInitial(ComPort2, ComBaudRate, ComDelay);
                if (bOK)
                    bOK = axCL2005Ocx2.SetLEDProperty(CardType2, LedNum0, LedWidth, LedHeight192, LedColor, 0);
                if (bOK)
                    bOK = axCL2005Ocx2.ShowPicture(0, VarPtr(PictBuf));
                if (bOK)
                {
                    bOK = axCL2005Ocx2.SwitchToBank(0);
                }
                axCL2005Ocx2.CloseCL2005();


                bitmap = new Bitmap(pictureBox5.Image);
                Array.Clear(PictBuf, 0, PictBuf.Length);
                PictToBuff(bitmap, PictBuf, pictureBox5.Width, pictureBox5.Height, LedWidth, LedHeight64, 0);

                bOK = axCL2005Ocx2.ComInitial(ComPort5, ComBaudRate, ComDelay);
                if (bOK)
                    bOK = axCL2005Ocx2.SetLEDProperty(CardType1, LedNum0, LedWidth, LedHeight64, LedColor, 0);
                if (bOK)
                    bOK = axCL2005Ocx2.ShowPicture(0, VarPtr(PictBuf));
                if (bOK)
                {
                    bOK = axCL2005Ocx2.SwitchToBank(0);
                }
                axCL2005Ocx2.CloseCL2005();


                bitmap = new Bitmap(pictureBox3.Image);
                Array.Clear(PictBuf, 0, PictBuf.Length);
                PictToBuff(bitmap, PictBuf, pictureBox3.Width, pictureBox3.Height, LedWidth, LedHeight64, 0);

                bOK = axCL2005Ocx2.ComInitial(ComPort3, ComBaudRate, ComDelay);
                if (bOK)
                    bOK = axCL2005Ocx2.SetLEDProperty(CardType1, LedNum0, LedWidth, LedHeight64, LedColor, 0);
                if (bOK)
                    bOK = axCL2005Ocx2.ShowPicture(0, VarPtr(PictBuf));
                if (bOK)
                {
                    bOK = axCL2005Ocx2.SwitchToBank(0);
                }
                axCL2005Ocx2.CloseCL2005();


                if (bOK)
                {
                    MessageBox.Show("卷烟信息发送成功！");
                }
                else
                {
                    MessageBox.Show("卷烟信息发送失败！");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("卷烟信息发送失败！" + Environment.NewLine + ex.Message);
            }           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            bool isrun = false;
            isrun = CreateCigNamePic(pictureBox1, 1, 4, "led1.bmp");
            if (isrun)
            {
                isrun = CreateCigNamePic(pictureBox4, 5, 6, "led2.bmp");
            }
            if (isrun)
            {
                isrun = CreateCigNamePic(pictureBox2, 7, 10, "led3.bmp");
            }
            if (isrun)
            {
                isrun = CreateCigNamePic(pictureBox5, 11, 12, "led4.bmp");
            }
            if (isrun)
            {
                isrun = CreateCigNamePic(pictureBox3, 13, 14, "led5.bmp");
            }
            if (isrun)
            {
                MessageBox.Show("Led信息生成完成");    
            }
            else
            {
                MessageBox.Show("Led信息生成失败");
            }
        }

       

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Bitmap image1 = new Bitmap(640, 192);
            pictureBox1.Image = (Image)image1;
            pictureBox1.Image.Save("Led1.bmp", ImageFormat.Bmp);
            Stream path = new FileStream("Led1.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
            Image img = new Bitmap(path);
            pictureBox1.Image = img;
            path.Close();
            path.Dispose();


            Bitmap image2 = new Bitmap(640, 192);
            pictureBox2.Image = (Image)image2;
            pictureBox2.Image.Save("Led2.bmp", ImageFormat.Bmp);
            path = new FileStream("Led2.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
            img = new Bitmap(path);
            pictureBox2.Image = img;
            path.Close();
            path.Dispose();

            Bitmap image3 = new Bitmap(640, 192);
            pictureBox3.Image = (Image)image3;
            pictureBox3.Image.Save("Led3.bmp", ImageFormat.Bmp);
            path = new FileStream("Led3.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
            img = new Bitmap(path);
            pictureBox3.Image = img;
            path.Close();
            path.Dispose();

            Bitmap image4 = new Bitmap(640, 192);
            pictureBox4.Image = (Image)image4;
            pictureBox4.Image.Save("Led4.bmp", ImageFormat.Bmp);
            path = new FileStream("Led4.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
            img = new Bitmap(path);
            pictureBox4.Image = img;
            path.Close();
            path.Dispose();

            Bitmap image5 = new Bitmap(640, 192);
            pictureBox5.Image = (Image)image5;
            pictureBox5.Image.Save("Led5.bmp", ImageFormat.Bmp);
            path = new FileStream("Led5.bmp", FileMode.Open, FileAccess.Read, FileShare.Read);
            img = new Bitmap(path);
            pictureBox5.Image = img;
            path.Close();
            path.Dispose();
            MessageBox.Show("清屏信息生成成功！");
        }

        private void button4_Click(object sender, EventArgs e)
        {
            //nixielight1.SendPD();
            //SendPD();
            if (nixielight1.SendPD())
            {
                MessageBox.Show("盘点信息发送成功！");
            }
            else
            {
                MessageBox.Show("盘点信息发送失败！");

            }
            
        }

        

        /// <summary>
        /// 生成卷烟品牌的图片
        /// 其中每5个品牌为一个组
        /// 图片640的宽度只能放下5个品牌名称
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="startledgroup">起始组</param>
        /// <param name="endledgroup">结束组</param>
        /// <param name="filename">保存文件名</param>
        /// <returns></returns>
        public bool CreateCigNamePic(PictureBox picture,int startledgroup,int endledgroup,string filename)
        {
           
            try
            {
                Bitmap image = new Bitmap(640, 192);
                int left = image.Height / 2 - 18;
                int top = -image.Width / 2;
                //创建Graphics类对象
                Graphics g = Graphics.FromImage(image);
                //设置旋转中心点 
                g.TranslateTransform(image.Width / 2, image.Height / 2);
                //设置旋转角度
                g.RotateTransform(-90);


                LedDisplay ledDisplay = new LedDisplay();
                ledDisplay.GetLedLineboxs();


                //将文本生成到图片框内
                int leftoffset = 1;
                for (int i = startledgroup; i <= endledgroup; i++)
                {                    
                    //按组获取显示的名称拼成字符串
                    string ledstring = ledDisplay.GetCigNames(i);

                    int topmove = 0;
                    foreach (char c in ledstring)
                    {
                        //画名称 
                        g.DrawString(c.ToString(), Font, new SolidBrush(Color.Red), left - ((leftoffset -1) * 16), top + topmove);
                        topmove += 16;
                        
                    }
                    leftoffset++;

                    //LED屏有问题必须写空两行再写　
                    int j = 1;
                    if (i == 2  || i == 8)
                    {
                        //写两行空白字符
                        while (j++ <= 2)
                        {
                            //空白字符
                            ledstring = "　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　　";

                            topmove = 0;
                            foreach (char c in ledstring)
                            {
                                //画名称 
                                g.DrawString(c.ToString(), Font, new SolidBrush(Color.Red), left - ((leftoffset - 1) * 16), top + topmove);
                                topmove += 16;

                            }
                            leftoffset++;
                        }
                    }
                }
                g.ResetTransform();


                //显示生成的图片
                picture.Image = (Image)image;
                picture.Image.Save(filename, ImageFormat.Bmp);
                

                Stream path = new FileStream(filename, FileMode.Open, FileAccess.Read, FileShare.Read);
                Image img = new Bitmap(path);
                picture.Image = img;
                path.Close();
                path.Dispose();
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }




            
        }


        //public bool CreateCigNumPic()
        //{
        //    try
        //    {
        //        Bitmap image = new Bitmap(640, 192);
        //        int left = image.Height / 2 - 18;
        //        int top = -image.Width / 2;
        //        //创建Graphics类对象
        //        Graphics g = Graphics.FromImage(image);
        //        //设置旋转中心点 
        //        g.TranslateTransform(image.Width / 2, image.Height / 2);
        //        //设置旋转角度
        //        g.RotateTransform(-90);


        //        OperateOpcAndSoft operateOpcAndSoft = new OperateOpcAndSoft();
        //        Dictionary<int, int> putoutnums = operateOpcAndSoft.GetPutOutNum();

        //        LineBoxProcessList lineboxprocesslist = LineBoxProcessList.GetList(ConfigurationSettings.AppSettings["Mode"].ToLower());

        //        for (int i = 0; i < lineboxprocesslist.Count; i++)
        //        {
        //            if (putoutnums.ContainsKey(Convert.ToInt32(lineboxprocesslist[i].LINEBOXCODE)))
        //            {
        //                lineboxprocesslist[i].OUTQTY = putoutnums[Convert.ToInt32(lineboxprocesslist[i].LINEBOXCODE)];
        //                lineboxprocesslist[i].NONQTY = lineboxprocesslist[i].NONQTY - lineboxprocesslist[i].OUTQTY;
        //            }
        //        }

        //        LedDisplay ledDisplay = new LedDisplay();
        //        ledDisplay.GetLedQTY(lineboxprocesslist);







        //        for (int i = 1; i <= 12; i++)
        //        {
        //            string ledstring = ledDisplay.GetCigNames(i);

        //            int topmove = 0;
        //            foreach (char c in ledstring)
        //            {
        //                //画文字 
        //                g.DrawString(c.ToString(), Font, new SolidBrush(Color.Red), left - ((i - 1) * 16), top + topmove);
        //                topmove += 16;
        //            }
        //        }
        //        g.ResetTransform();
        //        pictureBox1.Image = (Image)image;
        //        pictureBox1.Image.Save("LedPD.bmp", ImageFormat.Bmp);
        //        pictureBox1.Load("LedPD.bmp");
        //        return true;
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}


        //public bool SendPic()
        //{
        //    try
        //    {
        //        Bitmap bitmap = new Bitmap(pictureBox1.Image);
        //        PictToBuff(bitmap, PictBuf, pictureBox1.Width, pictureBox1.Height, LedWidth, LedHeight64, 0);

        //        bool bOK = axCL2005Ocx2.ComInitial(ComPort1, ComBaudRate, ComDelay);
        //        if (bOK)
        //            bOK = axCL2005Ocx2.SetLEDProperty(CardType1, LedNum1, LedWidth, LedHeight64, LedColor, 0);
        //        if (bOK)
        //            bOK = axCL2005Ocx2.ShowPicture(0, VarPtr(PictBuf));
        //        if (bOK)
        //        {
        //            bOK = axCL2005Ocx2.SwitchToBank(0);
        //        }
        //        if (bOK)
        //            axCL2005Ocx2.CloseCL2005();
        //        if (bOK)
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        return false;
        //    }
        //}

        private void nixielight1_Load(object sender, EventArgs e)
        {

        }

        private void buttonX1_Click(object sender, EventArgs e)
        {
            OperateOpcAndSoft operateOpcAndSoft = new OperateOpcAndSoft();
             operateOpcAndSoft.InDataToTaskAddress();
             operateOpcAndSoft.OutDataToTaskAddress();
        }

    }

 

   
}
