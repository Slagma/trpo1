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
using System.Data.SqlClient;

namespace TRPOKursovaya
{
    public partial class Films : Form
    {
        //СОЗДАНИЕ НЕОБХОДИМЫХ ПЕРЕМЕННЫХ

        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";//Адрес к БД.
        private OleDbConnection myConnection = new OleDbConnection(connectString);//Подключение бд.

        public Films()
        {
            InitializeComponent();
            myConnection.Open();
            //При запуске формы очищаю листбокс.
            listBox1.Items.Clear();
            //Запрос на вывод всех фильмов из БД.
            string query = "SELECT NameFilm FROM Films";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            //Заполнение листбокса фильмами.
            while (reader.Read())
            {
                listBox1.Items.Add(reader[0].ToString());

            }
        }
        //Поиск фильма через текстбокс.
        private void TextBox1_TextChanged(object sender, EventArgs e)
        {
            if (listBox1.FindString(textBox1.Text) >= 0)
                listBox1.SetSelected(listBox1.FindString(textBox1.Text), true);
        }



        //При закрытии программы закрывает БД и всю программу.
        private void Films_FormClosing(object sender, FormClosingEventArgs e)
        {
            myConnection.Close();
        }

        private void ListBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listBox1.SelectedIndex >= 0)
            {
                string items = listBox1.Items[listBox1.SelectedIndex].ToString();


                string query = "SELECT * FROM Films WHERE NameFilm = '" + items + "'";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                OleDbDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    textBox9.Text = reader[0].ToString(); //ID films
                    textBox2.Text = reader[1].ToString(); //Name film
                    textBox3.Text = reader[5].ToString(); //Country
                    textBox4.Text = reader[2].ToString(); //Age
                    textBox5.Text = reader[3].ToString().Substring(11); //Duration
                    textBox6.Text = reader[6].ToString(); //Rating
                    richTextBox1.Text = reader[4].ToString(); // Description
                    textBox7.Text = reader[7].ToString() + " р"; //Budget

                }
            }
        } //Выбор фильма в листбоксе

        private void Button1_Click(object sender, EventArgs e)
        {
            InsertFilms IF = new InsertFilms();
            IF.ShowDialog();
        } //Insert film

        private void Button2_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("При удалении выбраного фильма, также будут удалены все сеансы с данным фильмом, продолжить?", "Предупреждение", buttons: MessageBoxButtons.YesNo);
            try
            {
                if (result == DialogResult.Yes && listBox1.SelectedIndex != -1)
                {
                    string query = "SELECT ID_Films FROM Films where NameFilm = \"" + listBox1.Items[listBox1.SelectedIndex].ToString() + "\"";
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    int ID = Convert.ToInt32(command.ExecuteScalar());

                    query = "DELETE FROM SessionFilm WHERE Films =" + ID;
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();

                    query = "DELETE FROM Films WHERE ID_Films = " + ID;
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();


                    listBox1.Items.Clear();
                    //Запрос на вывод всех фильмов из БД.
                    query = "SELECT NameFilm FROM Films";
                    command = new OleDbCommand(query, myConnection);
                    OleDbDataReader reader = command.ExecuteReader();
                    //Заполнение листбокса фильмами.
                    while (reader.Read())
                    {
                        listBox1.Items.Add(reader[0].ToString());

                    }
                    MessageBox.Show("Удаление успешно выполнено");
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        } //Delete Film

        private void Button3_Click(object sender, EventArgs e)
        {
            ChangeFilms CF = new ChangeFilms();
            CF.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
