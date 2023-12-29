using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProiectMedii.Models;
using SQLite;


namespace ProiectMedii.Data
{
    public class ProjectDatabase
    {
        readonly SQLiteAsyncConnection _database;
        public ProjectDatabase(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<ServiceModel>().Wait();
            //_database.CreateTableAsync<Salon>().Wait();
        }
        public Task<List<ServiceModel>> GetServiceModelsAsync()
        {
            return _database.Table<ServiceModel>().ToListAsync();
        }

        public Task<ServiceModel> GetServiceModelAsync(int id)
        {
            return _database.Table<ServiceModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveServiceModelAsync(ServiceModel serviceModel)
        {
            if (serviceModel.ID != 0)
            {
                return _database.UpdateAsync(serviceModel);
            }
            else
            {
                return _database.InsertAsync(serviceModel);
            }
        }

        public Task<int> DeleteServiceModelAsync(ServiceModel serviceModel)
        {
            return _database.DeleteAsync(serviceModel);
        }

    }
}
