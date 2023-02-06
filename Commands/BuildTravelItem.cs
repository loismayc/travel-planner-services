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

    public TravelItem Execute()
    {
        TravelItem travelItem = new TravelItem();

        if (this.data.ContainsKey("id"))
        {
            int id = int.Parse(data["id"].ToString());
        }

        travelItem.Destination = data["destination"].ToString();
        travelItem.StartDate = DateTime.Parse(data["startDate"].ToString());
        travelItem.StartTime = DateTime.Parse(data["startTime"].ToString());
        travelItem.EndDate = DateTime.Parse(data["endDate"].ToString());
        travelItem.EndTime = DateTime.Parse(data["endTime"].ToString());
        travelItem.User = data["user"].ToString();

        return travelItem;
    }


}