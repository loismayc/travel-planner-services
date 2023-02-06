namespace TravelPlannerServices.Data;

using Microsoft.EntityFrameworkCore;
using TravelPlannerServices.Models;

public class DataContext : DbContext
{
    public DbSet<TravelItem> TravelItems { get; set; }

    public DataContext(DbContextOptions<DataContext> options)
    : base(options)
    {

    }

}