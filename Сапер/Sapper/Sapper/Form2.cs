using Microsoft.VisualBasic.ApplicationServices;
using Microsoft.VisualBasic.Logging;
using Sapper.Properties;
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
namespace Sapper
{
    public partial class Form2 : Form
    {
        private string data;
        int BackGround = 1;
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.mdb";
        private string connectionString1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FON.mdb";
        public Form2(string data, int BackGround)
        {
            Controls.Clear();
            InitializeComponent();
            this.data = data;
            this.BackGround = BackGround;

        }

        private void Form2_Load(object sender, EventArgs e)
        {
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
            label1.Parent = pictureBox1;
            label1.BackColor = Color.Transparent;
            using (OleDbConnection dbConnection = new OleDbConnection(connectionString1))
            {
                try
                {
                    dbConnection.Open();
                    string query = "SELECT BackGround FROM FON WHERE Login = data";
                    using (OleDbCommand command = new OleDbCommand(query, dbConnection))
                    {
                        command.Parameters.AddWithValue("@Login", data);
                        OleDbDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            BackGround = reader.GetInt32(0);
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка при авторизации:" + ex.Message);
                }
                finally
                {
                    dbConnection.Close();
                    GC.Collect(4, GCCollectionMode.Forced);
                    GC.GetTotalMemory(true);
                }
            }
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
        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(data, BackGround);
            f3.Show();
            this.Dispose();
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 f5 = new Form5(data, BackGround);
            f5.Show();
            this.Dispose();
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
        }
    }
}
