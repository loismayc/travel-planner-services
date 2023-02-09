namespace TravelPlannerServices.Services;

using System.Collections.Generic;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
using TravelPlannerServices.Data;


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
        return _dataContext.TravelItems.ToList<TravelItem>();
        // var travelItems = _dataContext.TravelItems.ToList<TravelItem>();

        // foreach (TravelItem item in travelItems)
        // {
        //     item.ExpenseItems = _expenseItemsService.GetByTravelItemId(item.Id);
        // }

        // return travelItems;
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
}