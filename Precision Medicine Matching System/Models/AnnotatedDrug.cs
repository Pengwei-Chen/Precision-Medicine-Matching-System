using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace Precision_Medicine_Matching_System.Models
{
	public class AnnotatedDrug
	{
		[Display(Name = "ID")]
		public string Id { get; set; }
		public string Name { get; set; }

		[Display(Name = "Drug Url")]
		public string DrugUrl { get; set; }
		public int Biomarker { get; set; }
	}
}
