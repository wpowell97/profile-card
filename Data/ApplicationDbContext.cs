using Microsoft.EntityFrameworkCore;
using ProfileCardApp.Models;

namespace ProfileCardApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<ContactMessage> ContactMessages { get; set; }
    }
}
