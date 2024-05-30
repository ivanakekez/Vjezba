using Microsoft.AspNetCore.Identity;

namespace Vjezba.Models.Dbo
{
    public class ApplicationUser:IdentityUser
    {
        public ICollection<TodoList> TodoLists { get; set; }    
        

    }
}
