namespace MP4.Bag;

public class Customer
{
    public string Name { get; set; }
    public string Email { get; set; }
    public string Address { get; set; }
    
    private List<Order> _orders = new List<Order>();

    public Customer(string name, string email, string address)
    {
        Name = name;
        Email = email;
        Address = address;
    }
    
    public void AddOrder(Order order)
    {
        if (!_orders.Contains(order))
        {
            _orders.Add(order);
        }
    }

    public override string ToString()
    {
        return $"Name: {Name} Email: {Email} Address: {Address}";
    }
}