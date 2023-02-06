namespace TravelPlannerServices.Commands;

using TravelPlannerServices.Models;
public class BuildExpenseItem
{
    private Dictionary<string, object> data;


    public BuildExpenseItem(Dictionary<string, object> data)
    {
        this.data = data;

    }
    public ExpenseItem Execute()
    {
        ExpenseItem expenseItem = new ExpenseItem();

        if (this.data.ContainsKey("id"))
        {
            int id = int.Parse(data["id"].ToString());
        }

        expenseItem.Cost = int.Parse(data["cost"].ToString());
        expenseItem.Name = data["name"].ToString();
        expenseItem.Note = data["note"].ToString();

        if (this.data.ContainsKey("travelItemId"))
        {
            int travelItemId = int.Parse(data["travelItemId"].ToString());
        }

        return expenseItem;
    }



}