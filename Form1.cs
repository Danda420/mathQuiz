using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp2
{
    public partial class Form1 : Form
    {
        Random randomizer = new Random();

        int addend1;
        int addend2;
        int minuend;
        int subtrahend;
        int multiplicand;
        int multiplier;
        int dividend;
        int divisor;
        int timeLeft;

        public void mulaiKuis()
        {
            addend1 = randomizer.Next(51);
            addend2 = randomizer.Next(51);
            plusLeftLabel.Text = addend1.ToString();
            plusRightLabel.Text = addend2.ToString();
            jumlah.Value = 0;

            minuend = randomizer.Next(1, 101);
            subtrahend = randomizer.Next(1, minuend);
            minusLeftLabel.Text = minuend.ToString();
            minusRightLabel.Text = subtrahend.ToString();
            pengurangan.Value = 0;

            multiplicand = randomizer.Next(2, 11);
            multiplier = randomizer.Next(2, 11);
            timesLeftLabel.Text = multiplicand.ToString();
            timesRightLabel.Text = multiplier.ToString();
            perkalian.Value = 0;

            divisor = randomizer.Next(2, 11);
            int temporaryQuotient = randomizer.Next(2, 11);
            dividend = divisor * temporaryQuotient;
            dividedLeftLabel.Text = dividend.ToString();
            dividedRightLabel.Text = divisor.ToString();
            pembagian.Value = 0;

            timeLeft = 30;
            timeLabel.Text = "30 detik";
            timer1.Start();
        }

        private bool cekJawaban()
        {
            if ((addend1 + addend2 == jumlah.Value)
                && (minuend - subtrahend == pengurangan.Value)
                && (multiplicand * multiplier == perkalian.Value)
                && (dividend / divisor == pembagian.Value))
                return true;
            else
                return false;
        }

        private void timer1_Tick_1(object sender, EventArgs e)
        {
            if (cekJawaban())
            {
                timer1.Stop();
                MessageBox.Show("Selemat, Semuanya bena r!");
                startButton.Enabled = true;
            }
            else if (timeLeft > 0)
            {
                timeLeft = timeLeft - 1;
                timeLabel.Text = timeLeft + " detik";
            }
            else
            {
                timer1.Stop();
                timeLabel.Text = "Waktu habis!";
                MessageBox.Show("Maaf, anda tidak menyelesaikan nya tepat waktu");
                jumlah.Value = addend1 + addend2;
                pengurangan.Value = minuend - subtrahend;
                perkalian.Value = multiplicand * multiplier;
                pembagian.Value = dividend / divisor;
                startButton.Enabled = true;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }

        private void startButton_Click(object sender, EventArgs e)
        {
            mulaiKuis();
            startButton.Enabled = false;
        }

        private void answer_Enter(object sender, EventArgs e)
        {
            NumericUpDown answerBox = sender as NumericUpDown;

            if (answerBox != null)
            {
                int lengthOfAnswer = answerBox.Value.ToString().Length;
                answerBox.Select(0, lengthOfAnswer);
            }
        }
    }
}
