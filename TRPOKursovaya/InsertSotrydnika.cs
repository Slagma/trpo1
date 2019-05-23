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
    public partial class InsertSotrydnika : Form
    {
        //СОЗДАНИЕ НЕОБХОДИМЫХ ПЕРЕМЕННЫХ
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";//Адрес к БД.
        private OleDbConnection myConnection = new OleDbConnection(connectString);//Подключение бд.
        int Seller;
        public InsertSotrydnika()
        {
            InitializeComponent();
            myConnection.Open();
        }
//True
        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (comboBox1.SelectedItem.ToString() == "Продавец")
                {
                    Seller = 1;
                }
                else Seller = 0;
                string query = "INSERT INTO Users (Login, Password, SecondName, Names, Patronymic,Seller) " +
                           "VALUES ('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "','" +
                           textBox4.Text + "','" + textBox5.Text + "','" + Seller + "')"; 
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
