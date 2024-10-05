using System;

// Product class with Name and Stock properties
public class Product
{
    public string Name { get; set; }
    public int Stock { get; set; }
}

// Custom exception class for out-of-stock products
public class ProductOutOfStockException : Exception
{
    // Constructor that passes the custom message to the base Exception class
    public ProductOutOfStockException(string message) : base(message)
    {
    }
}

// DeliveryService class that contains the PlaceOrder method
public class DeliveryService
{
    public bool PlaceOrder(Product product)
    {
        // Check if the product is in stock
        if (product.Stock <= 0)
        {
            // Throw a custom exception if the product is out of stock
            throw new ProductOutOfStockException("Product is out of stock");
        }

        // If stock is available, return true indicating the order can be placed
        return true;
    }
}

public class Program2
{
    public static void Main(string[] args)
    {
        // Create an instance of the DeliveryService class
        DeliveryService deliveryService = new DeliveryService();

        try
        {
            // Prompt the user to enter the product details
            Console.WriteLine("Enter the product name");
            string productName = Console.ReadLine();

            Console.WriteLine("Enter the number of stocks");
            int stock = Convert.ToInt32(Console.ReadLine());

            // Create a new Product object with the user input
            Product product = new Product
            {
                Name = productName,
                Stock = stock
            };

            // Try to place the order
            if (deliveryService.PlaceOrder(product))
            {
                // If the order is successfully placed, print a confirmation message
                Console.WriteLine("Order placed successfully");
            }
        }
        catch (ProductOutOfStockException ex)
        {
            // Catch the custom exception and print the message
            Console.WriteLine(ex.Message);
        }
        finally
        {
            // This block always executes, but there's no specific action required here
        }
    }
}