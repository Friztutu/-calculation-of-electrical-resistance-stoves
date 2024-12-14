using AngleSharp.Text;
using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using Stove_Calculator.Analyzers;
using Stove_Calculator.Calculators;
using Stove_Calculator.InputValidators;
using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Data;
using System.DirectoryServices.ActiveDirectory;
using System.Drawing;
using System.Linq;
using System.Linq.Expressions;
using System.Printing;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media.Animation;
using UglyToad.PdfPig.Graphics.Operations.PathConstruction;

namespace Stove_Calculator
{
    public partial class ChamberFurnaceForm : Form
    {

        private ChamberFurnace furnace;
        private readonly int yOffset = 36;
        
        private struct State
        {
            public static List<Fireproof> liningFireproofs;
            public static List<ThermalInsulation> liningInsulations;
            
            public static List<Fireproof> overlapFireproofs;
            public static List<ThermalInsulation> overlapInsulations;
        }

        public ChamberFurnaceForm()
        {
            InitializeComponent();

            double defaultWidth = 0.16;
            double defaultHeight = 0.2;
            double defaultLength = 0.15;
            double defaultAmbientTemperature = 20;
            double defaultWorkTemperature = 1350;
            double defaultOuterSurfaceTemperature = 70;
            bool defaultIsDoubleLayer = true;
            bool defaultIsWithDoor = true;

            cmbboxOverlapLayers.SelectedIndex = 0;
            cmbboxOverlapType.SelectedIndex = 0;
            txtboxFurnaceHeight.Text = string.Format("{0:f2}", defaultHeight);
            txtboxFurnaceWidth.Text = string.Format("{0:f2}", defaultWidth);
            txtboxFurnaceLength.Text = string.Format("{0:f2}", defaultLength);
            txtboxAmbientTemperature.Text = string.Format("{0:f2}", defaultAmbientTemperature);
            txtboxWorkTemperature.Text = string.Format("{0:f2}", defaultWorkTemperature);
            txtboxOuterSurfaceTemperature.Text = string.Format("{0:f2}", defaultOuterSurfaceTemperature);

            furnace = new(defaultLength, defaultHeight, defaultWidth,
                defaultWorkTemperature, defaultAmbientTemperature, defaultOuterSurfaceTemperature,
                defaultIsWithDoor, defaultIsDoubleLayer);
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                bool isDoor = cmbboxOverlapType.Text == "Дверца";
                bool isDoubleLayer = cmbboxOverlapLayers.Text == "2";
                double furnaceHeight = txtboxFurnaceHeight.Text.ToDouble();
                double furnaceWidth = txtboxFurnaceWidth.Text.ToDouble();
                double furnaceLength = txtboxFurnaceLength.Text.ToDouble();
                double ambientTemperature = txtboxAmbientTemperature.Text.ToDouble();
                double workTemperature = txtboxWorkTemperature.Text.ToDouble();
                double outerSurfaceTemperature = txtboxOuterSurfaceTemperature.Text.ToDouble();

                furnace = new(
                    furnaceLength, furnaceHeight, furnaceWidth,
                    workTemperature, ambientTemperature, outerSurfaceTemperature,
                    isDoor, isDoubleLayer);

                State.liningFireproofs = FireproofAnalyzer.GetSuitableLiningFireproofs(furnace.WorkTemperature);

                foreach (Fireproof fireproof in State.liningFireproofs)
                {
                    cmbboxLiningFireproof.Items.Add(fireproof.Name);
                }

                cmbboxLiningFireproof.SelectedIndex = 0;
                txtboxLiningFireproofWidth.Text = string.Format("{0:f2}", Math.Round(furnace.LiningFireproofWidth, 2));
                lblLiningFireproofTemperature.Text = string.Format("{0:f2}", Math.Round(furnace.LiningFireproofSurfaceTemperature, 2));

                pnlLining.Visible = true;
            }
            catch (FormatException error)
            {
                MessageBox.Show("Ошибка ввода данных!!");
            }
            catch (ArgumentNullException error)
            {
                MessageBox.Show("Одно из полей равно NULL");
            }
            catch (OverflowException error)
            {
                MessageBox.Show("Одно из введеных чисел слишком мало или слишком велико");
            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Ни один огнеупор не подойдет для такой температуры");
            }
        }

        private void cmbboxLiningFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            furnace.LiningFireproof = State.liningFireproofs[cmbboxLiningFireproof.SelectedIndex];
            FillLiningCalculatedData();
        }

        private void FillLiningCalculatedData()
        {
            if (furnace.LiningFireproofSurfaceTemperature < 0)
            {
                lblLiningFireproofTemperature.Text = "Слишком большая толщина огнеупора";
                return;
            }

            lblLiningFireproofTemperature.Text = string.Format("{0:f2}", Math.Round(furnace.LiningFireproofSurfaceTemperature, 2));

            cmbboxLiningInsulation.Items.Clear();
            lblLiningInsulationWidth.Text = "0 м";

            if (furnace.LiningFireproofSurfaceTemperature > 1100) return;

            try
            {
                State.liningInsulations = ThermalInsulationAnalyzer.GetSuitableLiningThermalInsulation(
                furnace.LiningFireproofSurfaceTemperature, furnace.WorkTemperature);

                foreach (ThermalInsulation insulation in State.liningInsulations)
                {
                    cmbboxLiningInsulation.Items.Add(insulation.Name);
                }

                cmbboxLiningInsulation.SelectedIndex = 0;
            }
            catch (InvalidOperationException)
            {
                lblLiningFireproofTemperature.Text = "Слишком большая толщина огнеупора";
            }
        }

        private void txtboxLiningFireproofWidth_TextChanged(object sender, EventArgs e)
        {
            furnace.LiningFireproofWidth = txtboxLiningFireproofWidth.Text.ToDouble();
            FillLiningCalculatedData();
        }

        private void cmbboxLiningInsulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            furnace.LiningInsulation = State.liningInsulations[cmbboxLiningInsulation.SelectedIndex];

            lblLiningInsulationWidth.Text = string.Format("{0:f2} м", Math.Round(furnace.LiningInsulationWidth, 2));
        }

        private void btnStopLiningCalculations_Click(object sender, EventArgs e)
        {
            furnace.resetLiningCalculation();
            cmbboxLiningFireproof.Items.Clear();
            cmbboxLiningInsulation.Items.Clear();
            lblLiningInsulationWidth.Text = "0 м";
            pnlLining.Visible = false;
        }

        private void btnCalculateOverlap_Click(object sender, EventArgs e)
        {
            if (furnace.LiningInsulationWidth == 0)
            {
                MessageBox.Show("Расчёт футеровки печи не был закончен");
                return;
            }

            btnCalculateOverlap.Visible = false;
            btnStopLiningCalculations.Visible = false;
            cmbboxLiningFireproof.Enabled = false;
            cmbboxLiningInsulation.Enabled = false;
            txtboxLiningFireproofWidth.Enabled = false;

            State.overlapFireproofs = FireproofAnalyzer.GetSuitableOverlapFireproofs(furnace.WorkTemperature);

            foreach (Fireproof fireproof in State.overlapFireproofs)
            {
                cmbboxOverlapFireproof.Items.Add(fireproof.Name);
            }

            cmbboxOverlapFireproof.SelectedIndex = 0;


            State.overlapInsulations = ThermalInsulationAnalyzer.GetSuitableOverlapThermalInsulation(furnace.WorkTemperature);

            foreach (ThermalInsulation insulations in State.overlapInsulations)
            {
                cmbboxOverlapInsulation.Items.Add(insulations.Name);
            }

            cmbboxOverlapInsulation.SelectedIndex = 0;

            pnlOverlap.Visible = true;

            if (!furnace.IsDoubleLayer)
            {

                label16.Visible = false;
                cmbboxOverlapInsulation.Visible = false;
                label19.Visible = false;
                txtboxOverlapInsulationWidth.Visible = false;
                label18.Visible = false;

                label14.Location = new System.Drawing.Point(label14.Location.X, label14.Location.Y - yOffset);
                txtboxOverlapFireproofWidth.Location = new System.Drawing.Point(txtboxOverlapFireproofWidth.Location.X, txtboxOverlapFireproofWidth.Location.Y - yOffset);
                label13.Location = new System.Drawing.Point(label13.Location.X, label13.Location.Y - yOffset);
                label17.Location = new System.Drawing.Point(label17.Location.X, label17.Location.Y - yOffset * 2);
                lblOverlapTemperature.Location = new System.Drawing.Point(lblOverlapTemperature.Location.X, lblOverlapTemperature.Location.Y - yOffset * 2);
                btnStopOverlapCalculation.Location = new System.Drawing.Point(btnStopOverlapCalculation.Location.X, btnStopOverlapCalculation.Location.Y - yOffset * 2);
                btnCalculateHeater.Location = new System.Drawing.Point(btnCalculateHeater.Location.X, btnCalculateHeater.Location.Y - yOffset * 2);
                label1.Location = new System.Drawing.Point(label1.Location.X, label1.Location.Y - yOffset * 2);
                label4.Location = new System.Drawing.Point(label4.Location.X, label4.Location.Y - yOffset * 2);
            }
        }

        private void cmbboxOverlapFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            furnace.OverlapFireproof = State.overlapFireproofs[cmbboxOverlapFireproof.SelectedIndex];
            lblOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(furnace.OverlapSurfaceTemperature, 2));
            label4.Text = string.Format("{0:f2} °C", Math.Round(furnace.OverlapLiningTemperature, 2));
        }
        
        private void cmbboxOverlapInsulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            furnace.OverlapInsulation = State.overlapInsulations[cmbboxOverlapInsulation.SelectedIndex];
            lblOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(furnace.OverlapSurfaceTemperature, 2));
            label4.Text = string.Format("{0:f2} °C", Math.Round(furnace.OverlapLiningTemperature, 2));
        }

        private void txtboxOverlapFireproofWidth_TextChanged(object sender, EventArgs e)
        {
            furnace.OverlapFireproofWidth = txtboxOverlapFireproofWidth.Text.ToDouble();
            lblOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(furnace.OverlapSurfaceTemperature, 2));
            label4.Text = string.Format("{0:f2} °C", Math.Round(furnace.OverlapLiningTemperature, 2));
        }

        private void txtboxOverlapInsulationWidth_TextChanged(object sender, EventArgs e)
        {
            furnace.OverlapInsulationWidth = txtboxOverlapInsulationWidth.Text.ToDouble();
            lblOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(furnace.OverlapSurfaceTemperature, 2));
            label4.Text = string.Format("{0:f2} °C", Math.Round(furnace.OverlapLiningTemperature, 2)); ;
        }

        private void btnStopOverlapCalculation_Click(object sender, EventArgs e)
        {
            furnace.resetOverlapCalculation();

            cmbboxLiningFireproof.Enabled = true;
            cmbboxLiningInsulation.Enabled = true;
            txtboxLiningFireproofWidth.Enabled = true;
            btnCalculateOverlap.Visible = true;
            btnStopLiningCalculations.Visible = true;

            pnlOverlap.Visible = false;

            if (!furnace.IsDoubleLayer)
            {
                label14.Location = new System.Drawing.Point(label14.Location.X, label14.Location.Y + yOffset);
                txtboxOverlapFireproofWidth.Location = new System.Drawing.Point(txtboxOverlapFireproofWidth.Location.X, txtboxOverlapFireproofWidth.Location.Y + yOffset);
                label13.Location = new System.Drawing.Point(label13.Location.X, label13.Location.Y + yOffset);
                label17.Location = new System.Drawing.Point(label17.Location.X, label17.Location.Y + yOffset * 2);
                lblOverlapTemperature.Location = new System.Drawing.Point(lblOverlapTemperature.Location.X, lblOverlapTemperature.Location.Y + yOffset * 2);
                btnStopOverlapCalculation.Location = new System.Drawing.Point(btnStopOverlapCalculation.Location.X, btnStopOverlapCalculation.Location.Y + yOffset * 2);
                btnCalculateHeater.Location = new System.Drawing.Point(btnCalculateHeater.Location.X, btnCalculateHeater.Location.Y + yOffset * 2);
                label1.Location = new System.Drawing.Point(label1.Location.X, label1.Location.Y + yOffset * 2);
                label4.Location = new System.Drawing.Point(label4.Location.X, label4.Location.Y + yOffset * 2);
            }
        }

        private void btnCalculateHeater_Click(object sender, EventArgs e)
        {
            label24.Visible = true;
        }

        private void txtboxFurnaceHeight_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxFurnaceHeight.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtboxFurnaceWidth_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxFurnaceWidth.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void txtboxFurnaceLength_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TxtboxDataSourceValidator.isCorrectSymbol(txtboxFurnaceLength.Text, e.KeyChar) == false)
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
