namespace TravelPlannerServices.Services;

using System.Collections.Generic;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
using TravelPlannerServices.Conf;

public class TravelItemServices : ITravelItemsService
{


    public TravelItem FindById(int id)
    {
        return ApplicationContext.Instance.travelItems.FirstOrDefault(i => i.Id == id);

    }
    public void Delete(int id)
    {
        ApplicationContext.Instance.travelItems.Remove(FindById(id));


    }
    public List<TravelItem> GetAll()
    {
        return ApplicationContext.Instance.travelItems;
    }

    public void Save(TravelItem item)
    {
        ApplicationContext.Instance.travelItems.Add(item);
    }
}