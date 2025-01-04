using UserRegistration.Domain.Model;
using UserRegistration.Infrastructure;
using UserRegistration.Services;

namespace UserRegistration
{

    class Program
    {
        static void Main(string[] args)
        {
            // Initialize the event store and dispatcher
            var eventStore = new EventStore();
            var dispatcher = new EventDispatcher();
            var userService = new UserService(eventStore, dispatcher);

            // Register event handler for UserRegisteredEvent
            dispatcher.RegisterHandler<User>(e =>
            {
                Console.WriteLine($"User registered: {e.Username}, {e.Email}");
            });

            // Register a user, which will create and store an event, then dispatch it
            userService.RegisterUser("john_doe", "john@example.com");

            // Update event documentation
            UpdateEventDocumentation();
        }

        private static void UpdateEventDocumentation()
        {
            var eventSchemas = EventSchemaRegistry.GetEventSchema("UserRegisteredEvent");
            if (eventSchemas != null)
            {
                EventCatalogSDK.UpdateEventSchema("UserRegisteredEvent", eventSchemas);
            }
        }
    }
}