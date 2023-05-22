using LataPrzestepne.Models;
using System;

namespace LataPrzestepne.Interfaces
{
    public interface IHistoryDataService
    {
        public IQueryable<HistoryData> GetActivePeople();
    }
}

