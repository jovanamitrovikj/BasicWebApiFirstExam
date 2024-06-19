using BasicWebApiFirstExam.Domain;
using Microsoft.EntityFrameworkCore;

namespace BasicWebApiFirstExam.Data
{
    public class CompanyDbContext : DbContext
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {

        }

        public DbSet<Company> Companies { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<Country> Countries { get; set; }
    }
}
