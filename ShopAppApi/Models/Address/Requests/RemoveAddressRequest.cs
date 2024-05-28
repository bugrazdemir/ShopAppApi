using Application.Features.Address.Commands;

namespace ShopAppApi.Models.Address.Requests;

public class RemoveAddressRequest
{

    public RemoveAddressCommand ToCommand(int id)
    {
        return new RemoveAddressCommand(id);
    }
}
