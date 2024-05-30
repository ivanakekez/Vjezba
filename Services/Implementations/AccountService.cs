using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Net.NetworkInformation;
using System.Security.Claims;
using Vjezba.Data;
using Vjezba.Models.Dbo;
using Vjezba.Models.ViewModel;
using Vjezba.Services.Interfaces;
using System.Threading.Tasks;


namespace Vjezba.Services.Implementations;

public class AccountService : IAccountService
{
    private UserManager<ApplicationUser> userManager;
    private SignInManager<ApplicationUser> signInManager;
    private ApplicationDbContext db;
    private IMapper mapper;

    public AccountService(UserManager<ApplicationUser> userManager,
        SignInManager<ApplicationUser> signInManager, ApplicationDbContext db, IMapper mapper)
    {
        this.userManager = userManager;
        this.signInManager = signInManager;
        this.db = db;
        this.mapper = mapper;
    }


    public async Task<ApplicationUserViewModel> GetUserProfile(ClaimsPrincipal user)
    {

        var dbo = await db.Users
            .Include(y => y.TodoLists)
            .ThenInclude(y => y.Zadataks)
            .FirstOrDefaultAsync(y => y.Id == userManager.GetUserId(user));

        return mapper.Map<ApplicationUserViewModel>(dbo);

    }

    public async Task AddToDoList(TodoList dbo, ClaimsPrincipal user)
    {

        dbo.ApplicationUserId = userManager.GetUserId(user);
        db.TodoLists.Add(dbo);
        await db.SaveChangesAsync();


    }

    public async Task<List<TodoList>> GetTodoList(ClaimsPrincipal user)
    {
        var userId = userManager.GetUserId(user);
        var response =db.TodoLists.Where(y=>y.ApplicationUserId == userId).ToList();
        return response;
    
    
    }

}
