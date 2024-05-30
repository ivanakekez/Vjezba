namespace Vjezba.Models.Dbo
{
    public class TodoList
    {
        public int Id { get; set; } 
        public string Title { get; set; }   

        public ApplicationUser? ApplicationUser { get; set; }
        public string? ApplicationUserId { get; set; }  

        

    }
}
