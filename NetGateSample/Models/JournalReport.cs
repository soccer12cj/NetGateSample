using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetGateSample.Models
{
	// using System.Xml.Serialization;
	// XmlSerializer serializer = new XmlSerializer(typeof(IATSRESPONSE));
	// using (StringReader reader = new StringReader(xml))
	// {
	//    var test = (IATSRESPONSE)serializer.Deserialize(reader);
	// }

	[XmlRoot("CST")]
	public class CustomerData
	{

		[XmlElement("CSTC")]
		public string CSTC { get; set; }

		[XmlElement("FN")]
		public string FirstName { get; set; }

		[XmlElement("LN")]
		public string LastName { get; set; }

		[XmlElement("ADD")]
		public string Address { get; set; }

		[XmlElement("CTY")]
		public string City { get; set; }

		[XmlElement("ST")]
		public string State { get; set; }

		[XmlElement("CNT")]
		public string Country { get; set; }

		[XmlElement("ZC")]
		public string ZipCode { get; set; }

		[XmlElement("PH")]
		public string Phone { get; set; }

		[XmlElement("MB")]
		public string MobilePhone { get; set; }

		[XmlElement("FX")]
		public string Fax { get; set; }

		[XmlElement("EM")]
		public string Email { get; set; }
	}

	[XmlRoot("CC")]
	public class CreditCardData
	{

		[XmlElement("CCN")]
		public string CardNumber { get; set; }

		[XmlElement("MP")]
		public string CardType { get; set; }

		[XmlElement("EXP")]
		public string CardExpiry { get; set; }
	}

	[XmlRoot("TN")]
	public class Transaction
	{

		[XmlElement("TNTYP")]
		public string TransactionType { get; set; }

		[XmlElement("TNID")]
		public string TransactionId { get; set; }

		[XmlElement("AGT")]
		public string Agent { get; set; }

		[XmlElement("CST")]
		public CustomerData CustomerData { get; set; }

		[XmlElement("CC")]
		public CreditCardData CreditCardData { get; set; }

		[XmlElement("INV")]
		public string InvoiceNumber { get; set; }

		[XmlElement("DTM")]
		public string TransactionDateTime { get; set; }

		[XmlElement("RE")]
		public string RE { get; set; }

		[XmlElement("ANM")]
		public string ANM { get; set; }

		[XmlElement("IT1")]
		public string Item1 { get; set; }

		[XmlElement("IT2")]
		public string Item2 { get; set; }

		[XmlElement("IT3")]
		public string Item3 { get; set; }

		[XmlElement("IT4")]
		public string Item4 { get; set; }

		[XmlElement("IT5")]
		public string Item5 { get; set; }

		[XmlElement("IT6")]
		public string Item6 { get; set; }

		[XmlElement("AMT")]
		public double Amount { get; set; }

		[XmlElement("RST")]
		public string ResponseString { get; set; }

		[XmlElement("CM")]
		public string CM { get; set; }
	}

	[XmlRoot("JOURNALREPORT")]
	public class JournalReport
	{

		[XmlElement("TN")]
		public List<Transaction> Transactions { get; set; }
	}

	[XmlRoot("IATSRESPONSE")]
	public class JournalReportResponse
	{
		//[XmlAttribute("xmlns")]
		//public object Xmlns { get; set; }

		[XmlElement("STATUS")]
		public string Status { get; set; }

		[XmlElement("ERRORS")]
		public string Errors { get; set; }

		[XmlElement("JOURNALREPORT")]
		public JournalReport JournalReport { get; set; }

       

        [XmlText]
        public string Text { get; set; }
    }


}
