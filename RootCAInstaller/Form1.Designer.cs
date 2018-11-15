namespace RootCAInstaller
{
    partial class Form1
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
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.lbIssuedBy = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.lbSerial = new System.Windows.Forms.Label();
            this.lbThumbprint = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.lbValidTo = new System.Windows.Forms.Label();
            this.lbValidFrom = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPK = new System.Windows.Forms.TextBox();
            this.lbInformation = new System.Windows.Forms.Label();
            this.lbIssuedTo = new System.Windows.Forms.Label();
            this.btnBrowser = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::RootCAInstaller.Properties.Resources.Logo;
            this.pictureBox1.InitialImage = global::RootCAInstaller.Properties.Resources.Logo;
            this.pictureBox1.Location = new System.Drawing.Point(9, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(45, 36);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(75, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(168, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Certificate Information";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(12, 52);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Issued to:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(10, 156);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 13);
            this.label3.TabIndex = 3;
            this.label3.Text = "Issued by:";
            // 
            // lbIssuedBy
            // 
            this.lbIssuedBy.AutoSize = true;
            this.lbIssuedBy.Location = new System.Drawing.Point(81, 156);
            this.lbIssuedBy.MaximumSize = new System.Drawing.Size(213, 0);
            this.lbIssuedBy.Name = "lbIssuedBy";
            this.lbIssuedBy.Size = new System.Drawing.Size(25, 13);
            this.lbIssuedBy.TabIndex = 7;
            this.lbIssuedBy.Text = "___";
            // 
            // btnImport
            // 
            this.btnImport.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnImport.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnImport.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnImport.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnImport.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnImport.Location = new System.Drawing.Point(197, 494);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 23);
            this.btnImport.TabIndex = 10;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.Location = new System.Drawing.Point(32, 191);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(43, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "Serial:";
            // 
            // lbSerial
            // 
            this.lbSerial.AutoSize = true;
            this.lbSerial.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbSerial.Location = new System.Drawing.Point(81, 191);
            this.lbSerial.MaximumSize = new System.Drawing.Size(213, 0);
            this.lbSerial.Name = "lbSerial";
            this.lbSerial.Size = new System.Drawing.Size(25, 13);
            this.lbSerial.TabIndex = 13;
            this.lbSerial.Text = "___";
            // 
            // lbThumbprint
            // 
            this.lbThumbprint.AutoSize = true;
            this.lbThumbprint.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbThumbprint.Location = new System.Drawing.Point(81, 219);
            this.lbThumbprint.MaximumSize = new System.Drawing.Size(213, 0);
            this.lbThumbprint.Name = "lbThumbprint";
            this.lbThumbprint.Size = new System.Drawing.Size(25, 13);
            this.lbThumbprint.TabIndex = 15;
            this.lbThumbprint.Text = "___";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.Location = new System.Drawing.Point(1, 219);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(74, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "Thumbprint:";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.Location = new System.Drawing.Point(4, 257);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(71, 13);
            this.label10.TabIndex = 16;
            this.label10.Text = "Public Key:";
            // 
            // lbValidTo
            // 
            this.lbValidTo.AutoSize = true;
            this.lbValidTo.Location = new System.Drawing.Point(185, 383);
            this.lbValidTo.Name = "lbValidTo";
            this.lbValidTo.Size = new System.Drawing.Size(25, 13);
            this.lbValidTo.TabIndex = 21;
            this.lbValidTo.Text = "___";
            // 
            // lbValidFrom
            // 
            this.lbValidFrom.AutoSize = true;
            this.lbValidFrom.Location = new System.Drawing.Point(75, 383);
            this.lbValidFrom.Name = "lbValidFrom";
            this.lbValidFrom.Size = new System.Drawing.Size(25, 13);
            this.lbValidFrom.TabIndex = 20;
            this.lbValidFrom.Text = "___";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.Location = new System.Drawing.Point(161, 383);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(18, 13);
            this.label5.TabIndex = 19;
            this.label5.Text = "to";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(6, 383);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(63, 13);
            this.label4.TabIndex = 18;
            this.label4.Text = "Valid from";
            // 
            // txtPK
            // 
            this.txtPK.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.txtPK.Location = new System.Drawing.Point(84, 257);
            this.txtPK.Multiline = true;
            this.txtPK.Name = "txtPK";
            this.txtPK.ReadOnly = true;
            this.txtPK.ScrollBars = System.Windows.Forms.ScrollBars.Horizontal;
            this.txtPK.Size = new System.Drawing.Size(213, 107);
            this.txtPK.TabIndex = 22;
            this.txtPK.Text = "___";
            // 
            // lbInformation
            // 
            this.lbInformation.AutoSize = true;
            this.lbInformation.Location = new System.Drawing.Point(81, 52);
            this.lbInformation.MaximumSize = new System.Drawing.Size(213, 0);
            this.lbInformation.Name = "lbInformation";
            this.lbInformation.Size = new System.Drawing.Size(25, 13);
            this.lbInformation.TabIndex = 23;
            this.lbInformation.Text = "___";
            // 
            // lbIssuedTo
            // 
            this.lbIssuedTo.AutoSize = true;
            this.lbIssuedTo.Location = new System.Drawing.Point(272, 478);
            this.lbIssuedTo.MaximumSize = new System.Drawing.Size(186, 0);
            this.lbIssuedTo.Name = "lbIssuedTo";
            this.lbIssuedTo.Size = new System.Drawing.Size(25, 13);
            this.lbIssuedTo.TabIndex = 6;
            this.lbIssuedTo.Text = "___";
            // 
            // btnBrowser
            // 
            this.btnBrowser.FlatAppearance.BorderColor = System.Drawing.Color.Gray;
            this.btnBrowser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Gray;
            this.btnBrowser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Gray;
            this.btnBrowser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnBrowser.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnBrowser.Location = new System.Drawing.Point(197, 465);
            this.btnBrowser.Name = "btnBrowser";
            this.btnBrowser.Size = new System.Drawing.Size(100, 23);
            this.btnBrowser.TabIndex = 24;
            this.btnBrowser.Text = "Browser";
            this.btnBrowser.UseVisualStyleBackColor = true;
            this.btnBrowser.Click += new System.EventHandler(this.btnBrowser_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.HighlightText;
            this.ClientSize = new System.Drawing.Size(309, 529);
            this.Controls.Add(this.btnBrowser);
            this.Controls.Add(this.lbInformation);
            this.Controls.Add(this.txtPK);
            this.Controls.Add(this.lbValidTo);
            this.Controls.Add(this.lbValidFrom);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.lbThumbprint);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.lbSerial);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.btnImport);
            this.Controls.Add(this.lbIssuedBy);
            this.Controls.Add(this.lbIssuedTo);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.pictureBox1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ForeColor = System.Drawing.SystemColors.WindowText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Icon = global::RootCAInstaller.Properties.Resources.certificate;
            this.Name = "Form1";
            this.Text = "Root CA Installer";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lbIssuedBy;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label lbSerial;
        private System.Windows.Forms.Label lbThumbprint;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label lbValidTo;
        private System.Windows.Forms.Label lbValidFrom;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPK;
        private System.Windows.Forms.Label lbInformation;
        private System.Windows.Forms.Label lbIssuedTo;
        private System.Windows.Forms.Button btnBrowser;
    }
}

