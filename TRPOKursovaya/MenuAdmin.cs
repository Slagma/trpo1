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
    public partial class MenuAdmin : Form
    {
        public MenuAdmin()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("Screenshot\\cinema.jpg");
        }

        private void Admin_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Sessions s = new Sessions();
            s.ShowDialog();            
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Films f = new Films();
            f.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Sotrydniki sotr = new Sotrydniki();
            sotr.ShowDialog();
        }

        private void Button5_Click(object sender, EventArgs e)
        {
            Ticket t = new Ticket();
            t.ShowDialog();
        }

        private void Button6_Click(object sender, EventArgs e)
        {
            Hall H = new Hall();
            H.ShowDialog();
        }

        private void Button7_Click(object sender, EventArgs e)
        {
            Statistic stat = new Statistic();
            stat.ShowDialog();
        }

        private void Button8_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
