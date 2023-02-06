namespace TravelPlannerServices.Interfaces;

using TravelPlannerServices.Models;

public interface IExpenseItemsService
{
    public List<ExpenseItem> GetAll();
    public void Save(ExpenseItem item);
    public ExpenseItem FindById(int id);
}