using System;
using System.Collections.Generic;

namespace ContentManagementSystemWebAPI.Models
{
    public partial class User
    {
        public User()
        {
            Articles = new HashSet<Article>();
            Comments = new HashSet<Comment>();
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string? Username { get; set; }
        public string? PasswordHash { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; } 
        public string? Address { get; set; }
        public int? StateID { get; set; }    
        public int? CountryID { get; set; } 
        public int? CityID { get; set; }
        public bool? isActive { get; set; }
        public DateTime? LastLoginTime { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }
        public virtual ICollection<Role> Roles { get; set; }
    }
}

