namespace Stove_Calculator
{
    partial class TubeFurnaceForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TubeFurnaceForm));
            panel1 = new Panel();
            panel5 = new Panel();
            panel6 = new Panel();
            pictureBox1 = new PictureBox();
            richTextBox1 = new RichTextBox();
            CalculateButton = new FontAwesome.Sharp.IconButton();
            MaximumSampleTemperature = new TextBox();
            AmbientGasTemperature = new TextBox();
            TemperatureOuterSurface = new TextBox();
            StoveLengthTextBox = new TextBox();
            StoveDiameterTextBox = new TextBox();
            label4 = new Label();
            label2 = new Label();
            label7 = new Label();
            label11 = new Label();
            label8 = new Label();
            label3 = new Label();
            label6 = new Label();
            label10 = new Label();
            label9 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            panel4 = new Panel();
            iconButton2 = new FontAwesome.Sharp.IconButton();
            panel1.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            panel3.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel5);
            panel1.Controls.Add(panel3);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4, 3, 4, 3);
            panel1.Name = "panel1";
            panel1.Size = new Size(535, 798);
            panel1.TabIndex = 1;
            panel1.Paint += panel1_Paint;
            // 
            // panel5
            // 
            panel5.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel5.Controls.Add(panel6);
            panel5.Controls.Add(richTextBox1);
            panel5.Controls.Add(CalculateButton);
            panel5.Controls.Add(MaximumSampleTemperature);
            panel5.Controls.Add(AmbientGasTemperature);
            panel5.Controls.Add(TemperatureOuterSurface);
            panel5.Controls.Add(StoveLengthTextBox);
            panel5.Controls.Add(StoveDiameterTextBox);
            panel5.Controls.Add(label4);
            panel5.Controls.Add(label2);
            panel5.Controls.Add(label7);
            panel5.Controls.Add(label11);
            panel5.Controls.Add(label8);
            panel5.Controls.Add(label3);
            panel5.Controls.Add(label6);
            panel5.Controls.Add(label10);
            panel5.Controls.Add(label9);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(0, 65);
            panel5.Name = "panel5";
            panel5.Size = new Size(535, 733);
            panel5.TabIndex = 6;
            // 
            // panel6
            // 
            panel6.Controls.Add(pictureBox1);
            panel6.Location = new Point(0, 296);
            panel6.Name = "panel6";
            panel6.Size = new Size(536, 235);
            panel6.TabIndex = 27;
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(536, 235);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 22;
            pictureBox1.TabStop = false;
            // 
            // richTextBox1
            // 
            richTextBox1.BackColor = Color.FromArgb(52, 52, 52);
            richTextBox1.BorderStyle = BorderStyle.None;
            richTextBox1.Font = new Font("Times New Roman", 12F, FontStyle.Regular, GraphicsUnit.Point, 204);
            richTextBox1.ForeColor = SystemColors.Control;
            richTextBox1.Location = new Point(18, 550);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(481, 161);
            richTextBox1.TabIndex = 23;
            richTextBox1.Text = resources.GetString("richTextBox1.Text");
            // 
            // CalculateButton
            // 
            CalculateButton.FlatAppearance.BorderSize = 0;
            CalculateButton.FlatStyle = FlatStyle.Flat;
            CalculateButton.IconChar = FontAwesome.Sharp.IconChar.CaretSquareRight;
            CalculateButton.IconColor = Color.White;
            CalculateButton.IconFont = FontAwesome.Sharp.IconFont.Auto;
            CalculateButton.Location = new Point(160, 207);
            CalculateButton.Name = "CalculateButton";
            CalculateButton.Size = new Size(188, 57);
            CalculateButton.TabIndex = 26;
            CalculateButton.Text = "Рассчитать";
            CalculateButton.TextImageRelation = TextImageRelation.ImageBeforeText;
            CalculateButton.UseVisualStyleBackColor = true;
            CalculateButton.Click += CalculateButton_Click;
            // 
            // MaximumSampleTemperature
            // 
            MaximumSampleTemperature.Location = new Point(334, 33);
            MaximumSampleTemperature.Name = "MaximumSampleTemperature";
            MaximumSampleTemperature.Size = new Size(125, 30);
            MaximumSampleTemperature.TabIndex = 11;
            MaximumSampleTemperature.KeyPress += MaximumSampleTemperature_KeyPress;
            // 
            // AmbientGasTemperature
            // 
            AmbientGasTemperature.Location = new Point(334, 87);
            AmbientGasTemperature.Name = "AmbientGasTemperature";
            AmbientGasTemperature.Size = new Size(125, 30);
            AmbientGasTemperature.TabIndex = 12;
            AmbientGasTemperature.KeyPress += AmbientGasTemperature_KeyPress;
            // 
            // TemperatureOuterSurface
            // 
            TemperatureOuterSurface.Location = new Point(334, 141);
            TemperatureOuterSurface.Name = "TemperatureOuterSurface";
            TemperatureOuterSurface.Size = new Size(125, 30);
            TemperatureOuterSurface.TabIndex = 13;
            TemperatureOuterSurface.KeyPress += TemperatureOuterSurface_KeyPress;
            // 
            // StoveLengthTextBox
            // 
            StoveLengthTextBox.Location = new Point(69, 33);
            StoveLengthTextBox.Name = "StoveLengthTextBox";
            StoveLengthTextBox.Size = new Size(125, 30);
            StoveLengthTextBox.TabIndex = 9;
            StoveLengthTextBox.KeyPress += StoveLengthTextBox_KeyPress;
            // 
            // StoveDiameterTextBox
            // 
            StoveDiameterTextBox.Location = new Point(69, 90);
            StoveDiameterTextBox.Name = "StoveDiameterTextBox";
            StoveDiameterTextBox.Size = new Size(125, 30);
            StoveDiameterTextBox.TabIndex = 8;
            StoveDiameterTextBox.KeyPress += StoveDiameterTextBox_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(200, 36);
            label4.Name = "label4";
            label4.Size = new Size(23, 22);
            label4.TabIndex = 14;
            label4.Text = "м";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 41);
            label2.Name = "label2";
            label2.Size = new Size(21, 22);
            label2.TabIndex = 2;
            label2.Text = "L";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(274, 149);
            label7.Name = "label7";
            label7.Size = new Size(45, 22);
            label7.TabIndex = 7;
            label7.Text = "tнар";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(468, 144);
            label11.Name = "label11";
            label11.Size = new Size(31, 22);
            label11.TabIndex = 17;
            label11.Text = "°С";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(200, 93);
            label8.Name = "label8";
            label8.Size = new Size(23, 22);
            label8.TabIndex = 15;
            label8.Text = "м";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(18, 90);
            label3.Name = "label3";
            label3.Size = new Size(20, 22);
            label3.TabIndex = 3;
            label3.Text = "d";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(274, 95);
            label6.Name = "label6";
            label6.Size = new Size(45, 22);
            label6.TabIndex = 6;
            label6.Text = "tокр";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(468, 93);
            label10.Name = "label10";
            label10.Size = new Size(31, 22);
            label10.TabIndex = 17;
            label10.Text = "°С";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(468, 41);
            label9.Name = "label9";
            label9.Size = new Size(31, 22);
            label9.TabIndex = 16;
            label9.Text = "°С";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(274, 41);
            label5.Name = "label5";
            label5.Size = new Size(28, 22);
            label5.TabIndex = 5;
            label5.Text = "tм";
            // 
            // panel3
            // 
            panel3.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel3.Controls.Add(iconButton1);
            panel3.Location = new Point(0, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(532, 65);
            panel3.TabIndex = 4;
            // 
            // iconButton1
            // 
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.ArrowRightToFile;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(137, 3);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(279, 53);
            iconButton1.TabIndex = 6;
            iconButton1.Text = "Начальные данные";
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // panel2
            // 
            panel2.Controls.Add(panel4);
            panel2.Dock = DockStyle.Right;
            panel2.Location = new Point(542, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(704, 798);
            panel2.TabIndex = 2;
            // 
            // panel4
            // 
            panel4.Anchor = AnchorStyles.Left | AnchorStyles.Right;
            panel4.Controls.Add(iconButton2);
            panel4.Location = new Point(0, 0);
            panel4.Name = "panel4";
            panel4.Size = new Size(704, 65);
            panel4.TabIndex = 5;
            // 
            // iconButton2
            // 
            iconButton2.FlatAppearance.BorderSize = 0;
            iconButton2.FlatStyle = FlatStyle.Flat;
            iconButton2.IconChar = FontAwesome.Sharp.IconChar.ArrowRightToFile;
            iconButton2.IconColor = Color.White;
            iconButton2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton2.Location = new Point(214, 6);
            iconButton2.Name = "iconButton2";
            iconButton2.Size = new Size(279, 53);
            iconButton2.TabIndex = 7;
            iconButton2.Text = "Результат";
            iconButton2.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton2.UseVisualStyleBackColor = true;
            // 
            // TubeFurnaceForm
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
            Name = "TubeFurnaceForm";
            Text = "TubeFurnace";
            panel1.ResumeLayout(false);
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            panel3.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel4.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TextBox TemperatureOuterSurface;
        private TextBox AmbientGasTemperature;
        private TextBox MaximumSampleTemperature;
        private TextBox StoveLengthTextBox;
        private TextBox StoveDiameterTextBox;
        private Label label7;
        private Label label6;
        private Label label5;
        private Label label3;
        private Label label2;
        private Label label11;
        private Label label10;
        private Label label9;
        private Label label8;
        private Label label4;
        private PictureBox pictureBox1;
        private RichTextBox richTextBox1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton CalculateButton;
        private Panel panel3;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Panel panel4;
        private Panel panel5;
        private Panel panel6;
        private FontAwesome.Sharp.IconButton iconButton2;
    }
}