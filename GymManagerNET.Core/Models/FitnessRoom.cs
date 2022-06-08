using System.ComponentModel.DataAnnotations;

namespace GymManagerNET.Core.Models
{
    public class FitnessRoom
    {
        [Key]
        public int Id { get; set; }

        public int MaxPeopleCapacity { get; set; }

        public List<RoomBooking> Bookings { get; set; }
    }
}
