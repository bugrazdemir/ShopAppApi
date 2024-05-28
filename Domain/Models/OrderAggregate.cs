namespace Domain.Models;
public  class OrderAggregate:BaseModel
{
    public OrderAggregate() 
    {
        //only db
    }

    private OrderAggregate(string orderNumber, decimal totalAmount, decimal discountAmount, DateTime orderDate) 
    {
        OrderNumber = orderNumber;
        TotalAmount = totalAmount;
        DiscountAmount = discountAmount;
        OrderDate = orderDate;
    }

    public string OrderNumber { get; set; }
    public decimal TotalAmount { get; set; }
    public decimal DiscountAmount { get; set; }
    public DateTime OrderDate { get; set; }
    public virtual List<ProductAggregate> Products { get; set; }
    public UserAggregate User { get; set; }
    public AddressAggregate Address { get; set; }


    public static OrderAggregate Create(string orderNumber, decimal totalAmount, decimal discountAmount, DateTime orderDate)
    {
        return new OrderAggregate(orderNumber, totalAmount, discountAmount, orderDate);
    }
}
