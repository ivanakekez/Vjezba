using Microsoft.AspNetCore.Identity;

namespace Vjezba.Models.Dbo
{
    public class ApplicationUser:IdentityUser
    {
        public string? FirstName { get; set; }  
        public string? LastName { get; set; }   
                
        public ICollection<TodoList>? TodoLists { get; set; }    
        

    }
}
