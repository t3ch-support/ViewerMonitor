namespace ViewerInterface
{
    partial class MainWindow
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
            this.txt_logger = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // txt_logger
            // 
            this.txt_logger.BackColor = System.Drawing.Color.Black;
            this.txt_logger.Dock = System.Windows.Forms.DockStyle.Fill;
            this.txt_logger.Font = new System.Drawing.Font("Consolas", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_logger.ForeColor = System.Drawing.Color.White;
            this.txt_logger.Location = new System.Drawing.Point(0, 0);
            this.txt_logger.Multiline = true;
            this.txt_logger.Name = "txt_logger";
            this.txt_logger.ReadOnly = true;
            this.txt_logger.Size = new System.Drawing.Size(223, 107);
            this.txt_logger.TabIndex = 2;
            this.txt_logger.Text = "Brea\r\nCalifornia\r\nUnited States\r\n1515826863.client";
            // 
            // MainWindow
            // 
            this.AccessibleName = "";
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(223, 107);
            this.Controls.Add(this.txt_logger);
            this.Font = new System.Drawing.Font("Courier New", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.Control;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainWindow";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "compusa.live";
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.MainWindow_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.TextBox txt_logger;
        
    }
}

