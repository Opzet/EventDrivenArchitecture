
// Example event: UserRegistered
using OIM.Domain.Events;


namespace OIM.Domain.Model
{

    public class User : UserRegisteredEvent
    {
        public string Username
        {
            get; private set;
        }
        public string Email
        {
            get; private set;
        }

        public User(string username, string email) : base(username, email)
        {
            Username = username;
            Email = email;
        }
    }
}