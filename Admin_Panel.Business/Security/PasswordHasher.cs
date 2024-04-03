using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Security
{
    public static class PasswordHasher
    {
        public static string EncodePasswordMD5(this string pass)
        {
            Byte[] orginalPassword;
            Byte[] encodedBytes;
            MD5 md5;
            md5 = new MD5CryptoServiceProvider();
            orginalPassword = ASCIIEncoding.Default.GetBytes(pass);
            encodedBytes = md5.ComputeHash(orginalPassword);
            return Convert.ToBase64String(encodedBytes);
        }
    }
}