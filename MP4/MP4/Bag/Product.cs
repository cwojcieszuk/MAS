namespace MP4.Bag;

public class Product
{
    public string Name { get; set; }
    public int Amount { get; set; }

    private List<Order> _orders = new List<Order>();

    public Product(string name, int amount)
    {
        Name = name;
        Amount = amount;
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
        return $"Name: {Name} Amount: {Amount}";
    }
}