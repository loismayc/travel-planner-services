namespace TravelPlannerServices.Services;

using System.Collections.Generic;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
using Microsoft.EntityFrameworkCore;
using TravelPlannerServices.Data;
using TravelPlannerServices.Commands;

public class TravelItemsMSSqlService : ITravelItemsService
{

    private readonly DataContext _dataContext;
    public TravelItemsMSSqlService(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    public void Delete(int id)
    {
        throw new NotImplementedException();
    }

    public TravelItem FindById(int id)
    {
        return _dataContext.TravelItems.SingleOrDefault(i => i.Id == id);
    }

    public List<TravelItem> GetAll()
    {
        return _dataContext.TravelItems.ToList<TravelItem>();
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
            temp.StartTime = item.StartTime;
            temp.EndTime = item.EndTime;
            temp.User = item.User;

        }

        _dataContext.SaveChanges();
    }
}