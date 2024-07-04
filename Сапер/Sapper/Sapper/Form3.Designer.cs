namespace Sapper
{
    partial class Form3
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form3));
            pictureBox1 = new PictureBox();
            button1 = new Button();
            radioButton1 = new RadioButton();
            radioButton2 = new RadioButton();
            radioButton3 = new RadioButton();
            label1 = new Label();
            button2 = new Button();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(979, 591);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkGray;
            button1.Cursor = Cursors.Hand;
            button1.FlatAppearance.BorderSize = 0;
            button1.FlatAppearance.MouseDownBackColor = Color.Silver;
            button1.FlatAppearance.MouseOverBackColor = Color.LightGray;
            button1.FlatStyle = FlatStyle.Flat;
            button1.Font = new Font("Microsoft YaHei", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            button1.Location = new Point(12, 12);
            button1.Name = "button1";
            button1.Size = new Size(132, 51);
            button1.TabIndex = 1;
            button1.Text = "Назад";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // radioButton1
            // 
            radioButton1.BackColor = Color.DarkGray;
            radioButton1.Cursor = Cursors.Hand;
            radioButton1.Font = new Font("Microsoft YaHei", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton1.Location = new Point(34, 214);
            radioButton1.Name = "radioButton1";
            radioButton1.Size = new Size(439, 63);
            radioButton1.TabIndex = 2;
            radioButton1.Text = "Новичок 8х8";
            radioButton1.UseVisualStyleBackColor = false;
            // 
            // radioButton2
            // 
            radioButton2.BackColor = Color.DarkGray;
            radioButton2.Cursor = Cursors.Hand;
            radioButton2.Font = new Font("Microsoft YaHei", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton2.Location = new Point(34, 340);
            radioButton2.Name = "radioButton2";
            radioButton2.Size = new Size(439, 63);
            radioButton2.TabIndex = 3;
            radioButton2.Text = "Любитель 16х16";
            radioButton2.UseVisualStyleBackColor = false;
            // 
            // radioButton3
            // 
            radioButton3.BackColor = Color.DarkGray;
            radioButton3.Cursor = Cursors.Hand;
            radioButton3.Font = new Font("Microsoft YaHei", 26.25F, FontStyle.Bold, GraphicsUnit.Point);
            radioButton3.Location = new Point(34, 454);
            radioButton3.Name = "radioButton3";
            radioButton3.Size = new Size(439, 63);
            radioButton3.TabIndex = 4;
            radioButton3.Text = "Профессионал  25x25";
            radioButton3.UseVisualStyleBackColor = false;
            // 
            // label1
            // 
            label1.Font = new Font("Microsoft YaHei", 72F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(193, 12);
            label1.Name = "label1";
            label1.Size = new Size(603, 143);
            label1.TabIndex = 5;
            label1.Text = "Уровень";
            label1.TextAlign = ContentAlignment.TopCenter;
            // 
            // button2
            // 
            button2.BackColor = Color.DarkGray;
            button2.Cursor = Cursors.Hand;
            button2.FlatAppearance.BorderSize = 0;
            button2.FlatAppearance.MouseDownBackColor = Color.Silver;
            button2.FlatAppearance.MouseOverBackColor = Color.LightGray;
            button2.FlatStyle = FlatStyle.Flat;
            button2.Font = new Font("Microsoft YaHei", 36F, FontStyle.Bold, GraphicsUnit.Point);
            button2.Location = new Point(603, 300);
            button2.Name = "button2";
            button2.RightToLeft = RightToLeft.No;
            button2.Size = new Size(245, 133);
            button2.TabIndex = 6;
            button2.Text = "Начать";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // Form3
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(979, 587);
            Controls.Add(button2);
            Controls.Add(label1);
            Controls.Add(radioButton3);
            Controls.Add(radioButton2);
            Controls.Add(radioButton1);
            Controls.Add(button1);
            Controls.Add(pictureBox1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Form3";
            Text = "Form3";
            Load += Form3_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox pictureBox1;
        private Button button1;
        private RadioButton radioButton1;
        private RadioButton radioButton2;
        private RadioButton radioButton3;
        private Label label1;
        private Button button2;
    }
}