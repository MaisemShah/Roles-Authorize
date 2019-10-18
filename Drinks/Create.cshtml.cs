using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test1.Data;

namespace Test1.Pages.Drinks
{
    public class CreateModel : PageModel
    {
        private readonly Test1.Data.ApplicationDbContext _context;

        public CreateModel(Test1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Drink Drink { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Drink.Add(Drink);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}