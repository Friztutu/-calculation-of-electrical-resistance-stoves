using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AngleSharp.Text;
using Stove_Calculator.Calculators;
using Stove_Calculator.InputValidators;
using static System.Windows.Forms.AxHost;
using Stove_Calculator.Models;

namespace Stove_Calculator
{
    public partial class TubeFurnaceForm : Form
    {

        private TubeFurnace furnace;
        private readonly int yOffset = 36;

        private struct State
        {
            public static List<Fireproof> liningFireproofs;
            public static List<ThermalInsulation> liningInsulations;

            public static List<Fireproof> overlapFireproofs;
            public static List<ThermalInsulation> overlapInsulations;
        }

        public TubeFurnaceForm()
        {
            InitializeComponent();

            //double defaultLength = 0.58;
            //double defaultDiameter = 0.075;
            //double defaultAmbientTemperature = 25;
            //double defaultWorkTemperature = 1140;
            //double defaultOuterSurfaceTemperature = 75;
            //bool defaultIsDoubleLayer = true;
            //bool defaultIsWithDoor = false;

            //cmbboxOverlapLayers.SelectedIndex = 0;
            //cmbboxOverlapType.SelectedIndex = 0;
            //txtboxFurnaceLength.Text = string.Format("{0:f2}", defaultLength);
            //txtboxFurnaceDiameter.Text = string.Format("{0:f2}", defaultDiameter);
            //txtboxAmbientTemperature.Text = string.Format("{0:f2}", defaultAmbientTemperature);
            //txtboxWorkTemperature.Text = string.Format("{0:f2}", defaultWorkTemperature);
            //txtboxOuterSurfaceTemperature.Text = string.Format("{0:f2}", defaultOuterSurfaceTemperature);

            //furnace = new(defaultLength, defaultDiameter,
            //    defaultWorkTemperature, defaultAmbientTemperature, defaultOuterSurfaceTemperature,
            //    defaultIsWithDoor, defaultIsDoubleLayer);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            //try
            //{
            //    bool isDoor = cmbboxOverlapType.Text == "Дверца";
            //    bool isDoubleLayer = cmbboxOverlapLayers.Text == "2";
            //    double furnaceDiameter = txtboxFurnaceDiameter.Text.ToDouble();
            //    double furnaceLength = txtboxFurnaceLength.Text.ToDouble();
            //    double ambientTemperature = txtboxAmbientTemperature.Text.ToDouble();
            //    double workTemperature = txtboxWorkTemperature.Text.ToDouble();
            //    double outerSurfaceTemperature = txtboxOuterSurfaceTemperature.Text.ToDouble();

            //    furnace = new(
            //        furnaceLength, furnaceDiameter,
            //        workTemperature, ambientTemperature, outerSurfaceTemperature,
            //        isDoor, isDoubleLayer);

            //    State.liningFireproofs = FireproofAnalyzer.GetSuitableLiningFireproofs(furnace.WorkTemperature);

            //    foreach (Fireproof fireproof in State.liningFireproofs)
            //    {
            //        cmbboxLiningFireproof.Items.Add(fireproof.Name);
            //    }

            //    State.liningInsulations = ThermalInsulationAnalyzer.GetSuitableOverlapThermalInsulation(furnace.WorkTemperature);

            //    foreach (ThermalInsulation insulation in State.liningInsulations)
            //    {
            //        cmbboxLiningInsulation.Items.Add(insulation.Name);
            //    }

            //    cmbboxLiningFireproof.SelectedIndex = 0;
            //    cmbboxLiningInsulation.SelectedIndex = 0;

            //    txtboxLiningFireproofWidth.Text = string.Format("{0:f2}", Math.Round(furnace.LiningFireproofWidth, 2));
            //    lblLiningFireproofTemperature.Text = string.Format("{0:f2}", Math.Round(furnace.LiningFireproofSurfaceTemperature, 2));

            //    pnlLining.Visible = true;
            //}
            //catch (FormatException)
            //{
            //    MessageBox.Show("Ошибка ввода данных!!");
            //}
            //catch (ArgumentNullException)
            //{
            //    MessageBox.Show("Одно из полей равно NULL");
            //}
            //catch (OverflowException)
            //{
            //    MessageBox.Show("Одно из введеных чисел слишком мало или слишком велико");
            //}
            //catch (ArgumentOutOfRangeException)
            //{
            //    MessageBox.Show("Ни один огнеупор не подойдет для такой температуры");
            //}
        }

        private void cmbboxLiningFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            //furnace.LiningFireproof = State.liningFireproofs[cmbboxLiningFireproof.SelectedIndex];
            //lblLiningFireproofTemperature.Text = string.Format("{0:f2} °C", Math.Round(furnace.LiningFireproofSurfaceTemperature, 2));
            //lblLiningInsulationWidth.Text = string.Format("{0:f2} м", Math.Round(furnace.LiningInsulationWidth, 2));
        }

        private void cmbboxLiningInsulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            //furnace.LiningInsulation = State.liningInsulations[cmbboxLiningInsulation.SelectedIndex];
            //lblLiningFireproofTemperature.Text = string.Format("{0:f2} °C", Math.Round(furnace.LiningFireproofSurfaceTemperature, 2));
            //lblLiningInsulationWidth.Text = string.Format("{0:f2} м", Math.Round(furnace.LiningInsulationWidth, 2));
        }

        private void txtboxLiningFireproofWidth_TextChanged(object sender, EventArgs e)
        {
            //furnace.LiningFireproofWidth = txtboxLiningFireproofWidth.Text.ToDouble();
            //lblLiningFireproofTemperature.Text = string.Format("{0:f2} °C", Math.Round(furnace.LiningFireproofSurfaceTemperature, 2));
            //lblLiningInsulationWidth.Text = string.Format("{0:f2} м", Math.Round(furnace.LiningInsulationWidth, 2));
        }

        private void btnCalculateOverlap_Click(object sender, EventArgs e)
        {
            cmbboxLiningFireproof.Enabled = false;
            cmbboxLiningInsulation.Enabled = false;
            txtboxLiningFireproofWidth.Enabled = false;
            btnCalculateOverlap.Visible = false;
            btnStopLiningCalculations.Visible = false;

            pnlOverlap.Visible = true;
        }

        private void btnStopLiningCalculations_Click(object sender, EventArgs e)
        {
            pnlLining.Visible = false;
        }

        private void txtboxFurnaceLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxFurnaceLength.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtboxFurnaceDiameter_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxFurnaceDiameter.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtboxAmbientTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxAmbientTemperature.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtboxWorkTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxWorkTemperature.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtboxOuterSurfaceTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxOuterSurfaceTemperature.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtboxLiningFireproofWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxLiningFireproofWidth.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtboxOverlapFireproofWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxOverlapFireproofWidth.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtboxOverlapInsulationWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxOverlapInsulationWidth.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }
    }
}
