using System;
using System.Runtime.InteropServices;

namespace ServerSide
{
    internal class Win32Native
    {
        [DllImport("AdvApi32.dll", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CryptReleaseContext(IntPtr ctx, int flags);

        [DllImport("AdvApi32.dll", EntryPoint = "CryptAcquireContextW", ExactSpelling = true, CharSet = CharSet.Unicode, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CryptAcquireContext(
           out IntPtr providerContext,
           string containerName,
           string providerName,
           uint providerType,
           uint flags);

        [DllImport("AdvApi32.dll", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CryptDestroyKey(IntPtr cryptKeyHandle);

        [DllImport("AdvApi32.dll", ExactSpelling = true, SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        internal static extern bool CryptGenKey(
           IntPtr providerContext,
           int algorithmId,
           uint flags,
           out IntPtr cryptKeyHandle);

        [DllImport("Crypt32.dll", SetLastError = true, ExactSpelling = true)]
        internal static extern IntPtr CertCreateSelfSignCertificate(
           IntPtr providerHandle,
           [In] CryptoApiBlob subjectIssuerBlob,
           int flags,
           ref CRYPT_KEY_PROV_INFO pKeyProvInfo,
           ref CRYPT_ALGORITHM_IDENTIFIER pSignatureAlgorithm,
           [In] SystemTime startTime,
           [In] SystemTime endTime,
           IntPtr extensions);

        [DllImport("kernel32.dll", SetLastError = true, ExactSpelling = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool FileTimeToSystemTime(
           [In] ref long fileTime,
           [Out] SystemTime systemTime);

        [DllImport("kernel32.dll", CharSet = CharSet.Auto, SetLastError = true)]
        internal static extern IntPtr LocalAlloc([In] uint uFlags, [In] IntPtr sizetdwBytes);

        [StructLayout(LayoutKind.Sequential)]
        internal class CryptoApiBlob
        {
            public int DataLength;
            public IntPtr Data;

            public CryptoApiBlob(int dataLength, IntPtr data)
            {
                this.DataLength = dataLength;
                this.Data = data;
            }
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class SystemTime
        {
            public short Year;
            public short Month;
            public short DayOfWeek;
            public short Day;
            public short Hour;
            public short Minute;
            public short Second;
            public short Milliseconds;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CRYPT_KEY_PROV_INFO
        {
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pwszContainerName;
            [MarshalAs(UnmanagedType.LPWStr)]
            public string pwszProvName;
            public uint dwProvType;
            public uint dwFlags;
            public uint cProvParam;
            public IntPtr rgProvParam;
            public uint dwKeySpec;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CRYPT_ALGORITHM_IDENTIFIER
        {
            [MarshalAs(UnmanagedType.LPStr)]
            public string pszObjId;
            public CRYPTOAPI_BLOB parameters;
        }

        [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
        public struct CRYPTOAPI_BLOB
        {
            public uint cbData;
            public IntPtr pbData;
        }

        [StructLayout(LayoutKind.Sequential)]
        internal class CryptKeyProviderParam
        {
            public int pwszContainerName;
            public IntPtr pbData;
            public int cbData;
            public int dwFlags;
        }

    }


}