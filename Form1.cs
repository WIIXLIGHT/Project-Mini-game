using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ЛБ6
{
    public partial class Form1 : Form
    {
        private bool lose = false;
        private int countCoins = 0;
        public Form1()
        {
            InitializeComponent();
            labelLose.Visible=false;
            btnRestart.Visible=false;
            KeyPreview = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(e.KeyChar == (char)Keys.Escape)
                this.Close();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            int speed = 15;
            bg1.Top += speed;
            bg2.Top += speed;

            int сarSpeed = 8;
            enemy1.Top += сarSpeed;
            enemy2.Top += сarSpeed;

            coin.Top += speed;

            if (bg1.Top >= 650)
            {
                bg1.Top = 0;
                bg2.Top = -650;
            }

            if (coin.Top >= 1024)
            {
                coin.Top = -60;
                Random random = new Random();
                coin.Left = random.Next(150, 800);
            }

            if (enemy1.Top >= 1024)
            {
                enemy1.Top = -180;
                Random random = new Random();
                enemy1.Left = random.Next(150, 300);
            }

            if (enemy2.Top >= 1024)
            {
                enemy2.Top = -300;
                Random random = new Random();
                enemy2.Left = random.Next(200, 800);
            }

            if (player.Bounds.IntersectsWith(enemy1.Bounds) || player.Bounds.IntersectsWith(enemy2.Bounds) )
            {
                timer.Enabled = false;
                labelLose.Visible = true;
                btnRestart.Visible = true;
                lose = true;
            }

            if (player.Bounds.IntersectsWith(coin.Bounds))
            {
                countCoins++;
                labelCoins.Text = "Монети: " + countCoins.ToString();
                coin.Top = -60;
                Random random = new Random();
                coin.Left = random.Next(150, 800);
            }

            
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if (lose) return;
            int speed = 10;
            if ((e.KeyCode == Keys.Left || e.KeyCode == Keys.A) && player.Left > 10)
                player.Left -= speed;
           else if ((e.KeyCode == Keys.Right || e.KeyCode == Keys.D) && player.Right < 1000)
                player.Left += speed;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnRestart_Click(object sender, EventArgs e)
        {
            enemy1.Top = -180;
            enemy2.Top = -300;
            labelLose.Visible = false;
            btnRestart.Visible = false;
            timer.Enabled = true;
            lose = false;
            countCoins = 0;
            labelCoins.Text = "Монети: 0" ;
            coin.Top = -500;

        }
    }
}
