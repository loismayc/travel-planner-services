namespace TravelPlannerServices.Models
{
    public class TravelItem
    {
        public int Id { get; set; }
        public string? Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public int Budget { get; set; }

        public List<ExpenseItem> ExpenseItems { get; set; }
    }
}