using SqliteMAUI_MVVM.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace SqliteMAUI_MVVM.Service
{
    public interface ICoffeeService
    {
        Task add(Coffee coffee);
        Task<IEnumerable<Coffee>> all();
        Task<Coffee> get(long id);
        Task remove(long id);
    }
}
