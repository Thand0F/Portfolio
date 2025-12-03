using Microsoft.AspNetCore.Mvc;
using JobShadowJournal.Models;
using Microsoft.EntityFrameworkCore;
using JobShadowJournal.Data;

namespace JobShadowJournal.Controllers
{
    public class JournalController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        public async Task<IActionResult> Index()
        {
            return View(await _context.JournalEntries.ToListAsync());
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(JournalEntry entry)
        {
            if (!ModelState.IsValid) return View(entry);

            _context.Add(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Edit(int id)
        {
            var entry = await _context.JournalEntries.FindAsync(id);
            return View(entry);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(JournalEntry entry)
        {
            _context.Update(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int id)
        {
            var entry = await _context.JournalEntries.FindAsync(id);
            _context.JournalEntries.Remove(entry);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
