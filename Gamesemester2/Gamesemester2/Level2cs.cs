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

namespace Gamesemester2
{
    public partial class Level2cs : Form
    {
        bool enemyfire = true;
        int live = 2;
        PictureBox pb_player;
        PictureBox pb_arrow;
        PictureBox arrowadder1;
        PictureBox arrowSubtractor;
        PictureBox Envo1;
        PictureBox Envo2;
        PictureBox Protection;
        int protection_count = 0;
        ProgressBar Envo1bar;
        ProgressBar Envo2bar;
        ProgressBar player_health;
        ProgressBar enemy_health;
        PictureBox pb_enemy1;
        string enemy1Direction = "MoveUp";
        int total_arrows = 100;
        int score = 0;
        int duration = 30;
        List<PictureBox> enemy_fire = new List<PictureBox>();
        int enemy1_timetofire = 20;
        int enemy1_lasttofire = 0;

        public Level2cs()
        {
            InitializeComponent();
        }

        private void Level2cs_Load(object sender, EventArgs e)
        {
            arrow_stop_timer();
            createPlayer();
            createArrow();
            healthbar();
            arrowadder1 = createEnvironment(Properties.Resources.bolt_gold , this.Width - pb_player.Width, pb_player.Top);
            Controls.Add(arrowadder1);
            arrowSubtractor = createEnvironment(Properties.Resources.pill_red, this.Width - pb_player.Width + 20, pb_player.Top - 150);
            Controls.Add(arrowSubtractor);
            Envo1 = createEnvironmentwithbar(Properties.Resources.spikeBall1 , this.Width / 2, pb_player.Top + 100, ref Envo1bar) ;
            Controls.Add(Envo1);
            Envo2 = createEnvironmentwithbar(Properties.Resources.cloud, this.Width / 2 , pb_player.Top + 100, ref Envo2bar);
            Controls.Add(Envo2);
            Protection = createEnvironment(Properties.Resources.shield_gold, this.Width / 2 + 150, pb_player.Top + 100);
            Controls.Add(Protection);
            pb_enemy1 = createEnvironment(Properties.Resources.enemy, this.Width/2 + 250, pb_player.Top - 150);
            Controls.Add(pb_enemy1);
            enemy_healthbar();

        }
        private void createPlayer()
        {
            pb_player = new PictureBox();
            Image player_image = Gamesemester2.Properties.Resources.idle;

            pb_player.Image = player_image;

            pb_player.Width = player_image.Width;
            pb_player.Height = player_image.Height;
            pb_player.BackColor = Color.Transparent;
            pb_player.Left = this.Width / 2 - 400;
            pb_player.Top = this.Height / 2;
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
        private void shoot()
        {
            pb_arrow.Left = pb_arrow.Left + 100;
            if (pb_arrow.Left > 600)
            {
                pb_player.Image = Properties.Resources.idle;
                pb_arrow.Image = Properties.Resources.arrow;
                pb_arrow.Top = pb_player.Top + 30;
            }

        }

        private PictureBox createfire(Image fireimage , PictureBox source)
        {
            PictureBox pb_fire = new PictureBox();
            pb_fire.Image = fireimage;
            pb_fire.Width = fireimage.Width;
            pb_fire.Height = fireimage.Height;
            pb_fire.BackColor = Color.Transparent;
            System.Drawing.Point firelocation;
            firelocation = new System.Drawing.Point();
            firelocation.X = source.Left + (source.Width / 2) - 5;
            firelocation.Y = source.Top;
            pb_fire.Location = firelocation;
            return pb_fire;

        }

        private void arrow_adders_subtractor_visual()
        {
            Random random = new Random();
            int p1x, p1y, p2x, p2y;
            if (arrowadder1.Left < 20)
            {
                arrowadder1.Left = this.Width - pb_player.Width;
                p1x = random.Next(800, 1100);
                p1y = random.Next(20, 350);
                arrowadder1.Location = new System.Drawing.Point(p1x, p1y);

            }
            if (arrowSubtractor.Left < 20)
            {
                arrowSubtractor.Left = this.Width - pb_player.Width;
                p2x = random.Next(800, 1100);
                p2y = random.Next(20, 350);
                arrowSubtractor.Location = new System.Drawing.Point(p2x, p2y);

            }
            if (protection_count == 320)
            {
                if (Protection.Left < 20)
                {
                    Protection.Left = this.Width - pb_player.Width;
                    p2x = random.Next(800, 1100);
                    p2y = random.Next(20, 350);
                    Protection.Location = new System.Drawing.Point(p2x, p2y);

                }
            }
            else
            {
                arrowadder1.Left = arrowadder1.Left - 10;
                arrowSubtractor.Left = arrowSubtractor.Left - 20;
                Protection.Left = Protection.Left - 5;
            }

        }

        private void total_arrow()
        {
            if (pb_player.Bounds.IntersectsWith(arrowadder1.Bounds))
            {
                arrowadder1.Left = 1000;
                total_arrows = total_arrows + 50;
            }
            if (pb_player.Bounds.IntersectsWith(arrowSubtractor.Bounds))
            {
                arrowSubtractor.Left = 1000;
                total_arrows = total_arrows - 100;
            }
            if (pb_player.Bounds.IntersectsWith(Protection.Bounds))
            {
                Protection.Left = 1000;
                enemyfire = false;
            }


        }
        private void dieenemy ()
        {
            if (pb_arrow.Bounds.IntersectsWith(pb_enemy1.Bounds))
            {
                if (enemy_health.Value > 0)

                { 

                    enemy_health.Value = enemy_health.Value - 2;
                }
                
                if (enemy_health.Value <= 0)
                {
                    score = score + 150;
                    pb_enemy1.Image = Properties.Resources.flash08;
                    enemy_health.Hide();
                    pb_enemy1.Hide();
                    enemyfire = false;
                }

            }

        }
        private PictureBox createEnvironment(Image Img, int Left, int top)
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
        private PictureBox createEnvironmentwithbar(Image Img, int Left, int top, ref ProgressBar BAR)
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

        private void Environment()
        {
            Random random = new Random();
            int a, b;
            if (Envo1.Top < 20)
            {
                Envo1.Top = this.Height / 2 + 100;
                a = random.Next(400, 600);
                Envo1.Location = new System.Drawing.Point(a, 500);
                Envo1bar.Location = new System.Drawing.Point(a, 500);

            }
            if (Envo2.Top < 20)
            {
                Envo2.Top = this.Height / 2 + 100;
                b = random.Next(200, 380);
                Envo2.Location = new System.Drawing.Point(b, 500);
                Envo2bar.Location = new System.Drawing.Point(b, 500);

            }

            else
            {
                Envo1.Top = Envo1.Top - 10;
                Envo1bar.Top = Envo1bar.Top - 10;
                Envo2.Top = Envo2.Top - 15;
                Envo2bar.Top = Envo2bar.Top - 15;

            }
        }
        private void game_score()
        {
            if (pb_arrow.Bounds.IntersectsWith(Envo1.Bounds))
            {
                Envo1bar.Value = Envo1bar.Value - 50;
                if (Envo1bar.Value == 0)
                {

                    Envo1.Top = 1000;
                    Envo1bar.Top = 1000;
                    score = score + 20;
                    pb_arrow.Image = Properties.Resources.Explosion;
                    Envo1bar.Value = 100;
                }

            }
            if (pb_arrow.Bounds.IntersectsWith(Envo2.Bounds))
            {
                Envo2bar.Value = Envo2bar.Value - 25;
                if (Envo2bar.Value == 0)
                {

                    Envo2.Top = 1000;
                    Envo2bar.Top = 1000;
                    score = score + 20;
                    pb_arrow.Image = Properties.Resources.Explosion;
                    Envo2bar.Value = 100;
                }

            }

        }

        private void enemy_score ()
        {
            foreach(PictureBox arrow in enemy_fire)
            {
                if (arrow.Bounds.IntersectsWith(pb_player.Bounds))
                {
                    if (player_health.Value > 0)
                    {
                        player_health.Value = player_health.Value - 10;
                        
                        
                    }
                    if (player_health.Value <= 0)
                    {

                        arrow.Image = Properties.Resources.flash08;
                        live--;
                        player_health.Value = 100;
                    }        
                }
            }
            
        }

        public void healthbar()
        {
            player_health = new ProgressBar();
            player_health.Left = pb_player.Left;
            player_health.Top = this.Height - (pb_player.Height) + 10 ;
            player_health.Width = pb_player.Width;
            player_health.Height = 10;
            player_health.Value = 100;
            this.Controls.Add(player_health);
        }
        public void enemy_healthbar()
        {
            enemy_health = new ProgressBar();
            enemy_health.Left = pb_enemy1.Left; 
            enemy_health.Top = this.Height - (pb_enemy1.Height) - 150 ;
            enemy_health.Width = pb_enemy1.Width;
            enemy_health.Height = 10;
            enemy_health.Value = 100;
            this.Controls.Add(enemy_health);
        }
        private void arrow_stop_timer()
        {
            Arrowstoptimer = new System.Windows.Forms.Timer();
            Arrowstoptimer.Tick += new EventHandler(count_down);
            Arrowstoptimer.Interval = 500;
            Arrowstoptimer.Start();

        }
        private void count_down(object sender, EventArgs e)
        {

            if (duration == 0)
            {
                Arrowstoptimer.Stop();
                enemyfire = true;

            }
            else if (duration > 0)
            {
                duration--;
            }
        }



        private void GameLoopTimer_Tick(object sender, EventArgs e)
        {
            protection_count++;
            if (Keyboard.IsKeyPressed(Key.UpArrow))
            {
                if (pb_player.Top > 10)
                {
                    pb_player.Top = pb_player.Top - 10;
                    player_health.Top = player_health.Top - 10;
                }

            }
            if (Keyboard.IsKeyPressed(Key.DownArrow))
            {

                if (pb_player.Top < 350)
                {
                    pb_player.Top = pb_player.Top + 10;
                    player_health.Top = player_health.Top + 10;
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
            if (enemy1Direction == "MoveUp")
            {
                pb_enemy1.Top = pb_enemy1.Top - 5;
                enemy_health.Top = enemy_health.Top - 5;
            }
            if (pb_enemy1.Top <= 0)
            {
                enemy1Direction = "MoveDown";
            }
            if ((pb_enemy1.Top + pb_enemy1.Height + 40) >= this.Height)
            {
                enemy1Direction = "MoveUp";
            }
            if (enemy1Direction == "MoveDown")
            {
                pb_enemy1.Top = pb_enemy1.Top + 5;
                enemy_health.Top = enemy_health.Top + 5;
            }
            enemy1_lasttofire++;
            if (enemyfire == true)
            {
                if (enemy1_lasttofire >= enemy1_timetofire)
                {
                    Image fireImage = Properties.Resources.enemy_arrow;
                    PictureBox pbfire = createfire(fireImage, pb_enemy1);
                    enemy_fire.Add(pbfire);
                    this.Controls.Add(pbfire);
                    enemy1_lasttofire = 0;
                }
                foreach (PictureBox arrows in enemy_fire)
                {
                    arrows.Left = arrows.Left - 50;
                }
                for (int idx = 0; idx < enemy_fire.Count; idx++)
                {

                    if (enemy_fire[idx].Left > this.Width)
                    {
                        enemy_fire.Remove(enemy_fire[idx]);
                    }
                }
            }
            


            shoot();
            arrow_adders_subtractor_visual();
            total_arrow();
            Environment();
            game_score();
            enemy_score();
            lbl_leftarrows.Text = "Arrows : " + total_arrows;
            lbl_score.Text = "Score :" + score;
            lbl_live.Text = "Lives : " + live;
            if (live == 0)
            {
                this.Close();
            }
            dieenemy();
            
        }

        private void Arrowstoptimer_Tick(object sender, EventArgs e)
        {

        }
    }
}
