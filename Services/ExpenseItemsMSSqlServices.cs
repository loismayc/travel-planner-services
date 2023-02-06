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
        throw new NotImplementedException();
    }

    public List<ExpenseItem> GetAll()
    {
        throw new NotImplementedException();
    }

    public void Save(ExpenseItem item)
    {
        throw new NotImplementedException();
    }
}