using Microsoft.EntityFrameworkCore;

namespace GMS.Models
{
    public class GMSDbContext:DbContext
    {
        public GMSDbContext()
        {
        }
        public GMSDbContext(DbContextOptions options) : base(options)
        {
        }
        public  DbSet<Invoice> Invoices { get; set; } = null!;
        public  DbSet<IssueLocker> IssueLockers { get; set; } = null!;
        public  DbSet<Locker> Lockers { get; set; } = null!;
        public  DbSet<Member> Members { get; set; } = null!;
        public  DbSet<Notification> Notifications { get; set; } = null!;
        public  DbSet<NotificationsRead> NotificationsReads { get; set; } = null!;
        public  DbSet<Payment> Payments { get; set; } = null!;
        public  DbSet<Role> Roles { get; set; } = null!;
        public  DbSet<Stock> Stocks { get; set; } = null!;
        public  DbSet<StockCategory> StockCategories { get; set; } = null!;
        public  DbSet<StockSubCategory> StockSubCategories { get; set; } = null!;
        public  DbSet<MembersSubscription> MembersSubscriptions { get; set; } = null!;
        public  DbSet<SubscriptionPlan> SubscriptionPlans { get; set; } = null!;
        public  DbSet<User> Users { get; set; } = null!;
        public  DbSet<UserRole> UserRoles { get; set; } = null!;


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(new Role
            {
                Id =1,
                Name="Super Admin",
                IsActive=true,
                IsDeleted=false,
                CreatedBy=1,
                CreatedAt = System.DateTime.Now

            }, new Role
            {
                Id = 2,
                Name = "Admin",
                IsActive = true,
                IsDeleted = false,
                CreatedBy = 1,
                CreatedAt = System.DateTime.Now

            });
        }
    }
}
