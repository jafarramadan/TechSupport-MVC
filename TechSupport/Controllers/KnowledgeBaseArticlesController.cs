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
    public class KnowledgeBaseArticlesController : Controller
    {
        private readonly TechSupportDbContext _context;

        public KnowledgeBaseArticlesController(TechSupportDbContext context)
        {
            _context = context;
        }

        // GET: KnowledgeBaseArticles
        public async Task<IActionResult> Index()
        {
              return _context.KnowledgeBaseArticles != null ? 
                          View(await _context.KnowledgeBaseArticles.ToListAsync()) :
                          Problem("Entity set 'TechSupportDbContext.KnowledgeBaseArticles'  is null.");
        }

        // GET: KnowledgeBaseArticles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.KnowledgeBaseArticles == null)
            {
                return NotFound();
            }

            var knowledgeBaseArticle = await _context.KnowledgeBaseArticles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knowledgeBaseArticle == null)
            {
                return NotFound();
            }

            return View(knowledgeBaseArticle);
        }

        // GET: KnowledgeBaseArticles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: KnowledgeBaseArticles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Title,Content,PublishedDate")] KnowledgeBaseArticle knowledgeBaseArticle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(knowledgeBaseArticle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(knowledgeBaseArticle);
        }

        // GET: KnowledgeBaseArticles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.KnowledgeBaseArticles == null)
            {
                return NotFound();
            }

            var knowledgeBaseArticle = await _context.KnowledgeBaseArticles.FindAsync(id);
            if (knowledgeBaseArticle == null)
            {
                return NotFound();
            }
            return View(knowledgeBaseArticle);
        }

        // POST: KnowledgeBaseArticles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Title,Content,PublishedDate")] KnowledgeBaseArticle knowledgeBaseArticle)
        {
            if (id != knowledgeBaseArticle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(knowledgeBaseArticle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!KnowledgeBaseArticleExists(knowledgeBaseArticle.Id))
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
            return View(knowledgeBaseArticle);
        }

        // GET: KnowledgeBaseArticles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.KnowledgeBaseArticles == null)
            {
                return NotFound();
            }

            var knowledgeBaseArticle = await _context.KnowledgeBaseArticles
                .FirstOrDefaultAsync(m => m.Id == id);
            if (knowledgeBaseArticle == null)
            {
                return NotFound();
            }

            return View(knowledgeBaseArticle);
        }

        // POST: KnowledgeBaseArticles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.KnowledgeBaseArticles == null)
            {
                return Problem("Entity set 'TechSupportDbContext.KnowledgeBaseArticles'  is null.");
            }
            var knowledgeBaseArticle = await _context.KnowledgeBaseArticles.FindAsync(id);
            if (knowledgeBaseArticle != null)
            {
                _context.KnowledgeBaseArticles.Remove(knowledgeBaseArticle);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool KnowledgeBaseArticleExists(int id)
        {
          return (_context.KnowledgeBaseArticles?.Any(e => e.Id == id)).GetValueOrDefault();
        }
    }
}
