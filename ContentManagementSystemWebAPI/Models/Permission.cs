using System;
using System.Collections.Generic;

namespace ContentManagementSystemWebAPI.Models
{
    public partial class Permission
    {
        public Permission()
        {
            Roles = new HashSet<Role>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;
        public string? MenuUrl { get; set; }

        public virtual ICollection<Role> Roles { get; set; }
    }
}
