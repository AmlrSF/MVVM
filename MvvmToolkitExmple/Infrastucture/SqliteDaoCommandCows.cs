using MvvmToolkitExmple.Entities;
using MvvmToolkitExmple.Services;
using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace MvvmToolkitExmple.Infrastucture
{
    public class SqliteDaoCommandCows : IDAOCow<CowInfo>
    {


        private SQLiteAsyncConnection db;

        public SqliteDaoCommandCows()
        {
            db = DaoContext.Database;
            
            // Create the table if it doesn't already exist
            db.CreateTableAsync<CowInfo>().Wait();
        }

        public Task<int> DeleteAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> IDAOCow<CowInfo>.CreateAsync(CowInfo entity)
        {
            return db.InsertAsync(entity);
        }

        Task<List<CowInfo>> IDAOCow<CowInfo>.ReadAllAsync()
        {
            return db.Table<CowInfo>().ToListAsync();
        }

        Task<CowInfo> IDAOCow<CowInfo>.ReadAsync(int id)
        {
            throw new NotImplementedException();
        }

        Task<int> IDAOCow<CowInfo>.UpdateAsync(CowInfo entity)
        {
            throw new NotImplementedException();
        }
    }
}
