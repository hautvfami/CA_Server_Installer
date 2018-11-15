﻿using System;
using System.Net.Security;

namespace ServerSide
{
    public delegate void SecureConnectionResultsCallback(object sender, SecureConnectionResults args);
    public class SecureConnectionResults
    {
        private SslStream secureStream;
        private Exception asyncException;
        internal SecureConnectionResults(SslStream sslStream)
        {
            this.secureStream = sslStream;
        }

        internal SecureConnectionResults(Exception exception)
        {
            this.asyncException = exception;
        }

        public Exception AsyncException { get { return asyncException; } }
        public SslStream SecureStream { get { return secureStream; } }

    }
}