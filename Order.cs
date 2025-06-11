using System;

public class Order
{
    public string OrderID { get; set; }
    public string CustomerName { get; set; }
    public double TotalAmount { get; set; }

    public Order(string orderID, string customerName, double totalAmount)
    {
        OrderID = orderID;
        CustomerName = customerName;
        TotalAmount = totalAmount;
    }
    public void DisplayInfo()
    {
        Console.WriteLine($"Order ID: {OrderID}");
        Console.WriteLine($"Name: {CustomerName}");
        Console.WriteLine($"Total revenue: {TotalAmount}");
        Console.WriteLine("-----------------------------");
    }
}