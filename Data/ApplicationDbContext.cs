using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using FinanceManagement.Models;

namespace FinanceManagement.Data
{
   
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public DbSet<FinanceManagement.Models.AppFile> AppFile { get; set; } = default!;
        public DbSet<Category> Categories { get; set; }
        public DbSet<Household> Households { get; set; }
        public DbSet<HouseholdMember> HouseholdMembers { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
            
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder
                .Entity<Transaction>()
                .ToTable(t => t.HasCheckConstraint("ck_type" ,"[Type] IN ('Income', 'Expense')"));
            builder
                .Entity<HouseholdMember>()
                .HasOne(hm => hm.User)
                .WithMany(a => a.HouseholdsBelong)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .Entity<HouseholdMember>()
                .HasOne(hm => hm.Household)
                .WithMany(a => a.Members)
                .OnDelete(DeleteBehavior.NoAction);
            builder
                .Entity<ApplicationUser>()
                .Property(u => u.UserName)
                .IsRequired()
                .HasMaxLength(20);
        }
       
    }
}
