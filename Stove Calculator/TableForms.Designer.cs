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
            dataGridView1 = new DataGridView();
            nameDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            maxTemperatureOfUseDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            aValueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            bValueDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            densityDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            dataGridView2 = new DataGridView();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn2 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn3 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn4 = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn5 = new DataGridViewTextBoxColumn();
            dataGridView3 = new DataGridView();
            dataGridViewTextBoxColumn6 = new DataGridViewTextBoxColumn();
            carborundumHeatersBindingSource = new BindingSource(components);
            ((System.ComponentModel.ISupportInitialize)thermalInsulationBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fireproofBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fireproofBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)thermalInsulationBindingSource1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)fireproofBindingSource2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).BeginInit();
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
            // dataGridView1
            // 
            dataGridView1.AutoGenerateColumns = false;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { nameDataGridViewTextBoxColumn, maxTemperatureOfUseDataGridViewTextBoxColumn, aValueDataGridViewTextBoxColumn, bValueDataGridViewTextBoxColumn, densityDataGridViewTextBoxColumn });
            dataGridView1.DataSource = fireproofBindingSource;
            dataGridView1.Location = new Point(12, 12);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1232, 263);
            dataGridView1.TabIndex = 0;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            nameDataGridViewTextBoxColumn.HeaderText = "Name";
            nameDataGridViewTextBoxColumn.MinimumWidth = 6;
            nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            nameDataGridViewTextBoxColumn.Width = 125;
            // 
            // maxTemperatureOfUseDataGridViewTextBoxColumn
            // 
            maxTemperatureOfUseDataGridViewTextBoxColumn.DataPropertyName = "MaxTemperatureOfUse";
            maxTemperatureOfUseDataGridViewTextBoxColumn.HeaderText = "MaxTemperatureOfUse";
            maxTemperatureOfUseDataGridViewTextBoxColumn.MinimumWidth = 6;
            maxTemperatureOfUseDataGridViewTextBoxColumn.Name = "maxTemperatureOfUseDataGridViewTextBoxColumn";
            maxTemperatureOfUseDataGridViewTextBoxColumn.Width = 125;
            // 
            // aValueDataGridViewTextBoxColumn
            // 
            aValueDataGridViewTextBoxColumn.DataPropertyName = "AValue";
            aValueDataGridViewTextBoxColumn.HeaderText = "AValue";
            aValueDataGridViewTextBoxColumn.MinimumWidth = 6;
            aValueDataGridViewTextBoxColumn.Name = "aValueDataGridViewTextBoxColumn";
            aValueDataGridViewTextBoxColumn.Width = 125;
            // 
            // bValueDataGridViewTextBoxColumn
            // 
            bValueDataGridViewTextBoxColumn.DataPropertyName = "BValue";
            bValueDataGridViewTextBoxColumn.HeaderText = "BValue";
            bValueDataGridViewTextBoxColumn.MinimumWidth = 6;
            bValueDataGridViewTextBoxColumn.Name = "bValueDataGridViewTextBoxColumn";
            bValueDataGridViewTextBoxColumn.Width = 125;
            // 
            // densityDataGridViewTextBoxColumn
            // 
            densityDataGridViewTextBoxColumn.DataPropertyName = "Density";
            densityDataGridViewTextBoxColumn.HeaderText = "Density";
            densityDataGridViewTextBoxColumn.MinimumWidth = 6;
            densityDataGridViewTextBoxColumn.Name = "densityDataGridViewTextBoxColumn";
            densityDataGridViewTextBoxColumn.Width = 125;
            // 
            // dataGridView2
            // 
            dataGridView2.AutoGenerateColumns = false;
            dataGridView2.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView2.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn1, dataGridViewTextBoxColumn2, dataGridViewTextBoxColumn3, dataGridViewTextBoxColumn4, dataGridViewTextBoxColumn5 });
            dataGridView2.DataSource = thermalInsulationBindingSource;
            dataGridView2.Location = new Point(12, 274);
            dataGridView2.Name = "dataGridView2";
            dataGridView2.RowHeadersWidth = 51;
            dataGridView2.Size = new Size(1232, 263);
            dataGridView2.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "Name";
            dataGridViewTextBoxColumn1.HeaderText = "Name";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 125;
            // 
            // dataGridViewTextBoxColumn2
            // 
            dataGridViewTextBoxColumn2.DataPropertyName = "MaxTemperatureOfUse";
            dataGridViewTextBoxColumn2.HeaderText = "MaxTemperatureOfUse";
            dataGridViewTextBoxColumn2.MinimumWidth = 6;
            dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            dataGridViewTextBoxColumn2.Width = 125;
            // 
            // dataGridViewTextBoxColumn3
            // 
            dataGridViewTextBoxColumn3.DataPropertyName = "AValue";
            dataGridViewTextBoxColumn3.HeaderText = "AValue";
            dataGridViewTextBoxColumn3.MinimumWidth = 6;
            dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            dataGridViewTextBoxColumn3.Width = 125;
            // 
            // dataGridViewTextBoxColumn4
            // 
            dataGridViewTextBoxColumn4.DataPropertyName = "BValue";
            dataGridViewTextBoxColumn4.HeaderText = "BValue";
            dataGridViewTextBoxColumn4.MinimumWidth = 6;
            dataGridViewTextBoxColumn4.Name = "dataGridViewTextBoxColumn4";
            dataGridViewTextBoxColumn4.Width = 125;
            // 
            // dataGridViewTextBoxColumn5
            // 
            dataGridViewTextBoxColumn5.DataPropertyName = "Density";
            dataGridViewTextBoxColumn5.HeaderText = "Density";
            dataGridViewTextBoxColumn5.MinimumWidth = 6;
            dataGridViewTextBoxColumn5.Name = "dataGridViewTextBoxColumn5";
            dataGridViewTextBoxColumn5.Width = 125;
            // 
            // dataGridView3
            // 
            dataGridView3.AutoGenerateColumns = false;
            dataGridView3.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView3.Columns.AddRange(new DataGridViewColumn[] { dataGridViewTextBoxColumn6 });
            dataGridView3.DataSource = carborundumHeatersBindingSource;
            dataGridView3.Location = new Point(12, 543);
            dataGridView3.Name = "dataGridView3";
            dataGridView3.RowHeadersWidth = 51;
            dataGridView3.Size = new Size(1232, 263);
            dataGridView3.TabIndex = 2;
            // 
            // dataGridViewTextBoxColumn6
            // 
            dataGridViewTextBoxColumn6.DataPropertyName = "Name";
            dataGridViewTextBoxColumn6.HeaderText = "Name";
            dataGridViewTextBoxColumn6.MinimumWidth = 6;
            dataGridViewTextBoxColumn6.Name = "dataGridViewTextBoxColumn6";
            dataGridViewTextBoxColumn6.Width = 125;
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
            Controls.Add(dataGridView3);
            Controls.Add(dataGridView2);
            Controls.Add(dataGridView1);
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
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView2).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView3).EndInit();
            ((System.ComponentModel.ISupportInitialize)carborundumHeatersBindingSource).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private BindingSource fireproofBindingSource;
        private BindingSource thermalInsulationBindingSource;
        private BindingSource carborondumHeatersBindingSource;
        private BindingSource electricMachinesBindingSource;
        private BindingSource heaterMaterialBindingSource;
        private BindingSource metalHeaterBindingSource;
        private BindingSource molybdenumHeatersBindingSource;
        private BindingSource transformersBindingSource;
        private BindingSource wireBindingSource;
        private BindingSource fireproofBindingSource1;
        private BindingSource thermalInsulationBindingSource1;
        private BindingSource fireproofBindingSource2;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn maxTemperatureOfUseDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn aValueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn bValueDataGridViewTextBoxColumn;
        private DataGridViewTextBoxColumn densityDataGridViewTextBoxColumn;
        private DataGridView dataGridView2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn4;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn5;
        private DataGridView dataGridView3;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn6;
        private BindingSource carborundumHeatersBindingSource;
    }
}