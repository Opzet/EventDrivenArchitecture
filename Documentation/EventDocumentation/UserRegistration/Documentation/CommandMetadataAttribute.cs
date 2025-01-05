using System;

namespace UserRegistration.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class CommandMetadataAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }

        public CommandMetadataAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
