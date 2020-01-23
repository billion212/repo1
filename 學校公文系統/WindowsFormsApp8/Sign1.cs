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
    public partial class Sign1 : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        public Sign1()
        {
            InitializeComponent();
            textBox2.AutoSize = false;
            textBox2.Height = 100;
            textBox2.ReadOnly = true;
            UpFile objsh = new UpFile();
            objsh.SetFileStatus("0");
            comboBox1.DataSource = objsh.retrieveAllFile();
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            MS2 f1 = new MS2();
            this.Hide();
            f1.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否確定退件此公文?", "退件確認",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            UpFile set = new UpFile();
            set.SetFFixContent(textBox1.Text);
            set.SetFileStatus("1");
            set.SetFileNumber(comboBox1.Text);

            if (result == DialogResult.Yes)
            {
                try
                {
                    if (set.UpfdateUpFile(set))
                    {
                        MessageBox.Show("已成功退件公文:" + set.GetFileNumber() + "\n" + "退件時間:" + Convert.ToString(DateTime.Now), "送出結果"
                                );

                        textBox1.Text = "";
                        textBox2.Text = "";





                    }
                    else
                    {
                        MessageBox.Show("退件公文:" + set.GetFileNumber() + "失敗");
                    }
                    this.Close();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void Sign1_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }

        private void button3_Click_1(object sender, EventArgs e)
        {

            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
           DialogResult result = MessageBox.Show("是否確定審核通過此公文?", "審核確認",
                                     MessageBoxButtons.YesNo,
                                     MessageBoxIcon.Question);
            UpFile set = new UpFile();
            set.SetFFixContent("無");
            set.SetFileStatus("2");
            set.SetFileNumber(comboBox1.Text);
            
            if (result == DialogResult.Yes)
            {
                try
                {
                    if (set.UpfdateUpFile(set))
                    {
                        MessageBox.Show("已成功審核公文:" + set.GetFileNumber() + "\n" + "審核時間:" + Convert.ToString(DateTime.Now), "送出結果"
                                );

                        
                        textBox2.Text = "";





                    }
                    else
                    {
                        MessageBox.Show("審核公文:" + set.GetFileNumber() + "失敗");
                    }
                    this.Close();
                }


                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
            }
            }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpFile objsh2 = new UpFile();
            objsh2 = objsh2.Retrieveq(comboBox1.Text);

            label3.Text = "公文標題:" + objsh2.GetFileTitle();
            textBox2.Text = objsh2.GetFileContent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
        }
    

