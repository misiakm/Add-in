namespace RODO.UserForms
{
    partial class Informacja
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.Naglowek = new System.Windows.Forms.Label();
            this.Napis = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pic = new System.Windows.Forms.PictureBox();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Controls.Add(this.Naglowek);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(330, 32);
            this.panel1.TabIndex = 7;
            // 
            // Naglowek
            // 
            this.Naglowek.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Naglowek.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.Naglowek.Location = new System.Drawing.Point(12, 6);
            this.Naglowek.Name = "Naglowek";
            this.Naglowek.Size = new System.Drawing.Size(222, 24);
            this.Naglowek.TabIndex = 12;
            this.Naglowek.Text = "Czy arkusz $1 zawiera dane osobowe?";
            this.Naglowek.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Napis
            // 
            this.Napis.Location = new System.Drawing.Point(15, 200);
            this.Napis.Name = "Napis";
            this.Napis.Size = new System.Drawing.Size(303, 23);
            this.Napis.TabIndex = 10;
            this.Napis.Text = "$1 jest arkuszem wolnym";
            this.Napis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.button1.Font = new System.Drawing.Font("MS Office Symbol Semibold", 12F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.ForeColor = System.Drawing.SystemColors.Highlight;
            this.button1.Location = new System.Drawing.Point(0, 237);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(330, 39);
            this.button1.TabIndex = 11;
            this.button1.Text = "OK";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::RODO.Properties.Resources.AntHeap_logo_RGB;
            this.pictureBox2.Location = new System.Drawing.Point(281, 38);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(37, 35);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox2.TabIndex = 9;
            this.pictureBox2.TabStop = false;
            // 
            // pic
            // 
            this.pic.Image = global::RODO.Properties.Resources.Checked__10bd00_128px;
            this.pic.Location = new System.Drawing.Point(106, 59);
            this.pic.Name = "pic";
            this.pic.Size = new System.Drawing.Size(128, 121);
            this.pic.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pic.TabIndex = 8;
            this.pic.TabStop = false;
            // 
            // Informacja
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(330, 276);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Napis);
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.pic);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Informacja";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Informacja";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label Naglowek;
        private System.Windows.Forms.PictureBox pic;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.Label Napis;
        private System.Windows.Forms.Button button1;
    }
}