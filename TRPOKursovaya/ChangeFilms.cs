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
    public partial class ChangeFilms : Form
    {
        //СОЗДАНИЕ НЕОБХОДИМЫХ ПЕРЕМЕННЫХ
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";//Адрес к БД.
        private OleDbConnection myConnection = new OleDbConnection(connectString);//Подключение бд.

        public ChangeFilms()
        {
            InitializeComponent();
            myConnection.Open();
            string query = "SELECT NameFilm FROM Films WHERE ID_Films = 5";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
            //Check
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            //
            try
            {
                string query = "UPDATE Films SET (NameFilm,Age_Category,Duration,Country_Product,Rating,Budget,Description) " +
                           "'" + comboBox1.SelectedItem + "','" + maskedTextBox1.Text.Remove(2, 1) + "','" + maskedTextBox2.Text + "','"
                            + textBox2.Text + "','" + maskedTextBox3.Text + "','" + maskedTextBox4.Text.Replace(" р", "") + "','" + richTextBox1.Text + "'";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Добавление успешно выполнено");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }
    }
}
