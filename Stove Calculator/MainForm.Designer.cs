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
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panelMenu = new Panel();
            exitBtn = new FontAwesome.Sharp.IconButton();
            theoryBtn = new FontAwesome.Sharp.IconButton();
            tableBtn = new FontAwesome.Sharp.IconButton();
            tubeBtn = new FontAwesome.Sharp.IconButton();
            chamberBtn = new FontAwesome.Sharp.IconButton();
            panelLogo = new Panel();
            btnHome = new PictureBox();
            panelTitleBar = new Panel();
            minimizeBtn = new FontAwesome.Sharp.IconButton();
            maximizeBtn = new FontAwesome.Sharp.IconButton();
            btnExit = new FontAwesome.Sharp.IconButton();
            lblTitleChildForm = new Label();
            iconCurrentChildForm = new FontAwesome.Sharp.IconPictureBox();
            panelShadow = new Panel();
            panelDesktop = new Panel();
            lblClock = new Label();
            pictureBox1 = new PictureBox();
            tmrClock = new System.Windows.Forms.Timer(components);
            panelMenu.SuspendLayout();
            panelLogo.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)btnHome).BeginInit();
            panelTitleBar.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).BeginInit();
            panelDesktop.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // contextMenuStrip1
            // 
            contextMenuStrip1.ImageScalingSize = new Size(20, 20);
            contextMenuStrip1.Name = "contextMenuStrip1";
            contextMenuStrip1.Size = new Size(61, 4);
            // 
            // panelMenu
            // 
            panelMenu.BackColor = Color.FromArgb(31, 30, 68);
            panelMenu.Controls.Add(exitBtn);
            panelMenu.Controls.Add(theoryBtn);
            panelMenu.Controls.Add(tableBtn);
            panelMenu.Controls.Add(tubeBtn);
            panelMenu.Controls.Add(chamberBtn);
            panelMenu.Controls.Add(panelLogo);
            panelMenu.Dock = DockStyle.Left;
            panelMenu.Location = new Point(0, 0);
            panelMenu.Margin = new Padding(4, 3, 4, 3);
            panelMenu.Name = "panelMenu";
            panelMenu.Size = new Size(344, 900);
            panelMenu.TabIndex = 1;
            // 
            // exitBtn
            // 
            exitBtn.Dock = DockStyle.Top;
            exitBtn.FlatAppearance.BorderSize = 0;
            exitBtn.FlatStyle = FlatStyle.Flat;
            exitBtn.ForeColor = Color.White;
            exitBtn.IconChar = FontAwesome.Sharp.IconChar.PersonChalkboard;
            exitBtn.IconColor = Color.White;
            exitBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            exitBtn.ImageAlign = ContentAlignment.MiddleLeft;
            exitBtn.Location = new Point(0, 478);
            exitBtn.Margin = new Padding(4, 3, 4, 3);
            exitBtn.Name = "exitBtn";
            exitBtn.Padding = new Padding(10, 0, 20, 0);
            exitBtn.Size = new Size(344, 85);
            exitBtn.TabIndex = 7;
            exitBtn.Text = "Как пользоваться";
            exitBtn.TextAlign = ContentAlignment.MiddleLeft;
            exitBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            exitBtn.UseVisualStyleBackColor = true;
            exitBtn.Click += guideBtn_Click;
            // 
            // theoryBtn
            // 
            theoryBtn.Dock = DockStyle.Top;
            theoryBtn.FlatAppearance.BorderSize = 0;
            theoryBtn.FlatStyle = FlatStyle.Flat;
            theoryBtn.ForeColor = Color.White;
            theoryBtn.IconChar = FontAwesome.Sharp.IconChar.UserGraduate;
            theoryBtn.IconColor = Color.White;
            theoryBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            theoryBtn.ImageAlign = ContentAlignment.MiddleLeft;
            theoryBtn.Location = new Point(0, 393);
            theoryBtn.Margin = new Padding(4, 3, 4, 3);
            theoryBtn.Name = "theoryBtn";
            theoryBtn.Padding = new Padding(10, 0, 20, 0);
            theoryBtn.Size = new Size(344, 85);
            theoryBtn.TabIndex = 6;
            theoryBtn.Text = "Теория";
            theoryBtn.TextAlign = ContentAlignment.MiddleLeft;
            theoryBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            theoryBtn.UseVisualStyleBackColor = true;
            theoryBtn.Click += theoryBtn_Click;
            // 
            // tableBtn
            // 
            tableBtn.Dock = DockStyle.Top;
            tableBtn.FlatAppearance.BorderSize = 0;
            tableBtn.FlatStyle = FlatStyle.Flat;
            tableBtn.ForeColor = Color.White;
            tableBtn.IconChar = FontAwesome.Sharp.IconChar.Table;
            tableBtn.IconColor = Color.White;
            tableBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            tableBtn.ImageAlign = ContentAlignment.MiddleLeft;
            tableBtn.Location = new Point(0, 308);
            tableBtn.Margin = new Padding(4, 3, 4, 3);
            tableBtn.Name = "tableBtn";
            tableBtn.Padding = new Padding(10, 0, 20, 0);
            tableBtn.Size = new Size(344, 85);
            tableBtn.TabIndex = 5;
            tableBtn.Text = "Табличные значения";
            tableBtn.TextAlign = ContentAlignment.MiddleLeft;
            tableBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            tableBtn.UseVisualStyleBackColor = true;
            tableBtn.Click += tableBtn_Click;
            // 
            // tubeBtn
            // 
            tubeBtn.Dock = DockStyle.Top;
            tubeBtn.FlatAppearance.BorderSize = 0;
            tubeBtn.FlatStyle = FlatStyle.Flat;
            tubeBtn.ForeColor = Color.White;
            tubeBtn.IconChar = FontAwesome.Sharp.IconChar.T;
            tubeBtn.IconColor = Color.White;
            tubeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            tubeBtn.ImageAlign = ContentAlignment.MiddleLeft;
            tubeBtn.Location = new Point(0, 223);
            tubeBtn.Margin = new Padding(4, 3, 4, 3);
            tubeBtn.Name = "tubeBtn";
            tubeBtn.Padding = new Padding(10, 0, 20, 0);
            tubeBtn.Size = new Size(344, 85);
            tubeBtn.TabIndex = 4;
            tubeBtn.Text = "Трубчатая печь";
            tubeBtn.TextAlign = ContentAlignment.MiddleLeft;
            tubeBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            tubeBtn.UseVisualStyleBackColor = true;
            tubeBtn.Click += tubeBtn_Click;
            // 
            // chamberBtn
            // 
            chamberBtn.Dock = DockStyle.Top;
            chamberBtn.FlatAppearance.BorderSize = 0;
            chamberBtn.FlatStyle = FlatStyle.Flat;
            chamberBtn.ForeColor = Color.White;
            chamberBtn.IconChar = FontAwesome.Sharp.IconChar.K;
            chamberBtn.IconColor = Color.White;
            chamberBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            chamberBtn.ImageAlign = ContentAlignment.MiddleLeft;
            chamberBtn.Location = new Point(0, 138);
            chamberBtn.Margin = new Padding(4, 3, 4, 3);
            chamberBtn.Name = "chamberBtn";
            chamberBtn.Padding = new Padding(10, 0, 20, 0);
            chamberBtn.Size = new Size(344, 85);
            chamberBtn.TabIndex = 3;
            chamberBtn.Text = "Камерная печь";
            chamberBtn.TextAlign = ContentAlignment.MiddleLeft;
            chamberBtn.TextImageRelation = TextImageRelation.ImageBeforeText;
            chamberBtn.UseVisualStyleBackColor = true;
            chamberBtn.Click += chamberBtn_Click;
            // 
            // panelLogo
            // 
            panelLogo.Controls.Add(btnHome);
            panelLogo.Dock = DockStyle.Top;
            panelLogo.Location = new Point(0, 0);
            panelLogo.Margin = new Padding(4, 3, 4, 3);
            panelLogo.Name = "panelLogo";
            panelLogo.Size = new Size(344, 138);
            panelLogo.TabIndex = 2;
            // 
            // btnHome
            // 
            btnHome.Dock = DockStyle.Fill;
            btnHome.Image = (Image)resources.GetObject("btnHome.Image");
            btnHome.Location = new Point(0, 0);
            btnHome.Name = "btnHome";
            btnHome.Size = new Size(344, 138);
            btnHome.SizeMode = PictureBoxSizeMode.Zoom;
            btnHome.TabIndex = 0;
            btnHome.TabStop = false;
            btnHome.Click += btnHome_Click;
            // 
            // panelTitleBar
            // 
            panelTitleBar.BackColor = Color.FromArgb(26, 25, 62);
            panelTitleBar.Controls.Add(minimizeBtn);
            panelTitleBar.Controls.Add(maximizeBtn);
            panelTitleBar.Controls.Add(btnExit);
            panelTitleBar.Controls.Add(lblTitleChildForm);
            panelTitleBar.Controls.Add(iconCurrentChildForm);
            panelTitleBar.Dock = DockStyle.Top;
            panelTitleBar.Location = new Point(344, 0);
            panelTitleBar.Name = "panelTitleBar";
            panelTitleBar.Size = new Size(1256, 79);
            panelTitleBar.TabIndex = 2;
            panelTitleBar.MouseDown += panelTitleBar_MouseDown;
            // 
            // minimizeBtn
            // 
            minimizeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            minimizeBtn.FlatAppearance.BorderSize = 0;
            minimizeBtn.FlatStyle = FlatStyle.Flat;
            minimizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMinimize;
            minimizeBtn.IconColor = Color.White;
            minimizeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            minimizeBtn.Location = new Point(962, 2);
            minimizeBtn.Name = "minimizeBtn";
            minimizeBtn.Size = new Size(94, 76);
            minimizeBtn.TabIndex = 4;
            minimizeBtn.UseVisualStyleBackColor = true;
            minimizeBtn.Click += minimizeBtn_Click;
            // 
            // maximizeBtn
            // 
            maximizeBtn.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            maximizeBtn.FlatAppearance.BorderSize = 0;
            maximizeBtn.FlatStyle = FlatStyle.Flat;
            maximizeBtn.IconChar = FontAwesome.Sharp.IconChar.WindowMaximize;
            maximizeBtn.IconColor = Color.White;
            maximizeBtn.IconFont = FontAwesome.Sharp.IconFont.Auto;
            maximizeBtn.Location = new Point(1062, 0);
            maximizeBtn.Name = "maximizeBtn";
            maximizeBtn.Size = new Size(94, 76);
            maximizeBtn.TabIndex = 3;
            maximizeBtn.UseVisualStyleBackColor = true;
            maximizeBtn.Click += maximizeBtn_Click;
            // 
            // btnExit
            // 
            btnExit.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            btnExit.FlatAppearance.BorderSize = 0;
            btnExit.FlatStyle = FlatStyle.Flat;
            btnExit.IconChar = FontAwesome.Sharp.IconChar.Close;
            btnExit.IconColor = Color.White;
            btnExit.IconFont = FontAwesome.Sharp.IconFont.Auto;
            btnExit.Location = new Point(1162, 0);
            btnExit.Name = "btnExit";
            btnExit.Size = new Size(94, 76);
            btnExit.TabIndex = 2;
            btnExit.UseVisualStyleBackColor = true;
            btnExit.Click += btnExit_Click;
            // 
            // lblTitleChildForm
            // 
            lblTitleChildForm.AutoSize = true;
            lblTitleChildForm.ForeColor = Color.White;
            lblTitleChildForm.Location = new Point(68, 29);
            lblTitleChildForm.Name = "lblTitleChildForm";
            lblTitleChildForm.Size = new Size(161, 22);
            lblTitleChildForm.TabIndex = 1;
            lblTitleChildForm.Text = "Главная страница";
            // 
            // iconCurrentChildForm
            // 
            iconCurrentChildForm.BackColor = Color.FromArgb(31, 30, 68);
            iconCurrentChildForm.ForeColor = Color.MediumPurple;
            iconCurrentChildForm.IconChar = FontAwesome.Sharp.IconChar.House;
            iconCurrentChildForm.IconColor = Color.MediumPurple;
            iconCurrentChildForm.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconCurrentChildForm.IconSize = 54;
            iconCurrentChildForm.Location = new Point(7, 12);
            iconCurrentChildForm.Name = "iconCurrentChildForm";
            iconCurrentChildForm.Size = new Size(55, 54);
            iconCurrentChildForm.TabIndex = 0;
            iconCurrentChildForm.TabStop = false;
            // 
            // panelShadow
            // 
            panelShadow.BackColor = Color.FromArgb(26, 24, 58);
            panelShadow.Dock = DockStyle.Top;
            panelShadow.Location = new Point(344, 79);
            panelShadow.Name = "panelShadow";
            panelShadow.Size = new Size(1256, 10);
            panelShadow.TabIndex = 3;
            // 
            // panelDesktop
            // 
            panelDesktop.BackColor = Color.FromArgb(34, 33, 74);
            panelDesktop.Controls.Add(lblClock);
            panelDesktop.Controls.Add(pictureBox1);
            panelDesktop.Dock = DockStyle.Fill;
            panelDesktop.Location = new Point(344, 89);
            panelDesktop.Name = "panelDesktop";
            panelDesktop.Size = new Size(1256, 811);
            panelDesktop.TabIndex = 4;
            // 
            // lblClock
            // 
            lblClock.Anchor = AnchorStyles.None;
            lblClock.AutoSize = true;
            lblClock.Font = new Font("Times New Roman", 40F);
            lblClock.Location = new Point(438, 516);
            lblClock.Name = "lblClock";
            lblClock.Size = new Size(386, 76);
            lblClock.TabIndex = 2;
            lblClock.Text = "00:00:00 PM";
            // 
            // pictureBox1
            // 
            pictureBox1.Anchor = AnchorStyles.None;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(261, 49);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(710, 464);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // tmrClock
            // 
            tmrClock.Interval = 1000;
            tmrClock.Tick += tmrClock_Tick;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1600, 900);
            Controls.Add(panelDesktop);
            Controls.Add(panelShadow);
            Controls.Add(panelTitleBar);
            Controls.Add(panelMenu);
            Font = new Font("Times New Roman", 12F);
            ForeColor = Color.White;
            Margin = new Padding(4, 3, 4, 3);
            Name = "MainForm";
            StartPosition = FormStartPosition.Manual;
            Text = "Главная страница";
            Load += MainForm_Load;
            panelMenu.ResumeLayout(false);
            panelLogo.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)btnHome).EndInit();
            panelTitleBar.ResumeLayout(false);
            panelTitleBar.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconCurrentChildForm).EndInit();
            panelDesktop.ResumeLayout(false);
            panelDesktop.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private ContextMenuStrip contextMenuStrip1;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Panel panelMenu;
        private FontAwesome.Sharp.IconButton chamberBtn;
        private Panel panelLogo;
        private FontAwesome.Sharp.IconButton exitBtn;
        private FontAwesome.Sharp.IconButton theoryBtn;
        private FontAwesome.Sharp.IconButton tableBtn;
        private FontAwesome.Sharp.IconButton tubeBtn;
        private PictureBox btnHome;
        private Panel panelTitleBar;
        private Label lblTitleChildForm;
        private FontAwesome.Sharp.IconPictureBox iconCurrentChildForm;
        private Panel panelShadow;
        private Panel panelDesktop;
        private PictureBox pictureBox1;
        private FontAwesome.Sharp.IconButton minimizeBtn;
        private FontAwesome.Sharp.IconButton maximizeBtn;
        private FontAwesome.Sharp.IconButton btnExit;
        private Label lblClock;
        private System.Windows.Forms.Timer tmrClock;
    }
}
