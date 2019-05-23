using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRPOKursovaya
{
    public partial class ChangeSession : Form
    {
        //РАБОТА С БД ACCESS
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";
        private OleDbConnection myConnection = new OleDbConnection(connectString);
        OleDbCommand command;
        OleDbDataReader reader;
        string query;
        //
        public ChangeSession()
        {
            InitializeComponent();
            myConnection.Open();

            query = "SELECT ID_SessionFilm FROM SessionFilm";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }

            query = "SELECT NameFilm FROM Films";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0]);
            }

            query = "SELECT HallName FROM Hall";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox3.Items.Add(reader[0]);
            }

        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string ID, Date, Film, Price, Hall;
            try
            {
                Film = comboBox2.SelectedItem.ToString();
                query = "SELECT ID_Films FROM Films WHERE NameFilm ='" + Film + "'";
                command = new OleDbCommand(query, myConnection);
                Film = command.ExecuteScalar().ToString();

                Hall = comboBox3.SelectedItem.ToString();
                query = "SELECT ID_Hall FROM Hall WHERE HallName ='" + Hall + "'";
                command = new OleDbCommand(query, myConnection);
                Hall = command.ExecuteScalar().ToString();

                ID = comboBox1.SelectedItem.ToString();
                Price = textBox4.Text;
                Date = dateTimePicker1.Value.ToString();
                Date = Date.Replace(".", "/");
                query = "UPDATE SessionFilm SET Films= '" + Film + "'," +
                               "Hall = '" + Hall + "'," +
                               "Data = #" + Date + "#," +
                               "Price = '" + Price + "' WHERE ID_SessionFilm = " + ID;
                command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Sessions S = new Sessions();
            S.ShowDialog();
                        
        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string query = "SELECT Films.NameFilm, Hall.HallName, SessionFilm.Data, SessionFilm.Price FROM Hall INNER JOIN (Films INNER JOIN SessionFilm ON Films.ID_Films = SessionFilm.Films) ON Hall.ID_Hall = SessionFilm.Hall WHERE ID_SessionFilm =" + comboBox1.SelectedItem;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {                
                comboBox2.SelectedIndex = comboBox2.Items.IndexOf(reader[0]);            
                comboBox3.SelectedIndex = comboBox3.Items.IndexOf(reader[1].ToString());         
                dateTimePicker1.Value = Convert.ToDateTime(reader[2]);
                textBox4.Text = reader[3].ToString();

            }
        }
    }
}
