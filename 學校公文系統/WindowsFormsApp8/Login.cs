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
    
    public partial class Login : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        String ACname,ACMP,ACg,ACtype;
        
        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        public Login()
        {
            InitializeComponent();
            comboBox1.Items.Add("行政人員");
            comboBox1.Items.Add("簽核人員");
            comboBox1.Items.Add("主管機關");
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";

        }
        void f_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            
            if (comboBox1.SelectedIndex.Equals(0))
            {
                Account objac = new Account();
                objac = objac.Retrieveac(textBox1.Text);
                InfoFix f = new InfoFix();
                
                
                if (textBox2.Text.Equals(objac.getACPA()) && objac.getACtype().Equals("0"))
                {
                    ACname = objac.getACname();
                    ACMP = objac.getACMP();
                    ACtype = "行政人員";
                    if (objac.getACg().Equals("1"))
                    {
                        ACg = "男性";
                    }
                    else
                    {
                        ACg = "女性";
                    }
                    MS1 lForm = new MS1();//實例化一個Form2窗口  
                    lForm.A = textBox1.Text;//設置Form2中string1的值  
                    lForm.SetValue();//設置Form2中Label1的  
                    lForm.FormClosing += new FormClosingEventHandler(f_FormClosing);
                    this.Hide();
                    lForm.Show();
                    MessageBox.Show("您好~" + ACname + "\n單位:" + ACtype + "\n性別:" + ACg + "\n行動電話:" + ACMP, "帳戶資訊",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("請檢查帳號或密碼是否正確", "密碼錯誤",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Question);
                }
            }
            else if (comboBox1.SelectedIndex.Equals(1))
            {
                Account objac = new Account();
                objac = objac.Retrieveac(textBox1.Text);

                if (textBox2.Text.Equals(objac.getACPA()) && objac.getACtype().Equals("1"))
                {
                    ACname = objac.getACname();
                    ACMP = objac.getACMP();
                    ACtype = "簽核人員";
                    if (objac.getACg().Equals("1"))
                    {
                        ACg = "男性";
                    }
                    else
                    {
                        ACg = "女性";
                    }
                    
                    MS2 lForm = new MS2();//實例化一個Form2窗口  
                    lForm.A = textBox1.Text;//設置Form2中string1的值  
                    lForm.SetValue();//設置Form2中Label1的  
                    lForm.FormClosing += new FormClosingEventHandler(f_FormClosing);
                    this.Hide();
                    lForm.Show();
                    MessageBox.Show("您好~" + ACname + "\n單位:" + ACtype + "\n性別:" + ACg + "\n行動電話:" + ACMP, "帳戶資訊",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("請檢查帳號或密碼是否正確", "密碼錯誤",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Question);
                }
            }
            else if (comboBox1.SelectedIndex.Equals(2))
            {
                Account objac = new Account();
                objac = objac.Retrieveac(textBox1.Text);

                if (textBox2.Text.Equals(objac.getACPA()) && objac.getACtype().Equals("2"))
                {
                    ACname = objac.getACname();
                    ACMP = objac.getACMP();
                    ACtype = "主管機關";
                    if (objac.getACg().Equals("1"))
                    {
                        ACg = "男性";
                    }
                    else
                    {
                        ACg = "女性";
                    }
                    MS3 lForm = new MS3();//實例化一個Form2窗口  
                    lForm.A = textBox1.Text;//設置Form2中string1的值  
                    lForm.SetValue();//設置Form2中Label1的  
                    lForm.FormClosing += new FormClosingEventHandler(f_FormClosing);
                    this.Hide();
                    lForm.Show();
                    MessageBox.Show("您好~" + ACname + "\n單位:" + ACtype + "\n性別:" + ACg + "\n行動電話:" + ACMP, "帳戶資訊",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Asterisk);
                }
                else
                {
                    MessageBox.Show("請檢查帳號或密碼是否正確", "密碼錯誤",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Question);
                }
            }
                }

            
            
        }
        
    }

