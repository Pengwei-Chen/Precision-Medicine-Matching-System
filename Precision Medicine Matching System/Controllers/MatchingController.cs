using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace Precision_Medicine_Matching_System.Controllers
{
    public class MatchingController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Result(IFormFile file)
		{
            ViewData["Name"] = file.FileName;
            HashSet<string> results = new();
            using (StreamReader streamReader = new(file.OpenReadStream()))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    string[] items = line.Split("\t");
                    if(items.Length >=8 && !items[8].Equals("synonymous SNV"))
                        results.Add(items[6]);
                    line = streamReader.ReadLine();
                }
            }
            ViewData["Results"] = results;
            return View();
		}
    }
}
