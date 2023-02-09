namespace TravelPlannerServices.Services;

using System.Collections.Generic;
using TravelPlannerServices.Interfaces;
using TravelPlannerServices.Models;
using TravelPlannerServices.Data;


public class CategoriesMSSqlServices : ICategoryService
{

    private readonly DataContext _dataContext;


    public CategoriesMSSqlServices(DataContext dataContext)
    {
        _dataContext = dataContext;
    }

    public void Delete(int id)
    {
        _dataContext.Categories.Remove(FindById(id));
        _dataContext.SaveChanges();
    }

    public Category FindById(int id)
    {
        return _dataContext.Categories.SingleOrDefault(i => i.Id == id);

    }

    public List<Category> GetAll()
    {
        return _dataContext.Categories.ToList<Category>();

    }

    public void Save(Category item)
    {
        if (item.Id == null || item.Id == 0)
        {
            _dataContext.Categories.Add(item);
        }
        else
        {
            Category temp = this.FindById(item.Id);
        }

        _dataContext.SaveChanges();
    }
}