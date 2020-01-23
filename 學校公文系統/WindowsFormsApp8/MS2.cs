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
    public partial class MS2 : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        String a,temp;
        public string A
        {
            set
            {
                a = value;
            }
        }

        public void SetValue()
        {
            this.temp = a;
        }
        public MS2()
        {
            InitializeComponent();
            label1.Text = "登入時間:" + Convert.ToString(DateTime.Now);
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            this.Hide();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sign1 f1 = new Sign1();
            
            f1.Show();
        }

        private void MS2_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Sign2 f1 = new Sign2();

            f1.Show();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            InfoFix lForm = new InfoFix();//實例化一個Form2窗口  
            lForm.B = temp;//設置Form2中string1的值  
            lForm.SetValue();//設置Form2中Label1的  
           
            lForm.ShowDialog();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();

            f1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Process f = new Process();
            f.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
