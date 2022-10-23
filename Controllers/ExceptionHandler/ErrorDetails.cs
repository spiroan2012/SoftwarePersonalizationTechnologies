using System.Text.Json;

namespace Controllers.ExceptionHandler
{
    public class ErrorDetails
    {
        public int Code { get; set; }
        public string? Message { get; set; }
        public override string ToString()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
