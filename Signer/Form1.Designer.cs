namespace Signer
{
    partial class Signer
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
            this.button1 = new System.Windows.Forms.Button();
            this.txtDocPath = new System.Windows.Forms.TextBox();
            this.txtCertPath = new System.Windows.Forms.TextBox();
            this.button2 = new System.Windows.Forms.Button();
            this.txtPass = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btnVerify = new System.Windows.Forms.Button();
            this.txtCertId = new System.Windows.Forms.TextBox();
            this.btnSign = new System.Windows.Forms.Button();
            this.btnSignEncrypt = new System.Windows.Forms.Button();
            this.btnVerifyDecrypt = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(301, 26);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Browser";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // txtDocPath
            // 
            this.txtDocPath.Location = new System.Drawing.Point(32, 27);
            this.txtDocPath.Name = "txtDocPath";
            this.txtDocPath.Size = new System.Drawing.Size(254, 20);
            this.txtDocPath.TabIndex = 1;
            // 
            // txtCertPath
            // 
            this.txtCertPath.Location = new System.Drawing.Point(32, 100);
            this.txtCertPath.Name = "txtCertPath";
            this.txtCertPath.Size = new System.Drawing.Size(254, 20);
            this.txtCertPath.TabIndex = 2;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(301, 100);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 23);
            this.button2.TabIndex = 3;
            this.button2.Text = "Browser";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // txtPass
            // 
            this.txtPass.Location = new System.Drawing.Point(32, 144);
            this.txtPass.Name = "txtPass";
            this.txtPass.Size = new System.Drawing.Size(176, 20);
            this.txtPass.TabIndex = 4;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Document path";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(32, 84);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Certificate path";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(32, 128);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(53, 13);
            this.label3.TabIndex = 7;
            this.label3.Text = "Password";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(28, 257);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(68, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Certificate ID";
            // 
            // btnVerify
            // 
            this.btnVerify.Location = new System.Drawing.Point(127, 320);
            this.btnVerify.Name = "btnVerify";
            this.btnVerify.Size = new System.Drawing.Size(81, 23);
            this.btnVerify.TabIndex = 9;
            this.btnVerify.Text = "Verify";
            this.btnVerify.UseVisualStyleBackColor = true;
            this.btnVerify.Click += new System.EventHandler(this.btnVerify_Click);
            // 
            // txtCertId
            // 
            this.txtCertId.Location = new System.Drawing.Point(28, 273);
            this.txtCertId.Name = "txtCertId";
            this.txtCertId.Size = new System.Drawing.Size(354, 20);
            this.txtCertId.TabIndex = 8;
            // 
            // btnSign
            // 
            this.btnSign.Location = new System.Drawing.Point(127, 192);
            this.btnSign.Name = "btnSign";
            this.btnSign.Size = new System.Drawing.Size(81, 23);
            this.btnSign.TabIndex = 11;
            this.btnSign.Text = "Sign";
            this.btnSign.UseVisualStyleBackColor = true;
            this.btnSign.Click += new System.EventHandler(this.btnSign_Click);
            // 
            // btnSignEncrypt
            // 
            this.btnSignEncrypt.Location = new System.Drawing.Point(233, 192);
            this.btnSignEncrypt.Name = "btnSignEncrypt";
            this.btnSignEncrypt.Size = new System.Drawing.Size(126, 23);
            this.btnSignEncrypt.TabIndex = 12;
            this.btnSignEncrypt.Text = "Sign && Encrypt";
            this.btnSignEncrypt.UseVisualStyleBackColor = true;
            this.btnSignEncrypt.Click += new System.EventHandler(this.btnSignEncrypt_Click);
            // 
            // btnVerifyDecrypt
            // 
            this.btnVerifyDecrypt.Location = new System.Drawing.Point(233, 320);
            this.btnVerifyDecrypt.Name = "btnVerifyDecrypt";
            this.btnVerifyDecrypt.Size = new System.Drawing.Size(126, 23);
            this.btnVerifyDecrypt.TabIndex = 13;
            this.btnVerifyDecrypt.Text = "Verify && Decrypt";
            this.btnVerifyDecrypt.UseVisualStyleBackColor = true;
            this.btnVerifyDecrypt.Click += new System.EventHandler(this.btnVerifyDecrypt_Click);
            // 
            // Signer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(406, 552);
            this.Controls.Add(this.btnVerifyDecrypt);
            this.Controls.Add(this.btnSignEncrypt);
            this.Controls.Add(this.btnSign);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.btnVerify);
            this.Controls.Add(this.txtCertId);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtPass);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.txtCertPath);
            this.Controls.Add(this.txtDocPath);
            this.Controls.Add(this.button1);
            this.Name = "Signer";
            this.Text = "Signer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox txtDocPath;
        private System.Windows.Forms.TextBox txtCertPath;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox txtPass;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnVerify;
        private System.Windows.Forms.TextBox txtCertId;
        private System.Windows.Forms.Button btnSign;
        private System.Windows.Forms.Button btnSignEncrypt;
        private System.Windows.Forms.Button btnVerifyDecrypt;
    }
}

