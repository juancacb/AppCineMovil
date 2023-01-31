using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace AppCineMovil
{
    public interface Database
    {
        SQLiteAsyncConnection GetConnection();
    }
}
