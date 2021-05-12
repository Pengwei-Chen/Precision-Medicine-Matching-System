using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Precision_Medicine_Matching_System.Data;
using Precision_Medicine_Matching_System.Models;

namespace Precision_Medicine_Matching_System.Controllers
{
    public class DrugLabelAnnotationsController : Controller
    {
        private readonly DatabaseContext _context;

        public DrugLabelAnnotationsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: DrugLabelAnnotations
        public async Task<IActionResult> Index(string searchString)
        {
            var drugLabelAnnotations = from m in _context.DrugLabelAnnotation select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                drugLabelAnnotations = drugLabelAnnotations.Where(s => s.Id.Contains(searchString));
            }
            return View(await drugLabelAnnotations.ToListAsync());
        }

        // GET: DrugLabelAnnotations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugLabelAnnotation = await _context.DrugLabelAnnotation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drugLabelAnnotation == null)
            {
                return NotFound();
            }

            return View(drugLabelAnnotation);
        }

        // GET: DrugLabelAnnotations/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: DrugLabelAnnotations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Source,DosingInformation,SummaryMarkdown")] DrugLabelAnnotation drugLabelAnnotation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(drugLabelAnnotation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(drugLabelAnnotation);
        }

        // GET: DrugLabelAnnotations/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugLabelAnnotation = await _context.DrugLabelAnnotation.FindAsync(id);
            if (drugLabelAnnotation == null)
            {
                return NotFound();
            }
            return View(drugLabelAnnotation);
        }

        // POST: DrugLabelAnnotations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Source,DosingInformation,SummaryMarkdown")] DrugLabelAnnotation drugLabelAnnotation)
        {
            if (id != drugLabelAnnotation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(drugLabelAnnotation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DrugLabelAnnotationExists(drugLabelAnnotation.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(drugLabelAnnotation);
        }

        // GET: DrugLabelAnnotations/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var drugLabelAnnotation = await _context.DrugLabelAnnotation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (drugLabelAnnotation == null)
            {
                return NotFound();
            }

            return View(drugLabelAnnotation);
        }

        // POST: DrugLabelAnnotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var drugLabelAnnotation = await _context.DrugLabelAnnotation.FindAsync(id);
            _context.DrugLabelAnnotation.Remove(drugLabelAnnotation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DrugLabelAnnotationExists(string id)
        {
            return _context.DrugLabelAnnotation.Any(e => e.Id == id);
        }
    }
}
