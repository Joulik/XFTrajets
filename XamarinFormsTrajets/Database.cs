using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace XamarinFormsTrajets
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Trajet>();
        }

        public Task<List<Trajet>> GetTrajetsAsync()
        {
            return _database.Table<Trajet>().ToListAsync();
        }

        public Task<int> SaveTrajetAsync(Trajet trajet)
        {
            return _database.InsertAsync(trajet);
        }
     }
}
