using System;

namespace BakeshopInventorySystem.Models
{
    public class TransactionRecord
    {
        public int TransId { get; set; }
        public int ProductId { get; set; }        // FIXED: int, not string
        public string ProductName { get; set; }   // kept for display
        public string Type { get; set; }          // "Restock" or "Sold"
        public int QuantityChanged { get; set; }  // FIXED: matches rubric name
        public DateTime Date { get; set; }        // FIXED: matches rubric name

        public TransactionRecord(int id, int productId, string productName, string type, int qty)
        {
            TransId = id;
            ProductId = productId;
            ProductName = productName;
            Type = type;
            QuantityChanged = qty;
            Date = DateTime.Now;
        }
    }
}