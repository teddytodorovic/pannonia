using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;

namespace EncryptDecrypt
{
    public class EncryptDecryptAlgorithms
    {
        public static string OlbEncryptor = "OLBSymmProvider";
        public const string dynamicEncryptionKey = "AlliantFlyEnco";
        public const string dynamicEncryptionKey32 = "AlliantFlyEncoqwewqwewqwewqwewqw";
        public static readonly byte[] dynamicEncSalt = new byte[] { 0x45, 0xF1, 0x61, 0x6e, 0x20, 0x00, 0x65, 0x64, 0x76, 0x65, 0x64, 0x03, 0x76 };  //hexadecimal
        public static readonly byte[] dynamicEncSalt16 = new byte[] { 0x45, 0xF1, 0x61, 0x6e, 0x20, 0x00, 0x65, 0x64, 0x76, 0x65, 0x64, 0x03, 0x76, 0x64, 0x03, 0x76 }; //hexadecimal

        public static string EncryptAES(string str)
        {
            string encryptString = String.Empty;
            byte[] clearBytes = Encoding.Unicode.GetBytes(str);

            try
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(dynamicEncryptionKey, dynamicEncSalt);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }

                        encryptString = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return encryptString;
        }

        public static string DecryptAES(string str)
        {
            string cipherText = str;
            string decryptedText = String.Empty;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            try
            {
                using (Aes encryptor = Aes.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(dynamicEncryptionKey, dynamicEncSalt);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }

                        decryptedText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return decryptedText;
        }


        public static string EncryptAESWithoutRfc2898DeriveBytes(string str)
        {
            string encryptString = String.Empty;
            byte[] clearBytes = Encoding.Unicode.GetBytes(str);

            try
            {

                using (Aes encryptor = Aes.Create())
                {
                    encryptor.Key = Encoding.ASCII.GetBytes(dynamicEncryptionKey32);
                    encryptor.IV = dynamicEncSalt16;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }

                        encryptString = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return encryptString;
        }

        public static string DecryptAESWithoutRfc2898DeriveBytes(string str)
        {
            string cipherText = str;
            string decryptedText = String.Empty;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            try
            {
                using (Aes encryptor = Aes.Create())
                {
                    encryptor.Key = Encoding.ASCII.GetBytes(dynamicEncryptionKey32);
                    encryptor.IV = dynamicEncSalt16;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }

                        decryptedText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return decryptedText;
        }


        public static string EncryptEnterprise(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            try
            {
                return Cryptographer.EncryptSymmetric("OLBSymmProvider", str);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return str;
            }
        }

        public static string DecryptEnterprise(string str)
        {
            if (string.IsNullOrEmpty(str))
            {
                return str;
            }
            try
            {
                return Cryptographer.DecryptSymmetric("OLBSymmProvider", str);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return str;
            }
        }

        public static string EncryptRijndael(string str)
        {
            string encryptString = String.Empty;
            byte[] clearBytes = Encoding.Unicode.GetBytes(str);

            try
            {

                using (Rijndael encryptor = Rijndael.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(dynamicEncryptionKey, dynamicEncSalt);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }

                        encryptString = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return encryptString;
        }

        public static string DecryptRijndael(string str)
        {
            string cipherText = str;
            string decryptedText = String.Empty;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            try
            {
                using (Rijndael encryptor = Rijndael.Create())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(dynamicEncryptionKey, dynamicEncSalt);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }

                        decryptedText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return decryptedText;
        }

        public static string EncryptRijndaelManaged(string str)
        {
            string encryptString = String.Empty;
            byte[] clearBytes = Encoding.Unicode.GetBytes(str);

            try
            {
                using (RijndaelManaged encryptor = new RijndaelManaged())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(dynamicEncryptionKey, dynamicEncSalt);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    using (MemoryStream ms = new MemoryStream())
                    {

                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }

                        encryptString = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return encryptString;
        }

        public static string DecryptRijndaelManaged(string str)
        {
            string cipherText = str;
            string decryptedText = String.Empty;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            try
            {
                using (RijndaelManaged encryptor = new RijndaelManaged())
                {
                    Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(dynamicEncryptionKey, dynamicEncSalt);
                    encryptor.Key = pdb.GetBytes(32);
                    encryptor.IV = pdb.GetBytes(16);

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(cipherBytes, 0, cipherBytes.Length);
                            cs.Close();
                        }

                        decryptedText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return decryptedText;
        }



        public static string EncryptRijndaelManagedWithoutRfc2898DerivedBytes(string str)
        {
            string encryptString = String.Empty;
            byte[] clearBytes = Encoding.Unicode.GetBytes(str);

            try
            {
                using (RijndaelManaged encryptor = new RijndaelManaged())
                {

                    encryptor.Key = Encoding.ASCII.GetBytes(dynamicEncryptionKey32);
                    encryptor.IV = dynamicEncSalt16;

                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(), CryptoStreamMode.Write))
                        {
                            cs.Write(clearBytes, 0, clearBytes.Length);
                            cs.Close();
                        }

                        encryptString = Convert.ToBase64String(ms.ToArray());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return encryptString;
        }

        public static string DecryptRijndaelManagedWithoutRfc2898DerivedBytes(string str)
        {
            string cipherText = str;
            string decryptedText = String.Empty;
            byte[] cipherBytes = Convert.FromBase64String(cipherText);

            try
            {
                using (RijndaelManaged encryptor = new RijndaelManaged())
                {

                    encryptor.Key = Encoding.ASCII.GetBytes(dynamicEncryptionKey32);
                    encryptor.IV = dynamicEncSalt16;

                    using (MemoryStream ms = new MemoryStream())
                    {

                        using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateDecryptor(), CryptoStreamMode.Write))
                        {

                            cs.Write(cipherBytes, 0, cipherBytes.Length);

                            cs.Close();

                        }

                        decryptedText = Encoding.Unicode.GetString(ms.ToArray());
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine(exception.Message);
            }

            return decryptedText;
        }



        public static string EncryptDES(string strData)
        {
            string strKey = "AlliantF";
            byte[] key = ASCIIEncoding.ASCII.GetBytes(strKey); //Encryption Key   
            byte[] IV = { 107, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray;



            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                // DESCryptoServiceProvider is a cryptography class defind in c#.  
                using (DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider())
                {
                    inputByteArray = new ASCIIEncoding().GetBytes(strData);
                    MemoryStream Objmst = new MemoryStream();
                    CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateEncryptor(key, IV), CryptoStreamMode.Write);
                    Objcs.Write(inputByteArray, 0, inputByteArray.Length);
                    Objcs.FlushFinalBlock();
                    return Convert.ToBase64String(Objmst.ToArray());//encrypted string
                }



            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static string DecryptDES(string strData)
        {
            string strKey = "AlliantF";
            byte[] key = ASCIIEncoding.ASCII.GetBytes(strKey); //Encryption Key   
            byte[] IV = { 107, 20, 30, 40, 50, 60, 70, 80 };
            byte[] inputByteArray = new byte[strData.Length];

            try
            {
                key = Encoding.UTF8.GetBytes(strKey);
                using (DESCryptoServiceProvider ObjDES = new DESCryptoServiceProvider())
                {
                    inputByteArray = Convert.FromBase64String(strData);

                    MemoryStream Objmst = new MemoryStream();
                    CryptoStream Objcs = new CryptoStream(Objmst, ObjDES.CreateDecryptor(key, IV), CryptoStreamMode.Write);
                    Objcs.Write(inputByteArray, 0, inputByteArray.Length);
                    Objcs.FlushFinalBlock();

                    Encoding encoding = Encoding.UTF8;
                    return encoding.GetString(Objmst.ToArray());
                }

            }
            catch (System.Exception ex)
            {
                throw ex;
            }
        }

        public static string EncryptSimpleAES(string strData)
        {
            SimplerAES saes = new SimplerAES();
            return saes.EncryptSimpleAES(strData);
        }

        public static string DecryptSimpleAES(string strData)
        {
            SimplerAES saes = new SimplerAES();
            return saes.DecryptSimpleAES(strData);
        }


        public static string EncryptStaticAES(string strData)
        {
            byte[] key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };

            // a hardcoded IV should not be used for production AES-CBC code
            // IVs should be unpredictable per ciphertext
            byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };

            ICryptoTransform encryptor, decryptor;
            UTF8Encoding encoder;

            try
            {
                Stopwatch sw = Stopwatch.StartNew();
                using (RijndaelManaged rm = new RijndaelManaged())
                {

                    encryptor = rm.CreateEncryptor(key, vector);
                    decryptor = rm.CreateDecryptor(key, vector);
                    encoder = new UTF8Encoding();
                    byte[] encoded = encoder.GetBytes(strData);
                    return Convert.ToBase64String(Transform(encoded, encryptor));

                }
            }

            catch (Exception ex)
            {

            }

            return strData;

        }

        public static string DecryptStaticAES(string strData)
        {
            byte[] key = { 123, 217, 19, 11, 24, 26, 85, 45, 114, 184, 27, 162, 37, 112, 222, 209, 241, 24, 175, 144, 173, 53, 196, 29, 24, 26, 17, 218, 131, 236, 53, 209 };

            // a hardcoded IV should not be used for production AES-CBC code
            // IVs should be unpredictable per ciphertext
            byte[] vector = { 146, 64, 191, 111, 23, 3, 113, 119, 231, 121, 221, 112, 79, 32, 114, 156 };

            ICryptoTransform encryptor, decryptor;
            UTF8Encoding encoder;

            try
            {
                using (RijndaelManaged rm = new RijndaelManaged())
                {
                    encryptor = rm.CreateEncryptor(key, vector);
                    decryptor = rm.CreateDecryptor(key, vector);
                    encoder = new UTF8Encoding();
                    byte[] encoded = Convert.FromBase64String(strData);
                    return encoder.GetString(Transform((encoded), decryptor));

                }

            }
            catch (Exception ex)
            {

            }

            return strData;
        }


        protected static byte[] Transform(byte[] buffer, ICryptoTransform transform)
        {
            MemoryStream stream = new MemoryStream();
            using (CryptoStream cs = new CryptoStream(stream, transform, CryptoStreamMode.Write))
            {
                cs.Write(buffer, 0, buffer.Length);
            }

            return stream.ToArray();
        }
    }
}
