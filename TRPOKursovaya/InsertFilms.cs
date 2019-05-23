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
    public partial class InsertFilms : Form
    {
        //СОЗДАНИЕ НЕОБХОДИМЫХ ПЕРЕМЕННЫХ
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";//Адрес к БД.
        private OleDbConnection myConnection = new OleDbConnection(connectString);//Подключение бд.


        public InsertFilms()
        {
            InitializeComponent();
            myConnection.Open();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                string query = "INSERT INTO Films (NameFilm,Age_Category,Duration,Country_Product,Rating,Budget,Description) " +
                           "VALUES ('" + textBox1.Text + "','" + maskedTextBox1.Text.Remove(2, 1) + "','" + maskedTextBox2.Text + "','"
                            + textBox2.Text + "','" + maskedTextBox3.Text + "','" + maskedTextBox4.Text.Replace(" р", "") + "','" + richTextBox1.Text + "')";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Добавление успешно выполнено");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }                          
        } //Insert Films

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
        }
    }
}
