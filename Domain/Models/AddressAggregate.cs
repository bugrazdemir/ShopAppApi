namespace Domain.Models;

public class AddressAggregate:BaseModel
{
    public AddressAggregate()
    {
        //only db
    }

    private AddressAggregate(string street, string city, string state, string postalCode, string country, string addresName)
    {
        Street = street;
        City = city;
        State = state;
        PostalCode = postalCode;
        Country = country;
        AddresName = addresName;
    }

    public string Street {get; set;}
    public string City { get; set;}
    public string State { get; set;}
    public string PostalCode { get; set;}
    public string Country { get; set;}
    public string AddresName{ get; set;}
    public static AddressAggregate Create(string street, string city, string state, string postalCode, string country, string addresName)
    {
        return new AddressAggregate(street, city, state, postalCode, country, addresName);
    }
}
