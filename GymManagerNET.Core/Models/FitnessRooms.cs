using System.ComponentModel.DataAnnotations;

namespace GymManagerNET.Core.Models
{
    public class FitnessRooms
    {
        [Key]
        public int Id { get; set; }

        public int MaxPeopleCapacity { get; set; }
    }
}
