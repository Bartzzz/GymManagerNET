using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace GymManagerNET.Core.Models.Users
{
    public class Client : UserBase
    {
        public IEnumerable<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public IEnumerable<FingerPrint> FingerPrint { get; set; } = new List<FingerPrint>();
        public DateTime LastEntrance { get; set; }
    }
}
