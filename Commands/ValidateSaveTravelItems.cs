namespace TravelPlannerServices.Commands;

using System.Globalization;

public class ValidateSaveTravelItems
{
    private Dictionary<string, object> payload;
    public Dictionary<string, List<string>> Errors { get; private set; }

    public ValidateSaveTravelItems(Dictionary<string, object> payload)
    {
        this.payload = payload;

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
        var cultureInfo = new CultureInfo("en-US");
        int id = int.Parse(payload["id"].ToString());
        string startDate = payload["startDate"].ToString();
        string endDate = payload["endDate"].ToString();


        if (!payload.ContainsKey("destination"))
        {
            Console.WriteLine(startDate);
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
                DateTime.ParseExact(startDate, "D", cultureInfo);

            }
            catch (FormatException e)
            {
                Errors["startDate"].Add("Unable to parse date");
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
                DateTime.ParseExact(endDate, "D", cultureInfo);

            }
            catch (FormatException e)
            {
                Errors["endDate"].Add("Unable to parse date");
            }
        }

        if (!payload.ContainsKey("user"))
        {
            Errors["user"].Add("user is required");
        }

        // validation if date does not overlap with other dates
        // validation if start date is before end date and vice versa

    }


}