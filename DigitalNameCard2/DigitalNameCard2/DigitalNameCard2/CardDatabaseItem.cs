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
        public String Nama { get; set; }
        public String Address { get; set; }
        public String Phone { get; set; }
        public String ExtraInfo{ get;set;}
    }
}
