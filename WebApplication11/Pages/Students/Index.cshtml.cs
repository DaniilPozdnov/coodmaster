using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using WebApplication11.Data;
using WebApplication11.Data.Identity;

namespace WebApplication11.Pages.Students
{
    [Authorize(Roles = "Сompany")]
    public class IndexModel : PageModel
    {
        private readonly WebApplication11.Data.ApplicationDbContext _context;

        public IndexModel(WebApplication11.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Student> Student { get;set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Students != null)
            {
                Student = await _context.Students.ToListAsync();
            }
        }
    }
}

