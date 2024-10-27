namespace TechSupport.Models
{
    public class InventoryItem
    {
        public int Id { get; set; } // Primary Key
        public string Name { get; set; }
        public int Quantity { get; set; }
        public decimal Price { get; set; }
    }
}
