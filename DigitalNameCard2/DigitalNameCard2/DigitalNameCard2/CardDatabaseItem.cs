using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using SQLitePCL;

namespace DigitalNameCard2
{
    public class CardDatabaseItem
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public String jsonContent{ get;set;}
    }
}
