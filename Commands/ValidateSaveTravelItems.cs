namespace TravelPlannerServices.Commands;

using System.Globalization;
using TravelPlannerServices.Interfaces;
public class ValidateSaveTravelItems
{
    private Dictionary<string, object> payload;
    public Dictionary<string, List<string>> Errors { get; private set; }
    private readonly ITravelItemsService _travelItemsService;


    public ValidateSaveTravelItems(Dictionary<string, object> payload, ITravelItemsService travelItemsService)
    {
        this.payload = payload;
        this._travelItemsService = travelItemsService;

        this.Errors = new Dictionary<string, List<string>>();
        Errors.Add("destination", new List<string>());
        Errors.Add("startDate", new List<string>());
        Errors.Add("endDate", new List<string>());
        Errors.Add("user", new List<string>());
    }

    public bool HasErrors()
    {
        bool ans = false;

        if (Errors["destination"].Count > 0)
        {
            ans = true;
        }

        if (Errors["startDate"].Count > 0)
        {
            ans = true;
        }
        if (Errors["endDate"].Count > 0)
        {
            ans = true;
        }

        if (Errors["user"].Count > 0)
        {
            ans = true;
        }

        return ans;
    }

    public bool HasNoErrors()
    {
        return !HasErrors();
    }

    public void Execute()
    {
        DateTime startDate = new DateTime();
        DateTime endDate = new DateTime();

        var cultureInfo = new CultureInfo("en-US");

        if (!payload.ContainsKey("destination"))
        {
            Errors["destination"].Add("destination is required");
        }

        if (!payload.ContainsKey("startDate"))
        {
            Errors["startDate"].Add("start date is required");
        }
        else
        {
            try
            {
                if (DateTime.ParseExact(payload["startDate"].ToString(), "yyyy-MM-dd", null) == DateTime.ParseExact(payload["endDate"].ToString(), "yyyy-MM-dd", null))
                {
                    Errors["startDate"].Add("start date cannot be the same with end date");
                }

                DateTime.ParseExact(payload["startDate"].ToString(), "yyyy-MM-dd", null);
            }

            catch (FormatException a)
            {
                Errors["startDate"].Add("invalid date");
            }
        }

        if (!payload.ContainsKey("endDate"))
        {
            Errors["endDate"].Add("end date is required");
        }
        else
        {
            try
            {
                if (DateTime.ParseExact(payload["startDate"].ToString(), "yyyy-MM-dd", null) > DateTime.ParseExact(payload["endDate"].ToString(), "yyyy-MM-dd", null))
                {
                    Errors["endDate"].Add("invalid date range");
                }

                DateTime.ParseExact(payload["endDate"].ToString(), "yyyy-MM-dd", null);
            }

            catch (FormatException e)
            {
                Errors["endDate"].Add("invalid date");
            }
        }


        if (payload.ContainsKey("startDate") && payload.ContainsKey("endDate"))
        {

            DateTime start = DateTime.ParseExact(payload["startDate"].ToString(), "yyyy-MM-dd", null);
            DateTime end = DateTime.ParseExact(payload["startDate"].ToString(), "yyyy-MM-dd", null);

            // Check if end date is valid
            if (end < start)
            {
                Errors["endDate"].Add("End Date must be greater than start date");
            }
            if (start < end)
            {
                Errors["startDate"].Add("start date must be earlier than end date");
            }

            var startDates = _travelItemsService.GetItemsByDate(payload["startDate"].ToString());
            var endDates = _travelItemsService.GetItemsByDate(payload["endDate"].ToString());

            string toDoTimeConflict = "";

            // Check if date is overlapping with other saved items
            bool overlap = startDates.Any(x =>
            {
                DateTime tempStart = DateTime.ParseExact(x.StartDate.ToString(), "yyyy-MM-dd", null);
                DateTime tempEnd = DateTime.ParseExact(x.EndDate.ToString(), "yyyy-MM-dd", null);

                // Check if the new start and end dates fall completely within the start and end dates of any existing items
                if (tempStart <= startDate && endDate <= tempEnd)
                {
                    toDoTimeConflict = x.Destination;
                    return true;
                }

                return false;
            });

            if (overlap)
            {
                Errors["startTime"].Add($"Time entered is conflicting with the time of another trip to {toDoTimeConflict}");
            }

        }

    }
}