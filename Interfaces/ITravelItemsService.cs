namespace TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
public interface ITravelItemsService
{
    public List<TravelItem> GetAll();
    public void Save(TravelItem item);
    public void Delete(int id);
    public TravelItem FindById(int id);
    public List<TravelItem> GetItemsByDate(string date);



}