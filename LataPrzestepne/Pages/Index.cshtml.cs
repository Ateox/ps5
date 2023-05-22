using LataPrzestepne.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System;
using LataPrzestepne.Data;
using System.Security.Claims;
using System.Collections;
using System.Drawing.Printing;
using LataPrzestepne.Interfaces;
using LataPrzestepne.Services;

namespace LataPrzestepne.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public HistoryData HistoryData { get; set; }

        private readonly ILogger<IndexModel> _logger;

        private readonly IHistoryDataService _historyDataService;
        public IQueryable<HistoryData> Records { get; set; }
        public IList<HistoryData> historyDataList { get; set; }

        private readonly DataContext _context;
        public IndexModel(ILogger<IndexModel> logger, DataContext context, IHistoryDataService historyDataService)
        {
            _logger = logger;
            _historyDataService = historyDataService;
            _context = context;
        }

        public void OnGet()
        {
            var historyDataList = _context.HistoryData.ToList();
            Records = _historyDataService.GetActivePeople();
        }
        public IActionResult OnPost() {
            if(HistoryData.Year < 1899 || HistoryData.Year > 2024) { return Page(); }
            historyDataList = _context.HistoryData.ToList();
            HistoryData.UserId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            HistoryData.Time = DateTime.Now;
            if(HistoryData.Name == null)
            {
                if(HistoryData.UserId != null)
                {
                    HistoryData.Name = User.FindFirstValue(ClaimTypes.NameIdentifier);
                }
                else
                {
                    HistoryData.Name = "random user";
                    HistoryData.UserId = "null";
                }
            }
            else if(HistoryData.UserId == null)
            {
                HistoryData.UserId = "null";
            }
            if(HistoryData.Year % 4 == 0)
            {
                HistoryData.Result = "To byl rok przestepny";
            }
            else
            {
                HistoryData.Result = "To nie byl rok przestepny";
            }
            _context.HistoryData.Add(HistoryData);
            _context.SaveChanges();
            return Page();
        
        }
    }
}