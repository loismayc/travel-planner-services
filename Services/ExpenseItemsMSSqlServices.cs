namespace TravelPlannerServices.Services;

using System.Collections.Generic;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
using TravelPlannerServices.Data;


public class ExpenseItemsMSSqlServices : IExpenseItemsServices
{

    private readonly DataContext _dataContext;

    public ExpenseItemsMSSqlServices(DataContext dataContext)
    {
        _dataContext = dataContext;

    }

    public ExpenseItem FindById(int id)
    {
        return _dataContext.ExpenseItems.SingleOrDefault(i => i.Id == id);

    }

    public List<ExpenseItem> GetAll()
    {
        return _dataContext.ExpenseItems.ToList<ExpenseItem>();

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
}