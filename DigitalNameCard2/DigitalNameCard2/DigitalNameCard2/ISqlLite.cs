using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;

namespace DigitalNameCard2
{
    public interface ISqlLite
    {
        SQLiteConnection GetConnection();
    }
}
