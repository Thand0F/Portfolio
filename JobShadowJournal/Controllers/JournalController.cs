using iTextSharp.text;
using iTextSharp.text.pdf;
using JobShadowJournal.Data;
using JobShadowJournal.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JobShadowJournal.Controllers
{
    public class JournalController(AppDbContext context) : Controller
    {
        private readonly AppDbContext _context = context;

        public async Task<IActionResult> Index(string search)
        {
            ViewBag.Search = search;

            var query = _context.JournalEntries.AsQueryable();

            if (!string.IsNullOrEmpty(search))
            {
                query = query.Where(e =>
                    e.Title.Contains(search) ||
                    e.Content.Contains(search));
            }

            return View(await query.ToListAsync());
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

        public async Task<IActionResult> ExportPdf(int id)
        {
            var entry = await _context.JournalEntries.FindAsync(id);
            if (entry == null) return NotFound();

            using var stream = new MemoryStream();
            var document = new Document();
            PdfWriter.GetInstance(document, stream);

            document.Open();

            document.Add(new Paragraph($"Journal Entry #{entry.Id}\n\n"));
            document.Add(new Paragraph($"Title: {entry.Title}\n"));
            document.Add(new Paragraph($"Date: {entry.DateCreated.ToShortDateString()}\n\n"));
            document.Add(new Paragraph("Content:\n"));
            document.Add(new Paragraph(entry.Content));

            document.Close();

            return File(stream.ToArray(), "application/pdf", $"JournalEntry_{entry.Id}.pdf");
        }
    }
}
