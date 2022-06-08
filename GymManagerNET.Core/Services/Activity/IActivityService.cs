using GymManagerNET.Core.Models.DTOs.Activities;
using GymManagerNET.Core.Models.DTOs.Rooms;

namespace GymManagerNET.Core.Services.RoomBookings;

public interface IActivityService
{
    Task<IEnumerable<ActivityDto>> GetActivities();
    Task<ActivityDto> GetActivity(int activityId);
    Task<ActivityDto> AddActivity(ActivityDto activity);
    Task<ActivityDto> UpdateActivity(ActivityDto activity);
    Task<ActivityDto> RemoveActivity(int activityId);
}