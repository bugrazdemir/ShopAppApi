using Application.Features.Address.Commands;

namespace ShopAppApi.Models.Address.Requests;

public class UpdateAddressRequest
{
    public string Address { get; set; }
    public string AddressName { get; set; }

    public UpdateAddressCommand ToCommand(int id)
    {
        return new UpdateAddressCommand(id, Address, AddressName);
    }
}
