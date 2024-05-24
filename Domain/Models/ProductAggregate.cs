namespace Domain.Models;

public  class ProductAggregate : BaseModel
{
    public ProductAggregate()
    {
        //only db
    }
    private ProductAggregate(string productName, string description,double price,double quantity) 
    {
        ProductName = productName;
        Description = description;
        Price = price;
        Quantity= quantity;
        ProductUploadDate= DateTime.Now;
    }
    public string ProductName { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public double Quantity { get; set; }
    public DateTime ProductUploadDate { get; set;}

    public static ProductAggregate Create(string productName, string  description, double price, double quantity)
    {
        return new ProductAggregate(productName, description, price, quantity);
    }
}
