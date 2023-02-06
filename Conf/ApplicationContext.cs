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
<<<<<<< HEAD
        // this.travelItems = new List<TravelItem>(){
        //     new TravelItem{ Id = 1, Destination = "Cebu", StartDate = "Friday, February 10, 2023" , StartTime="03:45", EndDate = "Monday, February 20, 2023", EndTime="02:00", User = "John Doe"},
        //     new TravelItem{ Id = 2, Destination = "Bohol", StartDate = "Tuesday, March 10, 2023", StartTime="10:00", EndDate = "Friday, March 13, 2023", EndTime="13:00", User = "Jane Doe"},
=======
        this.travelItems = new List<Item>(){
            new Item{ Id = 1, Destination = "Cebu", StartDate = "Friday, February 10, 2023" , EndDate = "Monday, February 20, 2023", User = "John Doe"},
            new Item{ Id = 2, Destination = "Bohol", StartDate = "Tuesday, March 10, 2023", EndDate = "Friday, March 13, 2023", User = "Jane Doe"},
>>>>>>> parent of 1e6cf53 (add sql service)

        // };
    }


}