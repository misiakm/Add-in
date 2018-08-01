using System;

namespace RODO.UserForms
{
    partial class CzyOsobowe
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
            this.panel2 = new System.Windows.Forms.Panel();
            this.lb2 = new System.Windows.Forms.Label();
            this.Napis = new System.Windows.Forms.Label();
            this.btnTak = new System.Windows.Forms.Button();
            this.btnNie = new System.Windows.Forms.Button();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(418, 43);
            this.panel1.TabIndex = 6;
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.SystemColors.Highlight;
            this.panel2.Controls.Add(this.lb2);
            this.panel2.Location = new System.Drawing.Point(8, 7);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(228, 36);
            this.panel2.TabIndex = 7;
            // 
            // lb2
            // 
            this.lb2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.lb2.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.lb2.Location = new System.Drawing.Point(2, 3);
            this.lb2.Name = "lb2";
            this.lb2.Size = new System.Drawing.Size(222, 24);
            this.lb2.TabIndex = 11;
            this.lb2.Text = "Czy arkusz $1 zawiera dane osobowe?";
            this.lb2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // Napis
            // 
            this.Napis.Location = new System.Drawing.Point(9, 63);
            this.Napis.Name = "Napis";
            this.Napis.Size = new System.Drawing.Size(399, 52);
            this.Napis.TabIndex = 8;
            this.Napis.Text = "Czy arkusz $1 zawiera dane osobowe?";
            this.Napis.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // btnTak
            // 
            this.btnTak.BackColor = System.Drawing.SystemColors.Highlight;
            this.btnTak.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.btnTak.Location = new System.Drawing.Point(287, 129);
            this.btnTak.Name = "btnTak";
            this.btnTak.Size = new System.Drawing.Size(107, 31);
            this.btnTak.TabIndex = 9;
            this.btnTak.Text = "Tak";
            this.btnTak.UseVisualStyleBackColor = false;
            this.btnTak.Click += new System.EventHandler(this.btnTak_Click);
            // 
            // btnNie
            // 
            this.btnNie.BackColor = System.Drawing.SystemColors.Control;
            this.btnNie.ForeColor = System.Drawing.SystemColors.Highlight;
            this.btnNie.Location = new System.Drawing.Point(18, 129);
            this.btnNie.Name = "btnNie";
            this.btnNie.Size = new System.Drawing.Size(107, 31);
            this.btnNie.TabIndex = 10;
            this.btnNie.Text = "Nie";
            this.btnNie.UseVisualStyleBackColor = false;
            this.btnNie.Click += new System.EventHandler(this.btnNie_Click);
            // 
            // CzyOsobowe
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange;
            this.ClientSize = new System.Drawing.Size(418, 181);
            this.ControlBox = false;
            this.Controls.Add(this.btnNie);
            this.Controls.Add(this.btnTak);
            this.Controls.Add(this.Napis);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "CzyOsobowe";
            this.Text = "Dane osobowe";
            this.Load += new System.EventHandler(this.CzyOsobowe_Load);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }


        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Label Napis;
        private System.Windows.Forms.Button btnTak;
        private System.Windows.Forms.Button btnNie;
        private System.Windows.Forms.Label lb2;
    }
}