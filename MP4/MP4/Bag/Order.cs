namespace MP4.Bag;

public class Order
{
    public DateTime OrderDate { get; set; }

    public Customer Customer { get; set; }
    public Product Product { get; set; }

    public Order(DateTime orderDate, Customer customer, Product product)
    {
        OrderDate = orderDate;
        Customer = customer;
        Product = product;
        
        customer.AddOrder(this);
        product.AddOrder(this);
    }

    public override string ToString()
    {
        return $"Date of order {OrderDate} Customer: {Customer} Product: {Product}";
    }
}