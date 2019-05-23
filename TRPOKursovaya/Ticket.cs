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
    public partial class Ticket : Form
    {
        //РАБОТА С БД ACCESS

        //Адрес к БД
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";
        //Подключение бд
        private OleDbConnection myConnection = new OleDbConnection(connectString);        
        OleDbCommand command; //Нужна для выполнения SQL запросов
        OleDbDataReader reader; //Нужна для считывания данных с SQL запросов
        string query, countQuery; //Нужна для написания SQL запроса 

        private void Button2_Click(object sender, EventArgs e)
        {
            try
            {
                int rowsIndex = dataGridView1.CurrentRow.Index;
                int idTicket = Convert.ToInt32(dataGridView1.Rows[rowsIndex].Cells[0].Value);
                int Mesto = Convert.ToInt32(dataGridView1.Rows[rowsIndex].Cells[4].Value);
                int idSession = Convert.ToInt32(dataGridView1.Rows[rowsIndex].Cells[6].Value);
                query = "UPDATE SessionFilm SET [Mesto " + Mesto + "] = '1' WHERE ID_SessionFilm = " + idSession;
                command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();

                query = "DELETE FROM Ticket WHERE ID_Ticket = " + idTicket;
                command = new OleDbCommand(query, myConnection);
                command.ExecuteNonQuery();
                vvodDataGried(); 

            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);
            } 
            
        }

        int countSession,i=0;

        private void Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        public Ticket()
        {
            InitializeComponent();
            myConnection.Open();
            vvodDataGried();             
        }

        private void vvodDataGried()
        {
            try
            {
                dataGridView1.Rows.Clear();
                countQuery = "SELECT Count(ID_Ticket) FROM Ticket;";
                command = new OleDbCommand(countQuery, myConnection);
                countSession = Convert.ToInt32(command.ExecuteScalar());
                dataGridView1.Rows.Add(countSession);
                query = "SELECT Ticket.ID_Ticket, Ticket.DataTime, Films.NameFilm, Hall.HallName, Ticket.Mesto, Ticket.AllPrice, Ticket.SessionFilm " +
                        "FROM(Hall INNER JOIN(Films INNER JOIN SessionFilm ON Films.ID_Films = SessionFilm.Films) ON Hall.ID_Hall = SessionFilm.Hall) INNER JOIN Ticket ON SessionFilm.ID_SessionFilm = Ticket.SessionFilm; ";
                command = new OleDbCommand(query, myConnection);
                reader = command.ExecuteReader();
                while (reader.Read())
                {
                    dataGridView1.Rows[i].Cells[0].Value = reader[0];
                    dataGridView1.Rows[i].Cells[1].Value = reader[1];
                    dataGridView1.Rows[i].Cells[2].Value = reader[2];
                    dataGridView1.Rows[i].Cells[3].Value = reader[3];
                    dataGridView1.Rows[i].Cells[4].Value = reader[4];
                    dataGridView1.Rows[i].Cells[5].Value = reader[5];
                    dataGridView1.Rows[i].Cells[6].Value = reader[6];
                    i++;
                }
                i = 0;
            }
            catch (Exception es)
            {

                MessageBox.Show(es.Message);
            }    
        }
    }
}
