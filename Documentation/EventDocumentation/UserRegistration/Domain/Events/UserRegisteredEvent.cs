namespace UserRegistration.Domain.Events
{
    // Event representing a user registration
    public class UserRegisteredEvent : IEvent
    {
        public Guid Id
        {
            get; private set;
        }
        public DateTime OccurredOn
        {
            get; private set;
        }
        public string Username
        {
            get; private set;
        }
        public string Email
        {
            get; private set;
        }

        public UserRegisteredEvent(string username, string email)
        {
            Id = Guid.NewGuid();
            OccurredOn = DateTime.UtcNow;
            Username = username;
            Email = email;
        }
    }
}