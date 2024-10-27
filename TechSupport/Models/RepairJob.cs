namespace TechSupport.Models
{
    public class RepairJob
    {
        public int RepairJobId { get; set; } // Primary Key
        public string JobDescription { get; set; }
        public bool Completed { get; set; }
        public DateTime ScheduledDate { get; set; } // Updated to DateTime for proper date handling
    }
}
