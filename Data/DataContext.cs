namespace TravelPlannerServices.Data;

using Microsoft.EntityFrameworkCore;
using TravelPlannerServices.Models;

public class DataContext : DbContext
{
    public DbSet<TravelItem> TravelItems { get; set; }
    public DbSet<ExpenseItem> ExpenseItems { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ExpenseItem>().HasOne(t => t.TravelItem).WithMany(e => e.ExpenseItems);
    }


    public DataContext(DbContextOptions<DataContext> options)
    : base(options)
    {

    }

}