using System;
using System.Collections.Generic;
using BakeshopInventorySystem.Models;

namespace BakeshopInventorySystem
{
    class Program
    {
        static List<Product> productList = new List<Product>();
        static List<Category> categoryList = new List<Category>();
        static List<Supplier> supplierList = new List<Supplier>();
        static List<TransactionRecord> transHistory = new List<TransactionRecord>();

        static int transCounter = 1;

        static void Main(string[] args)
        {
            // Initial Data
            categoryList.Add(new Category(1, "Whole Cakes"));
            categoryList.Add(new Category(2, "Baking Ingredients"));

            supplierList.Add(new Supplier(1, "Oas Baking Supplies", "09123456789"));
            supplierList.Add(new Supplier(2, "Polangui Sugar Mill", "09987654321"));

            productList.Add(new Product(1, "Red Velvet Cake", 1, 1, 8, 850.00));
            productList.Add(new Product(2, "Chocolate Moist Cake", 1, 1, 3, 750.00));
            productList.Add(new Product(3, "All-Purpose Flour (1kg)", 2, 1, 20, 65.00));

            bool isRunning = true;

            while (isRunning)
            {
                Console.Clear();
                Console.WriteLine("========================================");
                Console.WriteLine("    MANILYN'S BAKESHOP INVENTORY        ");
                Console.WriteLine("========================================");
                Console.WriteLine("1. Add New Product");
                Console.WriteLine("2. View All Products");
                Console.WriteLine("3. Search Product");
                Console.WriteLine("4. Update Product Details");
                Console.WriteLine("5. Delete Product");
                Console.WriteLine("6. Restock / Deduct Stock");
                Console.WriteLine("7. View Transaction History");
                Console.WriteLine("8. Show Low-Stock Items");
                Console.WriteLine("9. Compute Total Inventory Value");
                Console.WriteLine("0. Exit");
                Console.WriteLine("========================================");
                Console.Write("Enter your choice: ");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1": AddNewProduct(); break;
                    case "2": ViewProducts(); break;
                    case "3": SearchProduct(); break;
                    case "4": UpdateProduct(); break;
                    case "5": DeleteProduct(); break;
                    case "6": ManageStock(); break;
                    case "7": ViewHistory(); break;
                    case "8": ShowLowStock(); break;
                    case "9": ComputeTotalValue(); break;
                    case "0": isRunning = false; break;
                    default:
                        Console.WriteLine("Invalid input! Try again.");
                        break;
                }

                if (isRunning)
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine();
                }
            }
        }

        // ─── FEATURE 1: ADD ───────────────────────────────────────
        static void AddNewProduct()
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int id = int.Parse(Console.ReadLine());

                foreach (Product p in productList)
                {
                    if (p.ProductId == id)
                    {
                        Console.WriteLine("Error: Product ID already exists!");
                        return;
                    }
                }

                Console.Write("Enter Product Name: ");
                string name = Console.ReadLine();

                Console.WriteLine("Available Categories:");
                foreach (Category c in categoryList)
                    Console.WriteLine($"  {c.Id}. {c.Name}");
                Console.Write("Enter Category ID: ");
                int catId = int.Parse(Console.ReadLine());

                Console.WriteLine("Available Suppliers:");
                foreach (Supplier s in supplierList)
                    Console.WriteLine($"  {s.Id}. {s.Name}");
                Console.Write("Enter Supplier ID: ");
                int supId = int.Parse(Console.ReadLine());

                Console.Write("Enter Initial Stock: ");
                int stock = int.Parse(Console.ReadLine());

                Console.Write("Enter Price: ");
                double price = double.Parse(Console.ReadLine());

                productList.Add(new Product(id, name, catId, supId, stock, price));
                Console.WriteLine("Product added successfully!");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // ─── FEATURE 2: VIEW ──────────────────────────────────────
        static void ViewProducts()
        {
            try
            {
                Console.WriteLine("\n--- BAKESHOP INVENTORY ---");
                if (productList.Count == 0)
                {
                    Console.WriteLine("Inventory is empty.");
                    return;
                }

                foreach (Product p in productList)
                {
                    Console.WriteLine($"ID: {p.ProductId} | {p.ProductName} | " +
                                      $"Stock: {p.StockQuantity} | Price: P{p.Price}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // ─── FEATURE 3: SEARCH ────────────────────────────────────
        static void SearchProduct()
        {
            try
            {
                Console.Write("Enter Product ID to search: ");
                int searchId = int.Parse(Console.ReadLine());

                foreach (Product p in productList)
                {
                    if (p.ProductId == searchId)
                    {
                        Console.WriteLine($"Found! -> {p.ProductName} | " +
                                          $"Stock: {p.StockQuantity} | Price: P{p.Price}");
                        return;
                    }
                }
                Console.WriteLine("Product not found.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // ─── FEATURE 4: UPDATE ────────────────────────────────────
        static void UpdateProduct()
        {
            try
            {
                Console.Write("Enter Product ID to update: ");
                int editId = int.Parse(Console.ReadLine());

                foreach (Product p in productList)
                {
                    if (p.ProductId == editId)
                    {
                        Console.Write($"Enter New Name (Current: {p.ProductName}): ");
                        string newName = Console.ReadLine();
                        if (!string.IsNullOrWhiteSpace(newName))
                            p.ProductName = newName;

                        Console.Write($"Enter New Price (Current: P{p.Price}): ");
                        p.Price = double.Parse(Console.ReadLine());

                        Console.WriteLine("Product updated successfully!");
                        return;
                    }
                }
                Console.WriteLine("Product not found.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // ─── FEATURE 5: DELETE ────────────────────────────────────
        static void DeleteProduct()
        {
            try
            {
                Console.Write("Enter Product ID to delete: ");
                int delId = int.Parse(Console.ReadLine());

                Product toRemove = null;
                foreach (Product p in productList)
                {
                    if (p.ProductId == delId)
                    {
                        toRemove = p;
                        break;
                    }
                }

                if (toRemove != null)
                {
                    productList.Remove(toRemove);
                    Console.WriteLine("Product deleted successfully.");
                }
                else
                {
                    Console.WriteLine("Product not found.");
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // ─── FEATURE 6: RESTOCK / DEDUCT ─────────────────────────
        static void ManageStock()
        {
            try
            {
                Console.Write("Enter Product ID: ");
                int id = int.Parse(Console.ReadLine());

                foreach (Product p in productList)
                {
                    if (p.ProductId == id)
                    {
                        Console.WriteLine("1. Restock (Add Stock)");
                        Console.WriteLine("2. Deduct Stock (Sold/Used)");
                        Console.Write("Select action: ");
                        string action = Console.ReadLine();

                        Console.Write("Enter quantity: ");
                        int qty = int.Parse(Console.ReadLine());

                        if (action == "1")
                        {
                            p.AddStock(qty);
                            transHistory.Add(new TransactionRecord(
                                transCounter++, p.ProductId, p.ProductName, "Restock", qty));
                            Console.WriteLine("Stock restocked successfully.");
                        }
                        else if (action == "2")
                        {
                            if (p.DeductStock(qty))
                            {
                                transHistory.Add(new TransactionRecord(
                                    transCounter++, p.ProductId, p.ProductName, "Sold", qty));
                                Console.WriteLine("Stock deducted successfully.");
                            }
                            else
                            {
                                Console.WriteLine("Error: Insufficient stock!");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid action selected.");
                        }
                        return;
                    }
                }
                Console.WriteLine("Product not found.");
            }
            catch (FormatException)
            {
                Console.WriteLine("Error: Please enter a valid number.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // ─── FEATURE 7: TRANSACTION HISTORY ──────────────────────
        static void ViewHistory()
        {
            try
            {
                Console.WriteLine("\n--- TRANSACTION HISTORY ---");
                if (transHistory.Count == 0)
                {
                    Console.WriteLine("No transactions yet.");
                    return;
                }

                foreach (TransactionRecord t in transHistory)
                {
                    Console.WriteLine($"[{t.Date}] ID#{t.TransId} | {t.Type} | " +
                                      $"{t.ProductName} | Qty: {t.QuantityChanged}");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // ─── FEATURE 8: LOW STOCK ─────────────────────────────────
        static void ShowLowStock()
        {
            try
            {
                Console.WriteLine("\n--- LOW STOCK WARNING (less than 5 units) ---");
                bool hasLowStock = false;

                foreach (Product p in productList)
                {
                    if (p.StockQuantity < 5)
                    {
                        Console.WriteLine($"- {p.ProductName} (Remaining: {p.StockQuantity})");
                        hasLowStock = true;
                    }
                }

                if (!hasLowStock)
                    Console.WriteLine("All stocks are in good condition.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }

        // ─── FEATURE 9: TOTAL VALUE ───────────────────────────────
        static void ComputeTotalValue()
        {
            try
            {
                double total = 0;
                foreach (Product p in productList)
                {
                    total += (p.Price * p.StockQuantity);
                }
                Console.WriteLine($"\nTotal Bakeshop Inventory Value: P{total:F2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}



