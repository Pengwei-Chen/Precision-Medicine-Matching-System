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
            List<string> results = new();
            using (StreamReader streamReader = new(file.OpenReadStream()))
            {
                string line = streamReader.ReadLine();
                while (line != null)
                {
                    results.Add(line);
                    line = streamReader.ReadLine();
                }
            }
            ViewData["Results"] = results;
            return View();
		}
    }
}
