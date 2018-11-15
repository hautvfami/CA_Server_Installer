//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Security.Cryptography.X509Certificates;
//using System.Text;
//using System.Threading.Tasks;

//using CERTENROLLLib;
//using System.Security.Principal;
//using System.Security.Cryptography;


//using System;
//using System.Runtime.InteropServices;

////namespace System.Security.Cryptography
////{
////    // Summary:
////    //     Represents the standard parameters for the System.Security.Cryptography.RSA
////    //     algorithm.
////    [Serializable]
////    [ComVisible(true)]
////    public struct RSAParameters
////    {
////        // Summary:
////        //     Represents the D parameter for the System.Security.Cryptography.RSA algorithm.
////        public byte[] D;
////        //
////        // Summary:
////        //     Represents the DP parameter for the System.Security.Cryptography.RSA algorithm.
////        public byte[] DP;
////        //
////        // Summary:
////        //     Represents the DQ parameter for the System.Security.Cryptography.RSA algorithm.
////        public byte[] DQ;
////        //
////        // Summary:
////        //     Represents the Exponent parameter for the System.Security.Cryptography.RSA
////        //     algorithm.
////        public byte[] Exponent;
////        //
////        // Summary:
////        //     Represents the InverseQ parameter for the System.Security.Cryptography.RSA
////        //     algorithm.
////        public byte[] InverseQ;
////        //
////        // Summary:
////        //     Represents the Modulus parameter for the System.Security.Cryptography.RSA
////        //     algorithm.
////        public byte[] Modulus;
////        //
////        // Summary:
////        //     Represents the P parameter for the System.Security.Cryptography.RSA algorithm.
////        public byte[] P;
////        //
////        // Summary:
////        //     Represents the Q parameter for the System.Security.Cryptography.RSA algorithm.
////        public byte[] Q;
////    }
////}

//namespace ServerSide
//{
//    class GenerateCert
//    {
//        //public RsaPrivateCrtKeyParameters KeyParams;
//        public GenerateCert() { }

//        public void makeCert()
//        {
//            X509Certificate2 privateCert = new X509Certificate2("certificate.pfx", "password", X509KeyStorageFlags.Exportable);

//            // This instance can not sign and verify with SHA256:
//            RSACryptoServiceProvider privateKey = (RSACryptoServiceProvider)privateCert.PrivateKey;

//            // This one can:
//            RSACryptoServiceProvider privateKey1 = new RSACryptoServiceProvider();
//            privateKey1.ImportParameters(privateKey.ExportParameters(true));

//            byte[] data = Encoding.UTF8.GetBytes("Data to be signed");

//            byte[] signature = privateKey1.SignData(data, "SHA256");

//            bool isValid = privateKey1.VerifyData(data, "SHA256", signature);
//        }

//    //    private void CreateCertificate(string fileName, string password)
//    //{
//    //    X509Certificate2 cert = null;
//    //    var name = new X500DistinguishedName("cn=" + WindowsIdentity.GetCurrent().Name);
//    //    // Generate Key
//    //    CngKeyCreationParameters keyParams = new CngKeyCreationParameters();
//    //    keyParams.KeyUsage = CngKeyUsages.Signing;
//    //    keyParams.Provider = CngProvider.MicrosoftSoftwareKeyStorageProvider;
//    //    //keyParams.Provider = new CngProvider("Microsoft Enhanced RSA and AES Cryptographic Provider");
//    //    keyParams.ExportPolicy = CngExportPolicies.AllowExport;
//    //    keyParams.Parameters.Add(new CngProperty("Length", BitConverter.GetBytes(2048), CngPropertyOptions.None));

//    //    CngKey newKey = CngKey.Create(CngAlgorithm2.Rsa, Guid.NewGuid().ToString(), keyParams);

//    //    // Init certificate
//    //    X509CertificateCreationParameters certParams = new X509CertificateCreationParameters(name);
//    //    certParams.StartTime = DateTime.Today.AddDays(-1);
//    //    certParams.EndTime = DateTime.Today.AddYears(30);
//    //    certParams.SignatureAlgorithm = X509CertificateSignatureAlgorithm.RsaSha256;
//    //    // Create cert
//    //    cert = newKey.CreateSelfSignedCertificate(certParams);

//    //    using (Stream outputStream = File.Create(fileName))
//    //    {
//    //        byte[] pfx = cert.Export(X509ContentType.Pfx, password);
//    //        outputStream.Write(pfx, 0, pfx.Length);
//    //        outputStream.Close();
//    //    }
//    //}

//        static byte[] GetPem(string type, byte[] data)
//        {
//            string pem = Encoding.UTF8.GetString(data);
//            string header = String.Format("-----BEGIN {0}-----\\n", type);
//            string footer = String.Format("-----END {0}-----", type);
//            int start = pem.IndexOf(header) + header.Length;
//            int end = pem.IndexOf(footer, start);
//            string base64 = pem.Substring(start, (end - start));
//            return Convert.FromBase64String(base64);
//        }

//        static X509Certificate2 LoadCertificateFile(string filename)
//        {
//            using (System.IO.FileStream fs = System.IO.File.OpenRead(filename))
//            {
//                byte[] data = new byte[fs.Length];
//                byte[] res = null;
//                fs.Read(data, 0, data.Length);
//                if (data[0] != 0x30)
//                {
//                    res = GetPem("RSA PRIVATE KEY", data);
//                }
//                X509Certificate2 x509 = new X509Certificate2(res); //Exception hit here
//                return x509;
//            }
//        }
//    }
//}
