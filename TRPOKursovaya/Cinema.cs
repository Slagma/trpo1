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
    public partial class Cinema : Form
    {
        //Адрес к БД
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";
        //Подключение бд
        private OleDbConnection myConnection = new OleDbConnection(connectString);       
        public Cinema()
        {
            InitializeComponent();
            // открываем соединение с БД
            myConnection.Open();
            this.BackgroundImage = Image.FromFile("Screenshot\\cinema.jpg");
            
        }
       
        private void Button1_Click(object sender, EventArgs e)
        {
            //Считываю введенный логин и пароль пользователем.
            string login, password;
            login = textBox1.Text;
            password = textBox2.Text;

            //Запрос к БД с получением пароля, логина и тип доступа.
            string query = "SELECT Login, Password,Seller FROM Users ORDER BY id";
            OleDbCommand command = new OleDbCommand(query, myConnection);
            OleDbDataReader reader = command.ExecuteReader();            

            //Проверяю есть ли такой пользователь.
            while (reader.Read())
            {
                //Если есть, то заходит под продавца.
                if (login == reader[0].ToString() && password == reader[1].ToString() && reader[2].ToString() == "True")
                {
                    MenuSeller MS = new MenuSeller();
                    this.Hide();
                    MS.ShowDialog();

                    break;
                }//Если тип доступа другой то под бухгалтера.
                else if (login == reader[0].ToString() && password == reader[1].ToString() && reader[2].ToString() == "False")
                {
                    MenuAdmin MA = new MenuAdmin();
                    this.Hide();
                    MA.ShowDialog();

                    break;
                }//Если введен неверный логин или пароль выдасть ошибку
                else { label3.Visible = true; textBox2.Clear(); }
            }
        }
        //При закрытии программы закрывает БД
        private void Autorization_FormClosed(object sender, FormClosedEventArgs e)
        {
            myConnection.Close();
        }
        //При нажатии на 1 из 2 текстбоксов пропадает ошибка о неверном логине или пароле.
        private void TextBox1_Click(object sender, EventArgs e)
        {
            label3.Visible = false;
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
