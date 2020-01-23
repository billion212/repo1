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

    public partial class MS1 : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        String temp,a;
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
        public MS1()
        {
            Login a1 = new Login();
            
            InitializeComponent();
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));


            label1.Text = "登入時間:"+Convert.ToString(DateTime.Now);
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            
            Update f3= new Update();
           
            
            f3.Show();
        }
      

        private void button4_Click(object sender, EventArgs e)
        {
            Login f1 = new Login();
            this.Hide();
            f1.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }

        private void button5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process f = new Process();
            f.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            

            InfoFix lForm = new InfoFix();//實例化一個Form2窗口  
            lForm.B = temp;//設置Form2中string1的值  
            lForm.SetValue();//設置Form2中Label1的  
           
            lForm.Show();
            


          
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form2 f1 = new Form2();

            f1.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Edit f2 = new Edit();
            
            f2.Show();
        }
    }
}
