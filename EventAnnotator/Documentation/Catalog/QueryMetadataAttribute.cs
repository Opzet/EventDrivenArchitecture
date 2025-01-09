using System;

[AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = true)]
sealed class QueryMetadataAttribute : Attribute
{
    public string Name { get; }
    public string Description { get; }

    public QueryMetadataAttribute(string name, string description)
    {
        Name = name;
        Description = description;
    }
}
    