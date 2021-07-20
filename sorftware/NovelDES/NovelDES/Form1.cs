using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace NovelDES
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button_Select_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            if(dialog.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = dialog.FileName;
            }
        }

        private void button_jia_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请选择一个文件");
                return;
            }

            if (string.IsNullOrEmpty(textBox_mima.Text) || textBox_mima.Text.Length < 8)
            {
                MessageBox.Show("密码至少8位");
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(textBox1.Text);
            string filePath = Path.GetDirectoryName(textBox1.Text);
            string fileEx = Path.GetExtension(textBox1.Text);

            byte[] allData = File.ReadAllBytes(textBox1.Text);
            byte[] allEData = DESMgr.DESEncrypt(allData, textBox_mima.Text, "jianghao");
            File.WriteAllBytes(textBox1.Text + ".dddt", allEData);
            MessageBox.Show("完成");
        }

        private void button_jie_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text))
            {
                MessageBox.Show("请选择一个文件");
                return;
            }

            if (string.IsNullOrEmpty(textBox_mima.Text) || textBox_mima.Text.Length < 8)
            {
                MessageBox.Show("密码至少8位");
                return;
            }

            string fileName = Path.GetFileNameWithoutExtension(textBox1.Text);
            string filePath = Path.GetDirectoryName(textBox1.Text);
            string fileEx = Path.GetExtension(textBox1.Text);
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
