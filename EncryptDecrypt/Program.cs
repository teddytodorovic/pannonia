using System;
using System.Collections.Generic;
using System.Configuration;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Security;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography;
using Microsoft.Practices.EnterpriseLibrary.Security.Cryptography.Configuration;

namespace EncryptDecrypt
{
    class Program
    {
        //static IEncryptor encryptor = new Encryptor();
        static void Main(string[] args)
        {
            //CryptographySettings k = new CryptographySettings();
            //k.SymmetricCryptoProviders.Add();
            EncryptDecrypt(EncryptDecryptAlgorithms.EncryptAES, EncryptDecryptAlgorithms.DecryptAES);
            EncryptDecrypt(EncryptDecryptAlgorithms.EncryptAESWithoutRfc2898DeriveBytes, EncryptDecryptAlgorithms.DecryptAESWithoutRfc2898DeriveBytes);
            EncryptDecrypt(EncryptDecryptAlgorithms.EncryptEnterprise, EncryptDecryptAlgorithms.DecryptEnterprise);
            EncryptDecrypt(EncryptDecryptAlgorithms.EncryptRijndael, EncryptDecryptAlgorithms.DecryptRijndael);
            EncryptDecrypt(EncryptDecryptAlgorithms.EncryptRijndaelManaged, EncryptDecryptAlgorithms.DecryptRijndaelManaged);
            EncryptDecrypt(EncryptDecryptAlgorithms.EncryptRijndaelManagedWithoutRfc2898DerivedBytes, EncryptDecryptAlgorithms.DecryptRijndaelManagedWithoutRfc2898DerivedBytes);
            EncryptDecrypt(EncryptDecryptAlgorithms.EncryptDES, EncryptDecryptAlgorithms.DecryptDES);
            EncryptDecrypt(EncryptDecryptAlgorithms.EncryptSimpleAES, EncryptDecryptAlgorithms.DecryptSimpleAES);
            EncryptDecrypt(EncryptDecryptAlgorithms.EncryptStaticAES, EncryptDecryptAlgorithms.DecryptStaticAES);

            Console.ReadLine();

            //SecureString sec = new SecureString();
            //string pwd = "abc123"; /* Not Secure! */
            //pwd.ToCharArray().ToList().ForEach(sec.AppendChar);
            ///* and now : seal the deal */
            //sec.MakeReadOnly();
            //sec.ToString();

        }

        public static void EncryptDecrypt(Func<string, string> encryptionMethod, Func<string, string> decryptionMethod)
        {
            Console.WriteLine(encryptionMethod.Method.Name + " start");
            Stopwatch sw = Stopwatch.StartNew();
            int i = 0;
            while (i < 100)
            {
                string str = "tree09879622snell";
                string encStr = encryptionMethod(str);
                string deStr = decryptionMethod(encStr);
                i++;
            }
            Console.WriteLine(encryptionMethod.Method.Name + " completed in: " + sw.Elapsed);
        }


    }
}

