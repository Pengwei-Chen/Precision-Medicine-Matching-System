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
    public class AnnotatedDrugsController : Controller
    {
        private readonly DatabaseContext _context;

        public AnnotatedDrugsController(DatabaseContext context)
        {
            _context = context;
        }

        // GET: AnnotatedDrugs
        public async Task<IActionResult> Index(string searchString)
        {
            var annotatedDrugs = from m in _context.AnnotatedDrug select m;
            if (!string.IsNullOrEmpty(searchString))
            {
                annotatedDrugs = annotatedDrugs.Where(s => s.Id.Contains(searchString));
            }

            return View(await annotatedDrugs.ToListAsync());
        }

        // GET: AnnotatedDrugs/Details/5
        public async Task<IActionResult> Details(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annotatedDrug = await _context.AnnotatedDrug
                .FirstOrDefaultAsync(m => m.Id == id);
            if (annotatedDrug == null)
            {
                return NotFound();
            }

            return View(annotatedDrug);
        }

        // GET: AnnotatedDrugs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AnnotatedDrugs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,DrugUrl,Biomarker")] AnnotatedDrug annotatedDrug)
        {
            if (ModelState.IsValid)
            {
                _context.Add(annotatedDrug);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(annotatedDrug);
        }

        // GET: AnnotatedDrugs/Edit/5
        public async Task<IActionResult> Edit(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annotatedDrug = await _context.AnnotatedDrug.FindAsync(id);
            if (annotatedDrug == null)
            {
                return NotFound();
            }
            return View(annotatedDrug);
        }

        // POST: AnnotatedDrugs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,DrugUrl,Biomarker")] AnnotatedDrug annotatedDrug)
        {
            if (id != annotatedDrug.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(annotatedDrug);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AnnotatedDrugExists(annotatedDrug.Id))
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
            return View(annotatedDrug);
        }

        // GET: AnnotatedDrugs/Delete/5
        public async Task<IActionResult> Delete(string id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var annotatedDrug = await _context.AnnotatedDrug
                .FirstOrDefaultAsync(m => m.Id == id);
            if (annotatedDrug == null)
            {
                return NotFound();
            }

            return View(annotatedDrug);
        }

        // POST: AnnotatedDrugs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            var annotatedDrug = await _context.AnnotatedDrug.FindAsync(id);
            _context.AnnotatedDrug.Remove(annotatedDrug);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AnnotatedDrugExists(string id)
        {
            return _context.AnnotatedDrug.Any(e => e.Id == id);
        }
    }
}
