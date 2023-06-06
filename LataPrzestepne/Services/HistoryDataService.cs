using System;
using LataPrzestepne.Models;
using LataPrzestepne.Interfaces;
using LataPrzestepne.Data;

namespace LataPrzestepne.Services

{
    public class HistoryDataService: IHistoryDataService
    {
        public List<HistoryData> HistoryList()
        {
            return
            _context.HistoryData.ToList();
        }
        private readonly DataContext _context;
        public HistoryDataService(DataContext context)
        {
            _context = context;
        }
        public void AddHistoryData(HistoryData data)
        {
            _context.HistoryData.Add(data);
            _context.SaveChanges();
        }
        /*public IQueryable<HistoryData> GetActivePeople()
        {
            return
            _context.HistoryData.Where(p => p.IsActive);
        }*/
    }
}
