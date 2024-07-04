using ContentManagementSystemWebAPI.Models;
using ContentManagementSystemWebAPI.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using static System.Collections.Specialized.BitVector32;

namespace ContentManagementSystemWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CMSwebapiController : ControllerBase
    {
        private readonly ContentManagementSystemContext context;

        public CMSwebapiController(ContentManagementSystemContext context)
        {
            this.context = context;
        }

        public class ApiResponse
        {
            public object Result { get; set; }
            public string Message { get; set; }
        }

        

        [HttpGet("articlecategories")]
        public async Task<ActionResult<ApiResponse>> GetArticleCategories()
        {
            var categories = await this.context.ArticleCategories.ToListAsync();
            return Ok(new ApiResponse { Message = "ArticleCategories", Result = categories });
        }

        [HttpGet("articlecategories/{id}")]
        public async Task<ActionResult<ApiResponse>> GetArticleCategory(int id)
        {
            var category = await this.context.ArticleCategories.FindAsync(id);
            if (category == null)
            {
                return NotFound(new ApiResponse { Message = "ArticleCategory not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "ArticleCategory", Result = category });
        }

        [HttpGet("categories")]
        public async Task<ActionResult<ApiResponse>> GetCategories()
        {
            var categories = await this.context.Categories.ToListAsync();
            return Ok(new ApiResponse { Message = "Categories", Result = categories });
        }

        [HttpGet("categories/{id}")]
        public async Task<ActionResult<ApiResponse>> GetCategory(int id)
        {
            var category = await this.context.Categories.FindAsync(id);
            if (category == null)
            {
                return NotFound(new ApiResponse { Message = "Category not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Category", Result = category });
        }

        [HttpGet("comments")]
        public async Task<ActionResult<ApiResponse>> GetComments()
        {
            var comments = await this.context.Comments.ToListAsync();
            return Ok(new ApiResponse { Message = "Comments", Result = comments });
        }

        [HttpGet("comments/{id}")]
        public async Task<ActionResult<ApiResponse>> GetComment(int id)
        {
            var comment = await this.context.Comments.FindAsync(id);
            if (comment == null)
            {
                return NotFound(new ApiResponse { Message = "Comment not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Comment", Result = comment });
        }

        [HttpGet("permissions")]
        public async Task<ActionResult<ApiResponse>> GetPermissions()
        {
            var permissions = await this.context.Permissions.ToListAsync();
            return Ok(new ApiResponse { Message = "Permissions", Result = permissions });
        }

        [HttpGet("permissions/{id}")]
        public async Task<ActionResult<ApiResponse>> GetPermission(int id)
        {
            var permission = await this.context.Permissions.FindAsync(id);
            if (permission == null)
            {
                return NotFound(new ApiResponse { Message = "Permission not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Permission", Result = permission });
        }

        [HttpGet("roles")]
        public async Task<ActionResult<ApiResponse>> GetRoles()
        {
            var roles = await this.context.Roles.ToListAsync();
            return Ok(new ApiResponse { Message = "Roles", Result = roles });
        }

        [HttpGet("roles/{id}")]
        public async Task<ActionResult<ApiResponse>> GetRole(int id)
        {
            var role = await this.context.Roles.FindAsync(id);
            if (role == null)
            {
                return NotFound(new ApiResponse { Message = "Role not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Role", Result = role });
        }

        [HttpGet("tags")]
        public async Task<ActionResult<ApiResponse>> GetTags()
        {
            var tags = await this.context.Tags.ToListAsync();
            return Ok(new ApiResponse { Message = "Tags", Result = tags });
        }

        [HttpGet("tags/{id}")]
        public async Task<ActionResult<ApiResponse>> GetTag(int id)
        {
            var tag = await this.context.Tags.FindAsync(id);
            if (tag == null)
            {
                return NotFound(new ApiResponse { Message = "Tag not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Tag", Result = tag });
        }

        [HttpGet("users")]
        public async Task<ActionResult<ApiResponse>> GetUsers()
        {
            var users = await this.context.Users.ToListAsync();
            return Ok(new ApiResponse { Message = "Users", Result = users });
        }

        [HttpGet("users/{id}")]
        public async Task<ActionResult<ApiResponse>> GetUser(int id)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse { Message = "User not found", Result = null });
            }
            return Ok(new ApiResponse { Message = "User", Result = user });
        }

        [HttpPost("users")]
        public async Task<ActionResult<ApiResponse>> CreateUser([FromBody] UserDto createUserDto)
        {
            var existingUser = await this.context.Users.FirstOrDefaultAsync(u => u.Email == createUserDto.Email);
            if (existingUser != null)
            {
                return BadRequest(new ApiResponse { Message = "Email address already exists", Result = null });
            }

            var user = new User
            {
                Username = createUserDto.Username,
                PasswordHash = createUserDto.PasswordHash,
                Email = createUserDto.Email,
                LastLoginTime = createUserDto.LastLoginTime,
                CreatedAt = createUserDto.CreatedAt ?? DateTime.UtcNow,
                UpdatedAt = createUserDto.UpdatedAt ?? DateTime.UtcNow,
                Mobile = createUserDto.Mobile,
                Address = createUserDto.Address,
                StateID = createUserDto.StateID,
                CountryID = createUserDto.CountryID,
                CityID = createUserDto.CityID,
                isActive = createUserDto.isActive ?? true
            };

            this.context.Users.Add(user);
            await this.context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "User created successfully", Result = user });
        }

        [HttpPut("users/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateUser(int id, [FromBody] UserDto updateUserDto)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse { Message = "User not found", Result = null });
            }

            if (!string.IsNullOrEmpty(updateUserDto.Email) && updateUserDto.Email != user.Email)
            {
                var existingUser = await this.context.Users.FirstOrDefaultAsync(u => u.Email == updateUserDto.Email);
                if (existingUser != null)
                {
                    return BadRequest(new ApiResponse { Message = "Email address already exists", Result = null });
                }
                user.Email = updateUserDto.Email;
            }

            user.Username = updateUserDto.Username ?? user.Username;
            user.PasswordHash = updateUserDto.PasswordHash ?? user.PasswordHash;
            user.Email = updateUserDto.Email ?? user.Email;
            user.LastLoginTime = updateUserDto.LastLoginTime ?? user.LastLoginTime;
            user.Mobile = updateUserDto.Mobile ?? user.Mobile;
            user.Address = updateUserDto.Address ?? user.Address;
            user.StateID = updateUserDto.StateID ?? user.StateID;
            user.CountryID = updateUserDto.CountryID ?? user.CountryID;
            user.CityID = updateUserDto.CityID ?? user.CityID;
            user.isActive = updateUserDto.isActive ?? user.isActive;
            user.UpdatedAt = DateTime.UtcNow;

            await this.context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "User updated successfully", Result = user });
        }

        [HttpDelete("users/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteUser(int id)
        {
            var user = await this.context.Users.FindAsync(id);
            if (user == null)
            {
                return NotFound(new ApiResponse { Message = "User not found", Result = null });
            }

            this.context.Users.Remove(user);
            await this.context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "User deleted successfully", Result = user });
        }

        [HttpGet("articles")]
        public async Task<ActionResult<ApiResponse>> GetArticles()
        {
            var articles = await this.context.Articles.ToListAsync();
            return Ok(new ApiResponse { Message = "Getting all Articles at once", Result = articles });
        }
       
        [HttpGet("articles/{id}")]
        public async Task<ActionResult<ApiResponse>> GetArticle(int id)
        {
            var article = await this.context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound(new ApiResponse { Message = "No Such Article Is Found", Result = null });
            }
            return Ok(new ApiResponse { Message = "Required Article", Result = article });

        }
            [HttpPost("articles")]
        public async Task<ActionResult<ApiResponse>> CreateArticle([FromBody] ContentDto contentDto)
        {
            var article = new Article
            {
                Title = contentDto.Title,
                Content = contentDto.Body,
                Image = contentDto.ImageUrl,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                CreatedDate = DateTime.UtcNow,
                CreatedOn = DateTime.UtcNow,
                ModifiedDate = DateTime.UtcNow,
                CreatedBy = contentDto.CreatedBy,
                ModifiedBy = contentDto.ModifiedBy,
                Title1 = contentDto.Title1,
                Title2 = contentDto.Title2,
                Description = contentDto.Description,
                Type = contentDto.Type,
                Title3 = contentDto.Title3,
                URLButtonName = contentDto.URLButtonName,
                URL = contentDto.URL,
                Section = contentDto.Section,
                IsActive = contentDto.IsActive
            };

            this.context.Articles.Add(article);
            await this.context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "Article created successfully", Result = article });

        }


       
        [HttpPut("articles/{id}")]
        public async Task<ActionResult<ApiResponse>> UpdateArticle(int id, [FromBody] ContentDto contentDto)
        {
            var article = await this.context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound("Atricle not found");
            }

            article.Title = contentDto.Title ?? article.Title;
            article.Content = contentDto.Body ?? article.Content;
            article.Image = contentDto.ImageUrl ?? article.Image;
            article.UpdatedAt = DateTime.UtcNow;
            article.Title1 = contentDto.Title1 ?? article.Title1;
            article.Title2 = contentDto.Title2 ?? article.Title2;
            article.Title3 = contentDto.Title3 ?? article.Title3;
            article.CreatedAt = DateTime.UtcNow;
            article.Section = contentDto.Section ?? article.Section;
            article.ModifiedDate = DateTime.UtcNow;
            article.CreatedDate = DateTime.UtcNow;
            article.Description = contentDto.Description ?? article.Description;
            article.CreatedBy = contentDto.CreatedBy ?? article.CreatedBy;
            article.ModifiedBy = contentDto.ModifiedBy ?? article.ModifiedBy;
            article.URLButtonName = contentDto.URLButtonName ?? article.URLButtonName;
               article.URL = contentDto.URL ?? article.URL;
                article.Section = contentDto.Section ?? article.Section;
                article.IsActive = contentDto.IsActive ?? article.IsActive;
            article.Type = contentDto.Type ?? article.Type;
            await this.context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "Article updated successfully", Result = article });

        }


            [HttpDelete("articles/{id}")]
        public async Task<ActionResult<ApiResponse>> DeleteArticle(int id)
        {
            var article = await this.context.Articles.FindAsync(id);
            if (article == null)
            {
                return NotFound("Article not found");
            }

            this.context.Articles.Remove(article);
            await this.context.SaveChangesAsync();

            return Ok(new ApiResponse { Message = "Article deleted successfully", Result = article });
        }

        [HttpGet("users/search")]
        public async Task<ActionResult<ApiResponse>> GetUsersWithSearch(
            [FromQuery] string? username,
            [FromQuery] string? email,
            [FromQuery] string? mobile)
            {
                var query = this.context.Users.AsQueryable();

                if (!string.IsNullOrEmpty(username))
                {
                    query = query.Where(u => u.Username.Equals(username));
                }

                if (!string.IsNullOrEmpty(email))
                {
                    query = query.Where(u => u.Email.Equals(email));
                }

                if (!string.IsNullOrEmpty(mobile))
                {
                    query = query.Where(u => u.Mobile.Equals(mobile));
                }

                var users = await query.ToListAsync();

                if (users.Count == 0)
                {
                    return NotFound(new ApiResponse { Message = "User not found", Result = null });
                }

                return Ok(new ApiResponse { Message = "Users", Result = users });
        }




    }
}
