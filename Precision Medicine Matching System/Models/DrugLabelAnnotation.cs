using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Precision_Medicine_Matching_System.Models
{
	public class DrugLabelAnnotation
	{
		[Display(Name = "ID")]
		public string Id { get; set; }
		public string Source { get; set; }

		[Display(Name = "Dosing Information")]
		public string DosingInformation { get; set; }

		[Display(Name = "Summary Markdown")]
		public string SummaryMarkdown { get; set; }
	}
}
