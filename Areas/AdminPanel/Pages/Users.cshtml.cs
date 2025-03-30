
using FinanceManagement.Data;
using FinanceManagement.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace FinanceManagement.Areas.AdminPanel.Pages
{
    public class UsersModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;
        public UsersModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public List<ApplicationUser> Users { get; set; }
        public async Task OnGetAsync()
        {
            Users = new List<ApplicationUser>(await _userManager.Users.ToListAsync());
        }
    }
}
