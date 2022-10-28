using SQLite;
using System;
using System.Collections.Generic;
using System.IO;

namespace BankApp.ViewModel.Helpers
{
    /// <summary>
    /// Вспомогательный класс для работы с БД /
    /// Auxiliary class for working with the database
    /// </summary>
    public static class DatabaseHelper
    {
        private static readonly string dbPath = Path.Combine(Environment.CurrentDirectory, "Clients.db3");
        /// <summary>
        /// Добавление объекта в БД /
        /// Adding an item to the DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Insert<T>(T item)
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
        /// <summary>
        /// Обновление объекта в БД /
        /// Updating an item in the DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Update<T>(T item)
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
        /// <summary>
        /// Удаление объекта из БД /
        /// Deleteing an item from the DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="item"></param>
        /// <returns></returns>
        public static bool Delete<T>(T item)
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
        /// <summary>
        /// Получение списка всех объектов из БД /
        /// Getting a list of all items from the DB
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static List<T> Read<T>() where T : new()
        {
            List<T> items;
            using (SQLiteConnection conn = new SQLiteConnection(dbPath))
            {
                conn.CreateTable<T>();
                items = conn.Table<T>().ToList();
            }
            return items;
        }
    }
}
