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
            // The structure of the generated code will follow event catalog conventions 

            // List of folders to be created based on the event catalog structure
            List<string> EventCatalogFolders = new List<string>
            {
                "channels",
                        // {name}.{env}.events folders
                        // {name}.md
                "components",
                "domains",
                        // {name}\
                        // File -> changelog.md
                        // File -> ubiquitous-language.

                        // {name}\services
                        // {name}\{name}Services\
                        // {name}\versioned
                        
                        // {name}\versioned\{version}
                         // File -> index.md
                "pages",
                "public",
                "teams",
                "users"
            };

            var eventTypes = Assembly.GetExecutingAssembly().GetTypes()
              .Where(t => typeof(IEvent).IsAssignableFrom(t) && t.GetCustomAttribute<EventMetadataAttribute>() != null);


            string AppFolder = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);
            string BaseDirectory = Path.Combine(AppFolder, "Documentation-EventCatalog");

            Directory.CreateDirectory(BaseDirectory);


            foreach (var eventType in eventTypes)
            {
                var attribute = eventType.GetCustomAttribute<EventMetadataAttribute>();
            if (attribute != null)
            {
                string domainFolder = Path.Combine(BaseDirectory, "domains", attribute.Name);
                Directory.CreateDirectory(domainFolder);

                    string servicesFolder = Path.Combine(domainFolder, "services");
                    Directory.CreateDirectory(servicesFolder);


                Directory.CreateDirectory(Path.Combine(domainFolder, "versioned"));
                File.WriteAllText(Path.Combine(domainFolder, "changelog.md"), string.Empty);
                File.WriteAllText(Path.Combine(domainFolder, "index.md"), string.Empty);
                File.WriteAllText(Path.Combine(domainFolder, "ubiquitous-language.md"), string.Empty);

                string serviceFolder = Path.Combine(domainFolder, "services", $"{attribute.Name}Service");
                Directory.CreateDirectory(serviceFolder);
                Directory.CreateDirectory(Path.Combine(serviceFolder, "events"));
                Directory.CreateDirectory(Path.Combine(serviceFolder, "commands"));
                Directory.CreateDirectory(Path.Combine(serviceFolder, "queries"));
                Directory.CreateDirectory(Path.Combine(serviceFolder, "versioned"));
                File.WriteAllText(Path.Combine(serviceFolder, "changelog.md"), string.Empty);
                File.WriteAllText(Path.Combine(serviceFolder, "index.md"), string.Empty);

                string eventFolder = Path.Combine(serviceFolder, "events", eventType.Name);
                Directory.CreateDirectory(eventFolder);
                Directory.CreateDirectory(Path.Combine(eventFolder, "versioned"));
                File.WriteAllText(Path.Combine(eventFolder, "changelog.md"), string.Empty);
                File.WriteAllText(Path.Combine(eventFolder, "index.md"), string.Empty);
                File.WriteAllText(Path.Combine(eventFolder, "schema.json"), string.Empty);
            }

            foreach ( var folder in EventCatalogFolders)
            {
                Directory.CreateDirectory(Path.Combine(BaseDirectory, folder));
            }

        }

        }

        public static void ReGenerateMDXDocumentation()
        {
        
            GenerateDocumentationStructure();



            // Create a c# generator to ensure that your event schemas are automatically documented in MDX format,
            // which can be interpreted by tools like EventCatalog.

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