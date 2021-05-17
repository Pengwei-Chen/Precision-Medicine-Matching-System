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
    public class ClinicalGuidelineAnnotationsController : Controller
    {
        private readonly DatabaseContext _context;

        public ClinicalGuidelineAnnotationsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: ClinicalGuidelineAnnotations
        public async Task<IActionResult> Index(string searchString)
        {
            var clinicalGuidelineAnnotations = from m in _context.ClinicalGuidelineAnnotation select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                clinicalGuidelineAnnotations = clinicalGuidelineAnnotations.Where(s => s.Id.Contains(searchString));
            }

            return View(await clinicalGuidelineAnnotations.ToListAsync());
        }

        // GET: ClinicalGuidelineAnnotations/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicalGuidelineAnnotation = await _context.ClinicalGuidelineAnnotation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicalGuidelineAnnotation == null)
            {
                return NotFound();
            }

            return View(clinicalGuidelineAnnotation);
        }

        // GET: ClinicalGuidelineAnnotations/Create
        [Administrator]
        public IActionResult Create()
        {
            return View();
        }

        // POST: ClinicalGuidelineAnnotations/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Administrator]
        public async Task<IActionResult> Create([Bind("Id,Name,Recommendation,Drug,Source,SummaryMarkdown")] ClinicalGuidelineAnnotation clinicalGuidelineAnnotation)
        {
            if (ModelState.IsValid)
            {
                _context.Add(clinicalGuidelineAnnotation);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(clinicalGuidelineAnnotation);
        }

        // GET: ClinicalGuidelineAnnotations/Edit/5
        [Administrator]
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicalGuidelineAnnotation = await _context.ClinicalGuidelineAnnotation.FindAsync(id);
            if (clinicalGuidelineAnnotation == null)
            {
                return NotFound();
            }
            return View(clinicalGuidelineAnnotation);
        }

        // POST: ClinicalGuidelineAnnotations/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Administrator]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Recommendation,Source,SummaryMarkdown")] ClinicalGuidelineAnnotation clinicalGuidelineAnnotation)
        {
            if (id != clinicalGuidelineAnnotation.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(clinicalGuidelineAnnotation);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ClinicalGuidelineAnnotationExists(clinicalGuidelineAnnotation.Id))
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
            return View(clinicalGuidelineAnnotation);
        }

        // GET: ClinicalGuidelineAnnotations/Delete/5
        [Administrator]
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var clinicalGuidelineAnnotation = await _context.ClinicalGuidelineAnnotation
                .FirstOrDefaultAsync(m => m.Id == id);
            if (clinicalGuidelineAnnotation == null)
            {
                return NotFound();
            }

            return View(clinicalGuidelineAnnotation);
        }

        // POST: ClinicalGuidelineAnnotations/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Administrator]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var clinicalGuidelineAnnotation = await _context.ClinicalGuidelineAnnotation.FindAsync(id);
            _context.ClinicalGuidelineAnnotation.Remove(clinicalGuidelineAnnotation);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ClinicalGuidelineAnnotationExists(string id)
        {
            return _context.ClinicalGuidelineAnnotation.Any(e => e.Id == id);
        }
    }
}
