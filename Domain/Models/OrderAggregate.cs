namespace Domain.Models;
public  class OrderAggregate:BaseModel
{
    public OrderAggregate() 
    {
        //only db
    }

    private OrderAggregate(string orderNumber, double totalAmount, double discountAmount, DateTime orderDate) 
    {
        OrderNumber = orderNumber;
        TotalAmount = totalAmount;
        DiscountAmount = discountAmount;
        OrderDate = orderDate;
    }

    public string OrderNumber { get; set; }
    public double TotalAmount { get; set; }
    public double DiscountAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public virtual List<UserAggregate> Users { get; set; }

    public static OrderAggregate Create(string orderNumber, double totalAmount, double discountAmount, DateTime orderDate)
    {
        return new OrderAggregate(orderNumber, totalAmount, discountAmount, orderDate);
    }
}
