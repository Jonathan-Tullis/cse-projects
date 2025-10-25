using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        
        Address address1 = new Address("123 Main Street", "Seattle", "WA", "USA");
        Customer customer1 = new Customer("John Smith", address1);

        
        Order order1 = new Order(customer1);
        Product product1 = new Product("Laptop", "TECH-001", 999.99, 1);
        Product product2 = new Product("Wireless Mouse", "TECH-002", 29.99, 2);
        Product product3 = new Product("USB Cable", "TECH-003", 9.99, 3);
        order1.AddProduct(product1);
        order1.AddProduct(product2);
        order1.AddProduct(product3);

        
        Address address2 = new Address("456 Rue de la Paix", "Paris", "Île-de-France", "France");
        Customer customer2 = new Customer("Marie Dubois", address2);

        
        Order order2 = new Order(customer2);
        Product product4 = new Product("Bluetooth Headphones", "AUDIO-001", 149.99, 1);
        Product product5 = new Product("Phone Case", "ACC-001", 19.99, 2);
        order2.AddProduct(product4);
        order2.AddProduct(product5);

        
        Console.WriteLine("Order 1");
        Console.WriteLine("=======\n");
        
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order1.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order1.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Price: ${order1.CalculateTotalCost():F2}");
        Console.WriteLine("\n" + new string('=', 50) + "\n");

        
        Console.WriteLine("Order 2");
        Console.WriteLine("=======\n");
        
        Console.WriteLine("Packing Label:");
        Console.WriteLine(order2.GetPackingLabel());
        Console.WriteLine();

        Console.WriteLine("Shipping Label:");
        Console.WriteLine(order2.GetShippingLabel());
        Console.WriteLine();

        Console.WriteLine($"Total Price: ${order2.CalculateTotalCost():F2}");
    }
}