using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace test
{
    public partial class Theory : Form
    {
        public Theory()
        {
            InitializeComponent();
        }

        private void Theory_FormClosing(object sender, FormClosingEventArgs e)
        {
           
            
        }

        private void Theory_FormClosed(object sender, FormClosedEventArgs e)
        {
            Main main = new Main();
            main.load = true;
            main.Show();
        }

        private void Theory_Load(object sender, EventArgs e)
        {
            richTextBox5.LoadFile("текст/kaz.rtf");
            richTextBox1.LoadFile("текст/Мулан.rtf");
            richTextBox2.LoadFile("текст/Король лев.rtf");
            richTextBox3.LoadFile("текст/Вверх.rtf");
            richTextBox4.LoadFile("текст/Зверополис.rtf");
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox7_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox5_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
