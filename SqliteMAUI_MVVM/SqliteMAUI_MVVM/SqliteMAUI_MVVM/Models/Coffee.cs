using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteMAUI_MVVM.Models
{
    public class Coffee
    {
        [PrimaryKey, AutoIncrement]
        public long Id { get; set; }
        public string Roaster { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }

    }
}
