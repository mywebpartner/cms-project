namespace ContentManagementSystemWebAPI.Models.DTOs
{
    public class UserDto
    {
        public string Username { get; set; }
        public string PasswordHash { get; set; }
        public string Email { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string Mobile { get; set; }
        public string Address { get; set; }
        public int? StateID { get; set; }
        public int? CountryID { get; set; }
        public int? CityID { get; set; }
        public bool? isActive { get; set; }
    }
}
