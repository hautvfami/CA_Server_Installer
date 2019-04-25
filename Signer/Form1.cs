using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Signer
{
    public partial class Signer : Form
    {
        public Signer()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtDocPath.Text = fd.FileName;
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if (fd.ShowDialog() == DialogResult.OK)
            {
                txtCertPath.Text = fd.FileName;
            }
        }

        private void btnSign_Click(object sender, EventArgs e)
        {
            if (!signFieldNull())
            {
                byte[] data = File.ReadAllBytes(txtDocPath.Text);
                byte[] signedData = Utils.Sign(data, txtCertPath.Text, txtPass.Text);


                byte[] certid = Encoding.ASCII.GetBytes(getFileName(txtCertPath.Text));
                byte[] signature = new byte[signedData.Length + certid.Length];
                System.Buffer.BlockCopy(signedData, 0, signature, 0, signedData.Length);
                System.Buffer.BlockCopy(certid, 0, signature, signedData.Length, certid.Length);

                string sigPath = txtDocPath.Text + ".sign";
                File.WriteAllBytes(sigPath, signature);

                MessageBox.Show("Successful...");
                //MessageBox.Show(Utils.Verify(data, signedData, "C:\\Users\\hautv\\Desktop\\sslCertHDU.cer").ToString());
            }
        }

        private void btnVerify_Click(object sender, EventArgs e)
        {
            byte[] data = File.ReadAllBytes(txtDocPath.Text);

            string sigPath = txtDocPath.Text + ".sign";
            byte[] signature = File.ReadAllBytes(sigPath);

            byte[] signedData = new byte[256];
            byte[] certid = new byte[18];
            System.Buffer.BlockCopy(signature, 0, signedData, 0, 256);
            System.Buffer.BlockCopy(signature, 256, certid, 0, certid.Length);

            string certName = Encoding.ASCII.GetString(certid);
            txtCertId.Text = certName;

            string cerPath = sigPath.Substring(0, txtDocPath.Text.LastIndexOf("\\")) + "\\" + certName + ".cer";
            using (WebClient wc = new WebClient())
            {
                wc.DownloadFile(
                    // Param1 = Link of file
                    new System.Uri("http://localhost:8081/cert/get_public_cert/" + certName),
                    // Param2 = Path to save
                    cerPath
                );
            }

            bool success = Utils.Verify(data, signedData, cerPath);
            X509Certificate2 c = new X509Certificate2(cerPath);
            if (!success)
            {
                MessageBox.Show("The document changed");
            }
            else
            {
                MessageBox.Show("The document signed by certificate\n" + c.ToString().Replace("[","").Replace("]",""));
            }
        }

        private void btnSignEncrypt_Click(object sender, EventArgs e)
        {
            if (!signFieldNull())
            {
                //try
                //{
                byte[] data = File.ReadAllBytes(txtDocPath.Text);
                byte[] fileLen = BitConverter.GetBytes((long)data.Length);

                // Sign
                byte[] signedData = Utils.Sign(data, txtCertPath.Text, txtPass.Text);
                // Encrypt
                byte[] desKey = Utils.Encrypt(txtDocPath.Text, txtCertPath.Text, txtPass.Text);

                byte[] certid = Encoding.ASCII.GetBytes(getFileName(txtCertPath.Text));
                byte[] signature = new byte[signedData.Length + certid.Length + desKey.Length + fileLen.Length];
                System.Buffer.BlockCopy(signedData, 0, signature, 0, signedData.Length);
                System.Buffer.BlockCopy(certid, 0, signature, signedData.Length, certid.Length);
                System.Buffer.BlockCopy(fileLen, 0, signature, signedData.Length + certid.Length, fileLen.Length);
                System.Buffer.BlockCopy(desKey, 0, signature, signedData.Length + certid.Length + fileLen.Length, desKey.Length);

                //string sigPath = txtDocPath.Text.Substring(0, txtDocPath.Text.LastIndexOf(".")) + ".sign";
                string sigPath = txtDocPath.Text + ".sign";
                File.WriteAllBytes(sigPath, signature);

                //}
                //catch (Exception err)
                //{
                //    MessageBox.Show(err.Message);
                //}
                MessageBox.Show("Successful...");
            }
        }

        private void btnVerifyDecrypt_Click(object sender, EventArgs e)
        {
            if (!signFieldNull())
            {
                //try
                //{
                byte[] data = File.ReadAllBytes(txtDocPath.Text);

                string sigPath = txtDocPath.Text.Substring(0, txtDocPath.Text.LastIndexOf(".")) + ".sign";
                byte[] signature = File.ReadAllBytes(sigPath);

                byte[] signedData = new byte[256];
                byte[] certid = new byte[12];
                byte[] desKey = new byte[signature.Length - 276];
                byte[] fileLength = new byte[8];
                System.Buffer.BlockCopy(signature, 0, signedData, 0, 256);
                System.Buffer.BlockCopy(signature, 256, certid, 0, certid.Length);
                System.Buffer.BlockCopy(signature, 256 + 12, fileLength, 0, fileLength.Length);
                System.Buffer.BlockCopy(signature, 256 + 12 + 8, desKey, 0, desKey.Length);

                string certName = Encoding.ASCII.GetString(certid);
                txtCertId.Text = certName;

                // Decrypt
                string decryptPath = txtDocPath.Text.Substring(0, txtDocPath.Text.LastIndexOf("."));
                Utils.Decrypt(desKey, decryptPath, txtDocPath.Text, BitConverter.ToInt64(fileLength, 0), txtCertPath.Text, txtPass.Text);
                txtDocPath.Text = decryptPath;

                // Verify
                data = File.ReadAllBytes(txtDocPath.Text);
                string cerPath = sigPath.Substring(0, txtDocPath.Text.LastIndexOf("\\")) + "\\" + certName + ".cer";
                using (WebClient wc = new WebClient())
                {
                    wc.DownloadFile(
                        // Param1 = Link of file
                        new System.Uri("http://localhost:8081/cert/get_public_cert/" + certName),
                        // Param2 = Path to save
                        cerPath
                    );
                }

                bool success = Utils.Verify(data, signedData, cerPath);
                X509Certificate2 c = new X509Certificate2(cerPath);
                if (!success)
                {
                    MessageBox.Show("The document changed");
                }
                else
                {
                    MessageBox.Show("The document signed by certificate\n" + c);
                }
                //}
                //catch (Exception err)
                //{
                //    MessageBox.Show(err.Message);
                //}
            }
        }


        private bool signFieldNull()
        {
            if (txtCertPath.Text == "" || txtDocPath.Text == "" || txtPass.Text == "") return true;
            return false;
        }

        private string getFileName(string path)
        {
            int x1 = path.LastIndexOf("\\") + 1, x2 = path.LastIndexOf(".");
            string fileName = path.Substring(x1, x2 - x1);
            return fileName;
        }
    }
}
