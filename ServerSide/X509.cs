using CERTENROLLLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    class X509
    {
    }

    class PublicKey : IX509PublicKey
    {

        public CObjectId Algorithm
        {
            get { throw new NotImplementedException(); }
        }

        public string ComputeKeyIdentifier(KeyIdentifierHashAlgorithm Algorithm, EncodingType Encoding = EncodingType.XCN_CRYPT_STRING_BASE64)
        {
            throw new NotImplementedException();
        }

        public void Initialize(CObjectId pObjectId, string strEncodedKey, string strEncodedParameters, EncodingType Encoding = EncodingType.XCN_CRYPT_STRING_BASE64)
        {
            throw new NotImplementedException();
        }

        public void InitializeFromEncodedPublicKeyInfo(string strEncodedPublicKeyInfo, EncodingType Encoding = EncodingType.XCN_CRYPT_STRING_BASE64)
        {
            throw new NotImplementedException();
        }

        public int Length
        {
            get { throw new NotImplementedException(); }
        }

        public string get_EncodedKey(EncodingType Encoding = EncodingType.XCN_CRYPT_STRING_BASE64)
        {
            throw new NotImplementedException();
        }

        public string get_EncodedParameters(EncodingType Encoding = EncodingType.XCN_CRYPT_STRING_BASE64)
        {
            throw new NotImplementedException();
        }
    }
    //class SubjectName ;
}
