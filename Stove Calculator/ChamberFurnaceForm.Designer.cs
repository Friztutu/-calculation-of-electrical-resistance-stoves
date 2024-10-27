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
            panel1 = new Panel();
            CalculateButton = new FontAwesome.Sharp.IconButton();
            richTextBox1 = new RichTextBox();
            pictureBox1 = new PictureBox();
            label12 = new Label();
            StoveWidthTextBox = new TextBox();
            label13 = new Label();
            label11 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label4 = new Label();
            TemperatureOuterSurface = new TextBox();
            AmbientGasTemperature = new TextBox();
            MaximumSampleTemperature = new TextBox();
            StoveHeightTextBox = new TextBox();
            StoveLengthTextBox = new TextBox();
            label7 = new Label();
            label6 = new Label();
            label5 = new Label();
            label3 = new Label();
            label2 = new Label();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            label1 = new Label();
            panel2 = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            label14 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel2.SuspendLayout();
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
            // panel1
            // 
            panel1.Controls.Add(CalculateButton);
            panel1.Controls.Add(richTextBox1);
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(label12);
            panel1.Controls.Add(StoveWidthTextBox);
            panel1.Controls.Add(label13);
            panel1.Controls.Add(label11);
            panel1.Controls.Add(label10);
            panel1.Controls.Add(label9);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(TemperatureOuterSurface);
            panel1.Controls.Add(AmbientGasTemperature);
            panel1.Controls.Add(MaximumSampleTemperature);
            panel1.Controls.Add(StoveHeightTextBox);
            panel1.Controls.Add(StoveLengthTextBox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(iconButton1);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(13, 12);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(522, 774);
            panel1.TabIndex = 2;
            // 
            // CalculateButton
            // 
            CalculateButton.FlatAppearance.BorderSize = 0;
            CalculateButton.FlatStyle = FlatStyle.Flat;
            CalculateButton.IconChar = FontAwesome.Sharp.IconChar.CaretSquareRight;
            CalculateButton.IconColor = Color.White;
            CalculateButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            CalculateButton.Location = new Point(165, 280);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(188, 55);
            CalculateButton.TabIndex = 25;
            CalculateButton.Text = "Рассчитать";
            CalculateButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(52, 52, 52);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBox1.ForeColor = SystemColors.Control;
            richTextBox1.Location = new Point(22, 613);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(481, 162);
            richTextBox1.TabIndex = 24;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(22, 377);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(481, 230);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 21;
            pictureBox1.TabStop = false;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(204, 166);
            label12.Name = "label12";
            label12.Size = new Size(23, 22);
            label12.TabIndex = 20;
            label12.Text = "м";
            // 
            // StoveWidthTextBox
            // 
            StoveWidthTextBox.Location = new Point(73, 163);
            StoveWidthTextBox.Name = "StoveWidthTextBox";
            StoveWidthTextBox.Size = new Size(125, 30);
            StoveWidthTextBox.TabIndex = 19;
            StoveWidthTextBox.KeyPress += StoveWidthTextBox_KeyPress;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(22, 163);
            label13.Name = "label13";
            label13.Size = new Size(31, 22);
            label13.TabIndex = 18;
            label13.Text = "L2";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(473, 217);
            label11.Name = "label11";
            label11.Size = new Size(31, 22);
            label11.TabIndex = 17;
            label11.Text = "°С";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(473, 166);
            label10.Name = "label10";
            label10.Size = new Size(31, 22);
            label10.TabIndex = 17;
            label10.Text = "°С";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(473, 114);
            label9.Name = "label9";
            label9.Size = new Size(31, 22);
            label9.TabIndex = 16;
            label9.Text = "°С";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(205, 222);
            label8.Name = "label8";
            label8.Size = new Size(23, 22);
            label8.TabIndex = 15;
            label8.Text = "м";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(205, 109);
            label4.Name = "label4";
            label4.Size = new Size(23, 22);
            label4.TabIndex = 14;
            label4.Text = "м";
            // 
            // TemperatureOuterSurface
            // 
            TemperatureOuterSurface.Location = new Point(339, 214);
            TemperatureOuterSurface.Name = "TemperatureOuterSurface";
            TemperatureOuterSurface.Size = new Size(125, 30);
            TemperatureOuterSurface.TabIndex = 13;
            TemperatureOuterSurface.KeyPress += TemperatureOuterSurface_KeyPress;
            // 
            // AmbientGasTemperature
            // 
            AmbientGasTemperature.Location = new Point(339, 160);
            AmbientGasTemperature.Name = "AmbientGasTemperature";
            AmbientGasTemperature.Size = new Size(125, 30);
            AmbientGasTemperature.TabIndex = 12;
            AmbientGasTemperature.KeyPress += AmbientGasTemperature_KeyPress;
            // 
            // MaximumSampleTemperature
            // 
            MaximumSampleTemperature.Location = new Point(339, 106);
            MaximumSampleTemperature.Name = "MaximumSampleTemperature";
            MaximumSampleTemperature.Size = new Size(125, 30);
            MaximumSampleTemperature.TabIndex = 11;
            MaximumSampleTemperature.KeyPress += MaximumSampleTemperature_KeyPress;
            // 
            // StoveHeightTextBox
            // 
            StoveHeightTextBox.Location = new Point(74, 106);
            StoveHeightTextBox.Name = "StoveHeightTextBox";
            StoveHeightTextBox.Size = new Size(125, 30);
            StoveHeightTextBox.TabIndex = 9;
            StoveHeightTextBox.KeyPress += StoveHeightTextBox_KeyPress;
            // 
            // StoveLengthTextBox
            // 
            StoveLengthTextBox.Location = new Point(74, 219);
            StoveLengthTextBox.Name = "StoveLengthTextBox";
            StoveLengthTextBox.Size = new Size(125, 30);
            StoveLengthTextBox.TabIndex = 8;
            StoveLengthTextBox.KeyPress += StoveLengthTextBox_KeyPress;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(279, 222);
            label7.Name = "label7";
            label7.Size = new Size(45, 22);
            label7.TabIndex = 7;
            label7.Text = "tнар";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(279, 168);
            label6.Name = "label6";
            label6.Size = new Size(45, 22);
            label6.TabIndex = 6;
            label6.Text = "tокр";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(279, 114);
            label5.Name = "label5";
            label5.Size = new Size(28, 22);
            label5.TabIndex = 5;
            label5.Text = "tм";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 219);
            label3.Name = "label3";
            label3.Size = new Size(31, 22);
            label3.TabIndex = 3;
            label3.Text = "L3";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(23, 114);
            label2.Name = "label2";
            label2.Size = new Size(31, 22);
            label2.TabIndex = 2;
            label2.Text = "L1";
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.ArrowRightToFile;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(153, 6);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(45, 59);
            iconButton1.TabIndex = 1;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(205, 24);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(171, 22);
            label1.TabIndex = 0;
            label1.Text = "Начальные данные";
            // 
            // panel2
            // 
            panel2.Controls.Add(iconButton2);
            panel2.Controls.Add(label14);
            panel2.Location = new Point(542, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(692, 774);
            panel2.TabIndex = 3;
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.ArrowRightFromFile;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(323, 6);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(45, 59);
            iconButton2.TabIndex = 3;
            iconButton2.UseVisualStyleBackColor = true;
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(375, 24);
            label14.Margin = new Padding(4, 0, 4, 0);
            label14.Name = "label14";
            label14.Size = new Size(90, 22);
            label14.TabIndex = 2;
            label14.Text = "Результат";
            // 
            // ChamberFurnaceForm
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 52, 52);
            ClientSize = new Size(1246, 798);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4, 3, 4, 3);
            Name = "ChamberFurnaceForm";
            Text = "ChamberFurnace";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private FontAwesome.Sharp.IconSplitButton iconSplitButton1;
        private Panel panel1;
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
        private FontAwesome.Sharp.IconButton iconButton1;
        private Label label1;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton2;
        private Label label14;
        private FontAwesome.Sharp.IconButton CalculateButton;
    }
}