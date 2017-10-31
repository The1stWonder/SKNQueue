using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using SQLite;

namespace MasterQ
{
    public class MasterQDatabaseDAO
    {
        readonly SQLiteConnection database;

        public MasterQDatabaseDAO(string dbPath)
        {
            database = new SQLiteConnection(dbPath);
            database.CreateTable<SessionTable>();
        }

        public List<SessionTable> GetItems()
        {
            return database.Query<SessionTable>("SELECT * FROM [SessionTable]");
        }

        public SessionTable GetItem(String id)
        {
            return database.Table<SessionTable>().Where(i => i.ID.Equals(id)).FirstOrDefault();
        }

        public int SaveItem(SessionTable item)
        {
            if (GetItem(item.ID) != null)
            {
                return database.Update(item);
            }
            else
            {
                return database.Insert(item);
            }
        }

        public int DeleteItem(String ID)
        {
            return database.Delete(ID);
        }
    }
}

