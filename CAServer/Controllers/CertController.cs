using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;
using CAServer.Models;
using CAServer.Utils;
using Microsoft.AspNetCore.Mvc;


namespace CAServer.Controllers
{
    public class CertController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult get_ssl_certificate()
        {
            var rootCA = CertUtil.getInstance().getRootCA();
            ViewBag.Issued = rootCA.GetNameInfo(X509NameType.SimpleName, true);
            ViewBag.NotBefore = rootCA.NotBefore.ToLongDateString() +" "+ rootCA.NotBefore.ToLongTimeString();
            ViewBag.NotAfter = rootCA.NotAfter.ToLongDateString() +" "+ rootCA.NotAfter.ToLongTimeString();
            ViewBag.Serial = rootCA.SerialNumber;
            ViewBag.Thumbprint = rootCA.Thumbprint;
            ViewBag.PublicKey = rootCA.GetPublicKeyString();
            return View();
        }

        #region demo_ssl_certificate
        /*
        [HttpGet]
        public FileContentResult get_ssl_certificate()
        {
            var rootCA = CertUtil.getInstance().getRootCA();
            var rsa = RSA.Create();
            var dName = new DistinguishedName();
            dName.CN = "localhost";
            dName.C = "VN";
            dName.O = "Hong Duc University";
            dName.OU = "Faculty of Information Technology";
            dName.E = "FIT@hdu.edu.vn";
            dName.L = "Thanh Hoa";

            var request = new CertificateRequest(dName.getX509DistinguishedName(), rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            var subjectANB = new SubjectAlternativeNameBuilder();
            subjectANB.AddDnsName("localhost");
            subjectANB.AddEmailAddress("hautv@hdu.edu.vn");
            request.CertificateExtensions.Add(subjectANB.Build());
            request.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));
            request.CertificateExtensions.Add(new X509KeyUsageExtension(
                X509KeyUsageFlags.DigitalSignature |
                X509KeyUsageFlags.KeyCertSign |
                X509KeyUsageFlags.KeyEncipherment |
                X509KeyUsageFlags.DataEncipherment |
                X509KeyUsageFlags.NonRepudiation, false)
            );

            #region Comment
            //// set the AuthorityKeyIdentifier. There is no built-in 
            //// support, so it needs to be copied from the Subject Key 
            //// Identifier of the signing certificate and massaged slightly.
            //// AuthorityKeyIdentifier is "KeyID="
            //var issuerSubjectKey = rootCA.Extensions["Subject Key Identifier"].RawData;
            //var segment = new ArraySegment(issuerSubjectKey, 2, issuerSubjectKey.Length - 2);
            //var authorityKeyIdentifer = new byte[segment.Count + 4];
            //// these bytes define the "KeyID" part of the AuthorityKeyIdentifer
            //authorityKeyIdentifer[0] = 0x30;
            //authorityKeyIdentifer[1] = 0x16;
            //authorityKeyIdentifer[2] = 0x80;
            //authorityKeyIdentifer[3] = 0x14;
            //segment.CopyTo(authorityKeyIdentifer, 4);
            //request.CertificateExtensions.Add(new X509Extension("2.5.29.35", authorityKeyIdentifer, false));
            #endregion


            // set the AuthorityKeyIdentifier. There is no built-in 
            // support, so it needs to be copied from the Subject Key 
            // Identifier of the signing certificate and massaged slightly.
            // AuthorityKeyIdentifier is "KeyID="
            var issuerSubjectKey = rootCA.Extensions["Subject Key Identifier"].RawData;
            var segment = new byte[issuerSubjectKey.Length - 2];
            Buffer.BlockCopy(issuerSubjectKey, 2, segment, 0, issuerSubjectKey.Length - 2);
            var authorityKeyIdentifer = new byte[segment.Length + 4];
            // these bytes define the "KeyID" part of the AuthorityKeyIdentifer
            var KeyID = new byte[] { 0x30, 0x16, 0x80, 0x14 };
            KeyID.CopyTo(authorityKeyIdentifer, 0);
            segment.CopyTo(authorityKeyIdentifer, 4);
            request.CertificateExtensions.Add(new X509Extension("2.5.29.35", authorityKeyIdentifer, false));

            request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(
                new OidCollection {
                    new Oid("1.3.6.1.5.5.7.3.8"), // Timestamping
                    new Oid("1.3.6.1.5.5.7.3.2"), // TLS Client auth
                    new Oid("1.3.6.1.5.5.7.3.1")  // TLS Server auth
                }, false)
             );
            request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));

            // Add Time and Key
            X509Certificate2 sslCert = request.Create(rootCA, DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1), BitConverter.GetBytes(DateTimeOffset.Now.Ticks));
            sslCert = sslCert.CopyWithPrivateKey(rsa);

            // Create PFX (PKCS #12) with private key
            byte[] p12Cert = sslCert.Export(X509ContentType.Pkcs12, "password");
            // Create Base 64 encoded CER (public key only)
            string cerCert = "-----BEGIN CERTIFICATE-----\r\n" + Convert.ToBase64String(sslCert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks) + "\r\n-----END CERTIFICATE-----";
            byte[] pfxCert = sslCert.Export(X509ContentType.Pfx, "password");
            
            // Write to disk
            System.IO.File.WriteAllBytes(AppContext.BaseDirectory + "/sslCertHDU.p12", p12Cert);
            System.IO.File.WriteAllText(AppContext.BaseDirectory + "/sslCertHDU.cer", cerCert);
            System.IO.File.WriteAllBytes(AppContext.BaseDirectory + "/sslCertHDU.pfx", pfxCert);

            //FileContentResult fcResult = File(p12Cert, "application/octet-stream", "sslCertHDU.p12");
            FileContentResult fcResult = File(System.Text.Encoding.ASCII.GetBytes(cerCert), "application/octet-stream", "sslCertHDU.cer");
            return fcResult;
        }
        */
        #endregion


        [HttpPost]
        public FileContentResult get_ssl_certificate(DistinguishedName dName)
        {
            var rootCA = CertUtil.getInstance().getRootCA();
            var rsa = RSA.Create();

            var request = new CertificateRequest(dName.getX509DistinguishedName(),rsa, HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);

            var subjectANB = new SubjectAlternativeNameBuilder();
            subjectANB.AddDnsName(dName.DNS);
            subjectANB.AddEmailAddress(dName.E);
            request.CertificateExtensions.Add(subjectANB.Build());
            request.CertificateExtensions.Add(new X509BasicConstraintsExtension(false, false, 0, false));
            request.CertificateExtensions.Add(new X509KeyUsageExtension(
                X509KeyUsageFlags.DigitalSignature |
                X509KeyUsageFlags.KeyCertSign |
                X509KeyUsageFlags.KeyEncipherment |
                X509KeyUsageFlags.DataEncipherment |
                X509KeyUsageFlags.NonRepudiation, false)
            );
            
            // set the AuthorityKeyIdentifier. There is no built-in 
            // support, so it needs to be copied from the Subject Key 
            // Identifier of the signing certificate and massaged slightly.
            // AuthorityKeyIdentifier is "KeyID="
            var issuerSubjectKey = rootCA.Extensions["Subject Key Identifier"].RawData;
            var segment = new byte[issuerSubjectKey.Length - 2];
            Buffer.BlockCopy(issuerSubjectKey, 2, segment, 0, issuerSubjectKey.Length - 2);
            var authorityKeyIdentifer = new byte[segment.Length + 4];
            // these bytes define the "KeyID" part of the AuthorityKeyIdentifer
            var KeyID = new byte[] { 0x30, 0x16, 0x80, 0x14 };
            KeyID.CopyTo(authorityKeyIdentifer, 0);
            segment.CopyTo(authorityKeyIdentifer, 4);
            request.CertificateExtensions.Add(new X509Extension("2.5.29.35", authorityKeyIdentifer, false));

            request.CertificateExtensions.Add(new X509EnhancedKeyUsageExtension(
                new OidCollection {
                    new Oid("1.3.6.1.5.5.7.3.8"), // Timestamping
                    new Oid("1.3.6.1.5.5.7.3.2"), // TLS Client auth
                    new Oid("1.3.6.1.5.5.7.3.1")  // TLS Server auth
                }, false)
             );
            request.CertificateExtensions.Add(new X509SubjectKeyIdentifierExtension(request.PublicKey, false));

            // Add Time and Key
            X509Certificate2 sslCert = request.Create(rootCA, DateTimeOffset.Now, DateTimeOffset.Now.AddYears(1), BitConverter.GetBytes(DateTimeOffset.Now.Ticks));
            sslCert = sslCert.CopyWithPrivateKey(rsa);

            // Create PFX (PKCS #12) with private key
            byte[] p12Cert = sslCert.Export(X509ContentType.Pkcs12, "password");
            // Create Base 64 encoded CER (public key only)
            string cerCert = "-----BEGIN CERTIFICATE-----\r\n" + Convert.ToBase64String(sslCert.Export(X509ContentType.Cert), Base64FormattingOptions.InsertLineBreaks) + "\r\n-----END CERTIFICATE-----";
            byte[] pfxCert = sslCert.Export(X509ContentType.Pfx, "password");

            String CertID = DateTimeOffset.Now.Ticks.ToString();
            // Write to disk
            System.IO.File.WriteAllBytes(AppContext.BaseDirectory + "/" + CertID + ".p12", p12Cert);
            System.IO.File.WriteAllText(AppContext.BaseDirectory + "/" + CertID + ".cer", cerCert);
            System.IO.File.WriteAllBytes(AppContext.BaseDirectory + "/" + CertID + ".pfx", pfxCert);


            FileContentResult fcResult = File(p12Cert, "application/octet-stream", CertID + ".p12");
            //FileContentResult fcResult = File(System.Text.Encoding.ASCII.GetBytes(cerCert), "application/octet-stream", "176743490865.cer");
            return fcResult;
        }

        //-----------

        [HttpGet]
        public ActionResult get_public_cert(string id)
        {
            try
            {
                string cerCert = System.IO.File.ReadAllText(AppContext.BaseDirectory + "/" + id + ".cer");
                FileContentResult fcResult = File(System.Text.Encoding.ASCII.GetBytes(cerCert), "application/octet-stream", id + ".cer");
                return fcResult;
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                return Content("notfound");
            }
        }
    }
}