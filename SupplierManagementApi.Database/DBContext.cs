using Microsoft.EntityFrameworkCore;
using SupplierManagementApi.Database.Tables;


namespace SupplierManagementApi.Database
{
    public class DBContext : DbContext
    {
        public DBContext(DbContextOptions<DBContext> dbContext) : base(dbContext)
        {
            Database.Migrate();
        }  
        public DbSet<Supplier> Suppliers { get; set; }
    }
}