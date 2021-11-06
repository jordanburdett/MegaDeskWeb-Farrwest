using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using MegaDeskWeb_Farrwest.Data;
using MegaDeskWeb_Farrwest.Model;

namespace MegaDeskWeb_Farrwest.Pages.Quotes
{
    public class DetailsModel : PageModel
    {
        private readonly MegaDeskWeb_Farrwest.Data.MegaDeskWeb_FarrwestContext _context;

        public DetailsModel(MegaDeskWeb_Farrwest.Data.MegaDeskWeb_FarrwestContext context)
        {
            _context = context;
        }

        public Quote Quote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Quote = await _context.Quote.FirstOrDefaultAsync(m => m.ID == id);

            if (Quote == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
