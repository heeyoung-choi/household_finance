using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinanceManagement.Models;

namespace FinanceManagement.Data
{
    public class ApplicationUser : IdentityUser
    {
        [PersonalData]
        public string CustomTag { get; set; }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }
        public DbSet<FinanceManagement.Models.AppFile> AppFile { get; set; } = default!;
    }
}
