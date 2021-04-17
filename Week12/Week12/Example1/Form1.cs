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

namespace Example1
{
    public partial class Form1 : Form
    {
        public void F1()
        {
            string cs = "Data Source = :memory:";
            string stm = "SELECT SQLITE_VERSION()";

            var con = new SQLiteConnection(cs);

            con.Open();

            var cmd = new SQLiteCommand(stm, con);

            string res = cmd.ExecuteScalar().ToString();

            MessageBox.Show(res);

            con.Close();
        }

        public void F2()
        {
            string cs = @"URI=file:test.db";
            SQLiteConnection.CreateFile("test.db");

            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                var cmd = new SQLiteCommand(con);
                cmd.CommandText = "DROP TABLE IF EXISTS cars";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "CREATE TABLE cars(id INTEGER PRIMARY KEY, name TEXT, price INT)";
                cmd.ExecuteNonQuery();

                cmd.CommandText = "INSERT INTO cars(name, price) VALUES('Audi',123)";

                cmd.ExecuteNonQuery();

                MessageBox.Show("OK!");
            }

        }

        public void F4()
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id");
            dt.Columns.Add("name");
            dt.Columns.Add("price");

            string cs = @"URI=file:test.db";
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                SQLiteCommand comm = new SQLiteCommand("Select * From cars", con);
                using (SQLiteDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        dt.Rows.Add(new object[] {
                            read.GetValue(read.GetOrdinal("id")),
                            read.GetValue(read.GetOrdinal("name")),
                            read.GetValue(read.GetOrdinal("price"))
                        });
                    }
                }
            }


            bindingSource1.DataSource = dt;
            bindingNavigator1.BindingSource = bindingSource1;
            dataGridView1.DataSource = bindingSource1;
        }


        public void F3()
        {
            string cs = @"URI=file:test.db";
            using (var con = new SQLiteConnection(cs))
            {
                con.Open();
                SQLiteCommand comm = new SQLiteCommand("Select * From cars", con);
                using (SQLiteDataReader read = comm.ExecuteReader())
                {
                    while (read.Read())
                    {
                        dataGridView1.Rows.Add(new object[] {
                            read.GetValue(0),  // U can use column index
                            read.GetValue(read.GetOrdinal("id")),  // Or column name like this
                            read.GetValue(read.GetOrdinal("name")),
                            read.GetValue(read.GetOrdinal("price"))
                        });
                    }
                }
            }
        }


        public Form1()
        {
            InitializeComponent();
            F4();
        }
    }
}
