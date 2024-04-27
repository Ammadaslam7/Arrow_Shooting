
namespace Gamesemester2
{
    partial class Gamelvl1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Gamelvl1));
            this.Gamelooptimer = new System.Windows.Forms.Timer(this.components);
            this.lbl_leftarrows = new System.Windows.Forms.Label();
            this.lbl_score = new System.Windows.Forms.Label();
            this.lbl_timer = new System.Windows.Forms.Label();
            this.Countdowntimer = new System.Windows.Forms.Timer(this.components);
            this.lbl_count = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Gamelooptimer
            // 
            this.Gamelooptimer.Enabled = true;
            this.Gamelooptimer.Interval = 60;
            this.Gamelooptimer.Tick += new System.EventHandler(this.Gamelooptimer_Tick);
            // 
            // lbl_leftarrows
            // 
            this.lbl_leftarrows.AutoSize = true;
            this.lbl_leftarrows.BackColor = System.Drawing.Color.Silver;
            this.lbl_leftarrows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_leftarrows.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_leftarrows.Location = new System.Drawing.Point(714, 9);
            this.lbl_leftarrows.Name = "lbl_leftarrows";
            this.lbl_leftarrows.Size = new System.Drawing.Size(52, 20);
            this.lbl_leftarrows.TabIndex = 0;
            this.lbl_leftarrows.Text = "Arrows";
            // 
            // lbl_score
            // 
            this.lbl_score.AutoSize = true;
            this.lbl_score.BackColor = System.Drawing.Color.Silver;
            this.lbl_score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_score.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_score.Location = new System.Drawing.Point(712, 422);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(52, 20);
            this.lbl_score.TabIndex = 1;
            this.lbl_score.Text = "Arrows";
            // 
            // lbl_timer
            // 
            this.lbl_timer.AutoSize = true;
            this.lbl_timer.BackColor = System.Drawing.Color.Silver;
            this.lbl_timer.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_timer.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_timer.Location = new System.Drawing.Point(711, 379);
            this.lbl_timer.Name = "lbl_timer";
            this.lbl_timer.Size = new System.Drawing.Size(0, 20);
            this.lbl_timer.TabIndex = 2;
            // 
            // lbl_count
            // 
            this.lbl_count.AutoSize = true;
            this.lbl_count.BackColor = System.Drawing.Color.Silver;
            this.lbl_count.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_count.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_count.Location = new System.Drawing.Point(723, 379);
            this.lbl_count.Name = "lbl_count";
            this.lbl_count.Size = new System.Drawing.Size(41, 20);
            this.lbl_count.TabIndex = 3;
            this.lbl_count.Text = "01:00";
            // 
            // Gamelvl1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(823, 480);
            this.Controls.Add(this.lbl_count);
            this.Controls.Add(this.lbl_timer);
            this.Controls.Add(this.lbl_score);
            this.Controls.Add(this.lbl_leftarrows);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.Color.Black;
            this.Name = "Gamelvl1";
            this.Text = "GameLevel1";
            this.Load += new System.EventHandler(this.Gamelvl1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer Gamelooptimer;
        private System.Windows.Forms.Label lbl_leftarrows;
        private System.Windows.Forms.Label lbl_score;
        private System.Windows.Forms.Label lbl_timer;
        private System.Windows.Forms.Timer Countdowntimer;
        private System.Windows.Forms.Label lbl_count;
    }
}

