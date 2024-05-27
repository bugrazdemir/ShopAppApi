namespace Domain.Models;

public class AddressAggregate:BaseModel
{
    public AddressAggregate()
    {
        //only db
    }

    private AddressAggregate(string address, string addressName)
    {
        Address=address;
        AddressName = addressName;
    }

    public string Address { get; set; }
    public string AddressName{ get; set;}
    public virtual UserAggregate User { get; set;}
    public virtual List<OrderAggregate> Orders { get; set;}
    public static AddressAggregate Create(string address, string addresName)
    {
        return new AddressAggregate(address, addresName);
    }
    public AddressAggregate Update(string addressName, string address)
    {
        AddressName= addressName;
        Address = address;
        return this;
    }
}
