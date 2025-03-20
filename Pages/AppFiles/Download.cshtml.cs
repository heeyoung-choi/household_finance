using FinanceManagement.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using FinanceManagement.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading.Tasks;

public class DownloadModel : PageModel
{
    private readonly ApplicationDbContext _context;

    public DownloadModel(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> OnGetAsync(int id)
    {
        var file = await _context.AppFile.FindAsync(id);
        if (file == null)
        {
            return NotFound();
        }
        System.Diagnostics.Debug.WriteLine(file.Id);
        return File(file.Content, "application/octet-stream", $"file_{file.Id}.bin");
    }
}