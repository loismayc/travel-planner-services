namespace TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
public interface ITravelItemsService
{
    public List<Item> GetAll();
    public void Save(Item item);
    public void Delete(int id);
    public Item FindById(int id);


}