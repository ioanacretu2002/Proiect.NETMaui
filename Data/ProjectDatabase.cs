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
            _database.CreateTableAsync<NailArtistModel>().Wait();
            //_database.CreateTableAsync<Salon>().Wait();
        }

        //Service
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

        //NailArtist
        public Task<List<NailArtistModel>> GetNailArtistModelsAsync()
        {
            return _database.Table<NailArtistModel>().ToListAsync();
        }

        public Task<NailArtistModel> GetNailArtistModelAsync(int id)
        {
            return _database.Table<NailArtistModel>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveNailArtistModelAsync(NailArtistModel nailArtistModel)
        {
            if (nailArtistModel.ID != 0)
            {
                return _database.UpdateAsync(nailArtistModel);
            }
            else
            {
                return _database.InsertAsync(nailArtistModel);
            }
        }

        public Task<int> DeleteNailArtistModelAsync(NailArtistModel nailArtistModel)
        {
            return _database.DeleteAsync(nailArtistModel);
        }


    }
}
