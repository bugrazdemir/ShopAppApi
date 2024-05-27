using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models;

public  class UserAggregate:BaseModel
{
    public UserAggregate()
    {
        //only db
    }

    private UserAggregate(string name,string lastName,string email,string phone)
    {
        Name = name;
        LastName = lastName;
        Email = email;
        CreatedDate=DateTime.Now;
        Phone=phone;
    }

    public string Name { get; set; }  
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Phone { get; set; }
    public DateTime CreatedDate { get; set; }
    public virtual List<AddressAggregate> Addresses { get; set; }
    public virtual List<OrderAggregate> Orders { get; set; }


    public static UserAggregate Create(string name,string lastName,string email,string phone)
    {
        return new UserAggregate(name,lastName,email,phone);
    }
}
