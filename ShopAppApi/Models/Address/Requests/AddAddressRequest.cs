using Application.Features.Address.Commands;

namespace ShopAppApi.Models.Address.Requests;

public class AddAddressRequest
{

    public string Address { get; set; }
    public string AddressName{ get; set; }

    public AddAddressCommand ToCommand(int userId )
    {
        return new AddAddressCommand(userId ,Address,AddressName);
    }
}
