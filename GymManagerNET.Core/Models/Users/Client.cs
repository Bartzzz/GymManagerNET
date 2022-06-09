namespace GymManagerNET.Core.Models.Users
{
    public class Client : UserBase
    {
        public IEnumerable<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public FingerPrint FingerPrint { get; set; }
        public DateTime LastEntrance { get; set; }
    }
}
