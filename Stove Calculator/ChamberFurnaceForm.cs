using AngleSharp.Text;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Stove_Calculator.Analyzers;
using Stove_Calculator.Calculators;
using Stove_Calculator.Furnaces;
using Stove_Calculator.InputValidators;
using Stove_Calculator.Models;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;

namespace Stove_Calculator
{
    public partial class ChamberFurnaceForm : Form
    {

        private struct State
        {
            // Input Data
            public static bool isDoor = true;
            public static bool isDoubleLayer = true;
            public static double furnaceWidth = 0.16;
            public static double furnaceHeight = 0.2;
            public static double furnaceLength = 0.15;
            public static double ambientGasTemperature = 20;
            public static double workTemperature = 1350;
            public static double outerSurfaceTemperature = 70;

            // All possible lining fireproof and insulations
            public static List<Fireproof> liningFireproofs = FireproofAnalyzer.GetFullLiningFireproofs();
            public static List<ThermalInsulation> liningInsulations = ThermalInsulationAnalyzer.GetFullInsulation();

            // Lining parameters data
            public static Fireproof currentLiningFireproof = liningFireproofs[0];
            public static ThermalInsulation currentLiningInsulation = liningInsulations[0];
            public static double liningFireproofWidth = 0;
            public static double liningFireproofTemperature = 0;
            public static double liningInsulationWidth = 0;

            // All possible overlap fireproof and insulations
            public static List<Fireproof> overlapFireproofs = FireproofAnalyzer.GetFullLiningFireproofs();
            public static List<ThermalInsulation> overlapInsulations = ThermalInsulationAnalyzer.GetFullInsulation();

            // Overlap parameters data
            public static Fireproof currentOverlapFireproof = overlapFireproofs[0];
            public static ThermalInsulation currentOverlapInsualtion = overlapInsulations[0];
            public static double overlapFireproofWidth = 0;
            public static double overlapInsualtionWidth = 0;
            public static double overlapLiningTemperature = 0; // rename
            public static double overlapSurfaceTemperature = 0;
        }

        public ChamberFurnaceForm()
        {
            InitializeComponent();

            cmbboxOverlapLayers.SelectedIndex = 0;
            cmbboxOverlapType.SelectedIndex = 0;
            txtboxFurnaceHeight.Text = string.Format("{0:f2}", State.furnaceHeight);
            txtboxFurnaceWidth.Text = string.Format("{0:f2}", State.furnaceWidth);
            txtboxFurnaceLength.Text = string.Format("{0:f2}", State.furnaceLength);
            txtboxAmbientTemperature.Text = string.Format("{0:f2}", State.ambientGasTemperature);
            txtboxWorkTemperature.Text = string.Format("{0:f2}", State.workTemperature);
            txtboxOuterSurfaceTemperature.Text = string.Format("{0:f2}", State.outerSurfaceTemperature);
        }

        private void BtnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                txtboxFurnaceHeight.Enabled = false;
                txtboxFurnaceWidth.Enabled = false;
                txtboxFurnaceLength.Enabled = false;
                txtboxAmbientTemperature.Enabled = false;
                txtboxWorkTemperature.Enabled = false;
                txtboxOuterSurfaceTemperature.Enabled = false;
                cmbboxOverlapLayers.Enabled = false;
                cmbboxOverlapType.Enabled = false;
                btnCalculate.Visible = false;

                State.isDoor = cmbboxOverlapType.Text == "Дверца";
                State.isDoubleLayer = cmbboxOverlapLayers.Text == "2";
                State.furnaceHeight = txtboxFurnaceHeight.Text.ToDouble();
                State.furnaceWidth = txtboxFurnaceWidth.Text.ToDouble();
                State.furnaceLength = txtboxFurnaceLength.Text.ToDouble();
                State.ambientGasTemperature = txtboxAmbientTemperature.Text.ToDouble();
                State.workTemperature = txtboxWorkTemperature.Text.ToDouble();
                State.outerSurfaceTemperature = txtboxOuterSurfaceTemperature.Text.ToDouble();

                State.liningFireproofs = FireproofAnalyzer.GetSuitableLiningFireproofs(State.workTemperature);

                foreach (Fireproof fireproof in State.liningFireproofs)
                {
                    cmbboxLiningFireproof.Items.Add(fireproof.Name);
                }

                cmbboxLiningFireproof.SelectedIndex = 0;
                State.currentLiningFireproof = State.liningFireproofs[0];
                txtboxLiningFireproofWidth.Text = String.Format("{0:f2}", State.liningFireproofWidth);

                State.liningFireproofTemperature = ChamberFurnace.CalculateLiningFireproofSurfaceTemperature(
                    State.liningFireproofs[cmbboxLiningFireproof.SelectedIndex],
                    State.outerSurfaceTemperature,
                    State.ambientGasTemperature,
                    State.workTemperature,
                    State.liningFireproofWidth);

                lblLiningFireproofTemperature.Text = string.Format("{0:f2}", Math.Round(State.liningFireproofTemperature, 2));

                pnlLining.Visible = true;
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
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ни один огнеупор не подойдет для такой температуры");
            }
        }

        private void FillLiningCalculatedData()
        {
            double maxInsulationTemperature = 1100;

            if (State.liningFireproofTemperature < 0)
            {
                lblLiningFireproofTemperature.Text = "Слишком большая толщина огнеупора";
                lblLiningInsulationWidth.Text = "0 м";
                cmbboxLiningInsulation.Items.Clear();
                return;
            }

            lblLiningFireproofTemperature.Text = string.Format("{0:f2}", Math.Round(State.liningFireproofTemperature, 2));

            cmbboxLiningInsulation.Items.Clear();
            lblLiningInsulationWidth.Text = "0 м";

            if (State.liningFireproofTemperature > maxInsulationTemperature) return;

            try
            {
                State.liningInsulations = ThermalInsulationAnalyzer.GetSuitableLiningThermalInsulation(
                State.liningFireproofTemperature, State.workTemperature);

                foreach (ThermalInsulation insulation in State.liningInsulations)
                {
                    cmbboxLiningInsulation.Items.Add(insulation.Name);
                }

                cmbboxLiningInsulation.SelectedIndex = 0;
                State.currentLiningInsulation = State.liningInsulations[cmbboxLiningInsulation.SelectedIndex];
            }
            catch (InvalidOperationException)
            {
                lblLiningFireproofTemperature.Text = "Слишком большая толщина огнеупора";
            }
        }

        private void CmbboxLiningFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            State.currentLiningFireproof = State.liningFireproofs[cmbboxLiningFireproof.SelectedIndex];
            State.liningFireproofTemperature = ChamberFurnace.CalculateLiningFireproofSurfaceTemperature(
                    State.currentLiningFireproof,
                    State.outerSurfaceTemperature,
                    State.ambientGasTemperature,
                    State.workTemperature,
                    State.liningFireproofWidth);

            FillLiningCalculatedData();
        }

        private void TxtboxLiningFireproofWidth_TextChanged(object sender, EventArgs e)
        {
            State.liningFireproofWidth = txtboxLiningFireproofWidth.Text.ToDouble();
            State.liningFireproofTemperature = ChamberFurnace.CalculateLiningFireproofSurfaceTemperature(
                    State.currentLiningFireproof,
                    State.outerSurfaceTemperature,
                    State.ambientGasTemperature,
                    State.workTemperature,
                    State.liningFireproofWidth);
            FillLiningCalculatedData();
        }

        private void CmbboxLiningInsulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            State.currentLiningInsulation = State.liningInsulations[cmbboxLiningInsulation.SelectedIndex];
            State.liningInsulationWidth = ChamberFurnace.CalculateInsulationWidth(
                State.currentLiningInsulation, State.liningFireproofTemperature,
                State.outerSurfaceTemperature, State.ambientGasTemperature
                );
            lblLiningInsulationWidth.Text = string.Format("{0:f2} м", Math.Round(State.liningInsulationWidth, 2));
        }

        private void BtnStopLiningCalculations_Click(object sender, EventArgs e)
        {
            txtboxFurnaceHeight.Enabled = true;
            txtboxFurnaceWidth.Enabled = true;
            txtboxFurnaceLength.Enabled = true;
            txtboxAmbientTemperature.Enabled = true;
            txtboxWorkTemperature.Enabled = true;
            txtboxOuterSurfaceTemperature.Enabled = true;
            cmbboxOverlapLayers.Enabled = true;
            cmbboxOverlapType.Enabled = true;
            btnCalculate.Visible = true;

            cmbboxLiningFireproof.Items.Clear();
            cmbboxLiningInsulation.Items.Clear();
            lblLiningInsulationWidth.Text = "0 м";
            pnlLining.Visible = false;
        }

        private unsafe void BtnCalculateOverlap_Click(object sender, EventArgs e)
        {
            if (State.liningInsulationWidth == 0)
            {
                MessageBox.Show("Расчёт футеровки печи не был закончен");
                return;
            }

            btnCalculateOverlap.Visible = false;
            btnStopLiningCalculations.Visible = false;
            cmbboxLiningFireproof.Enabled = false;
            cmbboxLiningInsulation.Enabled = false;
            txtboxLiningFireproofWidth.Enabled = false;

            State.overlapFireproofs = FireproofAnalyzer.GetSuitableOverlapFireproofs(State.workTemperature);
            ComboBox cmbboxOverlapFireproof = State.isDoubleLayer ? cmbboxDoubleOverlapFireproof : cmbboxSingleOverlapFireproof;
            foreach (Fireproof fireproof in State.overlapFireproofs)
            {
                cmbboxOverlapFireproof.Items.Add(fireproof.Name);
            }

            cmbboxOverlapFireproof.SelectedIndex = 0;
            State.currentOverlapFireproof = State.overlapFireproofs[cmbboxOverlapFireproof.SelectedIndex];

            if (State.isDoubleLayer)
            {
                State.overlapInsulations = ThermalInsulationAnalyzer.GetSuitableOverlapThermalInsulation(State.workTemperature);

                foreach (ThermalInsulation insulations in State.overlapInsulations)
                {
                    cmbboxDoubleOverlapInsulation.Items.Add(insulations.Name);
                }

                cmbboxDoubleOverlapInsulation.SelectedIndex = 0;
                State.currentOverlapInsualtion = State.overlapInsulations[cmbboxDoubleOverlapInsulation.SelectedIndex];

                pnlDoubleOverlap.Visible = true;
            }
            else
            {
                pnlSingleOverlap.Visible = true;
                pnlSingleOverlap.BringToFront();
            }

            pnlDoubleOverlap.Visible = true;
        }

        private unsafe void CmbboxOverlapFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            State.currentOverlapFireproof = State.overlapFireproofs[cmbboxDoubleOverlapFireproof.SelectedIndex];
            double overlapSurfaceTemperature = 0, overlapLiningTemperature = 0;
            ChamberFurnace.CalculateDoubleLayerOverlapSurfaceTemperature(
                State.currentOverlapFireproof, State.currentOverlapInsualtion,
                State.overlapInsualtionWidth, State.overlapFireproofWidth,
                State.workTemperature, State.ambientGasTemperature,
                &overlapSurfaceTemperature, &overlapLiningTemperature
                );

            State.overlapSurfaceTemperature = overlapSurfaceTemperature;
            State.overlapLiningTemperature = overlapLiningTemperature;

            lblDoubleOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(State.overlapSurfaceTemperature, 2));
            lblDoubleOverlapLiningTemperature.Text = string.Format("{0:f2} °C", Math.Round(State.overlapLiningTemperature, 2));

        }

        private unsafe void CmbboxOverlapInsulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            State.currentOverlapInsualtion = State.overlapInsulations[cmbboxDoubleOverlapInsulation.SelectedIndex];

            double overlapSurfaceTemperature = 0, overlapLiningTemperature = 0;
            ChamberFurnace.CalculateDoubleLayerOverlapSurfaceTemperature(
                State.currentOverlapFireproof, State.currentOverlapInsualtion,
                State.overlapInsualtionWidth, State.overlapFireproofWidth,
                State.workTemperature, State.ambientGasTemperature,
                &overlapSurfaceTemperature, &overlapLiningTemperature
                );

            State.overlapSurfaceTemperature = overlapSurfaceTemperature;
            State.overlapLiningTemperature = overlapLiningTemperature;

            lblDoubleOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(State.overlapSurfaceTemperature, 2));
            lblDoubleOverlapLiningTemperature.Text = string.Format("{0:f2} °C", Math.Round(State.overlapLiningTemperature, 2));
        }

        private unsafe void TxtboxOverlapFireproofWidth_TextChanged(object sender, EventArgs e)
        {

            State.overlapFireproofWidth = txtboxDoubleOverlapFireproofWidth.Text.ToDouble();

            double overlapSurfaceTemperature = 0, overlapLiningTemperature = 0;
            ChamberFurnace.CalculateDoubleLayerOverlapSurfaceTemperature(
                State.currentOverlapFireproof, State.currentOverlapInsualtion,
                State.overlapInsualtionWidth, State.overlapFireproofWidth,
                State.workTemperature, State.ambientGasTemperature,
                &overlapSurfaceTemperature, &overlapLiningTemperature
                );

            State.overlapSurfaceTemperature = overlapSurfaceTemperature;
            State.overlapLiningTemperature = overlapLiningTemperature;

            lblDoubleOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(State.overlapSurfaceTemperature, 2));
            lblDoubleOverlapLiningTemperature.Text = string.Format("{0:f2} °C", Math.Round(State.overlapLiningTemperature, 2));

        }

        private unsafe void TxtboxOverlapInsulationWidth_TextChanged(object sender, EventArgs e)
        {

            State.overlapInsualtionWidth = txtboxDoubleOverlapInsulationWidth.Text.ToDouble();
            double overlapSurfaceTemperature = 0, overlapLiningTemperature = 0;
            ChamberFurnace.CalculateDoubleLayerOverlapSurfaceTemperature(
                State.currentOverlapFireproof, State.currentOverlapInsualtion,
                State.overlapInsualtionWidth, State.overlapFireproofWidth,
                State.workTemperature, State.ambientGasTemperature,
                &overlapSurfaceTemperature, &overlapLiningTemperature
                );

            State.overlapSurfaceTemperature = overlapSurfaceTemperature;
            State.overlapLiningTemperature = overlapLiningTemperature;

            lblDoubleOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(State.overlapSurfaceTemperature, 2));
            lblDoubleOverlapLiningTemperature.Text = string.Format("{0:f2} °C", Math.Round(State.overlapLiningTemperature, 2));
        }

        private void cmbboxSingleOverlapFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            State.currentOverlapFireproof = State.overlapFireproofs[cmbboxSingleOverlapFireproof.SelectedIndex];
            State.overlapSurfaceTemperature = ChamberFurnace.CalculateOneLayerOverlapSurfaceTemperature(
                State.currentOverlapFireproof, State.ambientGasTemperature,
                State.workTemperature, State.overlapFireproofWidth
                );

            lblSingleOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(State.overlapSurfaceTemperature, 2));
        }

        private void txtboxSingleOverlapFireproofWidth_TextChanged(object sender, EventArgs e)
        {
            State.overlapFireproofWidth = txtboxSingleOverlapFireproofWidth.Text.ToDouble();
            State.overlapSurfaceTemperature = ChamberFurnace.CalculateOneLayerOverlapSurfaceTemperature(
                State.currentOverlapFireproof, State.ambientGasTemperature,
                State.workTemperature, State.overlapFireproofWidth
                );

            lblSingleOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(State.overlapSurfaceTemperature, 2));
        }

        private void BtnStopOverlapCalculation_Click(object sender, EventArgs e)
        {
            //furnace.resetOverlapCalculation();

            //cmbboxLiningFireproof.Enabled = true;
            //cmbboxLiningInsulation.Enabled = true;
            //txtboxLiningFireproofWidth.Enabled = true;
            //btnCalculateOverlap.Visible = true;
            //btnStopLiningCalculations.Visible = true;

            //pnlDoubleOverlap.Visible = false;
        }

        private void BtnCalculateHeater_Click(object sender, EventArgs e)
        {
            //panel2.Visible = true;
        }

        private void TxtboxFurnaceHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxFurnaceHeight.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void TxtboxFurnaceWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxFurnaceWidth.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void TxtboxFurnaceLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxFurnaceLength.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void TxtboxAmbientTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxAmbientTemperature.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void TxtboxWorkTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxWorkTemperature.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void TxtboxOuterSurfaceTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxOuterSurfaceTemperature.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void TxtboxLiningFireproofWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxLiningFireproofWidth.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void TxtboxOverlapFireproofWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxDoubleOverlapFireproofWidth.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void TxtboxOverlapInsulationWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxDoubleOverlapInsulationWidth.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
    }
}
