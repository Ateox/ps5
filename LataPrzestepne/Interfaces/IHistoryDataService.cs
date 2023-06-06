using LataPrzestepne.Models;
using System;

namespace LataPrzestepne.Interfaces
{
    public interface IHistoryDataService
    {
        //public IQueryable<HistoryData> GetActivePeople();
        public List<HistoryData> HistoryList();
        public void AddHistoryData(HistoryData data);
    }
}

