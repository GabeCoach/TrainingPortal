using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MGCTrainingPortalAPI.Interfaces
{
    public interface IRepository<T> where T : class
    {
        IQueryable<T> SelectAllFromDB();
        Task<T> SelectById(int Id);
        Task<T> SaveToDB(T obj);
        Task<List<T>> SaveToDB(List<T> obj);
        Task<T> UpdateToDB(T obj, int Id);
        Task<T> DeleteFromDB(int Id);
    }
}
