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
    public partial class Clear : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        public Clear()
        {
            InitializeComponent();
            textBox1.AutoSize = false;
            textBox1.Height = 150;
            textBox1.ReadOnly = true;
            UpFile u = new UpFile();
            u.SetFileStatus("3");
            comboBox1.DataSource = u.retrieveAllFile();
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpFile u = new UpFile();
            u = u.Retrieveq(comboBox1.Text);
            comboBox1.DataSource = u.retrieveAllFile();
            label1.Text = "公文標題:" + u.GetFileTitle();
            label2.Text = "上傳日期:" + u.GetUpD();
            label3.Text = "上傳時間:" + u.GetUpT();
            textBox1.Text = u.GetFileContent();
            


        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpFile u = new UpFile();

            u.DeleteFile(comboBox1.Text);
            MessageBox.Show("刪除 " + comboBox1.Text + "成功");
            textBox1.Text = "";
            comboBox1.Text = "";
            u.SetFileStatus("3");
            comboBox1.DataSource = u.retrieveAllFile();
        }

        private void button2_Click(object sender, EventArgs e)
        {
           
           
        }

        private void Clear_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }
    }
}
