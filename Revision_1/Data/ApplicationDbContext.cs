namespace Revision_1.Data;
using Revision_1.Entities;
using Microsoft.EntityFrameworkCore;
public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options ) : base(options) { }
    public DbSet<Product> Products { get; set; }
}