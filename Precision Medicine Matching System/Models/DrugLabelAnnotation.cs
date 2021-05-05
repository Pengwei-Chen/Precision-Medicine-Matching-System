using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Precision_Medicine_Matching_System.Models
{
	public class DrugLabelAnnotation
	{
		[Required]
		[Display(Name = "ID")]
		public string Id { get; set; }

		[Required]
		public string Source { get; set; }

		[Required]
		[Display(Name = "Dosing Information")]
		public string DosingInformation { get; set; }

		[Required]
		[Display(Name = "Summary Markdown")]
		public string SummaryMarkdown { get; set; }
	}
}
