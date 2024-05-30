using System.Security.Claims;
using Vjezba.Models.Dbo;
using Vjezba.Models.ViewModel;

namespace Vjezba.Services.Interfaces
{
    public interface IAccountService
    {
        Task AddToDoList(TodoList dbo, ClaimsPrincipal user);
        Task<ApplicationUserViewModel> GetUserProfile(ClaimsPrincipal user);

        Task<List<TodoList>> GetTodoList(ClaimsPrincipal user);
    }
}