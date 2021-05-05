using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Precision_Medicine_Matching_System.Models;

namespace Precision_Medicine_Matching_System.Data
{
	public class DatabaseContext : DbContext
	{
		public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options) { }
		public DbSet<DrugLabelAnnotation> DrugLabelAnnotation { get; set; }
		public DbSet<ClinicalGuidelineAnnotation> ClinicalGuidelineAnnotation { get; set; }
		public DbSet<AnnotatedDrug> AnnotatedDrug { get; set; }
	}
}
