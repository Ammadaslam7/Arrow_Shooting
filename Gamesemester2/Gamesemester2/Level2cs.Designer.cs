
namespace Gamesemester2
{
    partial class Level2cs
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Level2cs));
            this.GameLoopTimer = new System.Windows.Forms.Timer(this.components);
            this.lbl_leftarrows = new System.Windows.Forms.Label();
            this.lbl_score = new System.Windows.Forms.Label();
            this.lbl_live = new System.Windows.Forms.Label();
            this.Arrowstoptimer = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // GameLoopTimer
            // 
            this.GameLoopTimer.Enabled = true;
            this.GameLoopTimer.Interval = 40;
            this.GameLoopTimer.Tick += new System.EventHandler(this.GameLoopTimer_Tick);
            // 
            // lbl_leftarrows
            // 
            this.lbl_leftarrows.AutoSize = true;
            this.lbl_leftarrows.BackColor = System.Drawing.Color.Silver;
            this.lbl_leftarrows.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_leftarrows.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_leftarrows.Location = new System.Drawing.Point(708, 9);
            this.lbl_leftarrows.Name = "lbl_leftarrows";
            this.lbl_leftarrows.Size = new System.Drawing.Size(52, 20);
            this.lbl_leftarrows.TabIndex = 1;
            this.lbl_leftarrows.Text = "Arrows";
            // 
            // lbl_score
            // 
            this.lbl_score.AutoSize = true;
            this.lbl_score.BackColor = System.Drawing.Color.Silver;
            this.lbl_score.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_score.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_score.Location = new System.Drawing.Point(708, 451);
            this.lbl_score.Name = "lbl_score";
            this.lbl_score.Size = new System.Drawing.Size(45, 20);
            this.lbl_score.TabIndex = 2;
            this.lbl_score.Text = "Score";
            // 
            // lbl_live
            // 
            this.lbl_live.AutoSize = true;
            this.lbl_live.BackColor = System.Drawing.Color.Silver;
            this.lbl_live.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.lbl_live.Font = new System.Drawing.Font("Arial Narrow", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_live.Location = new System.Drawing.Point(708, 407);
            this.lbl_live.Name = "lbl_live";
            this.lbl_live.Size = new System.Drawing.Size(42, 20);
            this.lbl_live.TabIndex = 3;
            this.lbl_live.Text = "Lives";
            // 
            // Arrowstoptimer
            // 
            this.Arrowstoptimer.Tick += new System.EventHandler(this.Arrowstoptimer_Tick);
            // 
            // Level2cs
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(823, 480);
            this.Controls.Add(this.lbl_live);
            this.Controls.Add(this.lbl_score);
            this.Controls.Add(this.lbl_leftarrows);
            this.DoubleBuffered = true;
            this.Name = "Level2cs";
            this.Text = "Level 2";
            this.Load += new System.EventHandler(this.Level2cs_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Timer GameLoopTimer;
        private System.Windows.Forms.Label lbl_leftarrows;
        private System.Windows.Forms.Label lbl_score;
        internal System.Windows.Forms.Label lbl_live;
        private System.Windows.Forms.Timer Arrowstoptimer;
    }
}