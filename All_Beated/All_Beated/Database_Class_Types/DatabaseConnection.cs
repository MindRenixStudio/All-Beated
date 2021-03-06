﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;
using All_Beated.Database_Class_Types;
using System.IO;

namespace All_Beated.Database_Class_Types
{
    class DatabaseConnection
    {
        private SQLiteAsyncConnection databaseConn;

        public DatabaseConnection(string databasePath)
        {
            databaseConn = new SQLiteAsyncConnection(databasePath);
            databaseConn.CreateTableAsync<GameWriteType>().Wait();
        }

        public Task<int> SaveGame(GameWriteType item)
        {
            if (item.ID != 0)
            {
                return databaseConn.UpdateAsync(item);
            }
            else
            {
                return databaseConn.InsertAsync(item);
            }
        }

        public Task<List<GameWriteType>> GetGamesList()
        {
            return databaseConn.QueryAsync<GameWriteType>("SELECT * FROM GameWriteType ORDER BY ID ASC");
        }

        public Task<List<GameWriteType>> GetGameDetail(int index)
        {
            return databaseConn.QueryAsync<GameWriteType>("SELECT * FROM GameWriteType WHERE ID =" + index);
        }

    }
}
