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
    public partial class Hall : Form
    {
        //Адрес к БД
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";
        //Подключение бд
        private OleDbConnection myConnection = new OleDbConnection(connectString);
        public Hall()
        {
            InitializeComponent();
            myConnection.Open();
            //Внесение залов в комбобокс
            string query = "SELECT HallName FROM Hall";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("При удалении выбраного зала, также будут удалены все сеансы с данным залом, продолжить?", "Предупреждение", buttons: MessageBoxButtons.YesNo);
            try
            {
                if (result == DialogResult.Yes && comboBox1.SelectedItem != null)
                {
                    string query = "SELECT ID_Hall FROM Hall where HallName = \"" + comboBox1.SelectedItem + "\"";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    int ID = Convert.ToInt32(command.ExecuteScalar());

                    query = "DELETE FROM SessionFilm WHERE Hall =" + ID;
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();

                    query = "DELETE FROM Hall WHERE ID_Hall =" + ID;
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();

                    comboBox1.Items.Clear();
                    query = "SELECT HallName FROM Hall";
                    command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader[0]);
                    }
                    MessageBox.Show("Удаление успешно выполнено");
                }
            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);
            }            
        } //Delete Hall

        private void Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
        } //Exit

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem != null && textBox1.Text != "")
                {
                    string query = "UPDATE Hall SET HallName = \"" + textBox1.Text + "\" WHERE HallName = \"" + comboBox1.SelectedItem + "\"";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Изменения успешно выполнены");

                    comboBox1.Items.Clear();
                    query = "SELECT HallName FROM Hall";
                    command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader[0]);
                    }
                }
            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);
            }            
        } //Update Hall

        private void Button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (textBox2.Text != "")
                {
                    string query = "INSERT INTO Hall (HallName) VALUES ('" + textBox2.Text + "')";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Добавление выполнено успешно");

                    comboBox1.Items.Clear();
                    query = "SELECT HallName FROM Hall";
                    command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    while (reader.Read())
                    {
                        comboBox1.Items.Add(reader[0]);
                    }
                }
            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);
            }            
        } //Insert Hall
    }
}
