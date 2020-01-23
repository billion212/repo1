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
    public partial class Edit : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        public Edit()
        {
            InitializeComponent();
            textBox1.AutoSize = false;
            textBox1.Height = 150;
            textBox1.ReadOnly = true;
            textBox2.AutoSize = false;
            textBox2.Height = 150;
            comboBox1.Items.Add("審核中");
            comboBox1.Items.Add("退件");
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                UpFile u = new UpFile();
                u.SetFileNumber(comboBox2.Text);
                u.SetFileTitle(textBox3.Text);
                u.SetFileContent(textBox2.Text);
                u.SetFileStatus("0");

                if (u.UpfdateFileInfo(u))
                {
                    MessageBox.Show("更新公文編號:" + comboBox2.Text + "成功");
                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";





                }
                else
                {
                    MessageBox.Show("更新公文編號:" + comboBox2.Text + " 失敗");
                }


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            UpFile u2 = new UpFile();
            u2 = u2.Retrieveq(comboBox2.Text);
            textBox1.Text = u2.GetFileContent();
            label1.Text = "公文標題:" + u2.GetFileTitle();
            label6.Text = "需修改內容:" + u2.GetFFixContent();
            comboBox1.Text = "";
            comboBox2.Text = "";



        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex.Equals(0))
            {
                UpFile u = new UpFile();
                u.SetFileStatus("0");
                comboBox2.DataSource = u.retrieveAllFile();
                u = u.Retrieveq(comboBox2.Text);
                textBox1.Text = u.GetFileContent();
                
            }


            else
            {
                UpFile u = new UpFile();
                u.SetFileStatus("1");
                comboBox2.DataSource = u.retrieveAllFile();

                u = u.Retrieveq(comboBox2.Text);
                textBox1.Text = u.GetFileContent();
                

            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpFile u = new UpFile();
            u = u.Retrieveq(comboBox2.Text);
            textBox1.Text = u.GetFileContent();
            label1.Text = "公文標題:" + u.GetFileTitle();
            label6.Text = "需修改內容:" + u.GetFFixContent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            UpFile u = new UpFile();

            u.DeleteFile(comboBox2.Text);
            MessageBox.Show("刪除 " + comboBox2.Text + "成功");
            textBox1.Text = "";
            comboBox1.Text = "";
            comboBox2.Text = "";
            
            
           
            
        }

        private void Edit_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }
    }
}
