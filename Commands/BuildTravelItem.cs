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

        int id = int.Parse(data["id"].ToString());
        string destination = data["destination"].ToString();
        string startDate = data["startDate"].ToString();
        string endDate = data["endDate"].ToString();
        string user = data["user"].ToString();
        //var parsedDate = DateTime.Parse(startDate).ToString();

        travelItem = new Item { Id = id, Destination = destination, StartDate = startDate, EndDate = endDate, User = user };
        return travelItem;
    }


}