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
    public class SupportRequestsController : Controller
    {
        private readonly TechSupportDbContext _context;

        public SupportRequestsController(TechSupportDbContext context)
        {
            _context = context;
        }

        // GET: SupportRequests
        public async Task<IActionResult> Index()
        {
              return _context.SupportRequests != null ? 
                          View(await _context.SupportRequests.ToListAsync()) :
                          Problem("Entity set 'TechSupportDbContext.SupportRequests'  is null.");
        }

        // GET: SupportRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.SupportRequests == null)
            {
                return NotFound();
            }

            var supportRequest = await _context.SupportRequests
                .FirstOrDefaultAsync(m => m.SupportRequestId == id);
            if (supportRequest == null)
            {
                return NotFound();
            }

            return View(supportRequest);
        }

        // GET: SupportRequests/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SupportRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SupportRequestId,CustomerName,CustomerPhoneNumber,Description,RequestDate,ReceiveUpdates,Status")] SupportRequest supportRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(supportRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(supportRequest);
        }

        // GET: SupportRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.SupportRequests == null)
            {
                return NotFound();
            }

            var supportRequest = await _context.SupportRequests.FindAsync(id);
            if (supportRequest == null)
            {
                return NotFound();
            }
            return View(supportRequest);
        }

        // POST: SupportRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SupportRequestId,CustomerName,CustomerPhoneNumber,Description,RequestDate,ReceiveUpdates,Status")] SupportRequest supportRequest)
        {
            if (id != supportRequest.SupportRequestId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(supportRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SupportRequestExists(supportRequest.SupportRequestId))
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
            return View(supportRequest);
        }

        // GET: SupportRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.SupportRequests == null)
            {
                return NotFound();
            }

            var supportRequest = await _context.SupportRequests
                .FirstOrDefaultAsync(m => m.SupportRequestId == id);
            if (supportRequest == null)
            {
                return NotFound();
            }

            return View(supportRequest);
        }

        // POST: SupportRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.SupportRequests == null)
            {
                return Problem("Entity set 'TechSupportDbContext.SupportRequests'  is null.");
            }
            var supportRequest = await _context.SupportRequests.FindAsync(id);
            if (supportRequest != null)
            {
                _context.SupportRequests.Remove(supportRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SupportRequestExists(int id)
        {
          return (_context.SupportRequests?.Any(e => e.SupportRequestId == id)).GetValueOrDefault();
        }
    }
}
