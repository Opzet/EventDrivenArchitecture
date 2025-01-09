using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
sealed class DomainMetadataAttribute : Attribute
{
    public string Name { get; }
    public string Description { get; }

    public DomainMetadataAttribute(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
    