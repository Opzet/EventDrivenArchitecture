using System;
using System.Linq;
using System.Reflection;
using System.Text;
using UserRegistration.Attributes;
using UserRegistration.Domain.Events;

namespace UserRegistration.Infrastructure
{
    public static class DocumentationGenerator
    {
        public static string GenerateMarkdownDocumentation()
        {
            var sb = new StringBuilder();
            sb.AppendLine("# Event Documentation");
            sb.AppendLine();

            var eventTypes = Assembly.GetExecutingAssembly().GetTypes()
                .Where(t => typeof(IEvent).IsAssignableFrom(t) && t.GetCustomAttribute<EventMetadataAttribute>() != null);

            foreach (var eventType in eventTypes)
            {
                var attribute = eventType.GetCustomAttribute<EventMetadataAttribute>();
                if (attribute != null)
                {
                    sb.AppendLine($"## {attribute.Name}");
                    sb.AppendLine(attribute.Description);
                    sb.AppendLine();
                    sb.AppendLine("### Properties");
                    sb.AppendLine("| Name | Type |");
                    sb.AppendLine("|------|------|");

                    foreach (var prop in eventType.GetProperties())
                    {
                        sb.AppendLine($"| {prop.Name} | {prop.PropertyType.Name} |");
                    }

                    sb.AppendLine();
                }
            }

            return sb.ToString();
        }
    }
}
