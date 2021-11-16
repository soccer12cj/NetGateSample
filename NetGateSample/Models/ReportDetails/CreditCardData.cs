using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetGateSample.Models.ReportDetails
{
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
}
