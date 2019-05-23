using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TRPOKursovaya
{
    public partial class MenuSeller : Form
    {
        public MenuSeller()
        {
            InitializeComponent();
            this.BackgroundImage = Image.FromFile("Screenshot\\cinema.jpg");
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            Sessions s = new Sessions();
            s.ShowDialog();
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            Ticket t = new Ticket();
            t.ShowDialog();
        }

        private void Button4_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void Button3_Click(object sender, EventArgs e)
        {
            Hall H = new Hall();
            H.ShowDialog();
        }
    }
}
