using Microsoft.AspNetCore.Http;

namespace Dtos.Requests
{
    public class FileDto
    {
        public IFormFile? MyFile { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? EmailAddress { get; set; }
    }
}
