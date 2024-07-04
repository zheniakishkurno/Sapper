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
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Data.Common;

namespace Sapper
{
    public partial class Form6 : Form
    {
        string data;
        int BackGround = 1;
        public Form6(string data, int BacKGround)
        {
            InitializeComponent();
            this.data = data;
            this.BackGround = BacKGround;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
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
            dataGridView1.Visible = false;
            Form5 f5 = new Form5(data, BackGround);
            f5.Show();
            this.Dispose();
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
        }
        private void button2_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string connectionString1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Tabl.mdb";
            OleDbConnection command1 = new OleDbConnection(connectionString1);
            command1.Open();
            string query1 = "SELECT * FROM Tabl";
            OleDbCommand dbCommand = new OleDbCommand(query1, command1);
            OleDbDataReader reader = dbCommand.ExecuteReader();
            if (reader.HasRows == false)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Login"], reader["Time"]);
                    dataGridView1.Sort(dataGridView1.Columns["Time"], ListSortDirection.Ascending);
                }
            }
            reader.Close();
            command1.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string connectionString2 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Tabl2.mdb";
            OleDbConnection command2 = new OleDbConnection(connectionString2);
            command2.Open();
            string query2 = "SELECT * FROM Tabl2";
            OleDbCommand dbCommand1 = new OleDbCommand(query2, command2);
            OleDbDataReader reader = dbCommand1.ExecuteReader();
            if (reader.HasRows == false)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Login"], reader["Time"]);
                    dataGridView1.Sort(dataGridView1.Columns["Time"], ListSortDirection.Ascending);
                }
            }
            reader.Close();
            command2.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            dataGridView1.Visible = true;
            dataGridView1.Rows.Clear();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            string connectionString3 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Tabl3.mdb";
            OleDbConnection command3 = new OleDbConnection(connectionString3);
            command3.Open();
            string query3 = "SELECT * FROM Tabl3";
            OleDbCommand dbCommand2 = new OleDbCommand(query3, command3);
            OleDbDataReader reader = dbCommand2.ExecuteReader();
            if (reader.HasRows == false)
            {
                MessageBox.Show("Ошибка");
            }
            else
            {
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Login"], reader["Time"]);
                    dataGridView1.Sort(dataGridView1.Columns["Time"], ListSortDirection.Ascending);
                }
            }
            reader.Close();
            command3.Close();
        }
    }
}
