namespace TravelPlannerServices.Commands;

using TravelPlannerServices.Models;
using TravelPlannerServices.Interfaces;

public class BuildExpenseItem
{
    private Dictionary<string, object> data;
    public ITravelItemsService _travelItemsService;


    public BuildExpenseItem(Dictionary<string, object> data, ITravelItemsService travelItemsService)
    {
        this.data = data;
        _travelItemsService = travelItemsService;

    }

    public ExpenseItem Execute()
    {
        ExpenseItem expenseItem = new ExpenseItem();

        if (data.ContainsKey("id"))
        {
            expenseItem.Id = int.Parse(data["id"].ToString());
        }
        expenseItem.Cost = int.Parse(data["cost"].ToString());
        expenseItem.Name = data["name"].ToString();
        expenseItem.Note = data["note"].ToString();
        expenseItem.TravelItemId = int.Parse(data["travelItemId"].ToString());
        return expenseItem;
    }


}