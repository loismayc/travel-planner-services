namespace TravelPlannerServices.Commands;

using System.Globalization;
using System.Text.RegularExpressions;
public class ValidateSaveCategories
{
    private Dictionary<string, object> payload;
    public Dictionary<string, List<string>> Errors { get; private set; }

    public ValidateSaveCategories(Dictionary<string, object> payload)
    {
        this.payload = payload;

        this.Errors = new Dictionary<string, List<string>>();
        Errors.Add("categoryName", new List<string>());


    }

    public bool HasErrors()
    {
        bool ans = false;

        if (Errors["categoryName"].Count > 0)
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


        if (!payload.ContainsKey("categoryName"))
        {
            Errors["categoryName"].Add("category name is required");
        }



    }


}