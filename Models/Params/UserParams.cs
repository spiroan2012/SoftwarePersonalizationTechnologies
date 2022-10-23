namespace Models.Params
{
    public class UserParams : PaginationParams
    {
        public string? SearchUsername { get; set; }
        public string? OrderBy { get; set; }
    }
}
