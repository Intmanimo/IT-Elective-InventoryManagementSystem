namespace BakeshopInventorySystem.Models
{
    public class Product
    {
        public int ProductId { get; private set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        private int _stockQuantity;
        public int StockQuantity
        {
            get { return _stockQuantity; }
        }

        public double Price { get; set; }

        public Product(int id, string name, int catId, int supId, int qty, double price)
        {
            ProductId = id;
            ProductName = name;
            CategoryId = catId;
            SupplierId = supId;
            _stockQuantity = qty;
            Price = price;
        }

        public void AddStock(int amount)
        {
            _stockQuantity += amount;
        }

        public bool DeductStock(int amount)
        {
            if (_stockQuantity >= amount)
            {
                _stockQuantity -= amount;
                return true;
            }
            return false;
        }
    }
}