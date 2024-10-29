namespace Stove_Calculator
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            contextMenuStrip1 = new ContextMenuStrip(components);
            panel1 = new Panel();
            iconButton9 = new FontAwesome.Sharp.IconButton();
            iconButton8 = new FontAwesome.Sharp.IconButton();
            iconButton7 = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            panel15 = new Panel();
            panel16 = new Panel();
            iconButton11 = new FontAwesome.Sharp.IconButton();
            iconButton10 = new FontAwesome.Sharp.IconButton();
            panel14 = new Panel();
            panel6 = new Panel();
            panel10 = new Panel();
            panel8 = new Panel();
            panel12 = new Panel();
            iconButton6 = new FontAwesome.Sharp.IconButton();
            panel13 = new Panel();
            iconButton5 = new FontAwesome.Sharp.IconButton();
            panel11 = new Panel();
            iconButton4 = new FontAwesome.Sharp.IconButton();
            panel9 = new Panel();
            iconButton3 = new FontAwesome.Sharp.IconButton();
            panel7 = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            panel5 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel3 = new Panel();
            pictureBox1 = new PictureBox();
            panel4 = new Panel();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel16.SuspendLayout();
            panel13.SuspendLayout();
            panel11.SuspendLayout();
            panel9.SuspendLayout();
            panel7.SuspendLayout();
            panel5.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(46, 46, 50);
            panel1.Controls.Add(iconButton9);
            panel1.Controls.Add(iconButton8);
            panel1.Controls.Add(iconButton7);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(1500, 55);
            panel1.TabIndex = 21;
            panel1.DoubleClick += panel1_DoubleClick;
            panel1.MouseDown += panel1_MouseDown;
            panel1.MouseMove += panel1_MouseMove;
            panel1.MouseUp += panel1_MouseUp;
            // 
            // iconButton9
            // 
            iconButton9.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton9.Cursor = Cursors.Hand;
            iconButton9.FlatAppearance.BorderSize = 0;
            iconButton9.FlatStyle = FlatStyle.Flat;
            iconButton9.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            iconButton9.IconColor = Color.White;
            iconButton9.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton9.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton9.Location = new Point(1311, 0);
            iconButton9.Name = "iconButton9";
            iconButton9.Size = new Size(59, 55);
            iconButton9.TabIndex = 23;
            iconButton9.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton9.UseVisualStyleBackColor = true;
            iconButton9.Click += iconButton9_Click;
            // 
            // iconButton8
            // 
            iconButton8.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton8.Cursor = Cursors.Hand;
            iconButton8.FlatAppearance.BorderSize = 0;
            iconButton8.FlatStyle = FlatStyle.Flat;
            iconButton8.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            iconButton8.IconColor = Color.White;
            iconButton8.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton8.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton8.Location = new Point(1376, 0);
            iconButton8.Name = "iconButton8";
            iconButton8.Size = new Size(59, 55);
            iconButton8.TabIndex = 23;
            iconButton8.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton8.UseVisualStyleBackColor = true;
            iconButton8.Click += iconButton8_Click;
            // 
            // iconButton7
            // 
            iconButton7.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconButton7.Cursor = Cursors.Hand;
            iconButton7.FlatAppearance.BorderSize = 0;
            iconButton7.FlatStyle = FlatStyle.Flat;
            iconButton7.IconChar = FontAwesome.Sharp.IconChar.TimesRectangle;
            iconButton7.IconColor = Color.White;
            iconButton7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton7.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton7.Location = new Point(1441, 0);
            iconButton7.Name = "iconButton7";
            iconButton7.Size = new Size(59, 55);
            iconButton7.TabIndex = 22;
            iconButton7.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton7.UseVisualStyleBackColor = true;
            iconButton7.Click += iconButton7_Click_1;
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(46, 46, 50);
            panel2.Controls.Add(panel15);
            panel2.Controls.Add(panel16);
            panel2.Controls.Add(iconButton10);
            panel2.Controls.Add(panel14);
            panel2.Controls.Add(panel6);
            panel2.Controls.Add(panel10);
            panel2.Controls.Add(panel8);
            panel2.Controls.Add(panel12);
            panel2.Controls.Add(iconButton6);
            panel2.Controls.Add(panel13);
            panel2.Controls.Add(panel11);
            panel2.Controls.Add(panel9);
            panel2.Controls.Add(panel7);
            panel2.Controls.Add(panel5);
            panel2.Controls.Add(panel3);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 55);
            panel2.Name = "panel2";
            panel2.Size = new Size(236, 845);
            panel2.TabIndex = 22;
            // 
            // panel15
            // 
            panel15.BackColor = Color.Yellow;
            panel15.Location = new Point(0, 360);
            panel15.Name = "panel15";
            panel15.Size = new Size(12, 71);
            panel15.TabIndex = 25;
            // 
            // panel16
            // 
            panel16.Controls.Add(iconButton11);
            panel16.Cursor = Cursors.Hand;
            panel16.Font = new Font("Times New Roman", 12F);
            panel16.ForeColor = SystemColors.Control;
            panel16.Location = new Point(12, 360);
            panel16.Margin = new Padding(3, 10, 3, 3);
            panel16.Name = "panel16";
            panel16.Size = new Size(233, 71);
            panel16.TabIndex = 26;
            // 
            // iconButton11
            // 
            iconButton11.Dock = DockStyle.Bottom;
            iconButton11.FlatAppearance.BorderSize = 0;
            iconButton11.FlatStyle = FlatStyle.Flat;
            iconButton11.IconChar = FontAwesome.Sharp.IconChar.TableCells;
            iconButton11.IconColor = Color.White;
            iconButton11.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton11.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton11.Location = new Point(0, 0);
            iconButton11.Name = "iconButton11";
            iconButton11.Padding = new Padding(10, 0, 0, 0);
            iconButton11.Size = new Size(233, 71);
            iconButton11.TabIndex = 22;
            iconButton11.Text = "Табличные значения";
            iconButton11.TextAlign = ContentAlignment.MiddleLeft;
            iconButton11.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton11.UseVisualStyleBackColor = true;
            iconButton11.Click += iconButton11_Click_1;
            // 
            // iconButton10
            // 
            iconButton10.Cursor = Cursors.Hand;
            iconButton10.Dock = DockStyle.Bottom;
            iconButton10.FlatAppearance.BorderSize = 0;
            iconButton10.FlatStyle = FlatStyle.Flat;
            iconButton10.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            iconButton10.ForeColor = SystemColors.Control;
            iconButton10.IconChar = FontAwesome.Sharp.IconChar.Sun;
            iconButton10.IconColor = Color.White;
            iconButton10.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton10.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton10.Location = new Point(0, 703);
            iconButton10.Margin = new Padding(10, 3, 3, 3);
            iconButton10.Name = "iconButton10";
            iconButton10.Padding = new Padding(10, 0, 0, 0);
            iconButton10.Size = new Size(236, 71);
            iconButton10.TabIndex = 24;
            iconButton10.Text = "Включить светлую тему";
            iconButton10.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton10.UseVisualStyleBackColor = true;
            // 
            // panel14
            // 
            panel14.BackColor = Color.Yellow;
            panel14.Location = new Point(0, 598);
            panel14.Name = "panel14";
            panel14.Size = new Size(12, 71);
            panel14.TabIndex = 20;
            // 
            // panel6
            // 
            panel6.BackColor = Color.Yellow;
            panel6.Location = new Point(0, 199);
            panel6.Name = "panel6";
            panel6.Size = new Size(12, 71);
            panel6.TabIndex = 20;
            // 
            // panel10
            // 
            panel10.BackColor = Color.Yellow;
            panel10.Location = new Point(0, 444);
            panel10.Name = "panel10";
            panel10.Size = new Size(12, 71);
            panel10.TabIndex = 20;
            panel10.Paint += panel10_Paint;
            // 
            // panel8
            // 
            panel8.BackColor = Color.Yellow;
            panel8.Location = new Point(0, 276);
            panel8.Name = "panel8";
            panel8.Size = new Size(12, 71);
            panel8.TabIndex = 20;
            // 
            // panel12
            // 
            panel12.BackColor = Color.Yellow;
            panel12.Location = new Point(0, 521);
            panel12.Name = "panel12";
            panel12.Size = new Size(12, 71);
            panel12.TabIndex = 20;
            // 
            // iconButton6
            // 
            iconButton6.Cursor = Cursors.Hand;
            iconButton6.Dock = DockStyle.Bottom;
            iconButton6.FlatAppearance.BorderSize = 0;
            iconButton6.FlatStyle = FlatStyle.Flat;
            iconButton6.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            iconButton6.ForeColor = SystemColors.Control;
            iconButton6.IconChar = FontAwesome.Sharp.IconChar.PowerOff;
            iconButton6.IconColor = Color.White;
            iconButton6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton6.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton6.Location = new Point(0, 774);
            iconButton6.Margin = new Padding(10, 3, 3, 3);
            iconButton6.Name = "iconButton6";
            iconButton6.Padding = new Padding(10, 0, 0, 0);
            iconButton6.Size = new Size(236, 71);
            iconButton6.TabIndex = 22;
            iconButton6.Text = "Выход";
            iconButton6.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton6.UseVisualStyleBackColor = true;
            iconButton6.Click += iconButton6_Click;
            // 
            // panel13
            // 
            panel13.Controls.Add(iconButton5);
            panel13.Cursor = Cursors.Hand;
            panel13.Font = new Font("Times New Roman", 12F);
            panel13.ForeColor = SystemColors.Control;
            panel13.Location = new Point(12, 598);
            panel13.Margin = new Padding(3, 10, 3, 3);
            panel13.Name = "panel13";
            panel13.Size = new Size(233, 71);
            panel13.TabIndex = 23;
            // 
            // iconButton5
            // 
            iconButton5.Dock = DockStyle.Bottom;
            iconButton5.FlatAppearance.BorderSize = 0;
            iconButton5.FlatStyle = FlatStyle.Flat;
            iconButton5.IconChar = FontAwesome.Sharp.IconChar.CaretSquareRight;
            iconButton5.IconColor = Color.White;
            iconButton5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton5.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton5.Location = new Point(0, 0);
            iconButton5.Name = "iconButton5";
            iconButton5.Padding = new Padding(10, 0, 0, 0);
            iconButton5.Size = new Size(233, 71);
            iconButton5.TabIndex = 22;
            iconButton5.Text = "О программе";
            iconButton5.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton5.UseVisualStyleBackColor = true;
            iconButton5.Click += iconButton5_Click;
            // 
            // panel11
            // 
            panel11.Controls.Add(iconButton4);
            panel11.Cursor = Cursors.Hand;
            panel11.Font = new Font("Times New Roman", 12F);
            panel11.ForeColor = SystemColors.Control;
            panel11.Location = new Point(12, 521);
            panel11.Margin = new Padding(3, 10, 3, 3);
            panel11.Name = "panel11";
            panel11.Size = new Size(233, 71);
            panel11.TabIndex = 22;
            // 
            // iconButton4
            // 
            iconButton4.Dock = DockStyle.Bottom;
            iconButton4.FlatAppearance.BorderSize = 0;
            iconButton4.FlatStyle = FlatStyle.Flat;
            iconButton4.IconChar = FontAwesome.Sharp.IconChar.BookOpen;
            iconButton4.IconColor = Color.White;
            iconButton4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton4.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton4.Location = new Point(0, 0);
            iconButton4.Name = "iconButton4";
            iconButton4.Padding = new Padding(10, 0, 0, 0);
            iconButton4.Size = new Size(233, 71);
            iconButton4.TabIndex = 22;
            iconButton4.Text = "Как пользоваться";
            iconButton4.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton4.UseVisualStyleBackColor = true;
            iconButton4.Click += iconButton4_Click;
            // 
            // panel9
            // 
            panel9.Controls.Add(iconButton3);
            panel9.Cursor = Cursors.Hand;
            panel9.Font = new Font("Times New Roman", 12F);
            panel9.ForeColor = SystemColors.Control;
            panel9.Location = new Point(12, 444);
            panel9.Margin = new Padding(3, 10, 3, 3);
            panel9.Name = "panel9";
            panel9.Size = new Size(233, 71);
            panel9.TabIndex = 21;
            // 
            // iconButton3
            // 
            iconButton3.Dock = DockStyle.Bottom;
            iconButton3.FlatAppearance.BorderSize = 0;
            iconButton3.FlatStyle = FlatStyle.Flat;
            iconButton3.IconChar = FontAwesome.Sharp.IconChar.BookBookmark;
            iconButton3.IconColor = Color.White;
            iconButton3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton3.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton3.Location = new Point(0, 0);
            iconButton3.Name = "iconButton3";
            iconButton3.Padding = new Padding(10, 0, 0, 0);
            iconButton3.Size = new Size(233, 71);
            iconButton3.TabIndex = 22;
            iconButton3.Text = "Теория";
            iconButton3.TextAlign = ContentAlignment.MiddleLeft;
            iconButton3.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton3.UseVisualStyleBackColor = true;
            iconButton3.Click += iconButton3_Click;
            // 
            // panel7
            // 
            panel7.Controls.Add(iconButton2);
            panel7.Cursor = Cursors.Hand;
            panel7.Font = new Font("Times New Roman", 12F);
            panel7.ForeColor = SystemColors.Control;
            panel7.Location = new Point(3, 276);
            panel7.Margin = new Padding(3, 10, 3, 3);
            panel7.Name = "panel7";
            panel7.Size = new Size(233, 71);
            panel7.TabIndex = 20;
            // 
            // iconButton2
            // 
            iconButton2.Dock = DockStyle.Bottom;
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.T;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton2.Location = new Point(0, 0);
            iconButton2.Name = "iconButton2";
            iconButton2.Padding = new Padding(10, 0, 0, 0);
            iconButton2.Size = new Size(233, 71);
            iconButton2.TabIndex = 22;
            iconButton2.Text = "Трубчатая печь";
            iconButton2.TextAlign = ContentAlignment.MiddleLeft;
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = true;
            iconButton2.Click += iconButton2_Click;
            // 
            // panel5
            // 
            panel5.Controls.Add(iconButton1);
            panel5.Cursor = Cursors.Hand;
            panel5.Font = new Font("Times New Roman", 12F);
            panel5.ForeColor = SystemColors.Control;
            panel5.Location = new Point(3, 199);
            panel5.Margin = new Padding(3, 10, 3, 3);
            panel5.Name = "panel5";
            panel5.Size = new Size(233, 71);
            panel5.TabIndex = 19;
            // 
            // iconButton1
            // 
            iconButton1.Dock = DockStyle.Bottom;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.K;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.ImageAlign = ContentAlignment.MiddleLeft;
            iconButton1.Location = new Point(0, 0);
            iconButton1.Name = "iconButton1";
            iconButton1.Padding = new Padding(10, 0, 0, 0);
            iconButton1.Size = new Size(233, 71);
            iconButton1.TabIndex = 21;
            iconButton1.Text = "Камерная печь";
            iconButton1.TextAlign = ContentAlignment.MiddleLeft;
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = true;
            iconButton1.Click += iconButton1_Click;
            // 
            // panel3
            // 
            panel3.Controls.Add(pictureBox1);
            panel3.Location = new Point(0, 0);
            panel3.Name = "panel3";
            panel3.Size = new Size(236, 163);
            panel3.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(236, 165);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // panel4
            // 
            panel4.BackColor = Color.FromArgb(52, 52, 52);
            panel4.Dock = DockStyle.Fill;
            panel4.Location = new Point(236, 55);
            panel4.Name = "panel4";
            panel4.Size = new Size(1264, 845);
            panel4.TabIndex = 23;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1500, 900);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "MainForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Главная страница";
            FormClosing += MainForm_FormClosing;
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel16.ResumeLayout(false);
            panel13.ResumeLayout(false);
            panel11.ResumeLayout(false);
            panel9.ResumeLayout(false);
            panel7.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel3.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private Panel panel1;
        private Panel panel2;
        private Panel panel3;
        private Panel panel4;
        private PictureBox pictureBox1;
        private Panel panel5;
        private Panel panel6;
        private Panel panel13;
        private Panel panel14;
        private Panel panel11;
        private Panel panel12;
        private Panel panel9;
        private Panel panel10;
        private Panel panel7;
        private Panel panel8;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private FontAwesome.Sharp.IconButton iconButton5;
        private FontAwesome.Sharp.IconButton iconButton4;
        private FontAwesome.Sharp.IconButton iconButton3;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private FontAwesome.Sharp.IconButton iconButton6;
        private FontAwesome.Sharp.IconButton iconButton7;
        private FontAwesome.Sharp.IconButton iconButton9;
        private FontAwesome.Sharp.IconButton iconButton8;
        private FontAwesome.Sharp.IconButton iconButton10;
        private Panel panel15;
        private Panel panel16;
        private FontAwesome.Sharp.IconButton iconButton11;
    }
}
