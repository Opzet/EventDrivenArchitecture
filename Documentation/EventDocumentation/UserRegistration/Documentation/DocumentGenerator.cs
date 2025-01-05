using System;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using UserRegistration.Attributes;
using UserRegistration.Domain.Events;

namespace UserRegistration.Infrastructure
{
    public static class DocumentationGenerator
    {

        private static void GenerateDocumentationStructure()
        {
            // Structure of the Event Catalog folders which will be filled ReGenerateMDXDocumentation
            // The structure of the generated code will follow eventcatalog conventions 

            // Create a c# generator to match
            //  ```npm
            //  > npx @eventcatalog/create-eventcatalog@latest my-event-catalog
            //  > Need to install the following packages:
            //  > @eventcatalog / create - eventcatalog@2.2.0
            //  > Ok to proceed ? (y)y
            // Installing dependencies:
            //  > -@eventcatalog / core
            //  > 
            // ```


        }

        public static void ReGenerateMDXDocumentation()
        {
            GenerateDocumentationStructure();

            var eventTypes = Assembly.GetExecutingAssembly().GetTypes()
              .Where(t => typeof(IEvent).IsAssignableFrom(t) && t.GetCustomAttribute<EventMetadataAttribute>() != null);

            foreach (var eventType in eventTypes)
            {
                //Enhance and extend Event Catalog mdx from samples 


                var sb = new StringBuilder();
                sb.AppendLine("# Event Documentation");
                sb.AppendLine();



                var attribute = eventType.GetCustomAttribute<EventMetadataAttribute>();
                if (attribute != null)
                {
                    sb.AppendLine($"## {attribute.Name}");
                    sb.AppendLine(attribute.Description);
                    sb.AppendLine();
                    sb.AppendLine("### Properties");
                    sb.AppendLine("| Name | Type | Description |");
                    sb.AppendLine("|------|------|-------------|");

                    foreach (var prop in eventType.GetProperties())
                    {
                        sb.AppendLine($"| {prop.Name} | {prop.PropertyType.Name} | |");
                    }

                    sb.AppendLine();
                    sb.AppendLine($"### {eventType} Example");

                    sb.AppendLine($"<{attribute.Name} ");
                    foreach (var prop in eventType.GetProperties())
                    {
                        sb.AppendLine($"  {prop.Name.ToLower()}=\"{{{prop.PropertyType.Name}}}\"");
                    }
                    sb.AppendLine("/>");
                    sb.AppendLine();
                }

                // Determine save location into Event Catalog Generated Documentation Directory Tree Structure
                string EventCatalogLocation = eventType_location; // match into Generated Documentation Structure

                // Structure of the Event Catalog
                string EventMDXDocument = eventType_filename + ".md"; //Event Catalog mdx (.md) file 

                string SavedMdxAs = Path.Combine(EventCatalogLocation, EventMDXDocument);
                File.WriteAllText(SavedMdxAs, sb.ToString());

                // Do a detailed report of  Event Catalog Generated Documentation Directory Tree Structure and files created or missing
                // Maybe report stats like size or completeness, maybe a report detailing where extra detail is required

                // After generate, you can see that in the events and services folder the information regarding the asyncAPI definition 
                // 

            }
        }
    }
}