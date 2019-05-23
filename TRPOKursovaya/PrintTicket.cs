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
    public partial class PrintTicket : Form
    {
        public PrintTicket()
        {

            InitializeComponent();
            panel2.BackgroundImage = Image.FromFile("Screenshot\\Shtrih.png");
            pictureBox1.BackgroundImage = Image.FromFile("Screenshot\\ShtrihCode.png");
            this.BackgroundImage = Image.FromFile("Screenshot\\cinema.jpg");
        }

        private void Button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            printDialog1.Document = printDocument1;
            DialogResult result = printDialog1.ShowDialog();
            if (result == DialogResult.OK)
            {
                printDocument1.Print();
            }
            this.Close();
        }

        private void PrintDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            var bitmap = new Bitmap(Width, Height);
            DrawToBitmap(bitmap, new Rectangle(Point.Empty, bitmap.Size));
            e.Graphics.DrawImage(bitmap, new Point(50, 50));
        }
    }
}
