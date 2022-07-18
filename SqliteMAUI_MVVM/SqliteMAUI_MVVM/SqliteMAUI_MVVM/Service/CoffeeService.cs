using SQLite;
using SqliteMAUI_MVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SqliteMAUI_MVVM.Service
{
    public class CoffeeService : ICoffeeService
    {
        static SQLiteAsyncConnection db;
        static async Task Init() 
        {
            if (db != null)
                return;
            var databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Personal), "MyData.db");
            db = new SQLiteAsyncConnection(databasePath);
            await db.CreateTableAsync<Coffee>();
        }

        public async Task add(Coffee coffee)
        {
            await Init();
            var id = await db.InsertAsync(coffee);

        }

        public async Task remove(long id) 
        {
            await Init();
            await db.DeleteAsync<Coffee>(id);
        }

        public async Task<IEnumerable<Coffee>> all() 
        {
            await Init();
            return await db.Table<Coffee>().ToListAsync();
        }

        public async Task<Coffee> get(long id) 
        {
            await Init();
            return await db.Table<Coffee>().Where(x=>x.Id==id).FirstOrDefaultAsync();
        }
    }
}
