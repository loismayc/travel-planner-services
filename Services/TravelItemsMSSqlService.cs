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

    public Item FindById(int id)
    {
        return _dataContext.Items.SingleOrDefault(i => i.Id == id);
    }

    public List<Item> GetAll()
    {
        return _dataContext.Items.ToList<Item>();
    }

    public void Save(Item item)
    {
        if (item.Id == null || item.Id == 0)
        {
            _dataContext.Items.Add(item);
        }
        else
        {
            Item temp = this.FindById(item.Id);
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