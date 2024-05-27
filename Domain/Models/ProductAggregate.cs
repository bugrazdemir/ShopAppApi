namespace Domain.Models;

public  class ProductAggregate : BaseModel
{
    public ProductAggregate()
    {
        //only db
    }
    private ProductAggregate(string productName, string description,decimal price,decimal quantity) 
    {
        ProductName = productName;
        Description = description;
        Price = price;
        Quantity= quantity;
        ProductUploadDate= DateTime.Now;
    }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public decimal  Price { get; set; }
    public decimal  Quantity { get; set; }
    public DateTime ProductUploadDate { get; set;}
    public virtual List<OrderAggregate> Orders { get; set; }

    public static ProductAggregate Create(string productName, string  description, decimal price, decimal quantity)
    {
        return new ProductAggregate(productName, description, price, quantity);
    }
}
