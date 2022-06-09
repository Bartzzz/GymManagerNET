using GymManager.Core.DTOs.Subscriptions;
using System;
using System.Collections.Generic;
using GymManagerNET.Core.Models.DTOs.Subscriptions;
using GymManagerNET.Core.Models.Users;

namespace GymManagerNET.Core.DTOs.Users
{
    public class ClientDto : UserDto
    {
        public DateTime LastEntrance { get; set; }
        public IEnumerable<SubscriptionDto> Subscriptions { get; set; }

        public FingerPrintDto FingerPrint { get; set; }
    }
}
