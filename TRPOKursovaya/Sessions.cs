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
    public partial class Sessions : Form
    {
        //Адрес к БД
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";
        //Подключение бд
        private OleDbConnection myConnection = new OleDbConnection(connectString);

       
        public Sessions()
        {
            InitializeComponent();
            myConnection.Open();
            countQuery = "SELECT Count(ID_SessionFilm) FROM SessionFilm;";
            command = new OleDbCommand(countQuery, myConnection);
            countSession = Convert.ToInt32(command.ExecuteScalar());
            dataGridView1.Rows.Add(countSession - 1);

            query = "SELECT SessionFilm.Data, Films.NameFilm, Hall.HallName, Price,SessionFilm.ID_SessionFilm FROM Hall INNER JOIN(Films INNER JOIN SessionFilm ON Films.ID_Films = SessionFilm.Films) ON Hall.ID_Hall = SessionFilm.Hall";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();
                                                       
                                          
            while (reader.Read())
            {       
                dataGridView1.Rows[j].Cells[0].Value = reader[0];
                dataGridView1.Rows[j].Cells[1].Value = reader[1];                
                dataGridView1.Rows[j].Cells[2].Value = reader[2];                
                dataGridView1.Rows[j].Cells[3].Value = reader[3];
                dataGridView1.Rows[j].Cells[4].Value = reader[4];
                j++;
            }
            j = 0;

            //Создание массива для работы с кнопками
            buttons.AddRange(new Button[] { button1, button2, button3, button4, button5, button6, button7, button8, button9, button10,
                                            button11, button12, button13, button14, button15, button16, button17, button18, button19, button20,
                                            button21, button22, button23, button24, button25, button26, button27, button28, button29, button30,
                                            button31, button32, button33, button34, button35, button36, button37, button38, button39, button40,
                                            button41, button42, button43, button44, button45, button46, button47, button48, button49, button50,
                                            button51, button52, button53, button54, button55, button56, button57, button58, button59, button60,
                                            button61, button62, button63, button64, button65, button66, button67, button68, button69, button70,
                                            button71, button72, button73, button74, button75, button76, button77, button78, button79, button80,
                                            button81, button82, button83, button84, button85, button86, button87, button88, button89, button90});

            //Внесение данных в комбобоксы фильма
            query = "SELECT NameFilm FROM Films";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();
            while(reader.Read())
            {
                comboBox2.Items.Add(reader[0]);
            }
            //Внесение данных в комбобоксы зала
            query = "SELECT HallName FROM Hall";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();
            while (reader.Read())
            {
                comboBox1.Items.Add(reader[0]);
            }

            try
            {
                panel1.Visible = true;
                nameFilm = dataGridView1.Rows[0].Cells[1].Value.ToString();
                for (int i = 1; i <= 90; i++)
                {
                    query = "SELECT SessionFilm.[Mesto " + i + "] FROM Films INNER JOIN SessionFilm ON Films.ID_Films = SessionFilm.Films WHERE NameFilm = \"" + nameFilm + "\"";
                    command = new OleDbCommand(query, myConnection);
                    if (command.ExecuteScalar().ToString() != "True")
                    {
                        //Если в БД Место под номером i не равно 1 то кнопка становится не доступна для взаимодействия.
                        buttons[i - 1].BackColor = Color.DarkGray;

                    }

                }
            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);
            }
        }

        //Создание необходимых переменыыхСОЗДАНИЕ НЕОБХОДИМЫХ ПЕРЕМЕННЫХ
        int j = 0, k = 0; //Нужна для ввод данных в dataGriedView1.Rows[j]..
        OleDbCommand command; //Нужна для выполнения SQL запросов
        OleDbDataReader reader; //Нужна для считывания данных с SQL запросов
        string query; //Нужна для написания SQL запроса 
        int countSession; //Нужна для определения количества сеансов
        string date1, date2; //Нужна для поиска сеанса по дате
        int rowsIndex; //Нужны для получения нажатой строки в dataGriedView
        string nameFilm; // Нужна для получения названия фильмо по нажатой строке в dataGriedView
        string countQuery; // Нужна для написания SQL запроса на количество записей
        string Date, Film, Hall, Price, currentMesto,ID;
        public List<Button> buttons = new List<Button>(); // Создает массив для кнопок-мест с 1 по 90

        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                dateTimePicker1.Visible = true;
                dateTimePicker2.Visible = true;
                label6.Visible = true;
                label5.Visible = true;

                checkBox2.Checked = false;
                checkBox3.Checked = false;
            }
            else
            {
                dateTimePicker1.Visible = false;
                dateTimePicker2.Visible = false;
                label6.Visible = false;
                label5.Visible = false;
            }
        } //При включении поиска по дате

        private void Button100_Click(object sender, EventArgs e)
        {
            this.Hide();
            ChangeSession cS = new ChangeSession();            
            cS.ShowDialog();
                      
        } //Открывает окно для изменения сеансов

        private void Button101_Click(object sender, EventArgs e)
        {
            this.Hide();
            InsertSession IS = new InsertSession();
            IS.ShowDialog();

        } //Открывает окно для добавления сеансов

        private void CheckBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                comboBox1.Visible = true;

                checkBox1.Checked = false;
                checkBox3.Checked = false;
            }
            else
            {
                comboBox1.Visible = false;
            }
        } //При включении поиска по залу

        private void CheckBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox3.Checked)
            {
                comboBox2.Visible = true;

                checkBox1.Checked = false;
                checkBox2.Checked = false;
            }
            else
            {
                comboBox2.Visible = false;
            }
        } //При включении поиска по фильму

        private void Button103_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked || checkBox2.Checked || checkBox3.Checked) // если хотя бы один вид выбран
            {
                if (checkBox1.Checked)
                {
                    dataGridView1.Rows.Clear();
                    date1 = dateTimePicker1.Value.ToString();
                    date2 = dateTimePicker2.Value.ToString();                    
                    query = "SELECT SessionFilm.Data, Hall.HallName, Films.NameFilm, SessionFilm.Price, SessionFilm.ID_SessionFilm " +
                    "FROM Hall INNER JOIN(Films INNER JOIN SessionFilm ON Films.ID_Films = SessionFilm.Films) ON Hall.ID_Hall = SessionFilm.Hall" +
                    " WHERE(((SessionFilm.Data) Between #" + dateTimePicker1.Value.ToString().Substring(0, 2) + "/" + dateTimePicker1.Value.ToString().Substring(3, 2) + 
                    "/" + dateTimePicker1.Value.ToString().Substring(6, 4) + "# And #" + dateTimePicker2.Value.ToString().Substring(0, 2) + 
                    "/" + dateTimePicker2.Value.ToString().Substring(3, 2) + "/" + dateTimePicker2.Value.ToString().Substring(6, 4) + "#));";
                    command = new OleDbCommand(query, myConnection);
                    reader = command.ExecuteReader();
                    k = 0;                 
                    while (reader.Read())
                    {                        
                        dataGridView1.Rows.Add(1);                       
                        dataGridView1.Rows[k].Cells[0].Value = reader[0];
                        dataGridView1.Rows[k].Cells[1].Value = reader[1];
                        dataGridView1.Rows[k].Cells[2].Value = reader[2];                        
                        dataGridView1.Rows[k].Cells[3].Value = reader[3];                       
                        dataGridView1.Rows[k].Cells[4].Value = reader[4];
                        k++;
                    }
                }
                else if (checkBox2.Checked)
                {
                    dataGridView1.Rows.Clear();
                    query = "SELECT SessionFilm.Data, Films.NameFilm, Hall.HallName, Price, SessionFilm.ID_SessionFilm FROM Hall INNER JOIN(Films INNER JOIN SessionFilm ON Films.ID_Films = SessionFilm.Films) ON Hall.ID_Hall = SessionFilm.Hall WHERE Hall.HallName = \"" + comboBox1.SelectedItem +"\"";
                    command = new OleDbCommand(query, myConnection);
                    reader = command.ExecuteReader();
                    k = 0;
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[k].Cells[0].Value = reader[0];
                        dataGridView1.Rows[k].Cells[1].Value = reader[1];
                        dataGridView1.Rows[k].Cells[2].Value = reader[2];
                        dataGridView1.Rows[k].Cells[3].Value = reader[3];
                        dataGridView1.Rows[k].Cells[4].Value = reader[4];
                        k++;
                    }
                }
                else if(checkBox3.Checked)
                {
                    dataGridView1.Rows.Clear();
                    query = "SELECT SessionFilm.Data, Films.NameFilm, Hall.HallName, Price, SessionFilm.ID_SessionFilm FROM Hall INNER JOIN(Films INNER JOIN SessionFilm ON Films.ID_Films = SessionFilm.Films) ON Hall.ID_Hall = SessionFilm.Hall WHERE Films.NameFilm = \"" + comboBox2.SelectedItem + "\"";
                    command = new OleDbCommand(query, myConnection);
                    reader = command.ExecuteReader();
                    k = 0;
                    while (reader.Read())
                    {
                        dataGridView1.Rows.Add(1);
                        dataGridView1.Rows[k].Cells[0].Value = reader[0];
                        dataGridView1.Rows[k].Cells[1].Value = reader[1];
                        dataGridView1.Rows[k].Cells[2].Value = reader[2];
                        dataGridView1.Rows[k].Cells[3].Value = reader[3];
                        dataGridView1.Rows[k].Cells[4].Value = reader[4];
                        k++;
                    }
                }
            }
            else
                MessageBox.Show("Выберите хотя бы один критерий поиска!");
        } //Поиск по (дате, названию зала, названию фильма)

        private void Button104_Click(object sender, EventArgs e)
        {
            dateTimePicker1.ResetText();
            dateTimePicker2.ResetText();
            comboBox1.SelectedIndex = -1;
            comboBox2.SelectedIndex = -1;
            checkBox1.Checked = false;
            checkBox2.Checked = false;
            checkBox3.Checked = false;

            dataGridView1.Rows.Clear();
            dataGridView1.Rows.Add(countSession - 1);
            query = "SELECT SessionFilm.Data, Films.NameFilm, Hall.HallName, Price,SessionFilm.ID_SessionFilm FROM Hall INNER JOIN(Films INNER JOIN SessionFilm ON Films.ID_Films = SessionFilm.Films) ON Hall.ID_Hall = SessionFilm.Hall";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows[j].Cells[0].Value = reader[0];
                dataGridView1.Rows[j].Cells[1].Value = reader[1];
                dataGridView1.Rows[j].Cells[2].Value = reader[2];
                dataGridView1.Rows[j].Cells[3].Value = reader[3];
                dataGridView1.Rows[j].Cells[4].Value = reader[4];
                j++;
            }
            j = 0;
        } // Сброс поиска

        private void Button102_Click(object sender, EventArgs e)
        {

            this.Close();
        } //Back

        private void SellTicket_Click(object sender, EventArgs e)
        {
            try
            {
                PrintTicket PT = new PrintTicket();

                rowsIndex = dataGridView1.CurrentRow.Index;
                Date = DateTime.Now.ToString().Replace(".", "/");

                Film = dataGridView1.Rows[rowsIndex].Cells[1].Value.ToString();
                PT.LabelFilm.Text = Film;
                query = "SELECT ID_Films FROM Films WHERE NameFilm =\"" + Film + "\"";
                command = new OleDbCommand(query, myConnection);
                Film = command.ExecuteScalar().ToString();

                Hall = dataGridView1.Rows[rowsIndex].Cells[2].Value.ToString();
                PT.LabelHall.Text += Hall;
                query = "SELECT ID_Hall FROM Hall WHERE HallName =\"" + Hall + "\"";
                command = new OleDbCommand(query, myConnection);
                Hall = command.ExecuteScalar().ToString();

                Price = dataGridView1.Rows[rowsIndex].Cells[3].Value.ToString();
                ID = dataGridView1.Rows[rowsIndex].Cells[4].Value.ToString();

                if (numericRyad.Value == 1)
                {
                    currentMesto = numericMesto.Value.ToString();
                }
                else if (numericRyad.Value == 2)
                {
                    currentMesto = (numericMesto.Value + 10).ToString();
                }
                else if (numericRyad.Value == 3)
                {
                    currentMesto = (numericMesto.Value + 20).ToString();
                }
                else if (numericRyad.Value == 4)
                {
                    currentMesto = (numericMesto.Value + 30).ToString();
                }
                else if (numericRyad.Value == 5)
                {
                    currentMesto = (numericMesto.Value + 40).ToString();
                }
                else if (numericRyad.Value == 6)
                {
                    currentMesto = (numericMesto.Value + 50).ToString();
                }
                else if (numericRyad.Value == 7)
                {
                    currentMesto = (numericMesto.Value + 60).ToString();
                }
                else if (numericRyad.Value == 8)
                {
                    currentMesto = (numericMesto.Value + 70).ToString();
                }
                else if (numericRyad.Value == 9)
                {
                    currentMesto = (numericMesto.Value + 80).ToString();
                }

                if (buttons[Convert.ToInt32(currentMesto) - 1].BackColor == Color.DarkGray)
                {
                    MessageBox.Show("Это место уже занято!");                    
                }
                else
                {
                    query = "INSERT INTO Ticket (DataTime, SessionFilm,Films,Hall,Mesto,AllPrice) VALUES (#" + Date + "#,'" + ID + "','" + Film + "','" + Hall + "','" + currentMesto + "','" + Price + "')";
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();

                    query = "UPDATE [SessionFilm] SET [Mesto " + currentMesto + "] = '0' WHERE [ID_SessionFilm] = " + ID;
                    command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();

                    buttons[Convert.ToInt32(currentMesto)].BackColor = Color.DarkGray;
                                     
                    PT.LabelData.Text = dataGridView1.Rows[rowsIndex].Cells[0].Value.ToString();
                    PT.LabelPrice.Text += Price;
                    PT.LabelMesto.Text += numericMesto.Value.ToString();
                    PT.LabelRyad.Text += numericRyad.Value.ToString();
                    PT.ShowDialog();
                }                
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
               
            
        } // Продажа билета на сеанс

        private void DataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                buttons[i].BackColor = Color.Aqua;
            }
            for (int i = 30; i < 60; i++)
            {
                buttons[i].BackColor = Color.Chartreuse;
            }
            for (int i = 60; i < 90; i++)
            {
                buttons[i].BackColor = Color.Gold;
            }
            panel1.Visible = true;
            
            try
            {
                rowsIndex = e.RowIndex;
                nameFilm = dataGridView1.Rows[rowsIndex].Cells[1].Value.ToString();
                for (int i = 1; i <= 90; i++)
                {
                    query = "SELECT SessionFilm.[Mesto " + i + "] FROM Films INNER JOIN SessionFilm ON Films.ID_Films = SessionFilm.Films WHERE NameFilm = \"" + nameFilm + "\"";
                    command = new OleDbCommand(query, myConnection);
                    if (command.ExecuteScalar().ToString() != "True")
                    {
                        //Если в БД Место под номером i не равно 1 то кнопка становится не доступна для взаимодействия.
                        buttons[i - 1].BackColor = Color.DarkGray;

                    }

                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
                
            
        } //При нажатии на строку в dataGriedView
    }
}
