using System;
using System.Collections.Generic;
using System.Text;

namespace SqliteMAUI_MVVM.Service
{
    public interface IToast
    {
        void MakeToast(string message);
    }
}
