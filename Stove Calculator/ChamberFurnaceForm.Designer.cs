namespace Stove_Calculator
{
    partial class ChamberFurnaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ChamberFurnaceForm));
            iconSplitButton1 = new FontAwesome.Sharp.IconSplitButton();
            InputMainPanel = new Panel();
            panel5 = new Panel();
            panel4 = new Panel();
            pictureBox1 = new PictureBox();
            CalculateButton = new FontAwesome.Sharp.IconButton();
            richTextBox1 = new RichTextBox();
            StoveHeightTextBox = new TextBox();
            TemperatureOuterSurface = new TextBox();
            MaximumSampleTemperature = new TextBox();
            label4 = new Label();
            label8 = new Label();
            AmbientGasTemperature = new TextBox();
            StoveLengthTextBox = new TextBox();
            label12 = new Label();
            label9 = new Label();
            label2 = new Label();
            label7 = new Label();
            StoveWidthTextBox = new TextBox();
            label10 = new Label();
            label3 = new Label();
            label6 = new Label();
            label13 = new Label();
            label11 = new Label();
            label5 = new Label();
            HeaderInputPanel = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            OutputMainPanel = new Panel();
            panel2 = new Panel();
            label22 = new Label();
            heatFlowTextBox = new TextBox();
            label21 = new Label();
            thermalInsulationWidthTextBox = new TextBox();
            label20 = new Label();
            label19 = new Label();
            comboBox2 = new ComboBox();
            label18 = new Label();
            fireproofSurfaceTemperatureTextBox = new TextBox();
            fireproofWidthTextBox = new TextBox();
            label17 = new Label();
            label16 = new Label();
            label15 = new Label();
            label14 = new Label();
            comboBox1 = new ComboBox();
            label1 = new Label();
            panel1 = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            InputMainPanel.SuspendLayout();
            panel5.SuspendLayout();
            panel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            HeaderInputPanel.SuspendLayout();
            OutputMainPanel.SuspendLayout();
            panel2.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // iconSplitButton1
            // 
            iconSplitButton1.Flip = FontAwesome.Sharp.FlipOrientation.Normal;
            iconSplitButton1.IconChar = FontAwesome.Sharp.IconChar.None;
            iconSplitButton1.IconColor = Color.Black;
            iconSplitButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconSplitButton1.IconSize = 48;
            iconSplitButton1.Name = "iconSplitButton1";
            iconSplitButton1.Rotation = 0D;
            iconSplitButton1.Size = new Size(23, 23);
            iconSplitButton1.Text = "iconSplitButton1";
            // 
            // InputMainPanel
            // 
            InputMainPanel.Controls.Add(panel5);
            InputMainPanel.Controls.Add(HeaderInputPanel);
            InputMainPanel.Dock = DockStyle.Left;
            InputMainPanel.Location = new Point(0, 0);
            InputMainPanel.Margin = new Padding(4, 3, 4, 3);
            InputMainPanel.Name = "InputMainPanel";
            InputMainPanel.Size = new Size(522, 798);
            InputMainPanel.TabIndex = 2;
            // 
            // panel5
            // 
            panel5.Controls.Add(panel4);
            panel5.Controls.Add(CalculateButton);
            panel5.Controls.Add(richTextBox1);
            panel5.Controls.Add(StoveHeightTextBox);
            panel5.Controls.Add(TemperatureOuterSurface);
            panel5.Controls.Add(MaximumSampleTemperature);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(AmbientGasTemperature);
            panel5.Controls.Add(StoveLengthTextBox);
            panel5.Controls.Add(label12);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(StoveWidthTextBox);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label13);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(label5);
            panel5.Dock = DockStyle.Fill;
            panel5.Location = new Point(0, 65);
            panel5.Name = "panel5";
            panel5.Size = new Size(522, 733);
            panel5.TabIndex = 28;
            // 
            // panel4
            // 
            panel4.Controls.Add(pictureBox1);
            panel4.Location = new Point(0, 272);
            panel4.Name = "panel4";
            panel4.Size = new Size(522, 253);
            panel4.TabIndex = 26;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(522, 253);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // CalculateButton
            // 
            CalculateButton.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            CalculateButton.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            CalculateButton.FlatAppearance.BorderSize = 0;
            CalculateButton.FlatStyle = FlatStyle.Flat;
            CalculateButton.IconChar = FontAwesome.Sharp.IconChar.CaretSquareRight;
            CalculateButton.IconColor = Color.White;
            CalculateButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            CalculateButton.Location = new Point(151, 193);
            CalculateButton.MaximumSize = new Size(188, 61);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(188, 61);
            CalculateButton.TabIndex = 25;
            CalculateButton.Text = "Продолжить";
            CalculateButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            richTextBox1.BackColor = Color.FromArgb(52, 52, 52);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBox1.ForeColor = SystemColors.Control;
            richTextBox1.Location = new Point(23, 548);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(481, 173);
            richTextBox1.TabIndex = 24;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // StoveHeightTextBox
            // 
            StoveHeightTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StoveHeightTextBox.Location = new Point(74, 18);
            StoveHeightTextBox.Name = "StoveHeightTextBox";
            StoveHeightTextBox.Size = new Size(125, 30);
            StoveHeightTextBox.TabIndex = 9;
            StoveHeightTextBox.KeyPress += StoveHeightTextBox_KeyPress;
            // 
            // TemperatureOuterSurface
            // 
            TemperatureOuterSurface.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            TemperatureOuterSurface.Location = new Point(339, 126);
            TemperatureOuterSurface.Name = "TemperatureOuterSurface";
            TemperatureOuterSurface.Size = new Size(128, 30);
            TemperatureOuterSurface.TabIndex = 13;
            TemperatureOuterSurface.KeyPress += TemperatureOuterSurface_KeyPress;
            // 
            // MaximumSampleTemperature
            // 
            MaximumSampleTemperature.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            MaximumSampleTemperature.Location = new Point(339, 18);
            MaximumSampleTemperature.Name = "MaximumSampleTemperature";
            MaximumSampleTemperature.Size = new Size(128, 30);
            MaximumSampleTemperature.TabIndex = 11;
            MaximumSampleTemperature.KeyPress += MaximumSampleTemperature_KeyPress;
            // 
            // label4
            // 
            label4.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label4.AutoSize = true;
            label4.Location = new Point(205, 21);
            label4.Name = "label4";
            label4.Size = new Size(23, 22);
            label4.TabIndex = 14;
            label4.Text = "м";
            // 
            // label8
            // 
            label8.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label8.AutoSize = true;
            label8.Location = new Point(205, 134);
            label8.Name = "label8";
            label8.Size = new Size(23, 22);
            label8.TabIndex = 15;
            label8.Text = "м";
            // 
            // AmbientGasTemperature
            // 
            AmbientGasTemperature.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            AmbientGasTemperature.Location = new Point(339, 72);
            AmbientGasTemperature.Name = "AmbientGasTemperature";
            AmbientGasTemperature.Size = new Size(128, 30);
            AmbientGasTemperature.TabIndex = 12;
            AmbientGasTemperature.KeyPress += AmbientGasTemperature_KeyPress;
            // 
            // StoveLengthTextBox
            // 
            StoveLengthTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StoveLengthTextBox.Location = new Point(74, 131);
            StoveLengthTextBox.Name = "StoveLengthTextBox";
            StoveLengthTextBox.Size = new Size(125, 30);
            StoveLengthTextBox.TabIndex = 8;
            StoveLengthTextBox.KeyPress += StoveLengthTextBox_KeyPress;
            // 
            // label12
            // 
            label12.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label12.AutoSize = true;
            label12.Location = new Point(204, 78);
            label12.Name = "label12";
            label12.Size = new Size(23, 22);
            label12.TabIndex = 20;
            label12.Text = "м";
            // 
            // label9
            // 
            label9.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label9.AutoSize = true;
            label9.Location = new Point(473, 26);
            label9.Name = "label9";
            label9.Size = new Size(31, 22);
            label9.TabIndex = 16;
            label9.Text = "°С";
            // 
            // label2
            // 
            label2.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label2.AutoSize = true;
            label2.Location = new Point(23, 26);
            label2.Name = "label2";
            label2.Size = new Size(31, 22);
            label2.TabIndex = 2;
            label2.Text = "L1";
            // 
            // label7
            // 
            label7.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label7.AutoSize = true;
            label7.Location = new Point(279, 134);
            label7.Name = "label7";
            label7.Size = new Size(45, 22);
            label7.TabIndex = 7;
            label7.Text = "tнар";
            // 
            // StoveWidthTextBox
            // 
            StoveWidthTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            StoveWidthTextBox.Location = new Point(73, 75);
            StoveWidthTextBox.Name = "StoveWidthTextBox";
            StoveWidthTextBox.Size = new Size(125, 30);
            StoveWidthTextBox.TabIndex = 19;
            StoveWidthTextBox.KeyPress += StoveWidthTextBox_KeyPress;
            // 
            // label10
            // 
            label10.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label10.AutoSize = true;
            label10.Location = new Point(473, 78);
            label10.Name = "label10";
            label10.Size = new Size(31, 22);
            label10.TabIndex = 17;
            label10.Text = "°С";
            // 
            // label3
            // 
            label3.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label3.AutoSize = true;
            label3.Location = new Point(23, 131);
            label3.Name = "label3";
            label3.Size = new Size(31, 22);
            label3.TabIndex = 3;
            label3.Text = "L3";
            // 
            // label6
            // 
            label6.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label6.AutoSize = true;
            label6.Location = new Point(279, 80);
            label6.Name = "label6";
            label6.Size = new Size(45, 22);
            label6.TabIndex = 6;
            label6.Text = "tокр";
            // 
            // label13
            // 
            label13.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label13.AutoSize = true;
            label13.Location = new Point(22, 75);
            label13.Name = "label13";
            label13.Size = new Size(31, 22);
            label13.TabIndex = 18;
            label13.Text = "L2";
            // 
            // label11
            // 
            label11.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label11.AutoSize = true;
            label11.Location = new Point(473, 129);
            label11.Name = "label11";
            label11.Size = new Size(31, 22);
            label11.TabIndex = 17;
            label11.Text = "°С";
            // 
            // label5
            // 
            label5.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label5.AutoSize = true;
            label5.Location = new Point(279, 26);
            label5.Name = "label5";
            label5.Size = new Size(28, 22);
            label5.TabIndex = 5;
            label5.Text = "tм";
            // 
            // HeaderInputPanel
            // 
            HeaderInputPanel.Controls.Add(iconButton1);
            HeaderInputPanel.Dock = DockStyle.Top;
            HeaderInputPanel.Location = new Point(0, 0);
            HeaderInputPanel.Name = "HeaderInputPanel";
            HeaderInputPanel.Size = new Size(522, 65);
            HeaderInputPanel.TabIndex = 26;
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.ArrowRightToFile;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(143, 7);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(236, 51);
            iconButton1.TabIndex = 1;
            iconButton1.Text = "Начальные данные";
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // OutputMainPanel
            // 
            OutputMainPanel.Controls.Add(panel2);
            OutputMainPanel.Controls.Add(panel1);
            OutputMainPanel.Dock = DockStyle.Right;
            OutputMainPanel.Location = new Point(523, 0);
            OutputMainPanel.Name = "OutputMainPanel";
            OutputMainPanel.Size = new Size(723, 798);
            OutputMainPanel.TabIndex = 3;
            // 
            // panel2
            // 
            panel2.AutoSize = true;
            panel2.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            panel2.Controls.Add(label22);
            panel2.Controls.Add(heatFlowTextBox);
            panel2.Controls.Add(label21);
            panel2.Controls.Add(thermalInsulationWidthTextBox);
            panel2.Controls.Add(label20);
            panel2.Controls.Add(label19);
            panel2.Controls.Add(comboBox2);
            panel2.Controls.Add(label18);
            panel2.Controls.Add(fireproofSurfaceTemperatureTextBox);
            panel2.Controls.Add(fireproofWidthTextBox);
            panel2.Controls.Add(label17);
            panel2.Controls.Add(label16);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label14);
            panel2.Controls.Add(comboBox1);
            panel2.Controls.Add(label1);
            panel2.Dock = DockStyle.Fill;
            panel2.Location = new Point(0, 65);
            panel2.Margin = new Padding(0);
            panel2.Name = "panel2";
            panel2.Size = new Size(723, 733);
            panel2.TabIndex = 5;
            // 
            // label22
            // 
            label22.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label22.AutoSize = true;
            label22.Location = new Point(629, 251);
            label22.Name = "label22";
            label22.Size = new Size(32, 22);
            label22.TabIndex = 34;
            label22.Text = "Вт";
            label22.Visible = false;
            // 
            // heatFlowTextBox
            // 
            heatFlowTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            heatFlowTextBox.Location = new Point(393, 248);
            heatFlowTextBox.Name = "heatFlowTextBox";
            heatFlowTextBox.Size = new Size(230, 30);
            heatFlowTextBox.TabIndex = 33;
            heatFlowTextBox.Visible = false;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.Location = new Point(14, 251);
            label21.Name = "label21";
            label21.Size = new Size(224, 22);
            label21.TabIndex = 32;
            label21.Text = "Полный тепловой поток:";
            label21.Visible = false;
            // 
            // thermalInsulationWidthTextBox
            // 
            thermalInsulationWidthTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            thermalInsulationWidthTextBox.Location = new Point(393, 209);
            thermalInsulationWidthTextBox.Name = "thermalInsulationWidthTextBox";
            thermalInsulationWidthTextBox.Size = new Size(230, 30);
            thermalInsulationWidthTextBox.TabIndex = 31;
            thermalInsulationWidthTextBox.Visible = false;
            // 
            // label20
            // 
            label20.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label20.AutoSize = true;
            label20.Location = new Point(629, 217);
            label20.Name = "label20";
            label20.Size = new Size(23, 22);
            label20.TabIndex = 30;
            label20.Text = "м";
            label20.Visible = false;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.Location = new Point(14, 212);
            label19.Name = "label19";
            label19.Size = new Size(305, 22);
            label19.TabIndex = 29;
            label19.Text = "Введите толщину слоя огнеупора: ";
            label19.Visible = false;
            // 
            // comboBox2
            // 
            comboBox2.BackColor = Color.FromArgb(52, 52, 52);
            comboBox2.FlatStyle = FlatStyle.Flat;
            comboBox2.ForeColor = SystemColors.Control;
            comboBox2.FormattingEnabled = true;
            comboBox2.Location = new Point(393, 171);
            comboBox2.Margin = new Padding(0);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(230, 30);
            comboBox2.TabIndex = 28;
            comboBox2.Visible = false;
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(14, 174);
            label18.Margin = new Padding(0);
            label18.Name = "label18";
            label18.Size = new Size(324, 22);
            label18.TabIndex = 27;
            label18.Text = "Выберите материал теплоизоляции: ";
            label18.Visible = false;
            // 
            // fireproofSurfaceTemperatureTextBox
            // 
            fireproofSurfaceTemperatureTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fireproofSurfaceTemperatureTextBox.Location = new Point(393, 134);
            fireproofSurfaceTemperatureTextBox.Name = "fireproofSurfaceTemperatureTextBox";
            fireproofSurfaceTemperatureTextBox.Size = new Size(230, 30);
            fireproofSurfaceTemperatureTextBox.TabIndex = 26;
            fireproofSurfaceTemperatureTextBox.Visible = false;
            fireproofSurfaceTemperatureTextBox.TextChanged += fireproofSurfaceTemperatureTextBox_TextChanged;
            fireproofSurfaceTemperatureTextBox.KeyPress += fireproofSurfaceTemperatureTextBox_KeyPress;
            // 
            // fireproofWidthTextBox
            // 
            fireproofWidthTextBox.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            fireproofWidthTextBox.Location = new Point(393, 94);
            fireproofWidthTextBox.Name = "fireproofWidthTextBox";
            fireproofWidthTextBox.Size = new Size(230, 30);
            fireproofWidthTextBox.TabIndex = 25;
            fireproofWidthTextBox.Visible = false;
            fireproofWidthTextBox.TextChanged += textBox1_TextChanged;
            fireproofWidthTextBox.KeyPress += fireproofWidthTextBox_KeyPress;
            // 
            // label17
            // 
            label17.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label17.AutoSize = true;
            label17.Location = new Point(629, 142);
            label17.Name = "label17";
            label17.Size = new Size(31, 22);
            label17.TabIndex = 24;
            label17.Text = "°С";
            label17.Visible = false;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Location = new Point(14, 139);
            label16.Name = "label16";
            label16.Size = new Size(345, 22);
            label16.TabIndex = 22;
            label16.Text = "Температура на границе раздела слоев:";
            label16.Visible = false;
            // 
            // label15
            // 
            label15.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            label15.AutoSize = true;
            label15.Location = new Point(629, 102);
            label15.Name = "label15";
            label15.Size = new Size(23, 22);
            label15.TabIndex = 21;
            label15.Text = "м";
            label15.Visible = false;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(14, 102);
            label14.Name = "label14";
            label14.Size = new Size(305, 22);
            label14.TabIndex = 2;
            label14.Text = "Введите толщину слоя огнеупора: ";
            label14.Visible = false;
            // 
            // comboBox1
            // 
            comboBox1.BackColor = Color.FromArgb(52, 52, 52);
            comboBox1.FlatStyle = FlatStyle.Flat;
            comboBox1.ForeColor = SystemColors.Control;
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(393, 54);
            comboBox1.Margin = new Padding(0);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(230, 30);
            comboBox1.TabIndex = 1;
            comboBox1.Visible = false;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 62);
            label1.Margin = new Padding(0);
            label1.Name = "label1";
            label1.Size = new Size(281, 22);
            label1.TabIndex = 0;
            label1.Text = "Выберите материал огнеупора: ";
            label1.Visible = false;
            // 
            // panel1
            // 
            panel1.Controls.Add(iconButton2);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(723, 65);
            panel1.TabIndex = 4;
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.ArrowRightToFile;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(243, 7);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(236, 51);
            iconButton2.TabIndex = 1;
            iconButton2.Text = "Результат";
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = true;
            // 
            // ChamberFurnaceForm
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 52, 52);
            ClientSize = new Size(1246, 798);
            Controls.Add(OutputMainPanel);
            Controls.Add(InputMainPanel);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ChamberFurnaceForm";
            Text = "ChamberFurnace";
            InputMainPanel.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            HeaderInputPanel.ResumeLayout(false);
            OutputMainPanel.ResumeLayout(false);
            OutputMainPanel.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconSplitButton iconSplitButton1;
        private Panel InputMainPanel;
        private Label label12;
        private TextBox StoveWidthTextBox;
        private Label label13;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label4;
        private TextBox TemperatureOuterSurface;
        private TextBox AmbientGasTemperature;
        private TextBox MaximumSampleTemperature;
        private TextBox StoveHeightTextBox;
        private TextBox StoveLengthTextBox;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private Panel OutputMainPanel;
        private FontAwesome.Sharp.IconButton CalculateButton;
        private Panel panel5;
        private Panel HeaderInputPanel;
        private Panel panel4;
        private Panel panel1;
        private FontAwesome.Sharp.IconButton iconButton2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel2;
        private Label label1;
        private ComboBox comboBox1;
        private Label label14;
        private Label label16;
        private Label label15;
        private Label label17;
        private TextBox fireproofSurfaceTemperatureTextBox;
        private TextBox fireproofWidthTextBox;
        private ComboBox comboBox2;
        private Label label18;
        private TextBox heatFlowTextBox;
        private Label label21;
        private TextBox thermalInsulationWidthTextBox;
        private Label label20;
        private Label label19;
        private Label label22;
    }
}