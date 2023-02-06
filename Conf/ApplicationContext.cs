namespace TravelPlannerServices.Conf;

using TravelPlannerServices.Models;

public class ApplicationContext
{
    public List<TravelItem> travelItems;
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
        // this.travelItems = new List<TravelItem>(){
        //     new TravelItem{ Id = 1, Destination = "Cebu", StartDate = "Friday, February 10, 2023" , EndDate = "Monday, February 20, 2023", User = "John Doe"},
        //     new TravelItem{ Id = 2, Destination = "Bohol", StartDate = "Tuesday, March 10, 2023", EndDate = "Friday, March 13, 2023", User = "Jane Doe"},

        // };
    }


}