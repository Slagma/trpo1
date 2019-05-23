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
    public partial class Sotrydniki : Form
    {
        //Адрес к БД
        private static string connectString = "Provider=Microsoft.Jet.OLEDB.4.0;Data Source=Cinema.mdb;";
        //Подключение бд
        private OleDbConnection myConnection = new OleDbConnection(connectString);
        string countQuery;
        OleDbCommand command;
        int countSession,j;
        string query;
        OleDbDataReader reader;

        public Sotrydniki()
        {
            InitializeComponent();
            myConnection.Open();

            countQuery = "SELECT Count(ID) FROM Users";
            command = new OleDbCommand(countQuery, myConnection);
            countSession = Convert.ToInt32(command.ExecuteScalar());
            dataGridView1.Rows.Add(countSession - 1);
            query = "SELECT * FROM Users";
            command = new OleDbCommand(query, myConnection);
            reader = command.ExecuteReader();

            while (reader.Read())
            {
                dataGridView1.Rows[j].Cells[0].Value = reader[0];
                dataGridView1.Rows[j].Cells[1].Value = reader[1];
                dataGridView1.Rows[j].Cells[2].Value = reader[2];
                dataGridView1.Rows[j].Cells[3].Value = reader[3];
                dataGridView1.Rows[j].Cells[4].Value = reader[4];
                dataGridView1.Rows[j].Cells[5].Value = reader[5];
                dataGridView1.Rows[j].Cells[6].Value = reader[6];
                j++;
            }

            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            InsertSotrydnika IS = new InsertSotrydnika();
            IS.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            ChangeSotrydniki CS = new ChangeSotrydniki();
            CS.ShowDialog();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Вы действительно хотети удалить учетную запись?", "Подтверждение", MessageBoxButtons.YesNo);
            try
            {
                int index;
                if (result == DialogResult.Yes && dataGridView1.CurrentRow != null)
                {
                    index = Convert.ToInt32(dataGridView1.CurrentRow);

                    string query = "DELETE FROM Users WHERE ID =" + dataGridView1.Rows[index].Cells[0];
                    OleDbCommand command = new OleDbCommand(query, myConnection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Удаление успешно выполнено");

                    dataGridView1.Rows.Clear();
                    countQuery = "SELECT Count(ID) FROM Users";
                    command = new OleDbCommand(countQuery, myConnection);
                    countSession = Convert.ToInt32(command.ExecuteScalar());
                    dataGridView1.Rows.Add(countSession - 1);
                    query = "SELECT * FROM Users";
                    command = new OleDbCommand(query, myConnection);
                    reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        dataGridView1.Rows[j].Cells[0].Value = reader[0];
                        dataGridView1.Rows[j].Cells[1].Value = reader[1];
                        dataGridView1.Rows[j].Cells[2].Value = reader[2];
                        dataGridView1.Rows[j].Cells[3].Value = reader[3];
                        dataGridView1.Rows[j].Cells[4].Value = reader[4];
                        dataGridView1.Rows[j].Cells[5].Value = reader[5];
                        dataGridView1.Rows[j].Cells[6].Value = reader[6];
                        j++;
                    }
                }
            }
            catch (Exception es)
            {
                MessageBox.Show(es.Message);
            }
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
