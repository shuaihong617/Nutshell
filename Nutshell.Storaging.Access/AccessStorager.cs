using System.Data;
using System.Data.OleDb;

namespace Nutshell.Storaging.Access
{
        public class AccessStorager
        {
                #region

                private OleDbConnection _connection;

                #endregion 属性

                public void Open(string filePath)
                {
                        _connection = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.4.0;Data Source=F:\\fruit.mdb"); //Jet OLEDB:Database Password=
                        _connection.Open();

                        //OleDbCommand cmd = conn.CreateCommand();

                        //cmd.CommandText = "select * from fruit";
                        //conn.Open();
                        //OleDbDataReader dr = cmd.ExecuteReader();
                        //DataTable dt = new DataTable();
                        //if (dr.HasRows)
                        //{
                        //        for (int i = 0; i < dr.FieldCount; i++)
                        //        {
                        //                dt.Columns.Add(dr.GetName(i));
                        //        }
                        //        dt.Rows.Clear();
                        //}
                        //while (dr.Read())
                        //{
                        //        DataRow row = dt.NewRow();
                        //        for (int i = 0; i < dr.FieldCount; i++)
                        //        {
                        //                row[i] = dr[i];
                        //        }
                        //        dt.Rows.Add(row);
                        //}
                        //cmd.Dispose();
                        //conn.Close();
                        //dataGridView1.DataSource = dt;

                       
                }

                public void Close()
                {
                        _connection.Close();
                }
        }
}
