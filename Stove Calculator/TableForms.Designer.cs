using RSAExtensions;

namespace Stove_Calculator
{
    partial class TableForms
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
            components = new System.ComponentModel.Container();
            thermalInsulationBindingSource = new BindingSource(components);
            fireproofBindingSource = new BindingSource(components);
            fireproofBindingSource1 = new BindingSource(components);
            thermalInsulationBindingSource1 = new BindingSource(components);
            fireproofBindingSource2 = new BindingSource(components);
            carborundumHeatersBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)thermalInsulationBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fireproofBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fireproofBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)thermalInsulationBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fireproofBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)carborundumHeatersBindingSource).BeginInit();
            SuspendLayout();
            // 
            // thermalInsulationBindingSource
            // 
            thermalInsulationBindingSource.DataSource = typeof(Models.ThermalInsulation);
            // 
            // fireproofBindingSource
            // 
            fireproofBindingSource.DataSource = typeof(Models.Fireproof);
            // 
            // fireproofBindingSource1
            // 
            fireproofBindingSource1.DataSource = typeof(Models.Fireproof);
            // 
            // thermalInsulationBindingSource1
            // 
            thermalInsulationBindingSource1.DataSource = typeof(Models.ThermalInsulation);
            // 
            // fireproofBindingSource2
            // 
            fireproofBindingSource2.DataSource = typeof(Models.Fireproof);
            // 
            // carborundumHeatersBindingSource
            // 
            carborundumHeatersBindingSource.DataSource = typeof(Models.CarborundumHeaters);
            // 
            // TableForms
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(34, 33, 74);
            ClientSize = new Size(1256, 811);
            Font = new Font("Times New Roman", 12F);
            ForeColor = Color.White;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "TableForms";
            Text = "TableForms";
            ((System.ComponentModel.ISupportInitialize)thermalInsulationBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)fireproofBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)fireproofBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)thermalInsulationBindingSource1).EndInit();
            ((System.ComponentModel.ISupportInitialize)fireproofBindingSource2).EndInit();
            ((System.ComponentModel.ISupportInitialize)carborundumHeatersBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource fireproofBindingSource;
        private BindingSource thermalInsulationBindingSource;
        private BindingSource fireproofBindingSource1;
        private BindingSource thermalInsulationBindingSource1;
        private BindingSource fireproofBindingSource2;
        private BindingSource carborundumHeatersBindingSource;
    }
}