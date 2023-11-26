using Microsoft.EntityFrameworkCore;
using RegistrationWizard.Server.Models;

namespace RegistrationWizard.Server.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
    }
}
