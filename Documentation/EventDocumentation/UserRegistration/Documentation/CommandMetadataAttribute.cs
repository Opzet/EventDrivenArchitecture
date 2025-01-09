using System;

namespace UserRegistration.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CommandMetadataAttribute : Attribute
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

        public CommandMetadataAttribute(string domain, string name, string description)
        {
            Domain = domain;
            Name = name;
            Description = description;
        }


       
    }
}
