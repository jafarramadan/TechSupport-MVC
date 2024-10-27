namespace TechSupport.Models
{
    public class SupportRequest
    {
        public int SupportRequestId { get; set; } // Primary Key
        public string CustomerName { get; set; }
        public string CustomerPhoneNumber { get; set; } // Foreign ke
        public string Description { get; set; }
        public DateTime RequestDate { get; set; }
        public bool ReceiveUpdates { get; set; }
        public string Status { get; set; }
    }
}
