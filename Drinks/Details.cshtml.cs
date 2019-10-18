using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test1.Data;

namespace Test1.Pages.Drinks
{
    public class DetailsModel : PageModel
    {
        private readonly Test1.Data.ApplicationDbContext _context;

        public DetailsModel(Test1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public Drink Drink { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Drink = await _context.Drink.FirstOrDefaultAsync(m => m.DID == id);

            if (Drink == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
