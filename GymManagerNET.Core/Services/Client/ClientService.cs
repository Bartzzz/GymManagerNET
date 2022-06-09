using AutoMapper;
using GymManagerNET.Core.DTOs.Users;
using GymManagerNET.Core.Enums;
using GymManagerNET.Core.Services.Subscriptions;

namespace GymManagerNET.Core.Services.Client;

public class ClientService : IClientService
{

    private readonly ISubscriptionService _subscriptionService;
    private readonly IClientRepository _clientRepository;
    private readonly IFingerPrintService _fingerPrintService;
    private readonly IFingerPrintRepository _fingerPrintRepository;
    private readonly IMapper _mapper;

    public ClientService(ISubscriptionService subscriptionService, IClientRepository clientRepository, IFingerPrintService fingerPrintService, IMapper mapper)
    {
        _subscriptionService = subscriptionService;
        _clientRepository = clientRepository;
        _fingerPrintService = fingerPrintService;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ClientDto>> GetClients()
    {
        var clients = await _clientRepository.GetEntities();
        var clientDtos = clients != null ? _mapper.Map<IEnumerable<ClientDto>>(clients) : null;

        if (clientDtos == null)
        {
            return null;
        }

        foreach (var clientDto in clientDtos)
        {
            clientDto.Subscriptions = await _subscriptionService.GetSubscriptions(clientDto.Id);
        }
        foreach (var clientDto in clientDtos)
        {
            clientDto.FingerPrint = await _fingerPrintService.GetFingerPrint(clientDto.Id);
        }

        return clientDtos;
    }

    public async Task<ClientDto> GetClient(int userId)
    {
        var client = await _clientRepository.GetById(userId);
        var clientDto = client != null ? _mapper.Map<ClientDto>(client) : null;

        if (clientDto == null)
        {
            return null;
        }

        clientDto.Subscriptions = await _subscriptionService.GetSubscriptions(client.Id);
        clientDto.FingerPrint = await _fingerPrintService.GetFingerPrint(clientDto.Id);

        return clientDto;
    }

    public async Task<ClientDto> AddClient(ClientDto client)
    {
        var addedClient = await _clientRepository.Add(_mapper.Map<Models.Users.Client>(client));

        return addedClient != null ? _mapper.Map<ClientDto>(addedClient) : null;
    }

    public async Task<ClientDto> UpdateClient(ClientDto client)
    {
        var updatedClient = await _clientRepository.UpdateAsync(_mapper.Map<Models.Users.Client>(client));

        return updatedClient != null ? _mapper.Map<ClientDto>(updatedClient) : null;
    }

    public async Task<ClientDto> RemoveClient(int clientId)
    {
        var removedClient = await _clientRepository.Delete(clientId);

        return removedClient != null ? _mapper.Map<ClientDto>(removedClient) : null;
    }

    public async Task<ClientDto> VerifyEntrance(int clientId)
    {
        var client = await GetClient(clientId);
        var subscription = await _subscriptionService.ValidateSubscriptionAsync(client.Subscriptions);

        if (!subscription.IsActive) return null;

        client.LastEntrance = DateTime.Now;
        if (subscription.SubscriptionType == SubscriptionType.CountedEntrances)
        {
            client.Subscriptions.First(x => x.Id == subscription.Id).EntrancesLeft--;
        }

        await UpdateClient(client);
        return client;
    }
}

