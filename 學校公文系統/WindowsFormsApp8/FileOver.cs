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
    public partial class FileOver : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        public FileOver()
        {
            InitializeComponent();
            textBox2.AutoSize = false;
            textBox2.Height = 100;
            textBox2.ReadOnly = true;
            UpFile objsh = new UpFile();
            objsh.SetFileStatus("2");
            comboBox1.DataSource = objsh.retrieveAllFile();
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));
        }

        private void FileOver_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否確定歸檔此公文?", "歸檔確認",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);
            UpFile set = new UpFile();
            set.SetFFixContent("無");
            set.SetFileStatus("3");
            set.SetFileNumber(comboBox1.Text); if (result == DialogResult.Yes)
            {
                try
                {
                    if (set.UpfdateUpFile(set))
                    {
                        MessageBox.Show("已成功歸檔公文:" + set.GetFileNumber() + "\n" + "歸檔時間:" + Convert.ToString(DateTime.Now), "送出結果"
                                );

                        
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

        private void button3_Click(object sender, EventArgs e)
        {
           
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpFile objsh2 = new UpFile();
            objsh2 = objsh2.Retrieveq(comboBox1.Text);

            label3.Text = "公文標題:" + objsh2.GetFileTitle();
            textBox2.Text = objsh2.GetFileContent();
        }
    }
}
