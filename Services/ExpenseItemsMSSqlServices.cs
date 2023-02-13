namespace TravelPlannerServices.Services;

using System.Collections.Generic;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
using TravelPlannerServices.Data;
using Microsoft.EntityFrameworkCore;

public class ExpenseItemsMSSqlServices : IExpenseItemsServices
{

    private readonly DataContext _dataContext;
    public ITravelItemsService _travelItemService;

    public ExpenseItemsMSSqlServices(DataContext dataContext, ITravelItemsService travelItemService)
    {
        _dataContext = dataContext;
        _travelItemService = travelItemService;

    }

    public ExpenseItem FindById(int id)
    {
        return _dataContext.ExpenseItems.SingleOrDefault(i => i.Id == id);

    }

    public List<ExpenseItem> GetAll()
    {
        return _dataContext.ExpenseItems
       .Include(ei => ei.Category)
       .Include(ei => ei.TravelItem)
       .ToList<ExpenseItem>();

    }

    public void Save(ExpenseItem item)
    {
        if (item.Id == null || item.Id == 0)
        {
            _dataContext.ExpenseItems.Add(item);
        }
        else
        {
            ExpenseItem temp = this.FindById(item.Id);
            temp.Cost = item.Cost;
            temp.Name = item.Name;
            temp.Note = item.Note;
            temp.TravelItem = item.TravelItem;


        }

        _dataContext.SaveChanges();
    }

    public void Delete(int id)
    {
        _dataContext.ExpenseItems.Remove(FindById(id));
        _dataContext.SaveChanges();

    }
}