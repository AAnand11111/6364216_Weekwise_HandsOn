using System;

class Program
{
    static void Main(string[] args)
    {
        Product[] productList = new Product[]
        {
            new Product(101, "Laptop", "Electronics"),
            new Product(205, "Shirt", "Clothing"),
            new Product(150, "Mobile", "Electronics"),
            new Product(303, "Book", "Education")
        };

        Console.WriteLine("Linear Search:");
        var result1 = SearchDemo.LinearSearch(productList, 150);
        Console.WriteLine(result1 != null ? $"Found: {result1.ProductName}" : "Product not found");

        Array.Sort(productList); // Binary search needs sorted array

        Console.WriteLine("\nBinary Search:");
        var result2 = SearchDemo.BinarySearch(productList, 150);
        Console.WriteLine(result2 != null ? $"Found: {result2.ProductName}" : "Product not found");
    }
}
