namespace ContentManagementSystemWebAPI.Models.DTOs
{
    public class ContentDto
 {
     public string Title { get; set; }
     public string Body { get; set; }
     public string ImageUrl { get; set; }


     public string? Title1 { get; set; }
     public string? Description { get; set; }
     public string? Type { get; set; }
     
     public int? CreatedBy { get; set; }
     public int? ModifiedBy { get; set; }
     public string? Title2 { get; set; }
     public string? Title3 { get; set; }
     public string? URLButtonName { get; set; }
     public string? URL { get; set; }
     public string? Section { get; set; }
     

     public bool? IsActive { get; set; }

 }
}