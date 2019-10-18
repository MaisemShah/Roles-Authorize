using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test1.Data;

namespace Test1.Pages.Foods
{
    public class DetailsModel : PageModel
    {
        private readonly Test1.Data.ApplicationDbContext _context;

        public DetailsModel(Test1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

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
            return Page();
        }
    }
}
