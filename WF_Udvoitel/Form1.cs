using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WF_Udvoitel
{
    public partial class form1 : Form
    {
        public form1()
        {
            InitializeComponent();
            btnCommand1.Text = "+1";
            btnCommand2.Text = "*2";
            btnReset.Text = "Сброс";
            lblNumber.Text = "0";
            btnStart.Text = "Играть";
            lblStart.Text = " ";
            lblCounter.Text = "0";
            text.Text = "Количество ходов";
            Congrats.Text = " ";
        }

        private void btnCommand1_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) + 1).ToString();
            lblCounter.Text = (int.Parse(lblCounter.Text) + 1).ToString();
        }

        private void btnCommand2_Click(object sender, EventArgs e)
        {
            lblNumber.Text = (int.Parse(lblNumber.Text) * 2).ToString();
            lblCounter.Text = (int.Parse(lblCounter.Text) + 1).ToString();
        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "1";
            lblCounter.Text = "0";
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblNumber.Text = "1";
            lblCounter.Text = "0";
            Random rnd = new Random();
            int value = rnd.Next(2, 4197);
            lblStart.Text = $"Получите число: {value}";
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            lblCounter.Text = (int.Parse(lblCounter.Text) + 1).ToString();
        }

        private void btnCheck_Click(object sender, EventArgs e) //почему-то не работает
        {
            if (lblNumber.Text == lblCounter.Text)
            {
                Congrats.Text = $"Поздравляем, у вас ушло {lblCounter.Text} попыток";
            }
        }
    }
}
