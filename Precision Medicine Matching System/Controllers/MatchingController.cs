using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using Precision_Medicine_Matching_System.Data;
using Precision_Medicine_Matching_System.Models;


namespace Precision_Medicine_Matching_System.Controllers
{
    public class MatchingController : Controller
    {
        private readonly DatabaseContext _context;

        public MatchingController(DatabaseContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(IFormFile file)
		{
            ViewData["Name"] = file.FileName;
            HashSet<string> searchStrings = new();
            HashSet<IQueryable<DrugLabelAnnotation>> results = new();
            using (StreamReader streamReader = new(file.OpenReadStream()))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    string[] items = line.Split("\t");
                    if(items.Length >=8 && !items[8].Equals("synonymous SNV"))
                        searchStrings.Add(items[6]);
                    line = streamReader.ReadLine();
                }
            }
            foreach (string searchString in searchStrings)
            {
                var drugLabelAnnotations = from m in _context.DrugLabelAnnotation select m;
                drugLabelAnnotations = drugLabelAnnotations.Where(s => s.SummaryMarkdown.Contains(searchString));
                results.Add(drugLabelAnnotations);
            }
            ViewData["Results"] = results;
            return View();
		}
    }
}
