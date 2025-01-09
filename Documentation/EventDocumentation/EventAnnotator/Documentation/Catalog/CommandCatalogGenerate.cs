using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EventAnnotator
{
    public partial class CommandMetadataAttribute : Attribute
    {
         public void GenerateMarkdown(string env, string filePath, string publishingExamplePath, string subscriptionExamplePath)
        {
            // MDX documentation for EventCatalog 

            if (!Array.Exists(Environments, e => e.Equals(env, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Invalid environment: {env}");
            }

            var markdown = new StringBuilder();
            markdown.AppendLine("---");
            markdown.AppendLine($"id: {Domain}.{env}.events");
            markdown.AppendLine($"name: {Name}");
            markdown.AppendLine($"version: {Version}");
            markdown.AppendLine("summary: |");
            markdown.AppendLine($"  {Summary}");
            markdown.AppendLine("owners:");
            foreach (var owner in Owners)
            {
                markdown.AppendLine($"  - {owner}");
            }
            markdown.AppendLine($"address: {Address}");
            markdown.AppendLine("protocols:");
            foreach (var protocol in Protocols)
            {
                markdown.AppendLine($"  - {protocol}");
            }
            markdown.AppendLine();
            markdown.AppendLine("parameters:");
            markdown.AppendLine("  env:");
            markdown.AppendLine("    enum:");
            foreach (var environment in Environments)
            {
                markdown.AppendLine($"      - {environment}");
            }
            markdown.AppendLine("    description: 'Environment to use'");
            markdown.AppendLine("---");
            markdown.AppendLine();
            markdown.AppendLine("### Overview");
            markdown.AppendLine(Description);
            markdown.AppendLine();
            markdown.AppendLine("<ChannelInformation />");
            markdown.AppendLine(ChannelOverview);
            markdown.AppendLine();
            markdown.AppendLine("### Publishing and Subscribing to Events");
            markdown.AppendLine();
            markdown.AppendLine("#### Publishing Example");
            markdown.AppendLine(LoadExampleCode(publishingExamplePath));
            markdown.AppendLine();
            markdown.AppendLine("#### Subscription Example");
            markdown.AppendLine(LoadExampleCode(subscriptionExamplePath));

            File.WriteAllText(filePath, markdown.ToString());
        }

        private string LoadExampleCode(string exampleFilePath)
        {
            if (File.Exists(exampleFilePath))
            {
                return File.ReadAllText(exampleFilePath);
            }
            else
            {
                throw new FileNotFoundException($"Example file not found: {exampleFilePath}");
            }
        }
    }
}
