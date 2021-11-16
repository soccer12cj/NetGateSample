using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace NetGateSample.Models.ReportDetails
{
	[XmlRoot("CST")]
	public class CustomerData
	{
		public string CustomerCode { get; set; }
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

}
