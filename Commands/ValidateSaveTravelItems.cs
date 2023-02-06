namespace TravelPlannerServices.Commands;

using System.Globalization;
using System.Text.RegularExpressions;
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
                if (DateTime.ParseExact(payload["startDate"].ToString(), "D", cultureInfo) == DateTime.ParseExact(payload["endDate"].ToString(), "D", cultureInfo))
                {
                    Errors["startDate"].Add("start date cannot be the same with end date");
                }

                DateTime.ParseExact(payload["startDate"].ToString(), "D", cultureInfo);
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
                if (DateTime.ParseExact(payload["startDate"].ToString(), "D", cultureInfo) > DateTime.ParseExact(payload["endDate"].ToString(), "D", cultureInfo))
                {
                    Errors["endDate"].Add("invalid date range");
                }

                DateTime.ParseExact(payload["endDate"].ToString(), "D", cultureInfo);
            }

            catch (FormatException e)
            {
                Errors["endDate"].Add("invalid date");
            }
        }



    }


}