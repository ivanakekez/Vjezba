namespace Vjezba.Models.Dbo
{
    public class Zadatak
    {

        public int Id { get; set; }
        
        public bool Status { get; set; }    

        public TodoList? TodoList { get; set; } 

        public int? TodoListId { get; set; }  
    }
}
