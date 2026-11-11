namespace tabletLocal
{
    partial class qrInicio
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            imgQr = new PictureBox();
            timerQr = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)imgQr).BeginInit();
            SuspendLayout();
            // 
            // imgQr
            // 
            imgQr.Location = new Point(55, 33);
            imgQr.Name = "imgQr";
            imgQr.Size = new Size(386, 308);
            imgQr.TabIndex = 0;
            imgQr.TabStop = false;
            // 
            // qrInicio
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(512, 363);
            Controls.Add(imgQr);
            MaximizeBox = false;
            MinimizeBox = false;
            Name = "qrInicio";
            StartPosition = FormStartPosition.CenterScreen;
            ((System.ComponentModel.ISupportInitialize)imgQr).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox imgQr;
        private System.Windows.Forms.Timer timerQr;
    }
}
