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
    public partial class MS3 : Form
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
        
        public MS3()
        {
            InitializeComponent();
            label1.Text = "登入時間:" + Convert.ToString(DateTime.Now);
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Regis f1 = new Regis();
            
            f1.Show();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            this.Hide();
            f1.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FileOver f1 = new FileOver();
           
            f1.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            InfoFix lForm = new InfoFix();//實例化一個Form2窗口  
            lForm.B = temp;//設置Form2中string1的值  
            lForm.SetValue();//設置Form2中Label1的  
            
            lForm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();

            f1.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            Process f = new Process();
            f.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Clear c = new Clear();
            c.Show();
        }
    }
}
