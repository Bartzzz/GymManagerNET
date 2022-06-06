using GymManagerNET.Core.DTOs.Users;

namespace GymManagerNET.Core.Services.UserService
{
    public interface IClientService
    {
        Task<IEnumerable<ClientDto>> GetClients();
        Task<ClientDto> GetClient(int userId);
        Task<ClientDto> AddClient(ClientDto client);
        Task<ClientDto> UpdateClient(ClientDto client);
        Task<ClientDto> RemoveClient(int clientId);
        Task<ClientDto> VerifyEntrance(int clientId);
    }
}
