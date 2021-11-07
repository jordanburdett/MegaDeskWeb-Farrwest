using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_Farrwest.Data;
using MegaDeskWeb_Farrwest.Model;

namespace MegaDeskWeb_Farrwest.Pages.Quotes
{
    public class IndexModel : PageModel
    {
        private readonly MegaDeskWeb_Farrwest.Data.MegaDeskWeb_FarrwestContext _context;

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }
        public IndexModel(MegaDeskWeb_Farrwest.Data.MegaDeskWeb_FarrwestContext context)
        {
            _context = context;
        }

        public IList<Quote> Quote { get;set; }

        public async Task OnGetAsync()
        {
            var quotes = from m in _context.Quote select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                quotes = quotes.Where(s => s.customerName.Contains(SearchString));
            }


            Quote = await quotes.ToListAsync();
        }
    }
}
