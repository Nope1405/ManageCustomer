using System;
using System.Collections.Generic;
using System.Linq;

public class ClassProgram
{
    private static readonly List<Order> orderList = [];
    private static void DisplayMenu()
    {
        Console.WriteLine("Manage Order System");
        Console.WriteLine("1. Enter the order");
        Console.WriteLine("2. Show list of the order");
        Console.WriteLine("3. Searching order by name");
        Console.WriteLine("4. Total revenue");
        Console.WriteLine("5. Exit system");
        Console.WriteLine("Please enter your choice from 1-5");
    }

    private static string PromptNonEmpty(string prompt)
    {
        string input;
        do
        {
            Console.Write(prompt);
            input = Console.ReadLine();
            if (string.IsNullOrWhiteSpace(input))
                Console.WriteLine("Input cannot be blank.");
        } while (string.IsNullOrWhiteSpace(input));
        return input;
    }

    private static double PromptDouble(string prompt)
    {
        double value;
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out value))
                return value;
            Console.WriteLine("Invalid input. Please enter a number.");
        }
    }

    private static void InputOrder()
    {
        int nums;
        Console.Write("Enter the numbers of orders: ");
        while (!int.TryParse(Console.ReadLine(), out nums) || nums <= 0)
        {
            Console.WriteLine("Invalid input. Please enter a positive number.");
            Console.Write("Enter the numbers of orders: ");
        }

        for (int i = 0; i < nums; i++)
        {
            Console.WriteLine($"\nEnter information of order {i + 1}");

            string orderId;
            while (true)
            {
                orderId = PromptNonEmpty("Order ID: ");
                if (orderList.Any(o => o.OrderID == orderId))
                {
                    Console.WriteLine("The order ID exists. Please enter another order ID.");
                }
                else break;
            }

            string customerName = PromptNonEmpty("Enter customer's name: ");
            double amount;
            do
            {
                amount = PromptDouble("Total order amount: ");
                if (amount <= 0)
                {
                    Console.WriteLine("Error: Total order amount must be a positive number. Please try again.");
                }
            } while (amount <= 0);
            Order newOrder = new(orderId, customerName, amount);
            orderList.Add(newOrder);
            Console.WriteLine("Order added successfully");
        }
    }

    private static void DisplayOrders()
    {
        Console.WriteLine("List of orders:");
        if (orderList.Count == 0)
        {
            Console.WriteLine("Empty");
            return;
        }
        foreach (var order in orderList)
        {
            order.DisplayInfo();
        }
    }

    private static void SearchByName()
    {
        while (true)
        {
            string keyword = PromptNonEmpty("Enter the name (Enter 0 to exit): ");
            if (keyword == "0")
            {
                Console.WriteLine("Exit the searching.");
                return;
            }

            var foundOrders = orderList
                .Where(order => order.CustomerName.Contains(keyword, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine("Result:");
            if (foundOrders.Count == 0)
            {
                Console.WriteLine("Cannot find the order");
            }
            else
            {
                foreach (var order in foundOrders)
                {
                    order.DisplayInfo();
                }
            }
            break;
        }
    }

    private static void Calculate()
    {
        if (orderList.Count == 0)
        {
            Console.WriteLine("Order list is empty now.");
            return;
        }
        double total = orderList.Sum(o => o.TotalAmount);
        Console.WriteLine($"Total revenue: {total}");
    }

    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        bool running = true;
        while (running)
        {
            DisplayMenu();
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    InputOrder();
                    break;
                case "2":
                    DisplayOrders();
                    break;
                case "3":
                    SearchByName();
                    break;
                case "4":
                    Calculate();
                    break;
                case "5":
                    running = false;
                    Console.WriteLine("Cảm ơn bạn đã sử dụng chương trình. Tạm biệt!");
                    break;
                default:
                    Console.WriteLine("Lựa chọn không hợp lệ. Vui lòng nhập lại.");
                    break;
            }
            Console.WriteLine("\nNhấn phím bất kỳ để tiếp tục...");
            Console.ReadKey();
            Console.Clear();
        }
    }
}
