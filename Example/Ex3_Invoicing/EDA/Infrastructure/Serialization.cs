﻿using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Newtonsoft.Json.Serialization;



public static class SerializationExtensions
{
    public static JsonSerializerSettings WithDefaults(this JsonSerializerSettings settings)
    {
        settings.WithNonDefaultConstructorContractResolver()
            .Converters.Add(new StringEnumConverter());

        return settings;
    }

    public class NonDefaultConstructorContractResolver : DefaultContractResolver
    {
        //protected override JsonObjectContract CreateObjectContract(Type objectType) =>
        //    JsonObjectContractProvider.UsingNonDefaultConstructor(
        //        base.CreateObjectContract(objectType),
        //        objectType,
        //        base.CreateConstructorParameters
        //    );
    }

    public static JsonSerializerSettings WithNonDefaultConstructorContractResolver(this JsonSerializerSettings settings)
    {
        settings.ContractResolver = new NonDefaultConstructorContractResolver();
        return settings;
    }

    public static JsonSerializerSettings WithConverters(this JsonSerializerSettings settings, params JsonConverter[] converters)
    {
        foreach (var converter in converters)
        {
            settings.Converters.Add(converter);
        }
        return settings;
    }

    /// <summary>
    /// Deserialize object from json with JsonNet
    /// </summary>
    /// <typeparam name="T">Type of the deserialized object</typeparam>
    /// <param name="json">json string</param>
    /// <param name="converters"></param>
    /// <returns>deserialized object</returns>
    public static T FromJson<T>(this string json, params JsonConverter[] converters) =>
        JsonConvert.DeserializeObject<T>(json,
            new JsonSerializerSettings().WithNonDefaultConstructorContractResolver().WithConverters(converters))!;

    /// <summary>
    /// Deserialize object from json with JsonNet
    /// </summary>
    /// <typeparam name="T">Type of the deserialized object</typeparam>
    /// <param name="json">json string</param>
    /// <param name="type">object type</param>
    /// <param name="converters"></param>
    /// <returns>deserialized object</returns>
    public static object? FromJson(this string json, Type type, params JsonConverter[] converters) =>
        JsonConvert.DeserializeObject(json, type,
            new JsonSerializerSettings().WithNonDefaultConstructorContractResolver().WithConverters(converters));

    /// <summary>
    /// Serialize object to json with JsonNet
    /// </summary>
    /// <param name="obj">object to serialize</param>
    /// <param name="converters"></param>
    /// <returns>json string</returns>
    public static string ToJson(this object obj, params JsonConverter[] converters) =>
        JsonConvert.SerializeObject(obj,
            new JsonSerializerSettings().WithNonDefaultConstructorContractResolver().WithConverters(converters));

    /// <summary>
    /// Serialize object to json with JsonNet
    /// </summary>
    /// <param name="obj">object to serialize</param>
    /// <returns>json string</returns>
    public static StringContent ToJsonStringContent(this object obj) =>
        new(obj.ToJson(), Encoding.UTF8, "application/json");
}