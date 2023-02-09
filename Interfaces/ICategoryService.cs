namespace TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
public interface ICategoryService
{
    public List<Category> GetAll();
    public void Delete(int id);

    public void Save(Category item);
    public Category FindById(int id);


}