using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NoobIncTshirt
{

    public class TShirtDatabase
    {
        readonly SQLiteAsyncConnection database;

        public TShirtDatabase(string dbPath)
        {
      
            
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TShirttable>().Wait();
       
        
        
        }

        public Task<List<TShirttable>> GetItemsAsync()
        {
            return database.Table<TShirttable>().ToListAsync();
        }

        public Task<List<TShirttable>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<TShirttable>("SELECT * FROM [TShirtDatabase] WHERE [Done] = 0");
        }

        public Task<TShirttable> GetItemAsync(int id)
        {
            return database.Table<TShirttable>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(TShirttable item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(TShirttable item)
        {
            return database.DeleteAsync(item);
        }
    }
}

