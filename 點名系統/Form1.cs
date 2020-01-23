using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using Microsoft.VisualBasic;

namespace WindowsFormsApp12
{
    public partial class Form1 : Form
    {
        Timer timer = new Timer();
        int kill=0;
        int p;
        int k;
        int c = 0;
        int dateT;
        String[] sp;
        String time;
        String record;
        String timej,timen;
        public int Idle_time = 0;
        [DllImport("user32.dll", EntryPoint = "FindWindow", CharSet = CharSet.Auto)]
        private extern static IntPtr FindWindow(string lpClassName, string lpWindowName);

        [DllImport("user32.dll", CharSet = CharSet.Auto)]
        public static extern int PostMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        public const int WM_CLOSE = 0x10;
        public Form1()
        {
            InitializeComponent();
            Random r = new Random();

            label4.Text = Convert.ToString(r.Next(1000, 10000));//設置亂數1000~9999
        }
        private void StartKiller()
        {

            timer.Enabled = true;
           
           
            timer.Start();
        }
        private void Timer_Tick(object sender, EventArgs e)
        {
            KillMessageBox();
            //停止Timer
            timer.Enabled = false;
            ((Timer)sender).Stop();
            
        }
        private void KillMessageBox()
        {
            IntPtr ptr;//設定預設不作用
            //依MessageBox的標題,找出MessageBox的視窗
            if (kill == 1)
            {
                ptr = FindWindow(null, "提醒");
                if (ptr != IntPtr.Zero)
                {
                    //找到則關閉MessageBox視窗
                    PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
            }
            else if (kill == 2)
            {
                 ptr = FindWindow(null, "成功");
                if (ptr != IntPtr.Zero)
                {
                    //找到則關閉MessageBox視窗
                    PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
            }
            else if (kill == 3)
            {
                ptr = FindWindow(null, "失敗");
                if (ptr != IntPtr.Zero)
                {
                    //找到則關閉MessageBox視窗
                    PostMessage(ptr, WM_CLOSE, IntPtr.Zero, IntPtr.Zero);
                }
            }
            
         
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                progressBar1.Maximum = Int32.Parse(textBox1.Text);
                k = Int32.Parse(textBox1.Text);
                textBox1.ReadOnly = true;
                time = null;
                progressBar1.Value = 0;
                Random r = new Random();
                for (int i = 1; i <= k; i++)
                {
                    time += Convert.ToString(r.Next(3)) + Convert.ToString(r.Next(5)) + Convert.ToString(r.Next(6)) + Convert.ToString(r.Next(10)) + Convert.ToString(r.Next(6)) + Convert.ToString(r.Next(10));
                    if (k != i)
                    {
                        time = time + ",";
                    }

                }
                label2.Text = "點名時間(HHmmss):" + time;
                sp = time.Split(',');
                button3.Enabled = false;
                WindowsFormsApp12.Properties.Settings.Default.times = textBox1.Text;
                WindowsFormsApp12.Properties.Settings.Default.Save();
            }
            catch (Exception ex)
            {
                MessageBox.Show("請輸入數字");
            }

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            Idle_time = 60;
            timer.Interval = 10000; //10秒啓動
            timer.Enabled = false;
            timer.Tick += new EventHandler(Timer_Tick);
            try
            {
                if (WindowsFormsApp12.Properties.Settings.Default.times.Equals(""))
                {
                    textBox1.Text = "20";
                }
                else
                {
                    textBox1.Text = WindowsFormsApp12.Properties.Settings.Default.times;//讀取點名次數
                }
               
                record = WindowsFormsApp12.Properties.Settings.Default.Record;//讀取記錄
                record += "\n";
                k = Int32.Parse(textBox1.Text);
                progressBar1.Maximum = k;
                Random r = new Random();
                for (int i = 1; i <= k; i++)
                {
                    time += Convert.ToString(r.Next(3)) + Convert.ToString(r.Next(4)) + Convert.ToString(r.Next(6)) + Convert.ToString(r.Next(10)) + Convert.ToString(r.Next(6)) + Convert.ToString(r.Next(10));
                    if (k != i)
                    {
                        time = time + ",";
                    }

                }
                label2.Text = "點名時間(HHmmss):" + time;
                sp = time.Split(',');

            }
            catch (Exception ex)
            {
                MessageBox.Show("首次使用請先設定點名次數");
            }
            timer1.Interval = Idle_time * 1000;//設定計時器幾毫秒執行一次
            timer1.Enabled = true;//打開器
            timer2.Interval = 1000;//設定計時器幾毫秒執行一次
            timer2.Enabled = true;

        }
        [DllImport("user32.dll")]
        private static extern bool GetLastInputInfo(ref LASTINPUTINFO plii);

        public static long GetIdleTick()
        {
            LASTINPUTINFO lastInputInfo = new LASTINPUTINFO();
            lastInputInfo.cbSize = Marshal.SizeOf(lastInputInfo);
            if (!GetLastInputInfo(ref lastInputInfo)) return 0;
            return Environment.TickCount - (long)lastInputInfo.dwTime;
        }
        [StructLayout(LayoutKind.Sequential)]
        private struct LASTINPUTINFO
        {
            [MarshalAs(UnmanagedType.U4)]
            public int cbSize;
            [MarshalAs(UnmanagedType.U4)]
            public uint dwTime;
        }
        public int WM_SYSCOMMAND = 0x0112;
        public int SC_MONITORPOWER = 0xF170;
        [DllImport("user32.dll")]
        private static extern int SendMessage(int hWnd, int hMsg, int wParam, int lParam);

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (GetIdleTick() / 1000 >= Idle_time)//閒置??秒
            {
                this.WindowState = FormWindowState.Minimized;

            }
           
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            label5.Text = "現在時間(HHmmss):" + DateTime.Now.ToString("HHmmss");
            timen = DateTime.Now.ToString("HHmmss");
            int n = Convert.ToInt32(timen);
            int j = Convert.ToInt32(timej);
            int R = n - j;
            if (R == 200&&j!=0)
            {
                if (p != progressBar1.Maximum && textBox1.ReadOnly == true && button2.Enabled == true)
                {

                    p++;
                    kill = 3;
                    StartKiller();
                    MessageBox.Show("點名失敗", "失敗", MessageBoxButtons.OK);

                    timer.Enabled = false;
                    progressBar1.Value = p;
                    if (p == progressBar1.Maximum)
                    {
                        MessageBox.Show("今日已點名結束");
                    }
                    Random r = new Random();
                    label4.Text = Convert.ToString(r.Next(1000, 10000));
                    WindowState = FormWindowState.Minimized;
                    if (p == 1 && k != 1)
                    {

                        record += DateTime.Now.ToString("yyyy/MM/dd:");
                        record += DateTime.Now.ToString("HH:mm:ss") + "-失敗" + ",";
                    }
                    else if (p == 1 && k == 1)
                    {

                        record += DateTime.Now.ToString("yyyy/MM/dd:");
                        record += DateTime.Now.ToString("HH:mm:ss") + "-失敗";
                    }
                    else if (p == progressBar1.Maximum)
                    {
                        record += DateTime.Now.ToString("HH:mm:ss") + "-失敗";
                    }
                    else
                    {
                        record += DateTime.Now.ToString("HH:mm:ss") + "-失敗" + ",";
                    }
                    String[] x = record.Split('\n');
                    if (x.Length == 8)//到第八個
                    {
                        x[0] = null;//清空最舊資料

                        record = null;
                        for (int i = 1; i <= 7; i++)//保留七天
                        {
                            if (i == 7)
                            {
                                record += x[i];
                            }
                            else
                            {

                                record += x[i] + "\n";
                            }
                        }
                    }
                    textBox2.Text = null;
                    button2.Enabled = false;
                    WindowsFormsApp12.Properties.Settings.Default.Record = record;
                    WindowsFormsApp12.Properties.Settings.Default.Save();
                }
            }
            if (DateTime.Now.ToString("HHmmss").Equals("000000"))//12點若未簽完自動歸零
            {

                textBox2.Text = null;
                if (p != 0)
                {
                    record += "\n";
                }

                p = 0;
                progressBar1.Value = p;
                this.Show();
                this.WindowState = FormWindowState.Normal;
                MessageBox.Show("由於過12點點名完畢已重置!!");
                c = 0;
                time = null;
                Random r = new Random();
                for (int i = 1; i <= k; i++)
                {
                    time += Convert.ToString(r.Next(3)) + Convert.ToString(r.Next(4)) + Convert.ToString(r.Next(6)) + Convert.ToString(r.Next(10)) + Convert.ToString(r.Next(6)) + Convert.ToString(r.Next(10));
                    if (k != i)
                    {
                        time = time + ",";
                    }

                }
                label2.Text = time;
                sp = time.Split(',');

            }
            else if (DateTime.Now.ToString("HHmmss").Equals("000000") && p != k && k != 0)
            {
                record += "\n";

            }
            for (int i = 0; i < k; i++)
            {
                if (DateTime.Now.ToString("HHmmss").Equals(sp[i]))
                {
                  
                    timej = DateTime.Now.ToString("HHmmss");
                    c++;
                    this.Show();
                    this.WindowState = FormWindowState.Normal;
                    kill = 1;
                    StartKiller();
                    DialogResult key = MessageBox.Show("可進行" + "第" + c + "次點名", "提醒", MessageBoxButtons.OK);
                    timer.Enabled = false;

                    button2.Enabled = true;




                }

            }
        }

        private void button1_Click(object sender, EventArgs e)
        {

            MessageBox.Show(record);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals(label4.Text) && p != progressBar1.Maximum && textBox1.ReadOnly == true)
            {

                p++;
                kill = 2;
                StartKiller();
                MessageBox.Show("點名成功", "成功", MessageBoxButtons.OK);
                timer.Enabled = false;
                progressBar1.Value = p;
                if (p == progressBar1.Maximum)
                {
                    MessageBox.Show("今日已點名完成");
                }
                Random r = new Random();
                label4.Text = Convert.ToString(r.Next(1000, 10000));
                WindowState = FormWindowState.Minimized;
                if (p == 1 && k != 1)
                {

                    record += DateTime.Now.ToString("yyyy/MM/dd:");
                    record += DateTime.Now.ToString("HH:mm:ss") + "-成功" + ",";
                }
                else if (p == 1 && k == 1)
                {

                    record += DateTime.Now.ToString("yyyy/MM/dd:");
                    record += DateTime.Now.ToString("HH:mm:ss") + "-成功";
                }
                else if (p == progressBar1.Maximum)
                {
                    record += DateTime.Now.ToString("HH:mm:ss") + "-成功";
                }
                else
                {
                    record += DateTime.Now.ToString("HH:mm:ss") + "-成功" + ",";
                }
                String[] x = record.Split('\n');
                if (x.Length == 8)//到第八個
                {
                    x[0] = null;//清空最舊資料

                    record = null;
                    for (int i = 1; i <= 7; i++)//保留七天
                    {
                        if (i == 7)
                        {
                            record += x[i];
                        }
                        else
                        {

                            record += x[i] + "\n";
                        }
                    }
                }
                textBox2.Text = null;
                button2.Enabled = false;
                WindowsFormsApp12.Properties.Settings.Default.Record = record;
                WindowsFormsApp12.Properties.Settings.Default.Save();
            }


            else
            {
                MessageBox.Show("請檢查驗證碼");
            }
        }






        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            e.Cancel = true;
            WindowsFormsApp12.Properties.Settings.Default.times = textBox1.Text;
            WindowsFormsApp12.Properties.Settings.Default.Record = record;
            WindowsFormsApp12.Properties.Settings.Default.Save();
            WindowState = FormWindowState.Minimized;


        }

        private void button4_Click(object sender, EventArgs e)
        {
            textBox1.ReadOnly = false;
            button3.Enabled = true;
        }



        private void button6_Click(object sender, EventArgs e)
        {
            record += "\n";
        }

        private void button7_Click(object sender, EventArgs e)
        {
            if (c < k)
            {
                timej = DateTime.Now.ToString("HHmmss");
                c++;
                this.Show();
                this.WindowState = FormWindowState.Normal;
                kill = 1;
                StartKiller();
                DialogResult key = MessageBox.Show("可進行" + "第" + c + "次點名", "提醒", MessageBoxButtons.OK);
                timer.Enabled = false;

                button2.Enabled = true;
            }
        }

        private void button8_Click(object sender, EventArgs e)
        {
            textBox2.Text = null;
            if (p != 0)
            {
                record += "\n";
            }

            WindowsFormsApp12.Properties.Settings.Default.Record = record;
            WindowsFormsApp12.Properties.Settings.Default.Save();


            p = 0;
            progressBar1.Value = p;
            this.Show();
            this.WindowState = FormWindowState.Normal;
            MessageBox.Show("由於過12點點名完畢已重置!!");
            c = 0;
            time = null;
            Random r = new Random();
            for (int i = 1; i <= k; i++)
            {
                time += Convert.ToString(r.Next(3)) + Convert.ToString(r.Next(4)) + Convert.ToString(r.Next(6)) + Convert.ToString(r.Next(10)) + Convert.ToString(r.Next(6)) + Convert.ToString(r.Next(10));
                if (k != i)
                {
                    time = time + ",";
                }

            }
            label2.Text = time;
            sp = time.Split(',');

        }

        private void button9_Click(object sender, EventArgs e)
        {
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void button5_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show("已重置!!");
            WindowsFormsApp12.Properties.Settings.Default.times = null;
            WindowsFormsApp12.Properties.Settings.Default.Record = null;
            WindowsFormsApp12.Properties.Settings.Default.Save();
            System.Environment.Exit(System.Environment.ExitCode);
        }

        private void button10_Click(object sender, EventArgs e)
        {
            String getpassword = Interaction.InputBox("請輸入密碼", "密碼請求");
            if (getpassword == "123")
            {
                textBox1.ReadOnly = false;
                button3.Enabled = true;
            }
            else
            {
                MessageBox.Show("密碼錯誤!!");
            }
        }

        private void button11_Click(object sender, EventArgs e)
        {
            if ( p != progressBar1.Maximum && textBox1.ReadOnly == true && button2.Enabled == true)
            {

                p++;
                kill = 3;
                StartKiller();
                MessageBox.Show("點名失敗", "失敗", MessageBoxButtons.OK);
                timer.Enabled = false;
                progressBar1.Value = p;
                if (p == progressBar1.Maximum)
                {
                    MessageBox.Show("今日已點名結束");
                }
                Random r = new Random();
                label4.Text = Convert.ToString(r.Next(1000, 10000));
                WindowState = FormWindowState.Minimized;
                if (p == 1 && k != 1)
                {

                    record += DateTime.Now.ToString("yyyy/MM/dd:");
                    record += DateTime.Now.ToString("HH:mm:ss") + "-失敗" + ",";
                }
                else if (p == 1 && k == 1)
                {

                    record += DateTime.Now.ToString("yyyy/MM/dd:");
                    record += DateTime.Now.ToString("HH:mm:ss") + "-失敗";
                }
                else if (p == progressBar1.Maximum)
                {
                    record += DateTime.Now.ToString("HH:mm:ss") + "-失敗";
                }
                else
                {
                    record += DateTime.Now.ToString("HH:mm:ss") + "-失敗" + ",";
                }
                String[] x = record.Split('\n');
                if (x.Length == 8)//到第八個
                {
                    x[0] = null;//清空最舊資料

                    record = null;
                    for (int i = 1; i <= 7; i++)//保留七天
                    {
                        if (i == 7)
                        {
                            record += x[i];
                        }
                        else
                        {

                            record += x[i] + "\n";
                        }
                    }
                }
                textBox2.Text = null;
                button2.Enabled = false;
                WindowsFormsApp12.Properties.Settings.Default.Record = record;
                WindowsFormsApp12.Properties.Settings.Default.Save();
            }
        }
    }
}
