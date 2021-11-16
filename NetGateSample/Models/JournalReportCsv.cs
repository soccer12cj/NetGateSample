using NetGateSample.Models.ReportDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetGateSample.Models
{
    public class JournalReportCsv
    {

        [XmlRoot("IATSRESPONSE")]
        public class JournalReportResponse
        {
            //[XmlAttribute("xmlns")]
            //public object Xmlns { get; set; }

            [XmlElement("STATUS")]
            public string Status { get; set; }

            [XmlElement("ERRORS")]
            public string Errors { get; set; }

            [XmlElement("FILE")]
            public string File { get; set; }

            public List<TransactionData> Transactions { get; set; }

        }



        public static TransactionData FromCsv(string csvLine)
        {

            TransactionData transaction = new TransactionData();
            CustomerData customerData = new CustomerData();
            CreditCardData creditCardData = new CreditCardData();
            try
            {
                string[] values = csvLine.Split(',');

                transaction.InvoiceNumber = values[0].ToString();
                transaction.TransactionDateTime = values[1].ToString();
                transaction.Agent = values[2].ToString();
                customerData.CustomerCode = values[3].ToString();
                creditCardData.CardType = values[4].ToString();
                customerData.FirstName = values[5].ToString();
                customerData.LastName = values[6].ToString();
                creditCardData.CardNumber = values[7].ToString();
                creditCardData.CardExpiry = values[8].ToString();
                transaction.Amount = Convert.ToDecimal(values[9]);
                transaction.ResponseString = values[10].ToString();
                transaction.Detail = values[11].ToString();
                transaction.TransactionId = values[12].ToString();
                transaction.CreditCardData = creditCardData;
                transaction.CustomerData = customerData;

               
            }
            catch (Exception ex)
            {

                Console.Write($"ERROR parsing this line: {csvLine}");
                Console.WriteLine(ex.Message);
            }

            return transaction;
        }
    }
}
