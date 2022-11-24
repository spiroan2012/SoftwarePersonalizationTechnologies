namespace Dtos.Responses
{
    public class UserRoleDto
    {
        public int Id { get; set; }
        public string? Username { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Email { get; set; }
        public string? DateOfBirth { get; set; }
        public string? CreationDate { get; set; }
        public bool IsDisabled { get; set; }
        public IList<string>? Roles { get; set; }
    }
}
