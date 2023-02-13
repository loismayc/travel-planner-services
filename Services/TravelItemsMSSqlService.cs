namespace TravelPlannerServices.Services;

using System.Collections.Generic;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
using TravelPlannerServices.Data;
using Microsoft.EntityFrameworkCore;

public class TravelItemsMSSqlService : ITravelItemsService
{

    private readonly DataContext _dataContext;




    public TravelItemsMSSqlService(DataContext dataContext)
    {
        _dataContext = dataContext;


    }
    public void Delete(int id)
    {
        _dataContext.TravelItems.Remove(FindById(id));
        _dataContext.SaveChanges();

    }

    public TravelItem FindById(int id)
    {
        return _dataContext.TravelItems.SingleOrDefault(i => i.Id == id);
    }

    public List<TravelItem> GetAll()
    {

        return _dataContext.TravelItems.Include(ti => ti.ExpenseItems).ToList<TravelItem>();

    }

    public void Save(TravelItem item)
    {
        if (item.Id == null || item.Id == 0)
        {
            _dataContext.TravelItems.Add(item);
        }
        else
        {
            TravelItem temp = this.FindById(item.Id);
            temp.Destination = item.Destination;
            temp.StartDate = item.StartDate;
            temp.EndDate = item.EndDate;
            temp.Budget = item.Budget;

        }

        _dataContext.SaveChanges();
    }

    public List<TravelItem> GetItemsByDate(string date)
    {
        List<TravelItem> allItems = this.GetAll();
        List<TravelItem> filteredItems = new List<TravelItem>();

        filteredItems = allItems.FindAll(x => x.StartDate.ToString("yyyy-MM-dd") == date);

        return filteredItems;
    }
}