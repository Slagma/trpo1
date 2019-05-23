namespace TRPOKursovaya
{
    partial class PrintTicket
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.LabelMesto = new System.Windows.Forms.Label();
            this.LabelRyad = new System.Windows.Forms.Label();
            this.LabelFilm = new System.Windows.Forms.Label();
            this.LabelHall = new System.Windows.Forms.Label();
            this.LabelPrice = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.LabelData = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.printDialog1 = new System.Windows.Forms.PrintDialog();
            this.printDocument1 = new System.Drawing.Printing.PrintDocument();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panel1.Location = new System.Drawing.Point(0, 38);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(480, 1);
            this.panel1.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.Color.Transparent;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label1.Location = new System.Drawing.Point(160, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(171, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Билет в кинотеатр";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button1.Location = new System.Drawing.Point(12, 248);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(145, 25);
            this.button1.TabIndex = 2;
            this.button1.Text = "Печать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // button2
            // 
            this.button2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.button2.Location = new System.Drawing.Point(458, 248);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(90, 25);
            this.button2.TabIndex = 3;
            this.button2.Text = "Закрыть";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.Color.Transparent;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label2.Location = new System.Drawing.Point(496, 65);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(22, 20);
            this.label2.TabIndex = 4;
            this.label2.Text = "О";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.BackColor = System.Drawing.Color.Transparent;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label3.Location = new System.Drawing.Point(496, 85);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(22, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "Н";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.BackColor = System.Drawing.Color.Transparent;
            this.label4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label4.Location = new System.Drawing.Point(496, 105);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(19, 20);
            this.label4.TabIndex = 4;
            this.label4.Text = "Т";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.BackColor = System.Drawing.Color.Transparent;
            this.label5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label5.Location = new System.Drawing.Point(496, 125);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 20);
            this.label5.TabIndex = 4;
            this.label5.Text = "Р";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.BackColor = System.Drawing.Color.Transparent;
            this.label6.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label6.Location = new System.Drawing.Point(496, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(22, 20);
            this.label6.TabIndex = 4;
            this.label6.Text = "О";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.BackColor = System.Drawing.Color.Transparent;
            this.label7.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label7.Location = new System.Drawing.Point(496, 165);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(22, 20);
            this.label7.TabIndex = 4;
            this.label7.Text = "Л";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.BackColor = System.Drawing.Color.Transparent;
            this.label8.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label8.Location = new System.Drawing.Point(496, 185);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(20, 20);
            this.label8.TabIndex = 4;
            this.label8.Text = "Ь";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.BackColor = System.Drawing.Color.Transparent;
            this.label9.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.label9.Location = new System.Drawing.Point(496, 45);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(20, 20);
            this.label9.TabIndex = 4;
            this.label9.Text = "К";
            // 
            // LabelMesto
            // 
            this.LabelMesto.AutoSize = true;
            this.LabelMesto.BackColor = System.Drawing.Color.Transparent;
            this.LabelMesto.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.LabelMesto.Location = new System.Drawing.Point(170, 50);
            this.LabelMesto.Name = "LabelMesto";
            this.LabelMesto.Size = new System.Drawing.Size(72, 20);
            this.LabelMesto.TabIndex = 5;
            this.LabelMesto.Text = "Место: ";
            // 
            // LabelRyad
            // 
            this.LabelRyad.AutoSize = true;
            this.LabelRyad.BackColor = System.Drawing.Color.Transparent;
            this.LabelRyad.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.LabelRyad.Location = new System.Drawing.Point(170, 85);
            this.LabelRyad.Name = "LabelRyad";
            this.LabelRyad.Size = new System.Drawing.Size(52, 20);
            this.LabelRyad.TabIndex = 5;
            this.LabelRyad.Text = "Ряд: ";
            // 
            // LabelFilm
            // 
            this.LabelFilm.AutoSize = true;
            this.LabelFilm.BackColor = System.Drawing.Color.Transparent;
            this.LabelFilm.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.25F);
            this.LabelFilm.Location = new System.Drawing.Point(264, 46);
            this.LabelFilm.Name = "LabelFilm";
            this.LabelFilm.Size = new System.Drawing.Size(53, 17);
            this.LabelFilm.TabIndex = 5;
            this.LabelFilm.Text = "Фильм";
            // 
            // LabelHall
            // 
            this.LabelHall.AutoSize = true;
            this.LabelHall.BackColor = System.Drawing.Color.Transparent;
            this.LabelHall.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.LabelHall.Location = new System.Drawing.Point(161, 185);
            this.LabelHall.Name = "LabelHall";
            this.LabelHall.Size = new System.Drawing.Size(51, 20);
            this.LabelHall.TabIndex = 5;
            this.LabelHall.Text = "Зал: ";
            // 
            // LabelPrice
            // 
            this.LabelPrice.AutoSize = true;
            this.LabelPrice.BackColor = System.Drawing.Color.Transparent;
            this.LabelPrice.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.LabelPrice.Location = new System.Drawing.Point(228, 214);
            this.LabelPrice.Name = "LabelPrice";
            this.LabelPrice.Size = new System.Drawing.Size(177, 20);
            this.LabelPrice.TabIndex = 5;
            this.LabelPrice.Text = "Стоимость билета: ";
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.ErrorImage = null;
            this.pictureBox1.InitialImage = null;
            this.pictureBox1.Location = new System.Drawing.Point(0, 198);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(129, 40);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 6;
            this.pictureBox1.TabStop = false;
            // 
            // LabelData
            // 
            this.LabelData.AutoSize = true;
            this.LabelData.BackColor = System.Drawing.Color.Transparent;
            this.LabelData.Font = new System.Drawing.Font("Microsoft Sans Serif", 12.25F);
            this.LabelData.Location = new System.Drawing.Point(316, 72);
            this.LabelData.Name = "LabelData";
            this.LabelData.Size = new System.Drawing.Size(158, 20);
            this.LabelData.TabIndex = 5;
            this.LabelData.Text = "01.02.2019 15:30:00";
            // 
            // panel2
            // 
            this.panel2.Location = new System.Drawing.Point(480, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(4, 250);
            this.panel2.TabIndex = 7;
            // 
            // printDialog1
            // 
            this.printDialog1.UseEXDialog = true;
            // 
            // printDocument1
            // 
            this.printDocument1.PrintPage += new System.Drawing.Printing.PrintPageEventHandler(this.PrintDocument1_PrintPage);
            // 
            // PrintTicket
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(560, 276);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.LabelData);
            this.Controls.Add(this.LabelFilm);
            this.Controls.Add(this.LabelPrice);
            this.Controls.Add(this.LabelHall);
            this.Controls.Add(this.LabelRyad);
            this.Controls.Add(this.LabelMesto);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.panel1);
            this.Name = "PrintTicket";
            this.Text = "PrintTicket";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PrintDialog printDialog1;
        public System.Windows.Forms.Label LabelMesto;
        public System.Windows.Forms.Label LabelRyad;
        public System.Windows.Forms.Label LabelFilm;
        public System.Windows.Forms.Label LabelHall;
        public System.Windows.Forms.Label LabelPrice;
        public System.Windows.Forms.Label LabelData;
        private System.Drawing.Printing.PrintDocument printDocument1;
    }
}