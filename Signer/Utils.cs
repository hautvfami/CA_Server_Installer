using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Forms;
using System.IO;

namespace Signer
{
    public class Utils
    {
        private static Random random = new Random();

        public static byte[] Encrypt(string filePath, string certPath, string password)
        {
            byte[] data = File.ReadAllBytes(filePath);

            byte[] desKey = new byte[8];
            random.NextBytes(desKey);
            SymmetricAlgorithm symmetricAlgorithm = DES.Create();
            symmetricAlgorithm.Key = desKey;
            symmetricAlgorithm.IV = desKey;


            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cryptoStream.Write(data, 0, data.Length);
                }
                File.WriteAllBytes(filePath + ".cipher", memoryStream.ToArray());
            }

            X509Certificate2 cert = new X509Certificate2(certPath, password);
            RSA rsa = cert.GetRSAPublicKey();
            
            return rsa.Encrypt(desKey,RSAEncryptionPadding.OaepSHA1);
        }

        public static void Decrypt(byte[] desKey, string decryptPath, string filePath, long fileLength, string certPath, string password)
        {
            X509Certificate2 cert = new X509Certificate2(certPath, password);
            RSA rsa = cert.GetRSAPrivateKey();

            byte[] data = File.ReadAllBytes(filePath);

            SymmetricAlgorithm symmetricAlgorithm = DES.Create();
            symmetricAlgorithm.Key = rsa.Decrypt(desKey, RSAEncryptionPadding.OaepSHA1);
            symmetricAlgorithm.IV = rsa.Decrypt(desKey, RSAEncryptionPadding.OaepSHA1);
            using (MemoryStream memoryStream = new MemoryStream(data))
            {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, symmetricAlgorithm.CreateDecryptor(), CryptoStreamMode.Read))
                {
                    byte[] decryptedBytes = new byte[data.Length];
                    cryptoStream.Read(decryptedBytes, 0, decryptedBytes.Length);
                    System.Array.Resize(ref decryptedBytes, (int)fileLength);
                    File.WriteAllBytes(decryptPath, decryptedBytes);
                }
            }
        }

        public static byte[] Sign(byte[] data, string certPath, string password)

        {
            ////  Access Personal(MY) certificate store of current user
            //X509Store my = new X509Store(StoreName.My, StoreLocation.CurrentUser);
            //my.Open(OpenFlags.ReadOnly);

            //// Find the certificate we'll use to sign
            //RSACryptoServiceProvider csp = null;
            //foreach (X509Certificate2 cert in my.Certificates)
            //{
            //    if (cert.Subject.Contains(certSubject))
            //    {
            //        // We found it.
            //        // Get its associated CSP and private key
            //        csp = (RSACryptoServiceProvider)cert.PrivateKey;
            //    }
            //}

            //if (csp == null)
            //{
            //    MessageBox.Show("No valid cert was found");
            //}
            //RSACryptoServiceProvider csp = null;


            X509Certificate2 cert = new X509Certificate2(certPath, password);
            RSA rsa = cert.GetRSAPrivateKey();

            if (rsa == null)
            {
                MessageBox.Show("No valid cert was found");
            }

            // Hash the data
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(data);

            // Sign the hash
            return rsa.SignHash(hash, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            //return csp.SignHash(hash, CryptoConfig.MapNameToOID("SHA1"));
        }

        public static bool Verify(byte[] data, byte[] signature, string certPath)
        {
            // Load the certificate we'll use to verify the signature from a file
            X509Certificate2 cert = new X509Certificate2(certPath);
            // Note:
            // If we want to use the client cert in an ASP.NET app, we may use something like this instead:
            // X509Certificate2 cert = new X509Certificate2(Request.ClientCertificate.Certificate);
            // Get its associated CSP and public key
            //RSACryptoServiceProvider csp = (RSACryptoServiceProvider)cert.PublicKey.Key;
            RSA rsa = cert.GetRSAPublicKey();
            // Hash the data
            SHA1Managed sha1 = new SHA1Managed();
            byte[] hash = sha1.ComputeHash(data);

            // Verify the signature with the hash
            return rsa.VerifyHash(hash, signature, HashAlgorithmName.SHA1, RSASignaturePadding.Pkcs1);
            //return csp.VerifyHash(hash, CryptoConfig.MapNameToOID("SHA1"), signature);
        }

        //void test()
        //{
        //    // Usage sample
        //    try
        //    {
        //        // Sign text
        //        byte[] signature = Sign("Test", "cn=my cert subject");
        //        // Verify signature. Testcert.cer corresponds to "cn=my cert subject"
        //        if (Verify("Test", signature, @"C:\testcert.cer"))
        //        {
        //            Console.WriteLine("Signature verified");
        //        }
        //        else
        //        {
        //            Console.WriteLine("ERROR: Signature not valid!");
        //        }
        //    }
        //    catch (Exception ex)
        //    {
        //        Console.WriteLine("EXCEPTION: " + ex.Message);
        //    }
        //}
    }
}
