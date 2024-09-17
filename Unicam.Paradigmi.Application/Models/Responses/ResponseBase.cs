using System.Text.Json.Serialization;

namespace Unicam.Paradigmi.Application.Models.Responses
{
    public class ResponseBase<T>
    {
        public bool IsSuccess { get; set; }
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]
        public List<string>? Errors { get; set; } = null;
        [JsonIgnore(Condition = JsonIgnoreCondition.WhenWritingNull)]

        public T? Result { get; set; } = default;
    }
}
