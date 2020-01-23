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
    public partial class Form2 : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        public Form2()
        {
            InitializeComponent();
            Account a = new Account();
            comboBox1.DataSource = a.retrieveAllFile();
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String t;
            Account a = new Account();
            a = a.RetrieveFN(comboBox1.Text);
            label1.Text ="電話號碼:"+ a.getACMP();
            if (a.getACtype().Equals("0"))
            {
                t = "行政人員";
            }
            else if (a.getACtype().Equals("1"))
            {
                t = "簽核人員";
            }
            else
            {
                t = "主管機關";
            }
            label3.Text = "所屬部門:" + t;


        }

        private void Form2_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }
    }
}
