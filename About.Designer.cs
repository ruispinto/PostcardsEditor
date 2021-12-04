
namespace PostcardsEditor
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.btn_closeAbout = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbl_softwareVersion = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_closeAbout
            // 
            this.btn_closeAbout.BackColor = System.Drawing.Color.Silver;
            this.btn_closeAbout.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_closeAbout.ForeColor = System.Drawing.Color.Black;
            this.btn_closeAbout.Location = new System.Drawing.Point(164, 347);
            this.btn_closeAbout.Name = "btn_closeAbout";
            this.btn_closeAbout.Size = new System.Drawing.Size(118, 28);
            this.btn_closeAbout.TabIndex = 13;
            this.btn_closeAbout.Text = "&Close";
            this.btn_closeAbout.UseVisualStyleBackColor = false;
            this.btn_closeAbout.UseWaitCursor = true;
            this.btn_closeAbout.Click += new System.EventHandler(this.btn_closeAbout_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(126, 201);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(186, 19);
            this.label5.TabIndex = 11;
            this.label5.Text = "Database engine: MySQL™";
            this.label5.UseWaitCursor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(21, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(395, 19);
            this.label4.TabIndex = 10;
            this.label4.Text = "Technology used: C#, .Net™ Framework, MySQL™, EPPlus™";
            this.label4.UseWaitCursor = true;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(118, 103);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(210, 19);
            this.label3.TabIndex = 9;
            this.label3.Text = "© Copyright 2021 by Rui Pinto";
            this.label3.UseWaitCursor = true;
            // 
            // lbl_softwareVersion
            // 
            this.lbl_softwareVersion.AutoSize = true;
            this.lbl_softwareVersion.Font = new System.Drawing.Font("Microsoft Tai Le", 11F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbl_softwareVersion.Location = new System.Drawing.Point(113, 69);
            this.lbl_softwareVersion.Name = "lbl_softwareVersion";
            this.lbl_softwareVersion.Size = new System.Drawing.Size(62, 19);
            this.lbl_softwareVersion.TabIndex = 8;
            this.lbl_softwareVersion.Text = "Version ";
            this.lbl_softwareVersion.UseWaitCursor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 16F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(296, 26);
            this.label1.TabIndex = 7;
            this.label1.Text = "Postcards Database Editor";
            this.label1.UseWaitCursor = true;
            // 
            // label6
            // 
            this.label6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(184)))), ((int)(((byte)(184)))), ((int)(((byte)(184)))));
            this.label6.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 7F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.label6.Location = new System.Drawing.Point(42, 265);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(363, 48);
            this.label6.TabIndex = 14;
            this.label6.Text = "Disclaimer: All wrtiten code is open source and can be accessed through  github a" +
    "nd can be modified freely. The only part that isn\'t correct is the login usernam" +
    "e and password, for obvious reasons.";
            this.label6.UseWaitCursor = true;
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.ClientSize = new System.Drawing.Size(449, 399);
            this.ControlBox = false;
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btn_closeAbout);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lbl_softwareVersion);
            this.Controls.Add(this.label1);
            this.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "About";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "About";
            this.UseWaitCursor = true;
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_closeAbout;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbl_softwareVersion;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label6;
    }
}