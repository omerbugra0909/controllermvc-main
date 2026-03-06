using Microsoft.EntityFrameworkCore;
using controllermvc.Models;

namespace controllermvc.Data
{
    public class NoteDbContext : DbContext
{
    public NoteDbContext(DbContextOptions<NoteDbContext> options) : base(options)
    {
    }

    public DbSet<Note> Notes { get; set; }
}}