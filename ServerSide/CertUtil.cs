using CERTENROLLLib;
using System;
using System.IO;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Security.Principal;

namespace ServerSide
{

    public static class CertUtil
    {

        public class SelfSignedCertProperties
        {
            public bool IsPrivateKeyExportable { get; set; }
            public int KeyBitLength { get; set; }
            public X500DistinguishedName Name { get; set; }
            public DateTime ValidFrom { get; set; }
            public DateTime ValidTo { get; set; }
        }

        public const string OID_RSA_SHA256RSA = "1.2.840.113549.1.1.11";
        public const string szOID_ENHANCED_KEY_USAGE = "2.5.29.37";

        public static void readCert()
        {

        }


        public static void CreateCert(string certPath, string password, string issuer)
        {
            X509Certificate2 cert = null;
            if (String.IsNullOrEmpty(issuer))
            {
                issuer = WindowsIdentity.GetCurrent().Name;
            }


            cert = CreateSelfSignedCertificate(
               new SelfSignedCertProperties
               {
                   IsPrivateKeyExportable = true,
                   KeyBitLength = 4096,
                   Name = new X500DistinguishedName("cn=" + issuer),
                   ValidFrom = DateTime.Today.AddDays(-1),
                   ValidTo = DateTime.Today.AddYears(30),
               });


            if (null == cert)
            {
                return; // user must have cancelled the operation
            }
            using (Stream outputStream = File.Create(certPath))
            {
                byte[] pfx = null;
                if (password == null)
                {
                    pfx = cert.Export(X509ContentType.Pfx);
                }
                else
                {
                    pfx = cert.Export(X509ContentType.Pfx, password); // set password
                }

                outputStream.Write(pfx, 0, pfx.Length);
                outputStream.Close();
            }
        }

        public static X509Certificate2 CreateSelfSignedCertificate(SelfSignedCertProperties properties)
        {
            //GenerateSignatureKey(properties.IsPrivateKeyExportable, properties.KeyBitLength);

            byte[] asnName = properties.Name.RawData;
            GCHandle asnNameHandle = GCHandle.Alloc(asnName, GCHandleType.Pinned);

            var keySize = properties.KeyBitLength;

            if (keySize <= 0)
                keySize = 2048; // Min keysize

            var algoritm = OID_RSA_SHA256RSA;

            CspParameters parameters = new CspParameters()
            {
                ProviderName = "Microsoft Enhanced RSA and AES Cryptographic Provider",
                ProviderType = 24,
                KeyContainerName = Guid.NewGuid().ToString(),
                KeyNumber = (int)KeyNumber.Exchange,
                Flags = CspProviderFlags.UseMachineKeyStore
            };

            try
            {

                Win32Native.CRYPT_ALGORITHM_IDENTIFIER signatureAlgorithm = new Win32Native.CRYPT_ALGORITHM_IDENTIFIER
                {
                    pszObjId = algoritm
                };

                signatureAlgorithm.parameters.cbData = 0;
                signatureAlgorithm.parameters.pbData = IntPtr.Zero;

                using (new RSACryptoServiceProvider(keySize, parameters))
                {

                    Win32Native.CRYPT_KEY_PROV_INFO providerInfo = new Win32Native.CRYPT_KEY_PROV_INFO
                    {
                        pwszProvName = parameters.ProviderName,
                        pwszContainerName = parameters.KeyContainerName,
                        dwProvType = (uint)parameters.ProviderType,
                        dwFlags = 0x20, //(uint)parameters.Flags, 
                        dwKeySpec = (uint)parameters.KeyNumber
                    };

                    IntPtr certHandle = Win32Native.CertCreateSelfSignCertificate(
                      IntPtr.Zero,
                      new Win32Native.CryptoApiBlob(asnName.Length, asnNameHandle.AddrOfPinnedObject()),
                      0,
                      ref providerInfo,
                      ref signatureAlgorithm,
                      ToSystemTime(properties.ValidFrom),
                      ToSystemTime(properties.ValidTo),
                      IntPtr.Zero);



                    //if (IntPtr.Zero == certHandle)
                    //    Win32ErrorHelper.ThrowExceptionIfGetLastErrorIsNotZero();

                    return new X509Certificate2(certHandle);
                }
            }
            finally
            {
                // Free the unmanaged memory.
                asnNameHandle.Free();
            }
        }

        private static Win32Native.SystemTime ToSystemTime(DateTime dateTime)
        {
            long fileTime = dateTime.ToFileTime();
            var systemTime = new Win32Native.SystemTime();
            //if (!Win32Native.FileTimeToSystemTime(ref fileTime, systemTime))
            //    Win32ErrorHelper.ThrowExceptionIfGetLastErrorIsNotZero();
            return systemTime;
        }

    }
}