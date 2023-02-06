namespace TravelPlannerServices.Data;

using Microsoft.EntityFrameworkCore;
using TravelPlannerServices.Models;

public class DataContext : DbContext
{
    public DbSet<Item> Items { get; set; }
    public DataContext(DbContextOptions<DataContext> options)
    : base(options)
    {

    }

}