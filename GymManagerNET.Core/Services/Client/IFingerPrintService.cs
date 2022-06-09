using GymManagerNET.Core.DTOs.Users;

namespace GymManagerNET.Core.Services.Client;

public interface IFingerPrintService
{
    public Task<List<FingerPrintDto>> GetFingerPrints();
    public Task<FingerPrintDto> GetFingerPrint(int UserId);
    public Task<FingerPrintDto> SaveFingerPrint(FingerPrintDto fingerPrint);
    public Task<FingerPrintDto> DeleteFingerPrint(int UserId);
}