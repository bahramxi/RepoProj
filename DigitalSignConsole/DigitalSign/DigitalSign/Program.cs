using DigitalSign.Model;
using System;
using System.Reflection;

namespace DigitalSign
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var myModel = new InfoModel {
                AcceptorCode="mostafa",
                AccessAddress="bahrami",
                Amount="12566",
                DestinationPAN="",
                RRN="testtest",
                SourcePAN="",
                Stan="5894631557270956",
                TerminalNumber="",
                TrackingNumber="689",
                TransactionType="1"
            };

           var myString= InfoModel.StringConcat(myModel);

           var signData= InfoModel.SignatureSHA256(myString);

            Console.WriteLine(signData);
            Console.ReadLine();


        }
    }
}
