using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.DataFormats;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.TrayNotify;
using System.Data.OleDb;

namespace Sapper
{
    public partial class Form3 : Form
    {
        string data;
        int BackGround = 1;
        private string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Users.mdb";
        private string connectionString1 = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=FON.mdb";
        public Form3(string data, int BackGround)
        {
            Controls.Clear();
            this.data = data;
            this.BackGround = BackGround;
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
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
            Form2 f2 = new Form2(data, BackGround);
            f2.Show();
            this.Dispose();
            GC.Collect(4, GCCollectionMode.Forced);
            GC.GetTotalMemory(true);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked == true)
            {
                Form4 f4 = new Form4(data, BackGround);
                f4.Show();
                this.Dispose();
                GC.Collect(4, GCCollectionMode.Forced);
                GC.GetTotalMemory(true);
            }
            else
            {
                if (radioButton2.Checked == true)
                {
                    Form7 f7 = new Form7(data, BackGround);
                    f7.Show();
                    this.Dispose();
                    GC.Collect(4, GCCollectionMode.Forced);
                    GC.GetTotalMemory(true);
                }
                else
                {
                    if (radioButton3.Checked == true)
                    {
                        Form8 f8 = new Form8(data, BackGround);
                        f8.Show();
                        this.Dispose();
                        GC.Collect(4, GCCollectionMode.Forced);
                        GC.GetTotalMemory(true);
                    }
                }
            }
        }
    }
}
