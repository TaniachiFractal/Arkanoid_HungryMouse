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
            this.TopStrip = new System.Windows.Forms.ToolStrip();
            this.InfoButton = new System.Windows.Forms.ToolStripButton();
            this.GameField = new System.Windows.Forms.PictureBox();
            this.LabelHowToStart = new System.Windows.Forms.Label();
            this.InfoStrip = new System.Windows.Forms.ToolStrip();
            this.TopStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.SuspendLayout();
            // 
            // TopStrip
            // 
            this.TopStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.TopStrip.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.TopStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoButton});
            this.TopStrip.Location = new System.Drawing.Point(0, 0);
            this.TopStrip.Name = "TopStrip";
            this.TopStrip.Size = new System.Drawing.Size(750, 25);
            this.TopStrip.TabIndex = 0;
            this.TopStrip.Text = "toolStrip1";
            // 
            // InfoButton
            // 
            this.InfoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InfoButton.Image = global::Arkanoid_HungryMouse.Forms.Properties.Resources.help;
            this.InfoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(23, 22);
            this.InfoButton.Text = "Помощь";
            // 
            // GameField
            // 
            this.GameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameField.Image = global::Arkanoid_HungryMouse.Forms.Properties.Resources.gradientBG;
            this.GameField.Location = new System.Drawing.Point(0, 25);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(750, 750);
            this.GameField.TabIndex = 1;
            this.GameField.TabStop = false;
            // 
            // LabelHowToStart
            // 
            this.LabelHowToStart.AutoSize = true;
            this.LabelHowToStart.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.LabelHowToStart.Location = new System.Drawing.Point(122, 297);
            this.LabelHowToStart.Name = "LabelHowToStart";
            this.LabelHowToStart.Size = new System.Drawing.Size(521, 29);
            this.LabelHowToStart.TabIndex = 2;
            this.LabelHowToStart.Text = "Чтобы начать или остановить игру, нажмите Enter";
            // 
            // InfoStrip
            // 
            this.InfoStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.InfoStrip.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoStrip.Location = new System.Drawing.Point(0, 25);
            this.InfoStrip.Name = "InfoStrip";
            this.InfoStrip.Size = new System.Drawing.Size(750, 25);
            this.InfoStrip.TabIndex = 3;
            this.InfoStrip.Text = "toolStrip1";
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 775);
            this.Controls.Add(this.InfoStrip);
            this.Controls.Add(this.LabelHowToStart);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.TopStrip);
            this.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.Name = "MainGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Голодная Мышь";
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainGameForm_KeyDown);
            this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainGameForm_KeyUp);
            this.TopStrip.ResumeLayout(false);
            this.TopStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip TopStrip;
        private System.Windows.Forms.PictureBox GameField;
        private System.Windows.Forms.ToolStripButton InfoButton;
        private System.Windows.Forms.Label LabelHowToStart;
        private System.Windows.Forms.ToolStrip InfoStrip;
    }
}
