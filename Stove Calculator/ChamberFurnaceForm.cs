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

        private ChamberFurnace furnace;
        private List<Fireproof> fireproofs;
        private Fireproof currentFireproof;

        public ChamberFurnaceForm()
        {
            InitializeComponent();
            cmbboxOverlapLayers.SelectedIndex = 0;
            cmbboxOverlapType.SelectedIndex = 0;
            txtboxFurnaceHeight.Text = "0.20";
            txtboxFurnaceWidth.Text = "0.16";
            txtboxFurnaceLength.Text = "0.15";
            txtboxAmbientTemperature.Text = "20";
            txtboxWorkTemperature.Text = "1350";
            txtboxOuterSurfaceTemperature.Text = "70";
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

                furnace = new(furnaceLength, furnaceHeight, furnaceWidth, workTemperature, ambientTemperature, outerSurfaceTemperature, isDoor, isDoubleLayer);
                AddFireproofToCmbbox();
                ShowLiningCalculations();

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
        }

        private void FillCalculatedData()
        {
            
        }

        private void AddFireproofToCmbbox()
        {
            fireproofs = FireproofAnalyzer.GetSuitableLiningFireproofs(furnace.MaxSampleTemperature);

            foreach (Fireproof fireproof in fireproofs)
            {
                cmbboxLiningFireproof.Items.Add(fireproof.Name);
            }
        }
        private void ShowLiningCalculations()
        {
            iconPictureBox1.Visible = true;
            lblTitleResultData.Visible = true;
            lblLiningCalculationTitle.Visible = true;
            label1.Visible = true;
            label4.Visible = true;
            label6.Visible = true;
            label7.Visible = true;
            label8.Visible = true;
            label12.Visible = true;
            cmbboxLiningFireproof.Visible = true;
            cmbboxLiningInsulation.Visible = true;
            txtboxLiningFireproofWidth.Visible = true;
            label14.Visible = true;
            btnContinueCalculations.Visible = true;
            btnStopCalculations.Visible = true;
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

        private void cmbboxLiningFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentFireproof = fireproofs[cmbboxLiningFireproof.SelectedIndex];
        }
    }
}
