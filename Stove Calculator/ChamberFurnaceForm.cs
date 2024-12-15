using AngleSharp.Text;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Microsoft.EntityFrameworkCore.Storage.Json;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal;
using Stove_Calculator.Analyzers;
using Stove_Calculator.Calculators;
using Stove_Calculator.Errors;
using Stove_Calculator.Furnaces;
using Stove_Calculator.InputValidators;
using Stove_Calculator.Models;
using Stove_Calculator.States;
using System.Diagnostics;
using System.DirectoryServices.ActiveDirectory;
using System.Runtime.CompilerServices;
using System.Security.RightsManagement;

namespace Stove_Calculator
{
    public partial class ChamberFurnaceForm : Form
    {
        private static readonly ChamberState chamberState = new();
        public ChamberFurnaceForm()
        {
            InitializeComponent();
        }

        private unsafe void BtnCalculate_Click(object sender, EventArgs e)
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

                bool isDoor = cmbboxOverlapType.Text == "Дверца";
                bool isDoubleLayer = cmbboxOverlapLayers.Text == "2";
                double L1 = txtboxFurnaceHeight.Text.ToDouble();
                double L2 = txtboxFurnaceWidth.Text.ToDouble();
                double L3 = txtboxFurnaceLength.Text.ToDouble();
                double t0 = txtboxAmbientTemperature.Text.ToDouble();
                double t1 = txtboxWorkTemperature.Text.ToDouble();
                double t3 = txtboxOuterSurfaceTemperature.Text.ToDouble();

                chamberState.GetInpuData(L1, L2, L3, t0, t1, t3, isDoor, isDoubleLayer);

                if (chamberState.LiningFireproofs == null) return;

                cmbboxLiningFireproof.Items.Clear();
                cmbboxLiningInsulation.Items.Clear();

                foreach (Fireproof fireproof in chamberState.LiningFireproofs)
                {
                    cmbboxLiningFireproof.Items.Add(fireproof.Name);
                }

                cmbboxLiningFireproof.SelectedIndex = 0;
                txtboxLiningFireproofWidth.Text = String.Format("{0:f2}", chamberState.H1);
                lblLiningFireproofTemperature.Text = string.Format("{0:f2}", Math.Round(chamberState.T2, 2));

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
            catch (NotCorrectInputDataException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void UpdateLiningData()
        {
            cmbboxLiningInsulation.Items.Clear();

            if (chamberState.T2 < 0)
            {
                lblLiningFireproofTemperature.Text = "Уменьшите толщину огнеупора.";
                cmbboxLiningInsulation.Items.Clear();
                lblLiningInsulationWidth.Text = "0 м";
                return;
            }

            lblLiningFireproofTemperature.Text = string.Format("{0:f2} °C", Math.Round(chamberState.T2, 2));

            if (chamberState.T2 > 1100 || chamberState.LiningInsulations == null)
            {
                cmbboxLiningInsulation.Items.Clear();
                lblLiningInsulationWidth.Text = "0 м";
                return;

            }

            foreach (ThermalInsulation ins in chamberState.LiningInsulations)
            {
                cmbboxLiningInsulation.Items.Add(ins.Name);
            }
            cmbboxLiningInsulation.SelectedIndex = 0;
            lblLiningInsulationWidth.Text = string.Format("{0:f2} м", Math.Round(chamberState.H2, 2));
        }
        private void CmbboxLiningFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chamberState.LiningFireproofs == null) return;

            chamberState.ChangeLiningFireproof(chamberState.LiningFireproofs[cmbboxLiningFireproof.SelectedIndex]);
            UpdateLiningData();
        }

        private unsafe void TxtboxLiningFireproofWidth_TextChanged(object sender, EventArgs e)
        {
            chamberState.ChangeLiningFireroofWidth(txtboxLiningFireproofWidth.Text.ToDouble());
            if (chamberState.LiningFireproofs == null) return;
            chamberState.ChangeLiningFireproof(chamberState.LiningFireproofs[cmbboxLiningFireproof.SelectedIndex]);
            UpdateLiningData();
        }

        private unsafe void CmbboxLiningInsulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chamberState.LiningInsulations == null) return;

            chamberState.ChangeLiningInsulation(chamberState.LiningInsulations[cmbboxLiningInsulation.SelectedIndex]);
            lblLiningInsulationWidth.Text = string.Format("{0:f2} м", Math.Round(chamberState.H2, 2));
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

            chamberState.ResetLiningData();
            pnlLining.Visible = false;
        }

        private void BtnCalculateOverlap_Click(object sender, EventArgs e)
        {
            cmbboxDoubleOverlapFireproof.Items.Clear();
            cmbboxDoubleOverlapInsulation.Items.Clear();
            cmbboxSingleOverlapFireproof.Items.Clear();

            if (chamberState.H2 == 0)
            {
                MessageBox.Show("Расчёт футеровки печи не был закончен");
                return;
            }

            btnCalculateOverlap.Visible = false;
            btnStopLiningCalculations.Visible = false;
            cmbboxLiningFireproof.Enabled = false;
            cmbboxLiningInsulation.Enabled = false;
            txtboxLiningFireproofWidth.Enabled = false;

            chamberState.StartOverlapCalcultions();

            if (chamberState.OverlapFireproofs == null) return;

            ComboBox cmbboxOverlapFireproof = chamberState.IsDoubleLayer ?
                cmbboxDoubleOverlapFireproof : cmbboxSingleOverlapFireproof;

            foreach (Fireproof fireproof in chamberState.OverlapFireproofs)
            {
                cmbboxOverlapFireproof.Items.Add(fireproof.Name);
            }

            cmbboxOverlapFireproof.SelectedIndex = 0;

            if (chamberState.IsDoubleLayer)
            {
                if (chamberState.OverlapInsulations == null) return;

                foreach (ThermalInsulation insulations in chamberState.OverlapInsulations)
                {
                    cmbboxDoubleOverlapInsulation.Items.Add(insulations.Name);
                }

                cmbboxDoubleOverlapInsulation.SelectedIndex = 0;

                pnlDoubleOverlap.Visible = true;
            }
            else
            {
                pnlSingleOverlap.Visible = true;
                pnlSingleOverlap.BringToFront();
            }

            pnlDoubleOverlap.Visible = true;
        }

        private void UpdateOverlapData()
        {
            if (chamberState.IsDoubleLayer && (chamberState.H3 == 0 || chamberState.H4 == 0))
            {
                lblDoubleOverlapTemperature.Text = "Нет данных";
                lblDoubleOverlapLiningTemperature.Text = "Нет данных";
                return;
            }
            else if (!chamberState.IsDoubleLayer && chamberState.H3 == 0)
            {
                lblSingleOverlapLiningTemperature.Text = "Нет данных";
            }

            if (chamberState.IsDoubleLayer)
            {
                lblDoubleOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(chamberState.T4, 2));
                lblDoubleOverlapLiningTemperature.Text = string.Format("{0:f2} °C", Math.Round(chamberState.T5, 2));
            }
            else
            {
                lblSingleOverlapLiningTemperature.Text = string.Format("{0:f2} °C", Math.Round(chamberState.T5, 2));
            }
        }

        private unsafe void CmbboxOverlapFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chamberState.OverlapFireproofs == null) return;

            chamberState.ChangeOverlapFireproof(chamberState.OverlapFireproofs[cmbboxDoubleOverlapFireproof.SelectedIndex]);

            UpdateOverlapData();
        }

        private unsafe void CmbboxOverlapInsulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chamberState.OverlapInsulations == null) return;

            chamberState.ChangeOverlapInsulation(chamberState.OverlapInsulations[cmbboxDoubleOverlapInsulation.SelectedIndex]);

            UpdateOverlapData();
        }

        private unsafe void TxtboxOverlapFireproofWidth_TextChanged(object sender, EventArgs e)
        {

            chamberState.ChangeOverlapFireproofWidth(txtboxDoubleOverlapFireproofWidth.Text.ToDouble());

            UpdateOverlapData();
        }

        private unsafe void TxtboxOverlapInsulationWidth_TextChanged(object sender, EventArgs e)
        {
            chamberState.ChangeOverlapInsulationWidth(txtboxDoubleOverlapInsulationWidth.Text.ToDouble());

            UpdateOverlapData();
        }

        private void CmbboxSingleOverlapFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            chamberState.ChangeOverlapFireproofWidth(txtboxDoubleOverlapFireproofWidth.Text.ToDouble());

            UpdateOverlapData();
        }

        private void TxtboxSingleOverlapFireproofWidth_TextChanged(object sender, EventArgs e)
        {
            chamberState.ChangeOverlapInsulationWidth(txtboxDoubleOverlapInsulationWidth.Text.ToDouble());

            UpdateOverlapData();
        }

        private void BtnStopOverlapCalculation_Click(object sender, EventArgs e)
        {
            chamberState.ResetOverlapData();

            pnlDoubleOverlap.Visible = false;
            pnlSingleOverlap.Visible = false;

            btnCalculateOverlap.Visible = true;
            btnStopLiningCalculations.Visible = true;
            cmbboxLiningFireproof.Enabled = true;
            cmbboxLiningInsulation.Enabled = true;
            txtboxLiningFireproofWidth.Enabled = true;
        }

        private void BtnCalculateHeater_Click(object sender, EventArgs e)
        {
            if (chamberState.CurrentLiningFireproof == null || chamberState.CurrentLiningInsultion == null
                || chamberState.CurrentOverlapFireproof == null || chamberState.CurrentOverlapInsulation == null) return;

            if (chamberState.IsDoubleLayer)
            {
                cmbboxDoubleOverlapFireproof.Enabled = false;
                cmbboxDoubleOverlapInsulation.Enabled = false;
                txtboxDoubleOverlapFireproofWidth.Enabled = false;
                txtboxDoubleOverlapInsulationWidth.Enabled = false;
            }
            else
            {
                cmbboxSingleOverlapFireproof.Enabled = false;
                txtboxSingleOverlapFireproofWidth.Enabled = false;
                cmbboxSingleOverlapFireproof.Items.Clear();
            }

            BtnEndThermalCalc.Visible = false;
            btnStopOverlapCalculation.Visible = false;

            chamberState.UpdateFullThermalData();

            MessageBox.Show(chamberState.X1.ToString());
            label25.Text = string.Format("a1 = {0:f5}", Math.Round(chamberState.CurrentLiningFireproof.AValue, 5));
            label26.Text = string.Format("b1 = {0:f5}", Math.Round(chamberState.CurrentLiningFireproof.BValue, 5));
            label29.Text = string.Format("x1 = {0:f5}", Math.Round(chamberState.X1, 5));
            label28.Text = string.Format("h1 = {0:f5}", Math.Round(chamberState.H1, 5));
            label34.Text = string.Format("t6 = {0:f2}", Math.Round(chamberState.CurrentLiningFireproof.MaxTemperatureOfUse, 2));
            label33.Text = string.Format("F0 = {0:f5}", Math.Round(chamberState.F00, 5));

            label40.Text = string.Format("a2 = {0:f5}", Math.Round(chamberState.CurrentLiningInsultion.AValue, 5));
            label39.Text = string.Format("b2 = {0:f5}", Math.Round(chamberState.CurrentLiningInsultion.BValue, 5));
            label38.Text = string.Format("x2 = {0:f5}", Math.Round(chamberState.X2, 5));
            label37.Text = string.Format("h2 = {0:f5}", Math.Round(chamberState.H2, 5));
            label36.Text = string.Format("t7 = {0:f2}", Math.Round(chamberState.CurrentLiningInsultion.MaxTemperatureOfUse, 2));
            label35.Text = string.Format("Ft = {0:f5}", Math.Round(chamberState.Ftt, 5));

            label46.Text = string.Format("a3 = {0:f5}", Math.Round(chamberState.CurrentOverlapFireproof.AValue, 5));
            label45.Text = string.Format("b3 = {0:f5}", Math.Round(chamberState.CurrentOverlapFireproof.BValue, 5));
            label44.Text = string.Format("x3 = {0:f5}", Math.Round(chamberState.X3, 5));
            label43.Text = string.Format("h3 = {0:f5}", Math.Round(chamberState.H3, 5));
            label42.Text = string.Format("t8 = {0:f2}", Math.Round(chamberState.CurrentOverlapFireproof.MaxTemperatureOfUse, 2));
            label41.Text = string.Format("F4 = {0:f5}", Math.Round(chamberState.F44, 5));

            label52.Text = string.Format("a4 = {0:f5}", Math.Round(chamberState.CurrentOverlapInsulation.AValue, 5));
            label51.Text = string.Format("b4 = {0:f5}", Math.Round(chamberState.CurrentOverlapInsulation.BValue, 5));
            label50.Text = string.Format("x4 = {0:f5}", Math.Round(chamberState.X4, 5));
            label49.Text = string.Format("h4 = {0:f5}", Math.Round(chamberState.H4, 5));
            label48.Text = string.Format("t9 = {0:f2}", Math.Round(chamberState.CurrentOverlapInsulation.MaxTemperatureOfUse, 2));
            label47.Text = string.Format("F4 = {0:f5}", Math.Round(chamberState.F44, 5));

            label58.Text = string.Format("F1 = {0:f5}", Math.Round(chamberState.F11, 5));
            label57.Text = string.Format("t2 = {0:f2}", Math.Round(chamberState.T2, 2));
            label56.Text = string.Format("y1 = {0:f5}", Math.Round(chamberState.Y1, 5));
            label55.Text = string.Format("q1 = {0:f5}", Math.Round(chamberState.Q11, 5));
            label54.Text = string.Format("F2 = {0:f5}", Math.Round(chamberState.F22, 5));
            label53.Text = string.Format("F3 = {0:f5}", Math.Round(chamberState.F33, 5));
            label60.Text = string.Format("t3 = {0:f2}", Math.Round(chamberState.T3, 2));
            label59.Text = string.Format("Q1 = {0:f5}", Math.Round(chamberState.Q111, 5));

            label64.Text = string.Format("t4 = {0:f2}", Math.Round(chamberState.T4, 2));
            label63.Text = string.Format("y2 = {0:f5}", Math.Round(chamberState.Y2, 5));
            label62.Text = string.Format("q2 = {0:f5}", Math.Round(chamberState.Q22, 5));
            label61.Text = string.Format("t5 = {0:f5}", Math.Round(chamberState.T5, 2));
            label65.Text = string.Format("Q2 = {0:f5}", Math.Round(chamberState.Q222, 5));

            label72.Text = string.Format("L1 = {0:f2}", Math.Round(chamberState.L1, 2));
            label69.Text = string.Format("L2 = {0:f2}", Math.Round(chamberState.L2, 2));
            label70.Text = string.Format("L3 = {0:f2}", Math.Round(chamberState.L3, 2));
            label71.Text = string.Format("L4 = {0:f5}", Math.Round(chamberState.L4, 2));
            label73.Text = string.Format("t0 = {0:f2}", Math.Round(chamberState.T0, 2));
            label74.Text = string.Format("t1 = {0:f2}", Math.Round(chamberState.T1, 2));

            panel2.Visible = true;
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

        private void iconButton4_Click(object sender, EventArgs e)
        {
            if (chamberState.IsDoubleLayer)
            {
                cmbboxDoubleOverlapFireproof.Enabled = true;
                cmbboxDoubleOverlapInsulation.Enabled = true;
                txtboxDoubleOverlapFireproofWidth.Enabled = true;
                txtboxDoubleOverlapInsulationWidth.Enabled = true;
            }
            else
            {
                cmbboxSingleOverlapFireproof.Enabled = true;
                txtboxSingleOverlapFireproofWidth.Enabled = true;
            }

            BtnEndThermalCalc.Visible = true;
            btnStopOverlapCalculation.Visible = true;

            panel2.Visible = false;
        }
    }
}
