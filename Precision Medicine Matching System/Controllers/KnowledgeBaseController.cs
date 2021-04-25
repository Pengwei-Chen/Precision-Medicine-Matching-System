using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Precision_Medicine_Matching_System.Controllers
{
	public class KnowledgeBaseController : Controller
	{
		public IActionResult Index()
		{
			return View();
		}

		public IActionResult DrugLabelAnnotations()
		{
			return View();
		}

		public IActionResult ClinicalGuidelineAnnotations()
		{
			return View();
		}

		public IActionResult AnnotatedDrugs()
		{
			return View();
		}
	}
}
