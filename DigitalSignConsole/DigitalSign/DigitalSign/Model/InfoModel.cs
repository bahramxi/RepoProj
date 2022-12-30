using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Globalization;
using System.IO;
using System.Net.Mail;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace DigitalSign.Model
{
    public class InfoModel
    {
        public string TrackingNumber { get; set; }
        public string SourcePAN { get; set; }
        public string DestinationPAN { get; set; }
        public string Amount { get; set; }
        public string TransactionType { get; set; }
        public string AcceptorCode { get; set; }
        public string TerminalNumber { get; set; }
        public string AccessAddress { get; set; }
        public string RRN { get; set; }
        public string Stan { get; set; }


        public static string StringConcat(InfoModel model)
        {
            foreach (PropertyInfo item in model.GetType().GetProperties())
            {

                if (string.IsNullOrEmpty(item.GetValue(model).ToString()))
                {
                    item.SetValue(model, "null");

                }

            }
            var myStr = model.TrackingNumber + "|" + model.SourcePAN + "|" + model.DestinationPAN + "|" + model.Amount + "|" + model.TransactionType +
                "|" + model.AcceptorCode + "|" + model.TerminalNumber + "|" + model.AccessAddress + "|" + model.RRN + "|" + model.Stan;

            return myStr;

        }

        public static string SignatureSHA256(string plainText)
        {   
            var privateKeyAddress = @"E:\sign\key_pair.pem";
            string pkText = File.ReadAllText(privateKeyAddress);
            var rsa = RSA.Create();
            rsa.ImportFromPem(pkText.ToCharArray());
            var bytesPlainTextData = Encoding.Default.GetBytes(plainText);
            var bytesCypherText = rsa.SignData(bytesPlainTextData,HashAlgorithmName.SHA256, RSASignaturePadding.Pkcs1);
            var cypherText = Convert.ToBase64String(bytesCypherText);
            //string privateKeyPEM = key.Replace("-----BEGIN PRIVATE KEY-----", "").Replace("\n",string.Empty).Replace("-----END PRIVATE KEY-----", "");
            //byte[] originalData = Encoding.ASCII.GetBytes(plainText);
            //byte[] pkEncript = Encoding.ASCII.GetBytes(privateKeyPEM);

            //var rsa = RSA.Create();
            ////   
            //RSACryptoServiceProvider rSA = new RSACryptoServiceProvider();
            //var PkRsa = rsa.Encrypt(pkEncript);

            //byte[] signedData = HashAndSignBytes(originalData, PkRsa);


            //  RSAParameters Key = RSAalg.ExportParameters(true);

            //  byte[] signedData = signedData = HashAndSignBytes(originalData, Key);
            // byte[] signature = RSA.SignData();

            return cypherText;
        }

        //public static byte[] HashAndSignBytes(byte[] DataToSign, byte[] Key)
        //{
        //    try
        //    {
        //        // Create a new instance of RSACryptoServiceProvider using the
        //        // key from RSAParameters.
        //        RSACryptoServiceProvider RSAalg = new RSACryptoServiceProvider();
        //        RSAalg.ImportParameters(Key);

        //        // Hash and sign the data. Pass a new instance of SHA256
        //        // to specify the hashing algorithm.
        //        return RSAalg.SignData(DataToSign, SHA256.Create());
        //    }
        //    catch (CryptographicException e)
        //    {
        //        Console.WriteLine(e.Message);

        //        return null;
        //    }
        //}

    }
}
