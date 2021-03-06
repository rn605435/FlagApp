﻿using SQLite.Net;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FlagApp.Model
{
    public class DBHelper
    {
        string path;
        SQLiteConnection conn;

        public DBHelper()
        {
            path = Path.Combine(Windows.Storage.ApplicationData.Current.LocalFolder.Path, "Databases", "FlagAppCopie.db");
            conn = new SQLite.Net.SQLiteConnection(new SQLite.Net.Platform.WinRT.SQLitePlatformWinRT(), path);
        }

        public List<Question> getEasyMode()
        {
            var data = conn.Table<Question>().Take(30);
            return data.ToList();
        }
        public List<Question> getMedium()
        {
            var data = conn.Table<Question>().Take(50);
            return data.ToList();
        }
        public List<Question> getExtremeMode()
        {
            var data = conn.Table<Question>().Take(100);
            return data.ToList();
        }
        public List<Question> getCustomMode()
        {
            int q = Convert.ToInt32(MainPage.customQ);
            var data = conn.Table<Question>().Take(q);
            return data.ToList();
        }

        public int insertScore(int score, string mode)
        {
            try
            {
                return conn.Insert(new Ranking() { Score = score, mode = mode });
            }
            catch (SQLiteException ex)
            {
                Debug.WriteLine(ex.Message);
                return -1;
            }
           
        }

        public List<Ranking> getRanking()
        {
            return conn.Table<Ranking>().ToList();
        }
    }
}
