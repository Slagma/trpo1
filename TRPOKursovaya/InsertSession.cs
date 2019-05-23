using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;

namespace TRPOKursovaya
{
    public partial class InsertSession : Form
    {
        //РАБОТА С БД ACCESS
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";
        private OleDbConnection myConnection = new OleDbConnection(connectString);
        OleDbCommand command;
        OleDbDataReader reader;
        string query;
        //

        public InsertSession()
        {
            InitializeComponent();
            myConnection.Open();

            query = "SELECT NameFilm FROM Films";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
            query = "SELECT HallName FROM Hall";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0]);
            }
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string  Date, Film, Price, Hall;
            try
            {
                Film = comboBox1.SelectedItem.ToString();
                query = "SELECT ID_Films FROM Films WHERE NameFilm ='" + Film + "'";
                command = new OleDbCommand(query, myConnection);
                Film = command.ExecuteScalar().ToString();

                Hall = comboBox2.SelectedItem.ToString();
                query = "SELECT ID_Hall FROM Hall WHERE HallName ='" + Hall + "'";
                command = new OleDbCommand(query, myConnection);
                Hall = command.ExecuteScalar().ToString();

                Price = textBox1.Text;
                Date = dateTimePicker1.Value.ToString();
                Date = Date.Replace(".", "/");
                query = "INSERT INTO SessionFilm ([Data],[Hall],[Films],[Price]) VALUES (#" + Date + "#,'" + Hall + "','" + Film + "','" + Price + "')";
                command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception)
            {
            }            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();    
            Sessions S = new Sessions();
            S.ShowDialog();
                    
        }
    }
}
