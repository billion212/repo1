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
    public partial class Regis : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        public Regis()
        {
            InitializeComponent();
            comboBox1.Items.Add("男");
            comboBox1.Items.Add("女");
            comboBox2.Items.Add("行政人員");
            comboBox2.Items.Add("簽核人員");
            comboBox2.Items.Add("主管機關");
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
        }

        private void button2_Click(object sender, EventArgs e)
        {
            MS3 f1 = new MS3();
            this.Hide();
            f1.Show();
        }

        private void Regis_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                String t, g;
                if (comboBox1.SelectedIndex.Equals(0))
                {
                    t = "0";
                }
                else if (comboBox1.SelectedIndex.Equals(1))
                {
                    t = "1";
                }
                else
                {
                    t = "2";
                }
                if (comboBox2.SelectedIndex.Equals(0))
                {
                    g = "1";
                }
                else
                {
                    g = "0";
                }
                Account obj = new Account();
                obj.setACID(textBox1.Text);
                obj.setACPA(textBox2.Text);
                obj.setACname(textBox3.Text);
                obj.setACtype(t);
                obj.setACMP(textBox5.Text);
                obj.setACg(g);

                if (obj.Insertf(obj))
                {
                    MessageBox.Show("建立"+comboBox1.Text+":" + textBox1.Text + "成功");

                    textBox1.Text = "";
                    textBox2.Text = "";
                    textBox3.Text = "";
                    textBox5.Text = "";
                    comboBox2.Text = "";
                    comboBox1.Text = "";




                }
                else
                {
                    MessageBox.Show("建立" + comboBox1.Text + ":" + textBox1.Text + "失敗");
                }
                this.Close();

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }
    }
        }
    
