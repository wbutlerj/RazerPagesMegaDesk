using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RazerPagesMegaDesk.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {

        }
    }

   /* * public class IndexModel : PageModel
    {
        private readonly RazerPagesMegaDeskContext _context;

        public IndexModel(RazerPagesMegaDeskContext context)
        {
            _context = context;
        }

        public IList<DeskQuote> DeskQuote { get; set; }

        public async Task OnGetAsync()
        {
            DeskQuote = await _context.DeskQuote
                .Include(d => d.Desk)
                .Include(d => d.Desk.SurfaceMaterial)
                .ToListAsync();


        }
    }
*/


}
