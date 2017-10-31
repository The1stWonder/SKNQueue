using System;
using SQLite;

namespace MasterQ
{
    public class SessionTable
    {
        [PrimaryKey]
        public string ID { get; set; }
        public string JSON_DATA { get; set; }
    }
}
