using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using EventAnnotator.Domain.Events;

public static class EventSchemaRegistry
{
    private static readonly Dictionary<string, string> _eventSchemas = new();

    static EventSchemaRegistry()
    {
        RegisterEventSchemas();
    }

    private static void RegisterEventSchemas()
    {
        var eventTypes = Assembly.GetExecutingAssembly().GetTypes()
            .Where(t => typeof(IEvent).IsAssignableFrom(t) && t.GetCustomAttribute<EventMetadataAttribute>() != null);

        foreach (var eventType in eventTypes)
        {
            var attribute = eventType.GetCustomAttribute<EventMetadataAttribute>();
            if (attribute != null)
            {
                _eventSchemas[attribute.Name] = attribute.Description;
            }
        }
    }

    public static string GetEventSchema(string eventName)
    {
        return _eventSchemas.TryGetValue(eventName, out var schema) ? schema : null;
    }
}
