using SQLite;
using SqliteMAUI_MVVM.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace SqliteMAUI_MVVM.Service
{
    public static class CoffeeService
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

        public static async Task add(Coffee coffee)
        {
            await Init();
            var id = await db.InsertAsync(coffee);

        }

        public static async Task remove(int id) 
        {
            await Init();
            await db.DeleteAsync<Coffee>(id);
        }

        public static async Task<IEnumerable<Coffee>> all() 
        {
            await Init();
            return await db.Table<Coffee>().ToListAsync();
        }

        public static async Task get() 
        {
            await Init();
            
        }
    }
}
