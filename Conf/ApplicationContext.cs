namespace TravelPlannerServices.Conf;

using TravelPlannerServices.Models;

public class ApplicationContext
{
    public List<Item> travelItems;
    private static ApplicationContext? instance = null;

    public static ApplicationContext Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new ApplicationContext();
            }
            return instance;
        }
    }

    public ApplicationContext()
    {
        this.travelItems = new List<Item>(){
            new Item{ Id = 1, Location = "Cebu", Date = "January 12" ,User = "John Doe"},
            new Item{ Id = 2, Location = "Bohol", Date = "February 12", User = "John Doe"},
            new Item{ Id = 3, Location = "France", Date = "March 12", User = "Jane Doe"}

        };
    }


}