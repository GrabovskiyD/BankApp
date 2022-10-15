using SQLite;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.WebRequestMethods;

namespace BankApp.ViewModel.Helpers
{
    public static class DatabaseHelper
    {
        private static readonly string dbPath = Path.Combine(Environment.CurrentDirectory, "Clients.db3");

        public static bool Insert<T>(T item) where T : new()
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<T>();
                int rows = conn.Insert(item);
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public static bool Update<T>(T item) where T : new()
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<T>();
                int rows = conn.Update(item);
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public static bool Delete<T>(T item) where T : new()
        {
            bool result = false;
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<T>();
                int rows = conn.Delete(item);
                if (rows > 0)
                {
                    result = true;
                }
            }
            return result;
        }
        public static List<T> Read<T>() where T : new()
        {
            List<T> items = new List<T>();
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<T>();
                items = conn.Table<T>().ToList();
            }
            return items;
        }
    }
}
