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


namespace NetGateSample
{
    class Program
    {
        static void Main(string[] args)
        {

            #region REPORTING
                        
            try
            {
                //Create a new instance of the proxy class
                var reporting = new Iats.NetGate.Reporting.ReportLinkV3();
                
                //call your soap endpoint using the proxy class
                var xml = reporting.GetCreditCardApprovedSpecificDateXML("test88", "test88", DateTime.Now.AddDays(-1), "127.0.0.1");

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
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                if (ex.InnerException != null)
                {
                    Console.WriteLine(ex.InnerException.Message);
                }
            }

            #endregion REPORTING
            
            
            
            
            Console.ReadKey();
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
