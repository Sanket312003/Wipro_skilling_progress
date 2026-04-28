using System;


ECommerceSystem eCommerceSystem = new ECommerceSystem();

eCommerceSystem.AddOrder(new Order { OrderId = 1, ProductName = "Laptop", Price = 999.99 });
eCommerceSystem.AddOrder(new Order { OrderId = 2, ProductName = "Smartphone", Price = 499.99 });
eCommerceSystem.UpdateOrder(1, "Gaming Laptop", 1299.99);
eCommerceSystem.ProcessOrders();
eCommerceSystem.TrackOrderStatus();


//Use List<Order> to store all orders placed
//Use Dictionary<int, Customer> to map customer ID to customer details
//Use HashSet<string> to store unique product categories
//Use Queue<Order> for order processing (FIFO)
//Use Stack<string> to track order status history (LIFO)
//Custom Object Example
//class Order
//{
//    public int OrderId;
//    public string ProductName;
//    public double Price;
//}



//Step 1: Define the Order and Customer classes
class Order
{
    public int OrderId { get; set; }
    public string ProductName { get; set; }
    public double Price { get; set; }
}

class Customer
{
    public int CustomerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}

//Step 2: Implement the e-commerce order management system with the help of collections we create a class ECommerceSystem

class ECommerceSystem

{
    private List<Order> orders = new List<Order>();
    private Dictionary<int, Customer> customers = new Dictionary<int, Customer>();
    private HashSet<string> productCategories = new HashSet<string>();
    private Queue<Order> orderProcessingQueue = new Queue<Order>();
    private Stack<string> orderStatusHistory = new Stack<string>();
    public void AddOrder(Order order)
    {
        orders.Add(order);
        orderProcessingQueue.Enqueue(order);
        productCategories.Add(order.ProductName); // Assuming product name represents category for simplicity
        Console.WriteLine($"Order {order.OrderId} added.");
    }
    public void UpdateOrder(int orderId, string newProductName, double newPrice)
    {
        var order = orders.Find(o => o.OrderId == orderId);// LINQ method to find the order by ID
        if (order != null)
        {
            order.ProductName = newProductName;
            order.Price = newPrice;
            Console.WriteLine($"Order {orderId} updated.");
        }
        else
        {
            Console.WriteLine($"Order {orderId} not found.");
        }
    }
    public void RemoveOrder(int orderId)
    {
        var order = orders.Find(o => o.OrderId == orderId);
        if (order != null)
        {
            orders.Remove(order);
            Console.WriteLine($"Order {orderId} removed.");
        }
        else
        {
            Console.WriteLine($"Order {orderId} not found.");
        }
    }
    public void ProcessOrders()
    {
        while (orderProcessingQueue.Count > 0)
        {
            var order = orderProcessingQueue.Dequeue();
            Console.WriteLine($"Processing Order {order.OrderId}: {order.ProductName} - ${order.Price}");
            orderStatusHistory.Push($"Processed Order {order.OrderId}");
        }
    }
    public void TrackOrderStatus()
    {
        Console.WriteLine("Order Status History:");
        foreach (var status in orderStatusHistory)
        {
            Console.WriteLine(status);
        }
    }
}