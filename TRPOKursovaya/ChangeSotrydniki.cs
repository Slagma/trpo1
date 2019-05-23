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
    public partial class ChangeSotrydniki : Form
    {
        //СОЗДАНИЕ НЕОБХОДИМЫХ ПЕРЕМЕННЫХ
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";//Адрес к БД.
        private OleDbConnection myConnection = new OleDbConnection(connectString);//Подключение бд.
        public ChangeSotrydniki()
        {
            InitializeComponent();
            myConnection.Open();

            comboBox2.Items.Clear();
            string query = "SELECT ID FROM Users";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox2.Items.Add(reader[0]);
            }
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            string Login, Password, SecondName, Name, Patronymic;
            int Seller;
            try
            {
                Login = textBox1.Text;
                Password = textBox2.Text;
                SecondName = textBox3.Text;
                Name = textBox4.Text;
                Patronymic = textBox5.Text;
                if (comboBox1.SelectedItem.ToString() == "Продавец")
                    Seller = 1;
                else Seller = 0;
                string query = "UPDATE Users SET Login ='"+Login+"',"+
                               "Password ='"+Password + "'," +
                               "SecondName ='"+SecondName + "'," +
                               "Name ='"+Name + "'," +
                               "Patronymic ='"+Patronymic + "'," +
                               "Seller ='"+Seller + "'";
                OleDbCommand command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                MessageBox.Show("Изменение успешно выполнено");
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();
            string query = "SELECT * FROM Users WHERE ID ="+comboBox2.SelectedItem;
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();
            while(reader.Read())
            {
                textBox1.Text = reader[1].ToString();
                textBox2.Text = reader[2].ToString();
                textBox3.Text = reader[3].ToString();
                textBox4.Text = reader[4].ToString();
                textBox5.Text = reader[5].ToString();
                if (reader[6].ToString() == "1")
                   comboBox1.Items.Add("Продавец");
                else comboBox1.Items.Add("Бухгалтер");
                
            }
        }
    }
}
