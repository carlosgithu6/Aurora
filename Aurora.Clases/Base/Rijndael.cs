using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using System.Security.Cryptography;

namespace Aurora.Clases.Base.Encriptacion
{
    public sealed class MiRijndael
    {
        #region Key
        private static byte[] _objTempKey = null;

        private static byte[] GetKey()
        {
            string _key = "5D00B664-E229-45";
            if (_objTempKey == null)
            {
                _objTempKey = System.Text.Encoding.UTF8.GetBytes(_key);
            }
            return _objTempKey;
        }

        #endregion

        #region Encriptar
        public static byte[] Encriptar(string strEncriptar, string strPK)
        {
            return Encriptar(strEncriptar, (new PasswordDeriveBytes(strPK, null)).GetBytes(32));
        }
        public static byte[] Encriptar(string strEncriptar)
        {
            return Encriptar(strEncriptar, GetKey());
        }
        public static byte[] Encriptar(string strEncriptar, byte[] bytPK)
        {
            Rijndael miRijndael = Rijndael.Create();
            byte[] encrypted = null;
            byte[] returnValue = null;

            try
            {
                miRijndael.Key = bytPK;
                miRijndael.GenerateIV();

                byte[] toEncrypt = System.Text.Encoding.UTF8.GetBytes(strEncriptar);
                encrypted = (miRijndael.CreateEncryptor()).TransformFinalBlock(toEncrypt, 0, toEncrypt.Length);

                returnValue = new byte[miRijndael.IV.Length + encrypted.Length];
                miRijndael.IV.CopyTo(returnValue, 0);
                encrypted.CopyTo(returnValue, miRijndael.IV.Length);

            }
            catch { }
            finally { miRijndael.Clear(); }

            return returnValue;
        }
        #endregion

        #region Desencriptar
        public static string Desencriptar(byte[] bytDesEncriptar, string strPK)
        {
            return Desencriptar(bytDesEncriptar, (new PasswordDeriveBytes(strPK, null)).GetBytes(32));
        }
        public static string Desencriptar(byte[] bytDesEncriptar)
        {
            return Desencriptar(bytDesEncriptar, GetKey());
        }
        public static string Desencriptar(byte[] bytDesEncriptar, byte[] bytPK)
        {
            Rijndael miRijndael = Rijndael.Create();
            byte[] tempArray = new byte[miRijndael.IV.Length];
            byte[] encrypted = new byte[bytDesEncriptar.Length - miRijndael.IV.Length];
            string returnValue = string.Empty;

            try
            {
                miRijndael.Key = bytPK;

                Array.Copy(bytDesEncriptar, tempArray, tempArray.Length);
                Array.Copy(bytDesEncriptar, tempArray.Length, encrypted, 0, encrypted.Length);
                miRijndael.IV = tempArray;

                returnValue = System.Text.Encoding.UTF8.GetString((miRijndael.CreateDecryptor()).TransformFinalBlock(encrypted, 0, encrypted.Length));

            }
            catch { }
            finally { miRijndael.Clear(); }

            return returnValue;
        }
        #endregion

    }
}
