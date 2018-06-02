using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Data;
using System.Data.SQLite;

namespace _01复习
{
    public static class SqliteHelper
    {
        private static readonly string conStr = ConfigurationManager.ConnectionStrings["itCastCater"].ConnectionString;

        public static int ExecuteNonQuery(string sql, params SQLiteParameter[] pms)
        {
            using (SQLiteConnection con=new SQLiteConnection(conStr))
            {
                using (SQLiteCommand cmd=new SQLiteCommand(sql, con))
                {
                    if (pms!=null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteNonQuery();
                }
            }
        }

        public static object ExecuteScalar(string sql, params SQLiteParameter[] pms)
        {
            using (SQLiteConnection con = new SQLiteConnection(conStr))
            {
                using (SQLiteCommand cmd = new SQLiteCommand(sql, con))
                {
                    if (pms != null)
                    {
                        cmd.Parameters.AddRange(pms);
                    }
                    con.Open();
                    return cmd.ExecuteScalar();
                }
            }
        }

        public static SQLiteDataReader ExecuteReader(string sql, params SQLiteParameter[] pms)
        {
            SQLiteConnection con = new SQLiteConnection(conStr);
            using (SQLiteCommand cmd=new SQLiteCommand(sql, con))
            {
                if (pms!=null)
                {
                    cmd.Parameters.AddRange(pms);
                }
                try
                {
                    if (con.State == ConnectionState.Closed)
                    {
                        con.Open();
                    }
                    return cmd.ExecuteReader(CommandBehavior.CloseConnection);
                }
                catch
                {
                    con.Close();
                    con.Dispose();
                    throw;
                }
            }
        }

        public static DataTable ExecuteDataTable(string sql, params SQLiteParameter[] pms)
        {
            DataTable dt = new DataTable();
            using (SQLiteDataAdapter adapter=new SQLiteDataAdapter(sql, conStr))
            {
                if (pms!=null)
                {
                    adapter.SelectCommand.Parameters.AddRange(pms);
                }
                adapter.Fill(dt);
            }
            return dt;
        }
    }
}
