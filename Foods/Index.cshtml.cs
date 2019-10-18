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
    public class IndexModel : PageModel
    {
        private readonly Test1.Data.ApplicationDbContext _context;

        public IndexModel(Test1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Food> Food { get;set; }

        public async Task OnGetAsync()
        {
            Food = await _context.Food
                .Include(f => f.Drinks).ToListAsync();
        }
    }
}
