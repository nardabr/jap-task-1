using System.Text.Json.Serialization;

namespace Server.Core.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UserStatus
    {
        Expired = 0,
        Active = 1,
    }
}
