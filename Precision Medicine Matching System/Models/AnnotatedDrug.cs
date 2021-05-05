using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Precision_Medicine_Matching_System.Models
{
	public class AnnotatedDrug
	{
		[Required]
		[Display(Name = "ID")]
		public string Id { get; set; }
		
		[Required]
		public string Name { get; set; }

		[Required]
		[Display(Name = "Drug Url")]
		public string DrugUrl { get; set; }

		[Required]
		public int Biomarker { get; set; }
	}
}
