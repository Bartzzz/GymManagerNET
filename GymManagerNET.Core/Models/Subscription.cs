using GymManagerNET.Core.Enums;
using GymManagerNET.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GymManagerNET.Core.Models
{
        public class Subscription
        {
            [Key]
            public int Id { get; set; }
            [Required]
            public SubscriptionType SubscriptionType { get; set; }
            [Required]
            public DateTime StartDate { get; set; }
            public int EntrancesLeft { get; set; }
            public int UserId { get; set; }
            public Client User { get; set; }
        }
}
