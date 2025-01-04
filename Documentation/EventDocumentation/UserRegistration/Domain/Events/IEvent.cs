namespace UserRegistration.Domain.Events
{
    // Interface for domain events
    public interface IEvent
    {
        Guid Id
        {
            get;
        }
        DateTime OccurredOn
        {
            get;
        }
    }
}