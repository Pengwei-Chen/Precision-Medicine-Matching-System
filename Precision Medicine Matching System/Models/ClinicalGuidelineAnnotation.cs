using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Precision_Medicine_Matching_System.Models
{
	public class ClinicalGuidelineAnnotation
	{
		[Display(Name = "ID")]
		public string Id { get; set; }
		public string Name { get; set; }
		public string Recommendation { get; set; }

		[Display(Name = "Drug ID")]
		public string Source { get; set; }

		[Display(Name = "Summary Markdown")]
		public string SummaryMarkdown { get; set; }
	}
}
