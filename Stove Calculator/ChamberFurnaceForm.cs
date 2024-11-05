using AngleSharp.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Stove_Calculator.Analyzers;
using Stove_Calculator.Calculators;
using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;

namespace Stove_Calculator
{
    public partial class ChamberFurnaceForm : Form
    {
        public ChamberFurnaceForm()
        {
            InitializeComponent();
        }

        private readonly Validator validator = new();

        private ChamberFurnace calc;
        private List<Fireproof> linigFireproofs;
        private List<ThermalInsulation> liningInsulations;
        private List<Fireproof> overlapFireproofs;
        private List<ThermalInsulation> overlapInsulations;

        private void StoveHeightTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(StoveHeightTextBox.Text, e.KeyChar) == false)
                e.Handled = true;
        }

        private void StoveWidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(StoveWidthTextBox.Text, e.KeyChar) == false)
                e.Handled = true;
        }

        private void StoveLengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(StoveLengthTextBox.Text, e.KeyChar) == false)
                e.Handled = true;
        }

        private void MaximumSampleTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(MaximumSampleTemperature.Text, e.KeyChar) == false)
                e.Handled = true;
        }

        private void AmbientGasTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(AmbientGasTemperature.Text, e.KeyChar) == false)
                e.Handled = true;
        }

        private void TemperatureOuterSurface_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(TemperatureOuterSurface.Text, e.KeyChar) == false)
                e.Handled = true;
        }

        private void fireproofWidthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(fireproofWidthTextBox.Text, e.KeyChar) == false)
                e.Handled = true;
        }

        private void fireproofSurfaceTemperatureTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(fireproofSurfaceTemperatureTextBox.Text, e.KeyChar) == false)
                e.Handled = true;
        }

        private void openResult()
        {
            comboBox1.Visible = true;
            comboBox2.Visible = true;
            comboBox5.Visible = true;
            label1.Visible = true;
            label14.Visible = true;
            label15.Visible = true;
            label16.Visible = true;
            label17.Visible = true;
            label18.Visible = true;
            label19.Visible = true;
            label20.Visible = true;
            label21.Visible = true;
            label22.Visible = true;
            label22.Visible = true;
            label25.Visible = true;
            label26.Visible = true;
            label27.Visible = true;
            label28.Visible = true;
            label29.Visible = true;
            fireproofWidthTextBox.Visible = true;
            fireproofSurfaceTemperatureTextBox.Visible = true;
            thermalInsulationWidthTextBox.Visible = true;
            heatFlowTextBox.Visible = true;
            textBox1.Visible = true;
            textBox2.Visible = true;
        }

        private void updateData()
        {
            if (calc.LiningFireproofSurfaceTemperature < 0 || double.IsNaN(calc.LiningFireproofSurfaceTemperature))
            {
                fireproofSurfaceTemperatureTextBox.Text = "Уменьшите толщину огнеупора";
            }
            else
            {
                fireproofSurfaceTemperatureTextBox.Text = string.Format("{0:f2}", calc.LiningFireproofSurfaceTemperature);
            }

            if (calc.LiningFireproofSurfaceTemperature >= 1100)
            {
                comboBox2.Items.Clear();
                comboBox2.Text = "";
                thermalInsulationWidthTextBox.Clear();
                textBox2.Clear();
                textBox1.Clear();
                return;
            }

            liningInsulations = ThermalInsulationAnalyzer.GetSuitableLiningThermalInsulation(calc.LiningFireproofSurfaceTemperature, calc.MaxSampleTemperature);
            comboBox2.Items.Clear();

            foreach (ThermalInsulation thermalInsulation in liningInsulations)
            {
                comboBox2.Items.Add(thermalInsulation.Name);
            }

            comboBox2.SelectedIndex = 0;

            overlapFireproofs = FireproofAnalyzer.GetSuitableOverlapFireproofs(calc.MaxSampleTemperature);
            comboBox5.Items.Clear();

            foreach (Fireproof fireproof in overlapFireproofs) 
            {
                comboBox5.Items.Add(fireproof.Name);
            }

            comboBox5.SelectedIndex = 0;

            textBox2.Text = calc.OverlapFireproofSurfaceTemperature.ToString();
        }

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            comboBox1.Items.Clear();

            try
            {
                double stoveHeight = double.Parse(StoveHeightTextBox.Text);
                double stoveWidth = double.Parse(StoveWidthTextBox.Text);
                double stoveLength = double.Parse(StoveLengthTextBox.Text);
                double maxSampleTemperature = double.Parse(MaximumSampleTemperature.Text);
                double ambientGasTemperature = double.Parse(AmbientGasTemperature.Text);
                double outerSurfaceTemperature = double.Parse(TemperatureOuterSurface.Text);
                bool isWithDoor = comboBox3.Text == "Дверца";
                bool isDoubleLayer = comboBox4.Text == "2";

                calc = new(
                    stoveLength, stoveHeight, stoveWidth,
                    maxSampleTemperature, ambientGasTemperature, outerSurfaceTemperature,
                    isWithDoor, isDoubleLayer
                    );

                linigFireproofs = FireproofAnalyzer.GetSuitableLiningFireproofs(calc.MaxSampleTemperature);

                openResult();

                foreach (Fireproof fireproof in linigFireproofs)
                {
                    comboBox1.Items.Add(fireproof.Name);
                }

                comboBox1.SelectedIndex = 0;
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода данных!!");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Одно из полей равно NULL");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Одно из введеных чисел слишком мало или слишком велико");
            }
            catch (InvalidOperationException)
            {
                MessageBox.Show("Не один из огнеупоров не выдержит такой температуры :(");
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            calc.LiningFireproof = linigFireproofs[comboBox1.SelectedIndex];
            updateData();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (fireproofWidthTextBox.Text == "") return;

            calc.LiningFireproofWidth = Double.Parse(fireproofWidthTextBox.Text);
            updateData();
        }

        private void fireproofSurfaceTemperatureTextBox_TextChanged(object sender, EventArgs e)
        {
            //if (fireproofSurfaceTemperatureTextBox.Text == "") return;

            //calc.FireproofSurfaceTemperature = Double.Parse(fireproofSurfaceTemperatureTextBox.Text);
            //updateData();
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            calc.LiningInsulation = liningInsulations[comboBox2.SelectedIndex];
            thermalInsulationWidthTextBox.Text = calc.LiningInsulationWidth.ToString();
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
            calc.OverlapFireproofWidth = textBox1.Text.ToDouble();
            updateData();
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {
            calc.OverlapFireproof = overlapFireproofs[comboBox5.SelectedIndex];
            textBox2.Text = calc.OverlapFireproofSurfaceTemperature.ToString();
        }
    }
}
