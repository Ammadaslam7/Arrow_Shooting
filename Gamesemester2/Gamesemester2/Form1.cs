using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EZInput;
using System.Threading;

namespace Gamesemester2
{
    public partial class Gamelvl1 : Form
    {
        
        PictureBox pb_player;
        PictureBox pb_arrow;
        PictureBox arrowadder1;
        PictureBox arrowadder2;
        PictureBox arrowadder3;
        PictureBox arrowSubtractor;
        PictureBox Envo1;
        PictureBox Envo2;
        PictureBox Envo3;
        PictureBox Envo4;
        ProgressBar Envo4bar;
        int total_arrows = 20;
        int score = 0;
        int duration = 60;

        
        public Gamelvl1()
        {
            InitializeComponent();
        }

        private void Gamelvl1_Load(object sender, EventArgs e)
        {
            timer();
            createPlayer();
            createArrow();
            arrowadder1 = createEnvironment(Properties.Resources.bronze_3, this.Width - pb_player.Width, pb_player.Top);
            Controls.Add(arrowadder1);
            arrowadder2 = createEnvironment(Properties.Resources.carrot, this.Width - pb_player.Width , pb_player.Top + 100);
            Controls.Add(arrowadder2);
            arrowadder3 = createEnvironment(Properties.Resources.gold_3, this.Width - pb_player.Width , pb_player.Top - 100);
            Controls.Add(arrowadder3);
            Envo1 = createEnvironment(Properties.Resources.flyMan_stand, this.Width / 2, pb_player.Top + 100);
            Controls.Add(Envo1);
            Envo2 = createEnvironment(Properties.Resources.wingMan1, this.Width / 2 + 50 , pb_player.Top + 50);
            Controls.Add(Envo2);
            Envo3 = createEnvironment(Properties.Resources.spikeMan_stand, this.Width / 2 + 70, pb_player.Top + 140);
            Controls.Add(Envo3);
            Envo4 = createEnvironmentwithbar(Properties.Resources.springMan_stand, this.Width / 2 + 80, pb_player.Top + 10 , ref Envo4bar);
            Controls.Add(Envo4);
            arrowSubtractor = createEnvironment(Properties.Resources.pill_red, this.Width - pb_player.Width + 20 , pb_player.Top - 150);
            Controls.Add(arrowSubtractor);

        }

        private void Gamelooptimer_Tick(object sender, EventArgs e)
        {
            if (duration > 0)
            {
                if (Keyboard.IsKeyPressed(Key.UpArrow))
                {
                    if (pb_player.Top > 10)
                    {
                        pb_player.Top = pb_player.Top - 10;
                    }

                }
                if (Keyboard.IsKeyPressed(Key.DownArrow))
                {

                    if (pb_player.Top < 350)
                    {
                        pb_player.Top = pb_player.Top + 10;
                    }

                }
                if (Keyboard.IsKeyPressed(Key.Space))
                {

                    if (total_arrows > 0)
                    {
                        pb_arrow.Left = pb_player.Left;
                        pb_player.Image = Properties.Resources.shoot;
                        total_arrows--;

                    }

                }
                shoot();
                arrow_adders_subtractor_visual();
                total_arrow();
                Environment();
                game_score();
                lbl_leftarrows.Text = "Arrows : " + total_arrows;
                lbl_score.Text = "Score :" + score;


            }
            if (score >= 100)
            {
                
                Level2cs Level2 = new Level2cs();
                Level2.Show();
                score = 0;
                this.Hide();

            }
            


        }
        private void createPlayer()
        {
            pb_player = new PictureBox();
            Image player_image = Gamesemester2.Properties.Resources.idle;
      
            pb_player.Image = player_image;

            pb_player.Width = player_image.Width;
            pb_player.Height = player_image.Height;
            pb_player.BackColor = Color.Transparent;
            pb_player.Left = this.Width/2 -400;
            pb_player.Top = this.Height/2;
            this.Controls.Add(pb_player);

        }
        private void createArrow()
        {
            pb_arrow = new PictureBox();
            Image arrow_image = Gamesemester2.Properties.Resources.arrow;

            pb_arrow.Image = arrow_image;

            pb_arrow.Width = arrow_image.Width;
            pb_arrow.Height = arrow_image.Height;
            pb_arrow.BackColor = Color.Transparent;
            pb_arrow.Left = pb_player.Left + pb_player.Width;
            pb_arrow.Top = this.Height / 2 + 30;
            this.Controls.Add(pb_arrow);

        }

        private void shoot ()
        {
            pb_arrow.Left = pb_arrow.Left + 100;
            if (pb_arrow.Left > 600)
            {
                pb_player.Image = Properties.Resources.idle;
                pb_arrow.Image = Properties.Resources.arrow;
                pb_arrow.Top = pb_player.Top + 30;
            }

        }

        private void arrow_adders_subtractor_visual()
        {
            Random random = new Random();
            int p1x , p1y , p2x , p2y , p3x , p3y ,p4x , p4y;
            if (arrowadder1.Left < 20 )
            {
                arrowadder1.Left = this.Width - pb_player.Width;
                p1x = random.Next(800, 1100);
                p1y = random.Next(20, 350);
                arrowadder1.Location = new System.Drawing.Point(p1x, p1y);

            }
            if (arrowadder2.Left < 20)
            {
                arrowadder2.Left = this.Width - pb_player.Width;
                p2x = random.Next(700, 1100);
                p2y = random.Next(20, 350);
                arrowadder2.Location = new System.Drawing.Point(p2x, p2y);

            }
            if (arrowadder3.Left < 20)
            {
                arrowadder3.Left = this.Width - pb_player.Width;
                p3x = random.Next(600, 1100);
                p3y = random.Next(20, 350);
                arrowadder3.Location = new System.Drawing.Point(p3x, p3y);

            }
            if (arrowSubtractor.Left < 20)
            {
                arrowSubtractor.Left = this.Width - pb_player.Width;
                p4x = random.Next(800, 1100);
                p4y = random.Next(20, 350);
                arrowSubtractor.Location = new System.Drawing.Point(p4x, p4y);

            }
            else
            {
                arrowadder1.Left = arrowadder1.Left - 10;
                arrowadder2.Left = arrowadder2.Left - 10;
                arrowadder3.Left = arrowadder3.Left - 10;
                arrowSubtractor.Left = arrowSubtractor.Left - 20;

            }

        }
        private void total_arrow ()
        {
            if (pb_player.Bounds.IntersectsWith(arrowadder1.Bounds))
            {
                arrowadder1.Left = 1000;
                total_arrows = total_arrows + 2;
            }
            if (pb_player.Bounds.IntersectsWith(arrowadder2.Bounds))
            {
                arrowadder2.Left = 1000;
                total_arrows = total_arrows + 5;
            }
            if (pb_player.Bounds.IntersectsWith(arrowadder3.Bounds))
            {
                arrowadder3.Left = 1000;
                total_arrows = total_arrows + 10;
            }
            if (pb_player.Bounds.IntersectsWith(arrowSubtractor.Bounds))
            {
                arrowSubtractor.Left = 1000;
                total_arrows = total_arrows - 30;
            }
        }
        private void game_score()
        {
            if (pb_arrow.Bounds.IntersectsWith(Envo1.Bounds))
            {
                Envo1.Top = 1000;
                score = score + 2;
                pb_arrow.Image = Properties.Resources.Explosion;
            }
            if (pb_arrow.Bounds.IntersectsWith(Envo2.Bounds))
            {
                Envo2.Top = 1000;
                score = score + 3;
                pb_arrow.Image = Properties.Resources.Explosion;
            }
            if (pb_arrow.Bounds.IntersectsWith(Envo3.Bounds))
            {
                Envo3.Top = 1000;
                score = score + 1;
                pb_arrow.Image = Properties.Resources.Explosion;
            }
            if (pb_arrow.Bounds.IntersectsWith(Envo4.Bounds))
            {
                Envo4bar.Value = Envo4bar.Value - 50;
                if (Envo4bar.Value == 0)
                {

                    Envo4.Top = 1000;
                    Envo4bar.Top = 1000;
                    score = score + 20;
                    pb_arrow.Image = Properties.Resources.Explosion;
                    Envo4bar.Value = 100;
                }
                
            }

        }

        private void Environment ()
        {
            Random random = new Random();
            int a , b , c , x;
            if (Envo1.Top < 20)
            {
                Envo1.Top = this.Height/2;
                a = random.Next(100, 500);
                Envo1.Location = new System.Drawing.Point(a, 500);

            }
            if (Envo2.Top < 20)
            {
                Envo2.Top = this.Height / 2 + 20;
                b = random.Next(200, 500);
                Envo2.Location = new System.Drawing.Point(b, 500);

            }
            if (Envo3.Top < 20)
            {
                Envo3.Top = this.Height / 2 + 60;
                c = random.Next(200, 500);
                Envo3.Location = new System.Drawing.Point(c, 500);

            }
            if (Envo4.Top < 20)
            {
                Envo4.Top = this.Height / 2 + 100;
                x = random.Next(200, 500);
                Envo4.Location = new System.Drawing.Point(x, 500);
                Envo4bar.Location = new System.Drawing.Point(x, 500);

            }
            else
            {
                Envo1.Top = Envo1.Top - 10;
                Envo2.Top = Envo2.Top - 15;
                Envo3.Top = Envo3.Top - 20;
                Envo4.Top = Envo4.Top - 10;
                Envo4bar.Top = Envo4bar.Top - 10;
            }
        }


         

        private PictureBox createEnvironment (Image Img , int Left , int top)
        {
            PictureBox pbEnvironment = new PictureBox();
            pbEnvironment.Left = Left;
            pbEnvironment.Top = top;
            pbEnvironment.Width = Img.Width;
            pbEnvironment.Height = Img.Height;
            pbEnvironment.Image = Img;
            pbEnvironment.BackColor = Color.Transparent;
            return pbEnvironment;

        }
        private PictureBox createEnvironmentwithbar(Image Img, int Left, int top , ref ProgressBar BAR)
        {
            BAR = new ProgressBar();
            BAR.Value = 100;
            PictureBox pbEnvironment = new PictureBox();
            pbEnvironment.Left = Left;
            BAR.Left = Left;
            pbEnvironment.Top = top;
            BAR.Top = this.Height - pbEnvironment.Height - 50;
            pbEnvironment.Width = Img.Width;
            BAR.Width = pbEnvironment.Width;
            pbEnvironment.Height = Img.Height;
            BAR.Height = 10;
            pbEnvironment.Image = Img;
            pbEnvironment.BackColor = Color.Transparent;
            Controls.Add(BAR);
            return pbEnvironment;

        }

        private void timer ()
        {
            Countdowntimer = new System.Windows.Forms.Timer();
            Countdowntimer.Tick += new EventHandler(count_down);
            Countdowntimer.Interval = 1000;
            Countdowntimer.Start();

        }
        private void count_down(object sender, EventArgs e)
        {

            if (duration == 0)
            {
                Countdowntimer.Stop();

            }
            else if (duration > 0)
            {
                duration--;
                lbl_count.Text = duration.ToString();
            }
        }
    }
}
