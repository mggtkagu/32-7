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
    public partial class Test : Form
    {
        bool close = false;
        int time = 0;
        IniFile INI = new IniFile("quests.ini");
        int qnow = 0;
        const int n = 10;
        int[] answer = new int[n];
        public Test()
        {
            InitializeComponent();
            KeyPreview = true;
            for (int i = 0; i < n; i++)
                answer[i] = -1;
            label1.Text = INI.ReadINI("vopr","1");
            RB1.Checked = true;
            RB1.Checked = false;
        }

        private void Test_Load(object sender, EventArgs e)
        {
            
        }

        public void ButClick(int i)
        {
            qnow = i;
            label1.Text=INI.ReadINI("vopr", Convert.ToString(i+1));
            RB0.Checked = false;
            RB1.Checked = false;
            RB2.Checked = false;
            RB3.Checked = false;
            switch (answer[qnow])
            {
                case 0:
                    {
                        RB0.Checked = true;
                        break;
                    }
                case 1:
                    {
                        RB1.Checked = true;
                        break;
                    }
                case 2:
                    {
                        RB2.Checked = true;
                        break;
                    }
                case 3:
                    {
                        RB3.Checked = true;
                        break;
                    }
            }
        }
        private void Test_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (close == true)
            {
                timer1.Enabled = false;
                Main main = new Main();
                main.load = true;
                main.Show();
            }
            else
            if (DialogResult.Yes == MessageBox.Show("Вы уверены, что хотите прервать тестирование и вернуться на главное окно?", "Вернуть ся на главное окно", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                timer1.Enabled = false;
                Main main = new Main();
                main.load = true;
                main.Show();
            }
            else
                e.Cancel = true;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Next_Click(object sender, EventArgs e)
        {
            if (qnow != n-1)
            ButClick(qnow + 1);
        }

        private void Test_Shown(object sender, EventArgs e)
        {
            time = 600;
            timer1.Enabled = true;
            ButClick(qnow);
        }

        private void RB_Click(object sender, EventArgs e)
        {
            if (RB0.Checked == true) answer[qnow] = 0;
            if (RB1.Checked == true) answer[qnow] = 1;
            if (RB2.Checked == true) answer[qnow] = 2;
            if (RB3.Checked == true) answer[qnow] = 3;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int L = 0;
            bool all = true;
            string text = "";
            for (int i = 0; i < n; i++)
            {
                if (answer[i] == Convert.ToInt32(INI.ReadINI("otv", Convert.ToString(i+1)))) L++;
                if (answer[i] == -1) all = false;
            }
            if (time != 0)
            {
                if (all == false) text = "Вы ответили не на все вопросы, вы уверены, что хотите закончить тестирование?";
                else text = "Вы уверены, что хотите закончить тестирование?";
                if (MessageBox.Show(text, "Завершить тестирование", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    timer1.Enabled = false;
                    close = true;
                    if (L <= 3) text = "Вы не очень знаете сюжет, закрепите знания пересмотрев мультфильм...";
                    if (L > 3 && L <= 8) text = "Неплохо. Но, стоит больше обращать внимание на сюжет мультфильмов.";
                    if (L > 8) text = "Да вы Ас в диснеевских мультфильмах!!! Так держать!";
                    if (MessageBox.Show(L+" правильных из 9 "+text, "Результат", MessageBoxButtons.OK) == DialogResult.OK) Close();
                }
            }
            if (time == 0)
            {
                if (L <= 5) text = "Плохо";
                if (L > 5 && L <= 10) text = "Хорошо";
                if (L > 10) text = "Отлично";
                if (MessageBox.Show(text, "Результат", MessageBoxButtons.OK) == DialogResult.OK) Close();
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            time--;
            TimeSpan TS = new TimeSpan(0, 0, time);
            toolStripStatusLabel1.Text = ("Времени осталось: " + TS.ToString());
            if (time == 0)
            {
                timer1.Enabled = false;
                close = true;
                button1.PerformClick();
            }
        }

        private void toolStripStatusLabel1_Click(object sender, EventArgs e)
        {

        }

        private void timer2_Tick(object sender, EventArgs e)
        {
        }

        private void Test_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void Test_KeyPress(object sender, KeyPressEventArgs e)
        {
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (qnow != 0)
                ButClick(qnow - 1);
        }
    }
}
