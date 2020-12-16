using Microsoft.EntityFrameworkCore;
using ApiProjetoFinal.Models;

namespace ApiProjetoFinal.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Provider> Providers { get; set; }
        public DbSet<Stock> Stocks { get; set; }
        public DbSet<Purchase> Purchases { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Sell> Sales { get; set; }
        public DbSet<Client> Clients { get; set; }
    }
}