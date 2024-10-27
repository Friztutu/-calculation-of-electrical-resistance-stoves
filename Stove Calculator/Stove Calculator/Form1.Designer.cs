namespace Stove_Calculator
{
    partial class Form1
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
            label1 = new Label();
            textBoxL1Size = new TextBox();
            label2 = new Label();
            label3 = new Label();
            textBoxL2Size = new TextBox();
            label4 = new Label();
            label5 = new Label();
            textBoxL3Size = new TextBox();
            label6 = new Label();
            label7 = new Label();
            textBoxTemperatureOuterSurface = new TextBox();
            label8 = new Label();
            label9 = new Label();
            textBoxAmbientGasTemperature = new TextBox();
            label10 = new Label();
            label11 = new Label();
            textBoxLimTemperatureSample = new TextBox();
            label12 = new Label();
            buttonCalculate = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 106);
            label1.Name = "label1";
            label1.Size = new Size(24, 20);
            label1.TabIndex = 0;
            label1.Text = "L1";
            // 
            // textBoxL1Size
            // 
            textBoxL1Size.Location = new Point(112, 103);
            textBoxL1Size.Name = "textBoxL1Size";
            textBoxL1Size.Size = new Size(125, 27);
            textBoxL1Size.TabIndex = 1;
            textBoxL1Size.KeyPress += textBoxL1Size_KeyPress;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(243, 110);
            label2.Name = "label2";
            label2.Size = new Size(20, 20);
            label2.TabIndex = 2;
            label2.Text = "м";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(243, 143);
            label3.Name = "label3";
            label3.Size = new Size(20, 20);
            label3.TabIndex = 5;
            label3.Text = "м";
            // 
            // textBoxL2Size
            // 
            textBoxL2Size.Location = new Point(112, 136);
            textBoxL2Size.Name = "textBoxL2Size";
            textBoxL2Size.Size = new Size(125, 27);
            textBoxL2Size.TabIndex = 4;
            textBoxL2Size.KeyPress += textBoxL2Size_KeyPress;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 139);
            label4.Name = "label4";
            label4.Size = new Size(24, 20);
            label4.TabIndex = 3;
            label4.Text = "L2";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(243, 176);
            label5.Name = "label5";
            label5.Size = new Size(20, 20);
            label5.TabIndex = 8;
            label5.Text = "м";
            // 
            // textBoxL3Size
            // 
            textBoxL3Size.Location = new Point(112, 169);
            textBoxL3Size.Name = "textBoxL3Size";
            textBoxL3Size.Size = new Size(125, 27);
            textBoxL3Size.TabIndex = 7;
            textBoxL3Size.KeyPress += textBoxL3Size_KeyPress;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(67, 172);
            label6.Name = "label6";
            label6.Size = new Size(24, 20);
            label6.TabIndex = 6;
            label6.Text = "L3";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(243, 296);
            label7.Name = "label7";
            label7.Size = new Size(24, 20);
            label7.TabIndex = 17;
            label7.Text = "°C";
            // 
            // textBoxTemperatureOuterSurface
            // 
            textBoxTemperatureOuterSurface.Location = new Point(112, 289);
            textBoxTemperatureOuterSurface.Name = "textBoxTemperatureOuterSurface";
            textBoxTemperatureOuterSurface.Size = new Size(125, 27);
            textBoxTemperatureOuterSurface.TabIndex = 16;
            textBoxTemperatureOuterSurface.KeyPress += textBoxTemperatureOuterSurface_KeyPress;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(67, 292);
            label8.Name = "label8";
            label8.Size = new Size(40, 20);
            label8.TabIndex = 15;
            label8.Text = "tнар";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(243, 263);
            label9.Name = "label9";
            label9.Size = new Size(24, 20);
            label9.TabIndex = 14;
            label9.Text = "°C";
            // 
            // textBoxAmbientGasTemperature
            // 
            textBoxAmbientGasTemperature.Location = new Point(112, 256);
            textBoxAmbientGasTemperature.Name = "textBoxAmbientGasTemperature";
            textBoxAmbientGasTemperature.Size = new Size(125, 27);
            textBoxAmbientGasTemperature.TabIndex = 13;
            textBoxAmbientGasTemperature.KeyPress += textBoxAmbientGasTemperature_KeyPress;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(67, 259);
            label10.Name = "label10";
            label10.Size = new Size(39, 20);
            label10.TabIndex = 12;
            label10.Text = "tокр";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(243, 230);
            label11.Name = "label11";
            label11.Size = new Size(24, 20);
            label11.TabIndex = 11;
            label11.Text = "°C";
            // 
            // textBoxLimTemperatureSample
            // 
            textBoxLimTemperatureSample.Location = new Point(112, 223);
            textBoxLimTemperatureSample.Name = "textBoxLimTemperatureSample";
            textBoxLimTemperatureSample.Size = new Size(125, 27);
            textBoxLimTemperatureSample.TabIndex = 10;
            textBoxLimTemperatureSample.KeyPress += textBoxLimTemperatureSample_KeyPress;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(67, 226);
            label12.Name = "label12";
            label12.Size = new Size(27, 20);
            label12.TabIndex = 9;
            label12.Text = "tm";
            // 
            // buttonCalculate
            // 
            buttonCalculate.Location = new Point(112, 345);
            buttonCalculate.Name = "buttonCalculate";
            buttonCalculate.Size = new Size(125, 42);
            buttonCalculate.TabIndex = 18;
            buttonCalculate.Text = "Рассчитать";
            buttonCalculate.UseVisualStyleBackColor = true;
            buttonCalculate.Click += buttonCalculate_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 873);
            Controls.Add(buttonCalculate);
            Controls.Add(label7);
            Controls.Add(textBoxTemperatureOuterSurface);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(textBoxAmbientGasTemperature);
            Controls.Add(label10);
            Controls.Add(label11);
            Controls.Add(textBoxLimTemperatureSample);
            Controls.Add(label12);
            Controls.Add(label5);
            Controls.Add(textBoxL3Size);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(textBoxL2Size);
            Controls.Add(label4);
            Controls.Add(label2);
            Controls.Add(textBoxL1Size);
            Controls.Add(label1);
            Name = "Form1";
            Text = "Form1";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private TextBox textBoxL1Size;
        private Label label2;
        private Label label3;
        private TextBox textBoxL2Size;
        private Label label4;
        private Label label5;
        private TextBox textBoxL3Size;
        private Label label6;
        private Label label7;
        private TextBox textBoxTemperatureOuterSurface;
        private Label label8;
        private Label label9;
        private TextBox textBoxAmbientGasTemperature;
        private Label label10;
        private Label label11;
        private TextBox textBoxLimTemperatureSample;
        private Label label12;
        private Button buttonCalculate;
    }
}
