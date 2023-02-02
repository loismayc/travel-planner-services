namespace TravelPlannerServices.Services;

using System.Collections.Generic;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
using TravelPlannerServices.Conf;

public class TravelItemServices : ITravelItemsService
{


    public Item FindById(int id)
    {
        return ApplicationContext.Instance.travelItems.FirstOrDefault(i => i.Id == id);

    }
    public void Delete(int id)
    {
        ApplicationContext.Instance.travelItems.Remove(FindById(id));


    }
    public List<Item> GetAll()
    {
        return ApplicationContext.Instance.travelItems;
    }

    public void Save(Item item)
    {
        ApplicationContext.Instance.travelItems.Add(item);
    }
}