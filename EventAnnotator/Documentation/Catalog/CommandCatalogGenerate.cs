using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EventAnnotator
{
    public partial class CommandMetadataAttribute : Attribute
    {
         public void GenerateMarkdown(string cmd, string filePath)
        {
            // MDX documentation for EventCatalog 

            if (!Array.Exists(Environments, e => e.Equals(cmd, StringComparison.OrdinalIgnoreCase)))
            {
                throw new ArgumentException($"Invalid environment: {cmd}");
            }

            var markdown = new StringBuilder();
            markdown.AppendLine("---");
            markdown.AppendLine($"id: {Domain}.{cmd}.events");
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
            markdown.AppendLine(LoadExampleCode(cmd) );

            File.WriteAllText(filePath, markdown.ToString());
        }

        private string LoadExampleCode(string command)
        {
            string exampleFilePath = $"code[{command}].md";

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
