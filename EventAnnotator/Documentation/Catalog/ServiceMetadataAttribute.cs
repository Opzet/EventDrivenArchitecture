using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
sealed class ServiceMetadataAttribute : Attribute
{
    public string Name { get; }
    public string Description { get; }

    public ServiceMetadataAttribute(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
    