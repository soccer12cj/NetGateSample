using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetGateSample.Models.ReportDetails
{
	[XmlRoot("TN")]
	public class TransactionData
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
		public decimal Amount { get; set; }

		[XmlElement("RST")]
		public string ResponseString { get; set; }

		[XmlElement("CM")]
		public string CM { get; set; }
		public string Detail { get; set; }
	}
}
