using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test1.Data;

namespace Test1.Pages.Foods
{
    public class EditModel : PageModel
    {
        private readonly Test1.Data.ApplicationDbContext _context;

        public EditModel(Test1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Food Food { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Food = await _context.Food
                .Include(f => f.Drinks).FirstOrDefaultAsync(m => m.FID == id);

            if (Food == null)
            {
                return NotFound();
            }
           ViewData["DID"] = new SelectList(_context.Set<Drink>(), "DID", "DID");
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Food).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FoodExists(Food.FID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool FoodExists(int id)
        {
            return _context.Food.Any(e => e.FID == id);
        }
    }
}
