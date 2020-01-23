using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp8
{
    public partial class InfoFix : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        private String b;
        public string B
        {
            set
            {
              b = value;
            }
        }

        public void SetValue()
        {
            this.textBox1.Text = b;
        }
        public InfoFix()
        {
           
            InitializeComponent();
            Account a = new Account();
            a = a.Retrieveac(b);
            textBox2.Text = "******";
            textBox3.Text = "******";
            textBox4.Text = "******";
            textBox5.Text = "******";
            textBox6.Text = "******";
            textBox1.ReadOnly = true;
            textBox2.ReadOnly = true;//
            textBox3.ReadOnly = true;
            textBox4.ReadOnly = true;
            textBox5.ReadOnly = true;
            textBox6.ReadOnly = true;
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));

        }

        private void InfoFix_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }
        

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)

        {
            Account a = new Account();
            a = a.Retrieveac(b);
            String t, g;
            if (a.GetType().Equals("0"))
            {
                t = "行政人員";
            }
            else if (a.GetType().Equals("0"))
            {
                t = "簽核人員";
            }
            else
            {
                t = "主管機關";
            }
            if (a.getACg().Equals("0"))
            {
                g = "女";
            }
            else
            {
                g = "男";
            }
            textBox2.Text = a.getACPA();
            textBox3.Text = a.getACname();
            textBox4.Text = t;
            textBox5.Text = a.getACMP();
            textBox6.Text = g;
            textBox2.ReadOnly = false;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Account a = new Account();
            a = a.Retrieveac(b);
            String t, g;
            if (a.GetType().Equals("0"))
            {
                t = "行政人員";
            }
            else if (a.GetType().Equals("0"))
            {
                t = "簽核人員";
            }
            else
            {
                t = "主管機關";
            }
            if (a.getACg().Equals("0"))
            {
                g = "女";
            }
            else
            {
                g = "男";
            }
            textBox2.Text = a.getACPA();
            textBox3.Text = a.getACname();
            textBox4.Text = t;
            textBox5.Text = a.getACMP();
            textBox6.Text = g;
            textBox5.ReadOnly = false;
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Account a = new Account();
            a = a.Retrieveac(b);
            String t, g;
            if (a.GetType().Equals("0"))
            {
                t = "行政人員";
            }
            else if (a.GetType().Equals("0"))
            {
                t = "簽核人員";
            }
            else
            {
                t = "主管機關";
            }
            if (a.getACg().Equals("0"))
            {
                g = "女";
            }
            else
            {
                g = "男";
            }
            textBox2.Text = a.getACPA();
            textBox3.Text = a.getACname();
            textBox4.Text = t;
            textBox5.Text = a.getACMP();
            textBox6.Text = g;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox2.Text.Equals("******"))
            {
                MessageBox.Show("請至少變更一個項目","錯誤提示",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else {
                try
                {
                    Account a = new Account();
                    a.setACID(textBox1.Text);
                    a.setACMP(textBox5.Text);
                    a.setACPA(textBox2.Text);
                    if (a.UpfdateACInfo(a))
                    {
                        MessageBox.Show("更新帳號:" + textBox1.Text + "成功");






                    }
                    else
                    {
                        MessageBox.Show("更新帳號:" + textBox1.Text + " 失敗");
                    }
                    this.Close();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            
        }
    }
  
}
