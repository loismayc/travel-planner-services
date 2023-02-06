namespace TravelPlannerServices.Models
{
    public class ExpenseItem
    {
        public int Id { get; set; }
        public int Cost { get; set; }

        public string? Name { get; set; }
        public string? Note { get; set; }

        public int TravelItemId { get; set; }
        public TravelItem TravelItem { get; set; }


    }
}