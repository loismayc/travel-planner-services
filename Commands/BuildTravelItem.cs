namespace TravelPlannerServices.Commands;
using System.Text.Json;

using TravelPlannerServices.Models;

public class BuildTravelItem
{
    private Dictionary<string, object> data;
    private DateTime parsed;

    public BuildTravelItem(Dictionary<string, object> data)
    {
        this.data = data;

    }

    public Item Execute()
    {
        Item travelItem = new Item();

        if (this.data.ContainsKey("id"))
        {
            int id = int.Parse(data["id"].ToString());
        }

        travelItem.Destination = data["destination"].ToString();
        travelItem.StartDate = data["startDate"].ToString();
        travelItem.StartTime = data["startTime"].ToString();
        travelItem.EndDate = data["endDate"].ToString();
        travelItem.EndTime = data["endTime"].ToString();
        travelItem.User = data["user"].ToString();

        return travelItem;
    }


}