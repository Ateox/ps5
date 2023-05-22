using System;
using LataPrzestepne.Models;
using LataPrzestepne.Interfaces;
using LataPrzestepne.Data;

namespace LataPrzestepne.Services

{
    public class HistoryDataService: IHistoryDataService
    {
        private readonly DataContext _context;
        public HistoryDataService(DataContext context)
        {
            _context = context;
        }
        public IQueryable<HistoryData> GetActivePeople()
        {
            return
            _context.HistoryData.Where(p => p.IsActive);
        }
    }
}
