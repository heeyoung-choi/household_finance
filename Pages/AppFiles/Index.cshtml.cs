using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using FinanceManagement.Data;
using FinanceManagement.Models;
using Microsoft.AspNetCore.Authorization;

namespace FinanceManagement.Pages.AppFiles
{
    [Authorize(Roles = "admin")]
    public class IndexModel : PageModel
    {
        private readonly FinanceManagement.Data.ApplicationDbContext _context;

        public IndexModel(FinanceManagement.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<AppFile> AppFile { get;set; } = default!;

        public async Task OnGetAsync()
        {
            AppFile = await _context.AppFile.ToListAsync();
        }
        public async Task<IActionResult> OnGetDownload(int id)
        {
            var fileRecord = await _context.AppFile.FindAsync(id);
            if (fileRecord == null || fileRecord.Content == null)
            {
                return NotFound("File not found.");
            }

            return File(fileRecord.Content, "application/octet-stream", $"file_{fileRecord.Id}.bin");
        }

    }
}
