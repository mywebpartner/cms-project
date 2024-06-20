using System;
using System.Collections.Generic;

namespace ContentManagementSystemWebAPI.Models
{
    public partial class Comment
    {
        public int Id { get; set; }
        public string Content { get; set; } = null!;
        public int? AuthorId { get; set; }
        public int? ArticleId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual Article? Article { get; set; }
        public virtual User? Author { get; set; }
    }
}
