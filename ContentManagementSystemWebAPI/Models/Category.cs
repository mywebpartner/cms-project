using System;
using System.Collections.Generic;

namespace ContentManagementSystemWebAPI.Models
{
    public partial class Category
    {
        public Category()
        {
            ArticleCategories = new HashSet<ArticleCategory>();
        }

        public int Id { get; set; }
        public string Name { get; set; } = null!;

        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
    }
}
