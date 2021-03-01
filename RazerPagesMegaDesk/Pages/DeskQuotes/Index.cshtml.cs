using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using RazerPagesMegaDesk.Data;
using RazerPagesMegaDesk.Model;

namespace RazerPagesMegaDesk.Pages.DeskQuotes
{
    public class IndexModel : PageModel
    {
        private readonly RazerPagesMegaDesk.Data.RazerPagesMegaDeskContext _context;

        public IndexModel(RazerPagesMegaDesk.Data.RazerPagesMegaDeskContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get;set; }

        public SelectList Dates { get; set; }

        public SelectList Names { get; set; }

        [BindProperty(SupportsGet = true)]
        public string DeskQuoteName { get; set; }

        public DateTime DeskQuoteDate { get; set; }

        [BindProperty(SupportsGet = true)]
        public string sortBy { get; set; }

        [BindProperty(SupportsGet = true)]
        public string SearchString { get; set; }

        public async Task OnGetAsync()
        {


            IQueryable<string> nameQuery = from m in _context.DeskQuote
                                           orderby m.CustomerName
                                           select m.CustomerName;
            IQueryable<DateTime> dateQuery = from m in _context.DeskQuote
                                             orderby m.QuoteDate
                                             select m.QuoteDate;

            var deskQuotes = from m in _context.DeskQuote
                             select m;

            if (!string.IsNullOrEmpty(SearchString))
            {
                deskQuotes = deskQuotes.Where(s => s.CustomerName.Contains(SearchString));
            }

            if (!string.IsNullOrEmpty(sortBy)) {

                switch (sortBy)
                {
                    case "cusName":
                        deskQuotes = deskQuotes.OrderBy(s => s.CustomerName);
                        break;
                    case "date":
                        deskQuotes = deskQuotes.OrderBy(s => s.QuoteDate);
                        break;
                }

           

            }



                /*  if (!string.IsNullOrEmpty(DeskQuoteName))
                  {
                      deskQuotes = deskQuotes.Where(x => x.CustomerName == DeskQuoteName);
                  }*/
                /* if (!String.IsNullOrEmpty(DeskQuoteDate))
                 {
                     deskQuotes = deskQuotes.Where(x => x.QuoteDate == DeskQuoteDate);
                 }*/

                /*      Names = new SelectList(await nameQuery.Distinct().ToListAsync());

                      Dates = new SelectList(await dateQuery.Distinct().ToListAsync());*/

                /* DeskQuote = await deskQuotes.ToListAsync();*/

                DeskQuote = await deskQuotes
                      .Include(d => d.Shipping)
                      .Include(d => d.Desk)
                      .Include(d => d.Desk.SurfaceMaterial)
                      .ToListAsync();
            } 
    }
}
