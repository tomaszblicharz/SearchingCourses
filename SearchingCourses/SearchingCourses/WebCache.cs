using System;
using System.Data;
using System.Data.SQLite;
using System.Net;

namespace SearchingCurses {
    class WebCache {
        static SQLiteConnection connection;

        private WebCache() { }

        public static string GetOrDownload(string url) {
            if (connection == null)
                Init();
            if (!IsInCache(url))
                SaveInCache(url, DownloadHTML(url));
            return GetFromCache(url);
        }

        static void Init() {
            OpenOrCreateSqlDb();
            if (!TableExists())
                CreateTable();
        }

        static string GetFromCache(string url) {
            var query = new SQLiteCommand($"select data from cache where url='{url}' limit 1", connection);
            var reader = query.ExecuteReader();
            reader.Read();
            return reader["data"] as string;
        }

        static bool IsInCache(string url) {
            var query = $"select * from cache where url='{url}' limit 1";
            var command = new SQLiteCommand(query, connection);
            return command.ExecuteScalar() != null;
        }

        static string DownloadHTML(string url) {
            Console.WriteLine("Downloading: " + url);
            var browser = new WebClient();
            return browser.DownloadString(url);
        }

        static bool TableExists() {
            var query = "SELECT name FROM sqlite_master WHERE type='table' AND name='cache'";
            var command = new SQLiteCommand(query, connection);
            var ret = command.ExecuteScalar();
            return ret != null;
        }

        static void OpenOrCreateSqlDb() {
            connection = new SQLiteConnection("Data Source=WebCacheDb.sqlite;");
            connection.Open();
        }

        static void CreateTable() {
            var query = "create table cache (url text, data text)";
            var command = new SQLiteCommand(query, connection);
            command.ExecuteNonQuery();
        }

        static void SaveInCache(string url, string data) {
            var sql = new SQLiteCommand(
                "INSERT INTO cache (url, data) VALUES (?, ?)", connection);
            var parameterType = DbType.String;
            sql.Parameters.Add(new SQLiteParameter(DbType.String, "param1") {Value = url});
            sql.Parameters.Add(new SQLiteParameter(DbType.String, "param2") {Value = data});
            sql.ExecuteNonQuery();
        }
    }
}