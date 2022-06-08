using AutoMapper;
using GymManagerNET.Core.Models;
using GymManagerNET.Core.Models.DTOs.Activities;
using GymManagerNET.Core.Services.RoomBookings;

namespace GymManagerNET.Core.Services.Activity;

public class ActivityService : IActivityService
{
    private readonly IActivityRepository _activityRepository;
    private readonly IRoomBookingRepository _roomBookingRepository;
    private readonly IMapper _mapper;

    public ActivityService(IActivityRepository activityRepository, IRoomBookingRepository roomBookingRepository, IMapper mapper)
    {
        _activityRepository = activityRepository;
        _roomBookingRepository = roomBookingRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<ActivityDto>> GetActivities()
    {
        var activities = await _activityRepository.GetEntities();
        var activityDtos = activities != null ? _mapper.Map<IEnumerable<ActivityDto>>(activities) : null;

        if (activityDtos == null)
        {
            return null;
        }

        foreach (var activityDto in activityDtos)
        {
            activityDto.Bookings = _roomBookingRepository.GetEntitiesByActivityId(activityDto.Id).Result.ToList();
        }

        return activityDtos;
    }

    public async Task<ActivityDto> AddActivity(ActivityDto activity)
    {
        var addedActivity = await _activityRepository.Add(_mapper.Map<Models.Activity>(activity));

        return addedActivity != null ? _mapper.Map<ActivityDto>(addedActivity) : null;
    }

    public async Task<ActivityDto> GetActivity(int activityId)
    {
        var activity = await _activityRepository.GetById(activityId);
        var activityDto = activity != null ? _mapper.Map<ActivityDto>(activity) : null;

        if (activityDto == null)
        {
            return null;
        }

        activityDto.Bookings = _roomBookingRepository.GetEntitiesByActivityId(activity.Id).Result.ToList();

        return activityDto;
    }

    public async Task<ActivityDto> RemoveActivity(int activityId)
    {
        var removedActivity = await _activityRepository.Delete(activityId);

        return removedActivity != null ? _mapper.Map<ActivityDto>(removedActivity) : null;
    }

    public async Task<ActivityDto> UpdateActivity(ActivityDto activity)
    {
        var updatedActivity = await _activityRepository.UpdateAsync(_mapper.Map<Models.Activity>(activity));

        return updatedActivity != null ? _mapper.Map<ActivityDto>(updatedActivity) : null;
    }
}