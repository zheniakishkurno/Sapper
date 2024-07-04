using Microsoft.VisualBasic.Logging;
using System.Data.OleDb;
using System.Diagnostics.Eventing.Reader;

namespace Sapper
{
    public partial class Form1 : Form
    {
        string data;
        int BackGround = 1;
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.mdb";
        private string connectionString1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FON.mdb";
        private void Connect()
        {
            using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
            {
                try
                {
                    dbConnection.Open();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка подключения к базе данных:" + ex.Message);
                }
                finally
                {
                    dbConnection.Close();
                }
            }
        }
        public Form1()
        {
            InitializeComponent();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
        }
        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = true;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            pictureBox5.Visible = true;
            pictureBox6.Visible = true;
            button2.Visible = true;

            button1.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            textBox3.Clear();
            pictureBox4.Visible = true;
        }
        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            textBox1.Visible = true;
            textBox2.Visible = true;
            textBox3.Visible = false;
            pictureBox5.Visible = false;
            pictureBox6.Visible = false;
            pictureBox2.Visible = true;
            pictureBox3.Visible = true;
            button1.Visible = true;
            button2.Visible = false;
            textBox1.Clear();
            textBox2.Clear();
            pictureBox4.Visible = true;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void pictureBox4_MouseDown(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = false;
        }

        private void pictureBox4_MouseUp(object sender, MouseEventArgs e)
        {
            textBox2.UseSystemPasswordChar = true;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox3.Text == textBox2.Text)
            {
                
                    if (textBox1.Text == "" && textBox2.Text == "" || textBox1.Text == "" || textBox2.Text == "")
                    {
                        MessageBox.Show("Все поля обязательны для заполнения");
                    }
                    else
                    {
                    if (textBox2.TextLength < 5)
                    {
                        MessageBox.Show("Пароль должен быть создан не менее из 5 символов");
                    }
                    else
                    {
                        string login = textBox1.Text;
                        string password = textBox2.Text;

                        using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
                        {
                            try
                            {
                                dbConnection.Open();
                                string query = "SELECT COUNT(*) FROM Users WHERE Login = @Login";
                                using (OleDbCommand command = new OleDbCommand(query, dbConnection))
                                {
                                    command.Parameters.AddWithValue("@Login", login);
                                    int count = (int)command.ExecuteScalar();
                                    if (count > 0)
                                    {
                                        MessageBox.Show("Имя пользователя уже занято. Пожалуйста, выберите другое");
                                        return;
                                    }
                                    else
                                    {
                                        this.data = login;
                                        using (OleDbConnection dbConnection1 = new OleDbConnection(connectionString1))
                                        {
                                            try
                                            {
                                                dbConnection1.Open();
                                                string query1 = "INSERT INTO FON VALUES (@Login, @BackGround)";
                                                using (OleDbCommand command1 = new OleDbCommand(query1, dbConnection1))
                                                {
                                                    command1.Parameters.AddWithValue("@Login", login);
                                                    command1.Parameters.AddWithValue("@BackGround", "1");
                                                    command1.ExecuteNonQuery();
                                                }
                                            }
                                            catch
                                            {
                                                MessageBox.Show("Ошибка");
                                            }
                                            finally
                                            {
                                                dbConnection1.Close();
                                                GC.Collect(4, GCCollectionMode.Forced);
                                                GC.GetTotalMemory(true);
                                            }
                                        }
                                        Form2 f2 = new Form2(data, BackGround);
                                        f2.Show();
                                        this.Hide();
                                        GC.Collect(4, GCCollectionMode.Forced);
                                        GC.GetTotalMemory(true);

                                    }
                                }
                                query = "INSERT INTO Users VALUES (@Login, @Password)";
                                using (OleDbCommand command = new OleDbCommand(query, dbConnection))
                                {
                                    command.Parameters.AddWithValue("@Login", login);
                                    command.Parameters.AddWithValue("@Password", password);
                                    command.ExecuteNonQuery();
                                }
                                MessageBox.Show("Регистрацмя прошла успешно.");
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show("Ошибка при регистрации:" + ex.Message);
                            }
                            finally
                            {
                                dbConnection.Close();
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Пороли не совпадают");
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" && textBox2.Text == "" || textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Все поля обязательны для заполнения");
            }
            else
            {
                string login = textBox1.Text;
                string password = textBox2.Text;
                using (OleDbConnection dbConnection = new OleDbConnection(connectionString))
                {
                    try
                    {
                        dbConnection.Open();
                        string query = "SELECT COUNT(*) FROM Users WHERE Login = @Login AND Password = @Password";
                        using (OleDbCommand command = new OleDbCommand(query, dbConnection))
                        {
                            command.Parameters.AddWithValue("@Login", login);
                            command.Parameters.AddWithValue("@Password", password);
                            int count = (int)command.ExecuteScalar();
                            if (count > 0)
                            {
                                this.data = login;
                                MessageBox.Show("С успешный вход в аккаунт: " + data);
                                Form2 f2 = new Form2(data, BackGround);
                                f2.Show();
                                this.Hide();
                                GC.Collect(4, GCCollectionMode.Forced);
                                GC.GetTotalMemory(true);
                            }
                            else
                            {
                                MessageBox.Show("Неврное имя пользователя или пароль");
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
            }

        }
        private void pictureBox6_MouseDown(object sender, MouseEventArgs e)
        {
            textBox3.UseSystemPasswordChar = false;
        }

        private void pictureBox6_MouseUp(object sender, MouseEventArgs e)
        {
            textBox3.UseSystemPasswordChar = true;
        }
    }
}