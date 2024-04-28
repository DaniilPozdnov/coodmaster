using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using WebApplication11.Data;
using WebApplication11.Data.Identity;
using WebApplication11.Models;

namespace WebApplication11.Pages.Students
{
    public class CreateModel : PageModel
    {
        private readonly WebApplication11.Data.ApplicationDbContext _context;
        private IMapper _mapper;

        public CreateModel (ApplicationDbContext context,
            IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        //public CreateStudentModel Student { get; set; }
        public StudentModel Student { get; set; }


        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
          if (!ModelState.IsValid)
            {
                return Page();
            }

            var student = _mapper.Map<Student>(Student);

            //_context.Students.Add(Student);
            _context.Students.Add(student);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
