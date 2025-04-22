using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinanceManagement.Data;
using FinanceManagement.Models;
using Microsoft.AspNetCore.Identity;

namespace FinanceManagement.Areas.AdminPanel.Pages
{
    public class UserDetailModel : PageModel
    {
        private readonly UserManager<ApplicationUser> _userManager;


        public UserDetailModel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        public ApplicationUser User { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string? id)
        {
            User = await _userManager.FindByIdAsync(id);
            if (User == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
