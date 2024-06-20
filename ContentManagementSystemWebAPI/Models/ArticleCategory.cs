using System;
using System.Collections.Generic;

namespace ContentManagementSystemWebAPI.Models
{
    public partial class ArticleCategory
    {
        public int Id { get; set; }
        public int? ArticleId { get; set; }
        public int? CategoryId { get; set; }
        public bool? IsActive { get; set; }

        public virtual Article? Article { get; set; }
        public virtual Category? Category { get; set; }
    }
}
