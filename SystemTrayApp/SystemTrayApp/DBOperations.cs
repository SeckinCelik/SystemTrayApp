using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SystemTrayApp
{
    class DBOperations
    {
        string dbName = "myDB.sqlite";
        SQLiteConnection conn;
        public DBOperations()
        {
            try
            {
                if (!File.Exists(dbName))
                    SQLiteConnection.CreateFile(dbName);

                if (conn == null)
                {
                    conn = new SQLiteConnection("Data Source=" + dbName + ";Version=3;");
                }
                if (conn.State != ConnectionState.Open)
                {
                    conn.Open();
                }

                string sql = "create table IF NOT EXISTS KeyWord (id INTEGER PRIMARY KEY, DateOfRecord datetime, ClipBoardText Text,RemainderText Text)";

                SQLiteCommand command = new SQLiteCommand(sql, conn);

                command.ExecuteNonQuery();
            }
            catch (Exception ec)
            {
            }
        }

        public async void insertRecord(SystemTrayApp.SharedItems.CopyItems cls)
        {
            try
            {

                string sql2 = "insert into KeyWord (id,DateOfRecord, ClipBoardText,RemainderText) values (NULL,datetime(CURRENT_TIMESTAMP, 'localtime'), '" + cls.Text + "','" + cls.Keyword + "')";

                SQLiteCommand command1 = new SQLiteCommand(sql2, conn);


                command1.ExecuteNonQuery();

                //return true;
            }
            catch (Exception ex)
            {
                //return false;
            }
        }

        public List<SystemTrayApp.SharedItems.CopyItems> getRecords()
        {
            try
            {
                List<SystemTrayApp.SharedItems.CopyItems> clsList = new List<SystemTrayApp.SharedItems.CopyItems>();

                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = "select * from KeyWord";
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SystemTrayApp.SharedItems.CopyItems cls = new SystemTrayApp.SharedItems.CopyItems();
                    cls.Date = Convert.ToDateTime(dr["DateOfRecord"]);
                    cls.Text = (string)dr["ClipBoardText"];
                    cls.Keyword = (string)dr["RemainderText"];
                    cls.Id = Convert.ToInt32(dr["id"]);
                    //yield return cls;
                    clsList.Add(cls);
                    //Thread.Sleep(1000);
                }
                return clsList;
            }
            catch (Exception ex)
            {
                return null;
            }
        }


        public void UpdateRecord(SystemTrayApp.SharedItems.CopyItems cls)
        {
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("Update KeyWord set DateOfRecord= datetime(CURRENT_TIMESTAMP, 'localtime'),RemainderText= {0}where id ={1}", cls.Keyword, cls.Id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }

        public SystemTrayApp.SharedItems.CopyItems GetRecordById(int id)
        {
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("select * from KeyWord where id ={0}", id);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SystemTrayApp.SharedItems.CopyItems cls = new SystemTrayApp.SharedItems.CopyItems();
                    cls.Date = Convert.ToDateTime(dr["DateOfRecord"]);
                    cls.Text = (string)dr["ClipBoardText"];
                    cls.Keyword = (string)dr["RemainderText"];
                    return cls;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public SystemTrayApp.SharedItems.CopyItems GetRecordByText(string text)
        {
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandText = string.Format("select * from KeyWord where ClipBoardText ='{0}'", text);
                SQLiteDataReader dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    SystemTrayApp.SharedItems.CopyItems cls = new SystemTrayApp.SharedItems.CopyItems();
                    cls.Date = Convert.ToDateTime(dr["DateOfRecord"]);
                    cls.Text = (string)dr["ClipBoardText"];
                    cls.Keyword = (string)dr["RemainderText"];
                    return cls;
                }
                return null;
            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public void DeleteById(int id)
        {
            try
            {
                SQLiteCommand cmd = conn.CreateCommand();
                cmd.CommandTimeout = int.MaxValue;
                cmd.CommandText = string.Format("Delete from KeyWord where id ={0}", id);
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {

            }
        }
        public void DeleteByIdList(List<string> idList)
        {
            try
            {

                foreach (var item in idList)
                {
                    Thread thr = new Thread(new ThreadStart(delegate
                        {
                            SQLiteCommand cmd = conn.CreateCommand();
                            cmd.CommandText = string.Format("Delete from KeyWord where id ={0}", item);
                            cmd.ExecuteNonQuery();
                        }));
                    thr.Start();
                }

            }
            catch (Exception ex)
            {
            }
        }
    }

}
