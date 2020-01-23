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
    public partial class Update : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        public Update()
        {

            InitializeComponent();
            textBox2.AutoSize = false;
            textBox2.Height = 100;
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Equals("") || textBox2.Text.Equals(""))
            {
                MessageBox.Show("標題或內容不可為空", "錯誤" );
            }
            else
            {
                DialogResult result = MessageBox.Show("請仔細檢查內容決定是否送出", "送出確認",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {

                   
                    try
                    {

                        UpFile objfile = new UpFile();
                        objfile.SetFileTitle(textBox1.Text);
                        objfile.SetFileContent(textBox2.Text);
                        objfile.SetUpD(Convert.ToString(DateTime.Today));
                        objfile.SetUpT(DateTime.Now.ToString("HH:mm ss tt"));

                        if (objfile.InsertUpFile(objfile))
                        {
                            MessageBox.Show("已成功送出公文:"+textBox1.Text+"\n" + "送出時間:" + Convert.ToString(DateTime.Now), "送出結果"
                                    );

                           textBox1.Text = "";
                            textBox2.Text = "";
                            

                          
                            

                        }
                        else
                        {
                            MessageBox.Show("送出公文:" + textBox1.Text + "失敗");
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

        private void Update_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }
    }
}
