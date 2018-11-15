using System;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;

namespace RootCAInstaller
{
    public partial class Form1 : Form
    {
        private X509Certificate2 cert;
        private string certPath = "./rootCA.cer";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            loadCert();
            Utils.FirefoxCfg.setUsingWindowCertStore();
        }

        private void btnImport_Click(object sender, EventArgs e)
        {
            try
            {
                X509Store store = new X509Store(StoreName.Root, StoreLocation.CurrentUser);
                store.Open(OpenFlags.ReadWrite);
                var certificates = store.Certificates.Find(X509FindType.FindBySubjectName, lbIssuedTo.Text, false);
                if (certificates != null && certificates.Count > 0)
                {
                    MessageBox.Show("Certificate already exists", "Information");
                }
                else
                {
                    store.Add(cert);
                    MessageBox.Show("Certificate installed successful..", "Information");
                }
                store.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to install root certificate!!!");
            }
        }

        private void btnBrowser_Click(object sender, EventArgs e)
        {
            OpenFileDialog fd = new OpenFileDialog();
            if(fd.ShowDialog() == DialogResult.OK)
            {
                certPath = fd.FileName;
                loadCert();
            }
        }


        private void loadCert()
        {
            try
            {
                cert = new X509Certificate2(certPath);
                lbIssuedBy.Text = cert.GetNameInfo(X509NameType.SimpleName, true);
                //lbIssuedTo.Text = cert.GetNameInfo(X509NameType.SimpleName, false);
                lbValidFrom.Text = cert.NotBefore.ToShortDateString();
                lbValidTo.Text = cert.NotAfter.ToShortDateString();
                lbSerial.Text = cert.GetSerialNumberString();
                lbThumbprint.Text = cert.Thumbprint;
                txtPK.Text = cert.GetPublicKeyString();
                lbInformation.Text = cert.SubjectName.Name.Replace(",", "\n");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Failed to load root certificate!!!");
            }
        }
    }
}
