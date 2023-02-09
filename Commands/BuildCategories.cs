namespace TravelPlannerServices.Commands;

using TravelPlannerServices.Models;

public class BuildCategories
{
    private Dictionary<string, object> data;

    public BuildCategories(Dictionary<string, object> data)
    {
        this.data = data;

    }

    public Category Execute()
    {
        Category categories = new Category();

        if (data.ContainsKey("id"))
        {
            categories.Id = int.Parse(data["id"].ToString());
        }
        categories.CategoryName = data["categoryName"].ToString();


        return categories;
    }


}