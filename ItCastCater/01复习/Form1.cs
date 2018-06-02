using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SQLite;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _01复习
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            #region 不使用SqliteHelper
            //List<ManagerInfo> list = new List<ManagerInfo>();
            ////从数据库表ManagerInfo中查询数据

            //string conStr = @"data source= G:\C#\C# Advanced\07 .NET就业班-三层项目+SVN五天\2015-05-13.NET就业班-三层项目+SVN\资料\ItcastCater.db; version=3;";

            //using (SQLiteConnection con=new SQLiteConnection(conStr))
            //{
            //    string sql = "select * from ManagerInfo";

            //    using (SQLiteCommand cmd=new SQLiteCommand(sql, con))
            //    {
            //        con.Open();
            //        SQLiteDataReader reader = cmd.ExecuteReader();
            //        if (reader.HasRows)
            //        {
            //            while (reader.Read())
            //            {
            //                #region 第二种方法
            //                //list.Add(new ManagerInfo() {
            //                //    MId = reader.GetInt32(0),
            //                //    MName=reader.GetString(1),
            //                //    MPwd=reader.GetString(2),
            //                //    MType=reader.GetInt32(3)
            //                //});
            //                #endregion
            //                #region 第三种写法
            //                list.Add(new ManagerInfo()
            //                {
            //                    MId = Convert.ToInt32(reader["mid"]),
            //                    MName = reader["mname"].ToString(),
            //                    MPwd = reader["mpwd"].ToString(),
            //                    MType = Convert.ToInt32(reader["mtype"])
            //                });
            //                #endregion
            //            }
            //        }
            //    }
            //    dataGridView1.DataSource = list; 
            #endregion

            #region 第一种方法
            //using (SQLiteDataAdapter adapter=new SQLiteDataAdapter(sql, conStr))
            //{
            //    DataTable dt = new DataTable();
            //    adapter.Fill(dt);
            //    dataGridView1.DataSource = dt;
            //}
            #endregion

            #region
            dataGridView1.DataSource = SqliteHelper.ExecuteDataTable("select * from ManagerInfo");
            #endregion
        }

        //显示数据到DataGridView中
    
    }
}
