using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TechSupport.Data;
using TechSupport.Models;

namespace TechSupport.Controllers
{
    public class RepairJobsController : Controller
    {
        private readonly TechSupportDbContext _context;

        public RepairJobsController(TechSupportDbContext context)
        {
            _context = context;
        }

        // GET: RepairJobs
        public async Task<IActionResult> Index()
        {
              return _context.RepairJobs != null ? 
                          View(await _context.RepairJobs.ToListAsync()) :
                          Problem("Entity set 'TechSupportDbContext.RepairJobs'  is null.");
        }

        // GET: RepairJobs/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.RepairJobs == null)
            {
                return NotFound();
            }

            var repairJob = await _context.RepairJobs
                .FirstOrDefaultAsync(m => m.RepairJobId == id);
            if (repairJob == null)
            {
                return NotFound();
            }

            return View(repairJob);
        }

        // GET: RepairJobs/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: RepairJobs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("RepairJobId,JobDescription,Completed,ScheduledDate")] RepairJob repairJob)
        {
            if (ModelState.IsValid)
            {
                _context.Add(repairJob);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(repairJob);
        }

        // GET: RepairJobs/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.RepairJobs == null)
            {
                return NotFound();
            }

            var repairJob = await _context.RepairJobs.FindAsync(id);
            if (repairJob == null)
            {
                return NotFound();
            }
            return View(repairJob);
        }

        // POST: RepairJobs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("RepairJobId,JobDescription,Completed,ScheduledDate")] RepairJob repairJob)
        {
            if (id != repairJob.RepairJobId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(repairJob);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!RepairJobExists(repairJob.RepairJobId))
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
            return View(repairJob);
        }

        // GET: RepairJobs/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.RepairJobs == null)
            {
                return NotFound();
            }

            var repairJob = await _context.RepairJobs
                .FirstOrDefaultAsync(m => m.RepairJobId == id);
            if (repairJob == null)
            {
                return NotFound();
            }

            return View(repairJob);
        }

        // POST: RepairJobs/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.RepairJobs == null)
            {
                return Problem("Entity set 'TechSupportDbContext.RepairJobs'  is null.");
            }
            var repairJob = await _context.RepairJobs.FindAsync(id);
            if (repairJob != null)
            {
                _context.RepairJobs.Remove(repairJob);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RepairJobExists(int id)
        {
          return (_context.RepairJobs?.Any(e => e.RepairJobId == id)).GetValueOrDefault();
        }
    }
}
