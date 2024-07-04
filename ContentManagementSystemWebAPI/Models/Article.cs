using System;
using System.Collections.Generic;

namespace ContentManagementSystemWebAPI.Models
{
        public partial class Article
    {
        public Article()
        {
            ArticleCategories = new HashSet<ArticleCategory>();
            Comments = new HashSet<Comment>();
            Tags = new HashSet<Tag>();
        }

        public int Id { get; set; }
        public string? Title { get; set; }
        
        public string? Content { get; set; }
        public string? Image { get; set; }
        public int? AuthorId { get; set; }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public virtual User? Author { get; set; }

        public DateTime? CreatedDate { get; set; }
        public DateTime? CreatedOn { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? ModifiedDate { get; set; }

        public int? ModifiedBy { get; set; }
        public string? Title1 { get; set; }
        public string? Title2 { get; set; }
        public string? Title3 { get; set; }
        public string? Description { get; set; }
        public string? Type { get; set; }
        public string? URLButtonName { get; set; }
        public string? URL { get; set; }                       
        public string? Section { get; set; }
        public bool? IsActive { get; set; }

        public virtual ICollection<ArticleCategory> ArticleCategories { get; set; }
        public virtual ICollection<Comment> Comments { get; set; }

        public virtual ICollection<Tag> Tags { get; set; }
    }

}
