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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
            btnStart.Text = "Начать";
            btnCheck.Text = "Проверить";
            lblGame.Text = " ";
            lblResult.Text = " ";
            lblCount.Text = "0";
            lblTest.Visible = false; //лейбл проверки записи из текстбокса
            lblNumber.Visible = false;  //лейбл проверки корректности рандома числа
        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            lblGame.Text = $"Попробуйте угадать число от 1 до 100";
            Random rnd = new Random();
            int value = rnd.Next(1, 100);
            lblNumber.Text = $"{value}";
        }

        private void tbGuess_TextChanged(object sender, EventArgs e)
        {
            lblTest.Text = tbGuess.Text;  
        }

        private void btnCheck_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(tbGuess.Text) == Convert.ToInt32(lblNumber.Text))
            {
                lblResult.Text = "Поздравляю, вы угадали";
            }
            else if (Convert.ToInt32(tbGuess.Text) > Convert.ToInt32(lblNumber.Text))
            {
                lblResult.Text = "Введённое число больше, попробуйте ещё раз";
            }
            else
            {
                lblResult.Text = "Введённое чилос мало, попробуйте ещё раз";
            }
        }
    }
}
