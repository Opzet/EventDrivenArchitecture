using System;

namespace UserRegistration.Attributes
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class EventMetadataAttribute : Attribute
    {
        public string Name { get; }
        public string Description { get; }

        public EventMetadataAttribute(string name, string description)
        {
            Name = name;
            Description = description;
        }
    }
}
