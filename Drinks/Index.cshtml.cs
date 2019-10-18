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
    public class IndexModel : PageModel
    {
        private readonly Test1.Data.ApplicationDbContext _context;

        public IndexModel(Test1.Data.ApplicationDbContext context)
        {
            _context = context;
        }

        public IList<Drink> Drink { get;set; }

        public async Task OnGetAsync()
        {
            var drink = from m in _context.Drink select m;
            if (User.IsInRole("captain"))
            {
                
                drink = drink.Where(s => s.Juices.Contains("captain"));
            
            }
            else if (User.IsInRole("hokage"))
            {
                drink = drink.Where(s => s.Juices.Contains("hokage"));
            }
            else if (User.IsInRole("saiyan"))
            {
                drink = drink.Where(s => s.Juices.Contains("saiyan"));
            }
            else
            {
                drink = drink.Where(s => s.Juices.Contains(""));
            }
                Drink = await drink.ToListAsync();
        }
    }
}
