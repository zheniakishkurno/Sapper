using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using static System.Windows.Forms.DataFormats;

namespace Sapper
{
    public partial class Form7 : Form
    {
        private static string connectionString2 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Tabl2.mdb";

        //сама игра 
        public const int mapSize = 16;
        public const int celllSize = 35;

        private static int currentPictureToSet = 0;

        public static int[,] map = new int[mapSize, mapSize];

        public static Button[,] buttons = new Button[mapSize, mapSize];

        public static Image spriteSet;

        private static bool isFirstStep;

        private static Point firstCoord;

        private static int revealedCellsCount = 0;

        public static int number;

        private static Stopwatch stopwatch = new Stopwatch();
        private string data;

        private int BackGround = 1;

        int Time;
        static int a, b;
        public Form7(string data, int BacKGround)
        {
            Controls.Clear();
            InitializeComponent();
            Init();
            this.data = data;
            this.BackGround = BacKGround;

        }
        private void Init()
        {

            revealedCellsCount = 0;
            currentPictureToSet = 0;
            isFirstStep = true;
            string relativePath = @"C:\Users\markk\OneDrive\Рабочий стол\РИСПО\Сапер\Sapper\Sapper\Sprites\tiles.png";
            string absolutePath = Path.GetFullPath(relativePath);
            spriteSet = new Bitmap(absolutePath);
            ConfigureMapSize();
            InitMap();
            InitButtons();
            stopwatch.Start();
        }



        private void ConfigureMapSize()
        {
            this.panel1.Width = mapSize * celllSize;
            this.panel1.Height = mapSize * celllSize;
        }
        private void InitMap()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    map[i, j] = 0;
                }
            }
        }
        private void InitButtons()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    Button button = new Button();
                    button.Location = new Point(j * celllSize, i * celllSize);
                    button.Size = new Size(celllSize, celllSize);
                    button.Image = FindNeededImage(0, 0);
                    button.MouseUp += new MouseEventHandler(OnButtonMouse);
                    this.panel1.Controls.Add(button);
                    buttons[i, j] = button;
                }
            }
        }

        private void OnButtonMouse(object sender, MouseEventArgs e)
        {
            Button pressedButton = sender as Button;
            switch (e.Button.ToString())
            {
                case "Right":
                    OnRightButtonPressed(pressedButton);
                    break;
                case "Left":
                    OnLeftButtonPressed(pressedButton, this);
                    break;
            }
        }

        private static void OnRightButtonPressed(Button pressedButton)
        {
            currentPictureToSet++;
            currentPictureToSet %= 3;
            int PosX = 0;
            int PosY = 0;
            switch (currentPictureToSet)
            {
                case 0:
                    PosX = 0;
                    PosY = 0;
                    break;
                case 1:
                    PosX = 0;
                    PosY = 2;
                    break;
                case 2:
                    PosX = 2;
                    PosY = 2;
                    break;
            }
            pressedButton.Image = FindNeededImage(PosX, PosY);
        }

        private static void OnLeftButtonPressed(Button pressedButton, Form7 form7)
        {
            string data = form7.data;
            int BackGround = form7.BackGround;
            pressedButton.Enabled = false;
            int iButton = pressedButton.Location.Y / celllSize;
            int jButton = pressedButton.Location.X / celllSize;
            if (isFirstStep)
            {
                firstCoord = new Point(jButton, iButton);
                SeedMap();
                CountCellBomb();
                isFirstStep = false;
            }
            OpenCells(iButton, jButton);

            if (map[iButton, jButton] == -1)
            {
                ShowAllBombs(iButton, jButton);
                MessageBox.Show("Поражение");
                Form3 f3 = new Form3(data, BackGround);
                f3.Show();
                form7.Dispose();
                GC.Collect(4, GCCollectionMode.Forced);
                GC.GetTotalMemory(true);
            }
            if (revealedCellsCount == mapSize * mapSize - number)  // number is the total number of bombs
            {
                stopwatch.Stop();
                MessageBox.Show("Победа. Время: " + stopwatch.Elapsed.ToString(@"mm\:ss"));
                int Time = form7.Time;
                Time = Convert.ToInt32(stopwatch.Elapsed.TotalSeconds);
                using (OleDbConnection dbConnection1 = new OleDbConnection(connectionString2))
                {
                    try
                    {
                        dbConnection1.Open();
                        string query1 = "SELECT COUNT(*) FROM Tabl2 WHERE Login = @Login";
                        using (OleDbCommand command1 = new OleDbCommand(query1, dbConnection1))
                        {
                            command1.Parameters.AddWithValue("@Login", data);
                            int count = Convert.ToInt32(command1.ExecuteScalar());
                            if (count > 0)
                            {
                                string query4 = "SELECT Time FROM Tabl2 WHERE Login = @data";
                                int count2 = 0;
                                using (OleDbCommand command4 = new OleDbCommand(query4, dbConnection1))
                                {
                                    command4.Parameters.AddWithValue("@Login", data);
                                    OleDbDataReader reader = command4.ExecuteReader();
                                    while (reader.Read())
                                    {
                                        int count1 = reader.GetInt32(0);
                                        count2 = count1;
                                    }
                                    reader.Close();
                                }
                                if (count2 > Time)
                                {
                                    string query2 = "UPDATE [Tabl2] SET [Time] = @Time WHERE [Login] = @Login";
                                    using (OleDbCommand command2 = new OleDbCommand(query2, dbConnection1))
                                    {
                                        command2.Parameters.AddWithValue("@Time", Time);
                                        command2.Parameters.AddWithValue("@Login", data);
                                        command2.ExecuteNonQuery();
                                    }
                                }
                            }
                            else
                            {
                                using (OleDbConnection dbConnection3 = new OleDbConnection(connectionString2))
                                {
                                    dbConnection3.Open();
                                    string query3 = "INSERT INTO [Tabl2] VALUES (@Login, @Time)";
                                    using (OleDbCommand command3 = new OleDbCommand(query3, dbConnection3))
                                    {
                                        command3.Parameters.AddWithValue("@Login", data);
                                        command3.Parameters.AddWithValue("@Time", Time);
                                        command3.ExecuteNonQuery();
                                    }
                                    dbConnection3.Close();
                                }
                            }
                            dbConnection1.Close();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Ошибка" + ex.Message);
                    }
                    finally
                    {
                        dbConnection1.Close();
                        GC.Collect(4, GCCollectionMode.Forced);
                        GC.GetTotalMemory(true);
                    }
                }
                stopwatch.Reset();
                form7.Time = 0;
                Form3 f3 = new Form3(data, BackGround);
                f3.Show();
                form7.Dispose();
                GC.Collect(4, GCCollectionMode.Forced);
                GC.GetTotalMemory(true);
            }
        }

        private static void ShowAllBombs(int iBomb, int jBomb)
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (i == iBomb && j == jBomb)
                        continue;
                    if (map[i, j] == -1)
                    {
                        buttons[i, j].Image = FindNeededImage(3, 2);
                    }
                }
            }
        }

        public static Image FindNeededImage(int xPos, int yPos)
        {
            Image image = new Bitmap(celllSize, celllSize);
            Graphics g = Graphics.FromImage(image);
            g.DrawImage(spriteSet, new Rectangle(new Point(0, 0), new Size(celllSize, celllSize)), 0 + 32 * xPos, 0 + 32 * yPos, 33, 33, GraphicsUnit.Pixel);


            return image;

        }

        private static void SeedMap()
        {
            Random r = new Random();
            number = r.Next(40,40);

            for (int i = 0; i < number; i++)
            {
                int posI = r.Next(0, mapSize - 1);
                int posJ = r.Next(0, mapSize - 1);
                while (map[posI, posJ] == -1 || (Math.Abs(posI - firstCoord.Y) <= 1 && Math.Abs(posJ - firstCoord.X) <= 1))
                {
                    posI = r.Next(0, mapSize - 1);
                    posJ = r.Next(0, mapSize - 1);
                }
                map[posI, posJ] = -1;
            }
        }

        private static void CountCellBomb()
        {
            for (int i = 0; i < mapSize; i++)
            {
                for (int j = 0; j < mapSize; j++)
                {
                    if (map[i, j] == -1)
                    {
                        for (int k = i - 1; k < i + 2; k++)
                        {
                            for (int l = j - 1; l < j + 2; l++)
                            {
                                if (!IsInBorder(k, l) || map[k, l] == -1)
                                    continue;
                                map[k, l] = map[k, l] + 1;

                            }
                        }
                    }
                }
            }
        }

        private static void OpenCell(int i, int j)
        {
            if (map[i, j] != -1)
            {
                revealedCellsCount++;
            }
            buttons[i, j].Enabled = false;
            switch (map[i, j])
            {
                case 1:
                    buttons[i, j].Image = FindNeededImage(1, 0);
                    break;
                case 2:
                    buttons[i, j].Image = FindNeededImage(2, 0);
                    break;
                case 3:
                    buttons[i, j].Image = FindNeededImage(3, 0);
                    break;
                case 4:
                    buttons[i, j].Image = FindNeededImage(4, 0);
                    break;
                case 5:
                    buttons[i, j].Image = FindNeededImage(0, 1);
                    break;
                case 6:
                    buttons[i, j].Image = FindNeededImage(1, 1);
                    break;
                case 7:
                    buttons[i, j].Image = FindNeededImage(2, 1);
                    break;
                case 8:
                    buttons[i, j].Image = FindNeededImage(3, 1);
                    break;
                case -1:
                    buttons[i, j].Image = FindNeededImage(1, 2);
                    break;
                case 0:
                    buttons[i, j].Image = FindNeededImage(0, 0);
                    break;
            }

        }

        private static void OpenCells(int i, int j)
        {
            OpenCell(i, j);

            if (map[i, j] > 0)
                return;

            for (int k = i - 1; k < i + 2; k++)
            {
                for (int l = j - 1; l < j + 2; l++)
                {
                    if (!IsInBorder(k, l))
                        continue;
                    if (!buttons[k, l].Enabled)
                        continue;
                    if (map[k, l] == 0)
                        OpenCells(k, l);
                    else if (map[k, l] > 0)
                        OpenCell(k, l);
                }
            }
        }
        private static bool IsInBorder(int i, int j)
        {
            if (i < 0 || j < 0 || j > mapSize - 1 || i > mapSize - 1)
            {
                return false;
            }
            return true;
        }
        //Сама игра
        private void button1_Click(object sender, EventArgs e)
        {
            Form3 f3 = new Form3(data, BackGround);
            f3.Show();
            this.Dispose();
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {

        }

        private void Form7_Load(object sender, EventArgs e)
        {
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
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
        int count = 0;
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (count == 4)
            {
                ShowAllBombs(a, b);
                count = 0;
            }
            count++;
        }
    }
}
