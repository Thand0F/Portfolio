using JobShadowJournal.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace JobShadowJournal.Data
{
    public class AppDbContext(DbContextOptions<AppDbContext> options) : DbContext(options)
    {
        public DbSet<JournalEntry> JournalEntries { get; set; }
    }
}
