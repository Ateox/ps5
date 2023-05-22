using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Security.Claims;
using LataPrzestepne.Data;
using LataPrzestepne.Models;

namespace LataPrzestepne.Pages
{
    public class HistoryPageModel : PageModel
    {
        [BindProperty(SupportsGet = true)]
        public string Search { get; set; }

        [BindProperty]
        public ID ID { get; set; }

        public HistoryData HistoryData { get; set; }
        public HistoryList<HistoryData> HistoryPages { get; set; }
        private readonly DataContext _context;


        public HistoryPageModel(DataContext context)
        {
            _context = context;
        }

        public void OnGet(int pageIndex = 1)
        {

            var query = _context.HistoryData.AsQueryable();

            if (!string.IsNullOrEmpty(Search))
            {
                query = query.Where(d => d.Name.Contains(Search) || d.Year.ToString().Contains(Search));
            }
            query = query.OrderByDescending(x => x.Time);
            HistoryPages = HistoryList<HistoryData>.Create(query, pageIndex, 20);
        }

        public IActionResult OnPost(int remid, int pageIndex = 1)
        {
            System.Diagnostics.Debug.WriteLine("ERROR" + remid);
            var query = _context.HistoryData.AsQueryable();
            var remove = query.Where(d => d.Id == remid).FirstOrDefault();
            _context.HistoryData.Remove(remove);
            _context.SaveChanges();
            query = _context.HistoryData.AsQueryable();
            query = query.OrderByDescending(x => x.Time);
            HistoryPages = HistoryList<HistoryData>.Create(query, pageIndex, 20);
            return Page();
        }
    }
}