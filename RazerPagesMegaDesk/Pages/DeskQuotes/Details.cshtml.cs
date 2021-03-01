﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using RazerPagesMegaDesk.Data;
using RazerPagesMegaDesk.Model;

namespace RazerPagesMegaDesk.Pages.DeskQuotes
{
    public class DetailsModel : PageModel
    {
        private readonly RazerPagesMegaDesk.Data.RazerPagesMegaDeskContext _context;

        public DetailsModel(RazerPagesMegaDesk.Data.RazerPagesMegaDeskContext context)
        {
            _context = context;
        }

        public DeskQuote DeskQuote { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            DeskQuote = await _context.DeskQuote
               .Include(d => d.Shipping)
                     .Include(d => d.Desk)
                     .Include(d => d.Desk.SurfaceMaterial).FirstOrDefaultAsync(m => m.DeskQuoteId == id);

            if (DeskQuote == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
