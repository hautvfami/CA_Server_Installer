using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Threading.Tasks;

namespace CAServer.Models
{
    public class DistinguishedName
    {
        // Common Name
        public string CN { get; set; }
        // Country
        public string C { get; set; }
        // Organization
        public string O { get; set; }
        // Organization Unit
        public string OU { get; set; }
        // Email
        public string E { get; set; }
        // City
        public string L { get; set; }
        // Domain Name
        public string DNS { get; set; }

        public DistinguishedName()
        {
            this.CN = "Random Common Name";
            this.C = "Random Country";
            this.O = "Random Organization";
            this.OU = "Random Organization Unit";
            this.E = "Random Email";
            this.L = "Random City";
        }

        override public string ToString()
        {
            string dName = "";
            dName += string.IsNullOrEmpty(this.CN) ? "" : "CN = " + this.CN;
            dName += string.IsNullOrEmpty(this.C) ? "" : ",C = " + this.C;
            dName += string.IsNullOrEmpty(this.O) ? "" : ",O = " + this.O;
            dName += string.IsNullOrEmpty(this.OU) ? "" : ",OU = " + this.OU;
            dName += string.IsNullOrEmpty(this.E) ? "" : ",E = " + this.E;
            dName += string.IsNullOrEmpty(this.L) ? "" : ",L = " + this.L;
            return dName;
        }

        public X500DistinguishedName getX509DistinguishedName()
        {
            return new X500DistinguishedName(this.ToString(), X500DistinguishedNameFlags.UseUTF8Encoding);
        }
    }
}
