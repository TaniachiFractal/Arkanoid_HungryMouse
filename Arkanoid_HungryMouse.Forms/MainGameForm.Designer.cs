namespace Arkanoid_HungryMouse.Forms
{
    partial class MainGameForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainGameForm));
            this.InfoStrip = new System.Windows.Forms.ToolStrip();
            this.InfoLabel = new System.Windows.Forms.Label();
            this.GameField = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoStrip
            // 
            this.InfoStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.InfoStrip.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoStrip.Location = new System.Drawing.Point(0, 0);
            this.InfoStrip.Name = "InfoStrip";
            this.InfoStrip.Size = new System.Drawing.Size(750, 25);
            this.InfoStrip.TabIndex = 3;
            this.InfoStrip.Text = "toolStrip1";
            // 
            // InfoLabel
            // 
            this.InfoLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.InfoLabel.Location = new System.Drawing.Point(103, 35);
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(532, 65);
            this.InfoLabel.TabIndex = 5;
            this.InfoLabel.Text = "Чтобы начать или остановить игру, нажмите Enter\r\nЧтобы получить справку, нажмите " +
    "F1\r\n\r\n";
            this.InfoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // GameField
            // 
            this.GameField.BackgroundImage = global::Arkanoid_HungryMouse.Forms.Properties.Resources.gradientBG;
            this.GameField.Location = new System.Drawing.Point(0, 25);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(750, 750);
            this.GameField.TabIndex = 4;
            this.GameField.TabStop = false;
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 775);
            this.Controls.Add(this.InfoLabel);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.InfoStrip);
            this.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Голодная Мышь";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainGameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainGameForm_KeyUp);
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStrip InfoStrip;
        private System.Windows.Forms.PictureBox GameField;
        private System.Windows.Forms.Label InfoLabel;
    }
}
