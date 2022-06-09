using AutoMapper;
using GymManagerNET.Core.DTOs.Users;
using GymManagerNET.Core.Models.Users;
using GymManagerNET.Core.Services.Subscriptions;

namespace GymManagerNET.Core.Services.Client;

public class FingerPrintService : IFingerPrintService
    {
        private readonly IClientRepository _clientRepository;
        private readonly ISubscriptionRepository _subscriptionRepository;
        private readonly IFingerPrintRepository _fingerPrintRepository;
        private readonly IMapper _mapper;

        public FingerPrintService(IClientRepository clientRepository, ISubscriptionRepository subscriptionRepository, IFingerPrintRepository fingerPrintRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _subscriptionRepository = subscriptionRepository;
            _fingerPrintRepository = fingerPrintRepository;
            _mapper = mapper;
        }
        public async Task<List<FingerPrintDto>> GetFingerPrints()
        {
        var fingerprints = await _fingerPrintRepository.GetEntities();
        var fingerprintDtos = fingerprints != null ? _mapper.Map<IEnumerable<FingerPrintDto>>(fingerprints) : null;

        return fingerprintDtos?.ToList();
    }

        public Task<FingerPrintDto> GetFingerPrint(int UserId)
        {
            throw new NotImplementedException();
        }

        public async Task<FingerPrintDto> SaveFingerPrint(FingerPrintDto fingerPrint)
        {
            var result = await _fingerPrintRepository.Add(_mapper.Map<FingerPrint>(fingerPrint));
            return _mapper.Map<FingerPrintDto>(result) ?? null;
        }

        public Task<FingerPrintDto> DeleteFingerPrint(int UserId)
        {
            throw new NotImplementedException();
        }
    }

