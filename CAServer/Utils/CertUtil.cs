using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CAServer.Utils
{
    public class CertUtil
    {
        private string rootCaPath = AppContext.BaseDirectory + "/rootCA.p12";
        private string password = "password";

        // Singeton
        private static CertUtil instance;
        public static CertUtil getInstance()
        {
            if (instance == null) return instance = new CertUtil();
            return instance;
        }

        public X509Certificate2 getRootCA()
        {
            return new X509Certificate2(this.rootCaPath, this.password);
        }

        public X509Certificate2 getRootCA(string password)
        {
            this.password = password;
            return new X509Certificate2(this.rootCaPath, this.password);
        }
    }
}
