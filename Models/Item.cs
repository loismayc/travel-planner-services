namespace TravelPlannerServices.Models
{
    public class Item
    {
        public int Id { get; set; }
        public string? Destination { get; set; }
        public string? StartDate { get; set; }
        public string? StartTime { get; set; }

        public string? EndDate { get; set; }
        public string? EndTime { get; set; }


        public string? User { get; set; }
    }
}