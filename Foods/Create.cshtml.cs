using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Test1.Data;

namespace Test1.Pages.Foods
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
        ViewData["DID"] = new SelectList(_context.Set<Drink>(), "DID", "DID");
            return Page();
        }

        [BindProperty]
        public Food Food { get; set; }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Food.Add(Food);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}