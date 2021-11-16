using System;
using System.Xml.Serialization;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NetGateSample.Models;
using System.IO;
using System.Xml;
using System.Runtime.Remoting.Messaging;
using NetGateSample.Models.ReportDetails;

namespace NetGateSample
{
    class Program
    {
        static void Main(string[] args)
        {

            #region REPORTING

            try
            {
                ////1) Reporting V3 XML Example
                GetCreditCardApprovalXmlReportingV3();

                //2) Reporting V1 CSV File Example
                //GetCreditCardApprovalCsvReportingV1();
            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }
            finally 
            {
                Console.ReadKey();
            }
            #endregion REPORTING
            
            
            
            
            
        }

        private static void GetCreditCardApprovalCsvReportingV1()
        {
            var reportingv1 = new Iats.NetGate.Reportingv1.ReportLink();
            var xml = reportingv1.GetCreditCardJournalCSV("aura88", "aura88", DateTime.Now, "127.0.0.1");
            var iatsResponse = ConvertNode<JournalReportCsv.JournalReportResponse>(xml);

            //Check to make sure the objects exist and has records
            if (iatsResponse?.File?.Length > 0)
            {
                var file = Encoding.UTF8.GetString(Convert.FromBase64String(iatsResponse.File));
                string[] strSeparators = new string[] { "\r\n" };
                string[] Lines = file.Split(strSeparators, StringSplitOptions.None);

                List<TransactionData> transactions = Lines.Skip(1).Select(x => JournalReportCsv.FromCsv(x.ToString())).ToList();

                var i = 1;
                //Loops through each of the transactions in the JournalReport
                foreach (var items in transactions)
                {
                    Console.WriteLine($"{i})\t TransactionID: {items.TransactionId} TransactionType: {items.TransactionType} Amount:{items.Amount}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Nothing to see here.");
            }
        }

        private static void GetCreditCardApprovalXmlReportingV3()
        {
            //Create a new instance of the proxy class
            var reporting = new Iats.NetGate.Reporting.ReportLinkV3();

            //call your soap endpoint using the proxy class
            var xml = reporting.GetCreditCardApprovedSpecificDateXML("test88", "test88", DateTime.Now, "127.0.0.1");

            //Calls a private class to convert the XmlNode to a IatsResponse object 
            var iatsResponse = ConvertNode<JournalReportResponse>(xml);
            
            //Check to make sure the objects exist and has records
            if (iatsResponse?.JournalReport?.Transactions?.Count > 0)
            {
                var i = 1;
                //Loops through each of the transactions in the JournalReport
                foreach (var items in iatsResponse.JournalReport.Transactions)
                {
                    Console.WriteLine($"{i})\t TransactionID: {items.TransactionId} TransactionType: {items.TransactionType} CardType: {items.CreditCardData.CardType} Amount:{items.Amount}");
                    i++;
                }
            }
            else
            {
                Console.WriteLine("Nothing to see here.");
            }
        }

        /// <summary>
        /// Generic method to convert the XmlNode to object.
        /// </summary>
        /// <typeparam name="T">Generic Type</typeparam>
        /// <param name="node">XmlNode to Convert</param>
        /// <returns></returns>
        private static T ConvertNode<T>(XmlNode node) where T : class
        {
            MemoryStream stm = new MemoryStream();

            StreamWriter stw = new StreamWriter(stm);
            stw.Write(node.OuterXml);
            stw.Flush();

            stm.Position = 0;

            XmlSerializer ser = new XmlSerializer(typeof(T));
            T result = (ser.Deserialize(stm) as T);

            return result;
        }
    }
}
