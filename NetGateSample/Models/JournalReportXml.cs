using NetGateSample.Models.ReportDetails;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetGateSample.Models
{

	[XmlRoot("JOURNALREPORT")]
	public class JournalReportXml
	{
		[XmlElement("TN")]
		public List<TransactionData> Transactions { get; set; }
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
		public JournalReportXml JournalReport { get; set; }

       

        [XmlText]
        public string Text { get; set; }
    }


}
