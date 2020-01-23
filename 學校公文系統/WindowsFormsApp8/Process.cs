using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.InteropServices;

namespace WindowsFormsApp8
{
    public partial class Process : Form
    {
        private Sunisoft.IrisSkin.SkinEngine skinEngine;
        public Process()
        {
            InitializeComponent();
            FileQ objsh = new FileQ();

            comboBox1.DataSource = objsh.retrieveAllFile();
            System.ComponentModel.ComponentResourceManager resources = new
System.ComponentModel.ComponentResourceManager(typeof(Login));
            this.skinEngine = new
Sunisoft.IrisSkin.SkinEngine(((System.ComponentModel.Component)(this)));


        }

        private void Process_Load(object sender, EventArgs e)
        {
            this.skinEngine.SkinFile = "MacOS.ssk";
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpFile objsh2 = new UpFile();
            objsh2 = objsh2.Retrieveq(comboBox1.Text);
            
            label1.Text = "公文標題:" + objsh2.GetFileTitle();
            progressBar1.Maximum = 4;
            progressBar1.Value = Convert.ToInt32(objsh2.GetFileStatus()) + 1;
            ModifyProgressBarColor.SetState(progressBar1, 1);
            if (objsh2.GetFileStatus().Equals("0"))
            {
                label2.Text = "目前狀態:公文以上傳審核中";
            }
            else if (objsh2.GetFileStatus().Equals("1"))
            {
                ModifyProgressBarColor.SetState(progressBar1, 2);
                label2.Text = "目前狀態:公文被退件請修正";
            }
            else if (objsh2.GetFileStatus().Equals("2"))
            {
               
         
                label2.Text = "目前狀態:公文已通過待歸檔";
            }
            else if (objsh2.GetFileStatus().Equals("3"))
            {
               
                label2.Text = "目前狀態:公文已歸檔";
            }
            
            
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UpFile objsh = new UpFile();
            objsh = objsh.Retrieveq(comboBox1.Text);
            MessageBox.Show(objsh.GetFileContent(), "公文內容",
                                     MessageBoxButtons.OK,
                                     MessageBoxIcon.Asterisk);
        }

        private void progressBar1_Click(object sender, EventArgs e)
        {

        }
        
    }
}
