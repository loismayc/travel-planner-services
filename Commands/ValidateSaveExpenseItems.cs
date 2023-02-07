namespace TravelPlannerServices.Commands;

using System.Globalization;
using System.Text.RegularExpressions;
public class ValidateSaveExpenseItems
{
    private Dictionary<string, object> payload;
    public Dictionary<string, List<string>> Errors { get; private set; }

    public ValidateSaveExpenseItems(Dictionary<string, object> payload)
    {
        this.payload = payload;

        this.Errors = new Dictionary<string, List<string>>();
        Errors.Add("cost", new List<string>());
        Errors.Add("name", new List<string>());
        Errors.Add("note", new List<string>());

    }

    public bool HasErrors()
    {
        bool ans = false;

        if (Errors["cost"].Count > 0)
        {
            ans = true;
        }

        if (Errors["name"].Count > 0)
        {
            ans = true;
        }
        if (Errors["note"].Count > 0)
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


        if (!payload.ContainsKey("cost"))
        {
            Errors["cost"].Add("cost is required");
        }

        if (!payload.ContainsKey("name"))
        {
            Errors["name"].Add("name is required");
        }



        if (!payload.ContainsKey("note"))
        {
            Errors["note"].Add("note");
        }






    }


}