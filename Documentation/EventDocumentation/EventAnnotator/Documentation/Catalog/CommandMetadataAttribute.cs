using System;
using System.IO;
using System.Text;

namespace EventAnnotator
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public partial class CommandMetadataAttribute : Attribute
    {
        public string Domain
        {
            get;
        }
        public string Name
        {
            get;
        }
        public string Description
        {
            get;
        }
        public string Version
        {
            get;
        }
        public string Summary
        {
            get;
        }
        public string[] Owners
        {
            get;
        }
        public string Address
        {
            get;
        }
        public string[] Protocols
        {
            get;
        }
        public string[] Environments
        {
            get;
        }
        public string ChannelOverview
        {
            get;
        }

        public CommandMetadataAttribute(
            string domain,
            string name,
            string description,
            string version,
            string summary,
            string[] owners,
            string address,
            string[] protocols,
            string[] environments,
            string channelOverview)
        {
            Domain = domain;
            Name = name;
            Description = description;
            Version = version;
            Summary = summary;
            Owners = owners;
            Address = address;
            Protocols = protocols;
            Environments = environments;
            ChannelOverview = channelOverview;
        }

       
    }
}
