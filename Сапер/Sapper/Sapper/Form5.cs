using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Data.OleDb;
using Microsoft.VisualBasic.Logging;

namespace Sapper
{
    public partial class Form5 : Form
    {
        string data;
        int BackGround = 1;
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.mdb";
        private string connectionString1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FON.mdb";
        public Form5(string data, int BacKGround)
        {
            InitializeComponent();
            this.data = data;
            this.BackGround = BacKGround;

        }

        private void Form5_Load(object sender, EventArgs e)
        {
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            label2.Parent = pictureBox1;
            label2.BackColor = Color.Transparent;
            label3.Parent = pictureBox1;
            label3.BackColor = Color.Transparent;
            switch (BackGround)
            {
                case 1:
                    {
                        Image image = new Bitmap(@"C:\Users\markk\OneDrive\Рабочий стол\РИСПО\Сапер\Sapper\Sapper\Resources\1.jpg");
                        this.pictureBox1.Image = image;
                        break;
                    }
                case 2:
                    {
                        Image image = new Bitmap(@"C:\Users\markk\OneDrive\Рабочий стол\РИСПО\Сапер\Sapper\Sapper\Resources\2.jpg");
                        this.pictureBox1.Image = image;
                        break;
                    }
                case 3:
                    {
                        Image image = new Bitmap(@"C:\Users\markk\OneDrive\Рабочий стол\РИСПО\Сапер\Sapper\Sapper\Resources\3.jpg");
                        this.pictureBox1.Image = image;
                        break;
                    }
                case 4:
                    {
                        Image image = new Bitmap(@"C:\Users\markk\OneDrive\Рабочий стол\РИСПО\Сапер\Sapper\Sapper\Resources\4.jpg");
                        this.pictureBox1.Image = image;
                        break;
                    }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 f2 = new Form2(data, BackGround);
            f2.Show();
            this.Dispose();
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
        }

        private void button6_Click(object sender, EventArgs e)
        {
            Form1 f1 = new Form1();
            f1.Show();
            this.Close();
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            Form6 f6 = new Form6(data, BackGround);
            f6.Show();
            this.Dispose();
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (OleDbConnection dbConnection1 = new OleDbConnection(connectionString1))
            {
                try
                {
                    dbConnection1.Open();
                    string query1 = "UPDATE FON SET BackGround = @BackGround WHERE Login = @Login";
                    using (OleDbCommand command1 = new OleDbCommand(query1, dbConnection1))
                    {
                        BackGround = 1;
                        command1.Parameters.AddWithValue("@BackGround", BackGround);
                        command1.Parameters.AddWithValue("@Login", data);
                        command1.ExecuteNonQuery();
                    }
                    Image image = new Bitmap(@"C:\Users\markk\OneDrive\Рабочий стол\РИСПО\Сапер\Sapper\Sapper\Resources\1.jpg");
                    this.pictureBox1.Image = image;
                    dbConnection1.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            using (OleDbConnection dbConnection1 = new OleDbConnection(connectionString1))
            {
                try
                {
                    dbConnection1.Open();
                    string query1 = "UPDATE FON SET BackGround = @BackGround WHERE Login = @Login";
                    using (OleDbCommand command1 = new OleDbCommand(query1, dbConnection1))
                    {
                        BackGround = 2;
                        command1.Parameters.AddWithValue("@BackGround", BackGround);
                        command1.Parameters.AddWithValue("@Login", data);
                        command1.ExecuteNonQuery();
                    }
                    Image image = new Bitmap(@"C:\Users\markk\OneDrive\Рабочий стол\РИСПО\Сапер\Sapper\Sapper\Resources\2.jpg");
                    this.pictureBox1.Image = image;
                    dbConnection1.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            using (OleDbConnection dbConnection1 = new OleDbConnection(connectionString1))
            {
                try
                {
                    dbConnection1.Open();
                    string query1 = "UPDATE FON SET BackGround = @BackGround WHERE Login = @Login";
                    using (OleDbCommand command1 = new OleDbCommand(query1, dbConnection1))
                    {
                        BackGround = 3;
                        command1.Parameters.AddWithValue("@BackGround", BackGround);
                        command1.Parameters.AddWithValue("@Login", data);
                        command1.ExecuteNonQuery();
                    }
                    Image image = new Bitmap(@"C:\Users\markk\OneDrive\Рабочий стол\РИСПО\Сапер\Sapper\Sapper\Resources\3.jpg");
                    this.pictureBox1.Image = image;
                    dbConnection1.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            using (OleDbConnection dbConnection1 = new OleDbConnection(connectionString1))
            {
                try
                {
                    dbConnection1.Open();
                    string query1 = "UPDATE FON SET BackGround = @BackGround WHERE Login = @Login";
                    using (OleDbCommand command1 = new OleDbCommand(query1, dbConnection1))
                    {
                        BackGround = 4;
                        command1.Parameters.AddWithValue("@BackGround", BackGround);
                        command1.Parameters.AddWithValue("@Login", data);
                        command1.ExecuteNonQuery();
                    }
                    Image image = new Bitmap(@"C:\Users\markk\OneDrive\Рабочий стол\РИСПО\Сапер\Sapper\Sapper\Resources\4.jpg");
                    this.pictureBox1.Image = image;
                    dbConnection1.Close();
                }
                catch
                {
                    MessageBox.Show("Ошибка");
                }
            }
        }
    }
}
