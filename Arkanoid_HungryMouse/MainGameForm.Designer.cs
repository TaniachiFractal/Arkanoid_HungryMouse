namespace Arkanoid_HungryMouse
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
            this.InfoLabel = new System.Windows.Forms.ToolStripLabel();
            this.InfoButton = new System.Windows.Forms.ToolStripButton();
            this.GameField = new System.Windows.Forms.PictureBox();
            this.InfoStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).BeginInit();
            this.SuspendLayout();
            // 
            // InfoStrip
            // 
            this.InfoStrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(196)))), ((int)(((byte)(227)))), ((int)(((byte)(222)))));
            this.InfoStrip.Font = new System.Drawing.Font("Comic Sans MS", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.InfoStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.InfoLabel,
            this.InfoButton});
            this.InfoStrip.Location = new System.Drawing.Point(0, 0);
            this.InfoStrip.Name = "InfoStrip";
            this.InfoStrip.Size = new System.Drawing.Size(750, 25);
            this.InfoStrip.TabIndex = 0;
            this.InfoStrip.Text = "toolStrip1";
            // 
            // InfoLabel
            // 
            this.InfoLabel.ForeColor = System.Drawing.Color.DarkSlateGray;
            this.InfoLabel.Name = "InfoLabel";
            this.InfoLabel.Size = new System.Drawing.Size(22, 22);
            this.InfoLabel.Text = "lb";
            // 
            // InfoButton
            // 
            this.InfoButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.InfoButton.Image = global::Arkanoid_HungryMouse.Properties.Resources.help;
            this.InfoButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.InfoButton.Name = "InfoButton";
            this.InfoButton.Size = new System.Drawing.Size(23, 22);
            this.InfoButton.Text = "Помощь";
            // 
            // GameField
            // 
            this.GameField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GameField.Location = new System.Drawing.Point(0, 25);
            this.GameField.Name = "GameField";
            this.GameField.Size = new System.Drawing.Size(750, 750);
            this.GameField.TabIndex = 1;
            this.GameField.TabStop = false;
            // 
            // MainGameForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 29F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(750, 775);
            this.Controls.Add(this.GameField);
            this.Controls.Add(this.InfoStrip);
            this.Font = new System.Drawing.Font("Comic Sans MS", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.Fixed3D;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(6, 7, 6, 7);
            this.MaximizeBox = false;
            this.Name = "MainGameForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Голодная Мышь";
            this.InfoStrip.ResumeLayout(false);
            this.InfoStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.GameField)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip InfoStrip;
        private System.Windows.Forms.PictureBox GameField;
        private System.Windows.Forms.ToolStripLabel InfoLabel;
        private System.Windows.Forms.ToolStripButton InfoButton;
    }
}
