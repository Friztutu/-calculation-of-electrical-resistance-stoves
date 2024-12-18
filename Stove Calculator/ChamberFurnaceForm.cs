using AngleSharp.Text;
using Stove_Calculator.Furnace_parts;
using Stove_Calculator.InputValidators;
using Stove_Calculator.Models;
using Stove_Calculator.States;
using System.Linq.Expressions;

namespace Stove_Calculator
{
    public partial class ChamberFurnaceForm : Form
    {
        private ChamberState _chamberState;
        private InputData _inputData;

        public ChamberFurnaceForm()
        {
            InitializeComponent();

            bool isDoor = cmbboxOverlapType.Text == "Дверца";
            bool isDoubleLayer = cmbboxOverlapLayers.Text == "2";
            double L1 = txtboxFurnaceHeight.Text.ToDouble();
            double L2 = txtboxFurnaceWidth.Text.ToDouble();
            double L3 = txtboxFurnaceLength.Text.ToDouble();
            double t0 = txtboxAmbientTemperature.Text.ToDouble();
            double t1 = txtboxWorkTemperature.Text.ToDouble();
            double t3 = txtboxOuterSurfaceTemperature.Text.ToDouble();

            _inputData = new(true, true, 0.2, 0.16, 0.15, 20, 1350, 70);
            _chamberState = new(_inputData);
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

                _inputData = new(isDoor, isDoubleLayer, L1, L2, L3, t0, t1, t3);
                _chamberState = new(_inputData);

                cmbboxLiningFireproof.Items.Clear();
                cmbboxLiningInsulation.Items.Clear();
                txtboxLiningFireproofWidth.Clear();
                lblLiningFireproofTemperature.Text = "0 °C";
                lblLiningInsulationWidth.Text = "0 м";

                foreach (Fireproof fireproof in _chamberState.ChamberLining.LiningFireproofs)
                {
                    cmbboxLiningFireproof.Items.Add(fireproof.Name);
                }

                cmbboxLiningFireproof.SelectedIndex = 0;

                txtboxLiningFireproofWidth.Text = String.Format("{0:f2}", _chamberState.ChamberLining.h1);
                lblLiningFireproofTemperature.Text = string.Format("{0:f2}", Math.Round(_chamberState.ChamberLining.t2, 2));

                pnlLining.Visible = true;
            }
            catch (FormatException)
            {
                MessageBox.Show("Ошибка ввода данных.");
            }
            catch (ArgumentNullException)
            {
                MessageBox.Show("Слишком высокая рабочая температура");
            }
            catch (IndexOutOfRangeException)
            {
                MessageBox.Show("Слишком высокая рабочая температура");
            }
            catch (OverflowException)
            {
                MessageBox.Show("Одно из введеных чисел слишком мало или слишком велико.");
            }
            catch (DivideByZeroException error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void UpdateLiningData()
        {
            cmbboxLiningInsulation.Items.Clear();

            if (_chamberState.ChamberLining.t2 < 0)
            {
                lblLiningFireproofTemperature.Text = "Уменьшите толщину огнеупора.";
                cmbboxLiningInsulation.Items.Clear();
                lblLiningInsulationWidth.Text = "0 м";
                return;
            }

            lblLiningFireproofTemperature.Text = string.Format("{0:f2} °C", Math.Round(_chamberState.ChamberLining.t2, 2));

            if (_chamberState.ChamberLining.t2 > 1100 || _chamberState.ChamberLining.LiningInsulations == null)
            {
                cmbboxLiningInsulation.Items.Clear();
                lblLiningInsulationWidth.Text = "0 м";
                return;
            }

            foreach (ThermalInsulation ins in _chamberState.ChamberLining.LiningInsulations)
            {
                cmbboxLiningInsulation.Items.Add(ins.Name);
            }

            cmbboxLiningInsulation.SelectedIndex = 0;
            lblLiningInsulationWidth.Text = string.Format("{0:f2} м", Math.Round(_chamberState.ChamberLining.h2, 2));
        }

        private void CmbboxLiningFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_chamberState.ChamberLining.LiningFireproofs == null) return;

            _chamberState.ChangeLiningFireproof(_chamberState.ChamberLining.LiningFireproofs[cmbboxLiningFireproof.SelectedIndex]);
            UpdateLiningData();
        }

        private unsafe void TxtboxLiningFireproofWidth_TextChanged(object sender, EventArgs e)
        {
            _chamberState.ChangeLiningFireroofWidth(txtboxLiningFireproofWidth.Text.ToDouble());
            UpdateLiningData();
        }

        private unsafe void CmbboxLiningInsulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_chamberState.ChamberLining.LiningInsulations == null) return;

            _chamberState.ChangeLiningInsulation(_chamberState.ChamberLining.LiningInsulations[cmbboxLiningInsulation.SelectedIndex]);
            lblLiningInsulationWidth.Text = string.Format("{0:f2} м", Math.Round(_chamberState.ChamberLining.h2, 2));
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

            pnlLining.Visible = false;
        }

        private void BtnCalculateOverlap_Click(object sender, EventArgs e)
        {
            cmbboxDoubleOverlapFireproof.Items.Clear();
            cmbboxDoubleOverlapInsulation.Items.Clear();
            cmbboxSingleOverlapFireproof.Items.Clear();

            if (_chamberState.ChamberLining.h2 == 0)
            {
                MessageBox.Show("Расчёт футеровки печи не был закончен");
                return;
            }

            btnCalculateOverlap.Visible = false;
            btnStopLiningCalculations.Visible = false;
            cmbboxLiningFireproof.Enabled = false;
            cmbboxLiningInsulation.Enabled = false;
            txtboxLiningFireproofWidth.Enabled = false;

            if (_chamberState.ChamberOverlap.OverlapFireproofs == null) return;

            ComboBox cmbboxOverlapFireproof = _inputData.IsDoubleLayer ?
                cmbboxDoubleOverlapFireproof : cmbboxSingleOverlapFireproof;

            foreach (Fireproof fireproof in _chamberState.ChamberOverlap.OverlapFireproofs)
            {
                cmbboxOverlapFireproof.Items.Add(fireproof.Name);
            }

            cmbboxOverlapFireproof.SelectedIndex = 0;

            if (_inputData.IsDoubleLayer)
            {
                if (_chamberState.ChamberOverlap.OverlapInsulations == null) return;

                foreach (ThermalInsulation insulations in _chamberState.ChamberOverlap.OverlapInsulations)
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
            if (_inputData.IsDoubleLayer && (_chamberState.ChamberOverlap.h3 == 0 || _chamberState.ChamberOverlap.h4 == 0))
            {
                lblDoubleOverlapTemperature.Text = "Нет данных";
                lblDoubleOverlapLiningTemperature.Text = "Нет данных";
                return;
            }
            else if (!_inputData.IsDoubleLayer && _chamberState.ChamberOverlap.h3 == 0)
            {
                lblSingleOverlapLiningTemperature.Text = "Нет данных";
            }

            if (_inputData.IsDoubleLayer)
            {
                lblDoubleOverlapTemperature.Text = string.Format("{0:f2} °C", Math.Round(_chamberState.ChamberOverlap.t4, 2));
                lblDoubleOverlapLiningTemperature.Text = string.Format("{0:f2} °C", Math.Round(_chamberState.ChamberOverlap.t5, 2));
            }
            else
            {
                lblSingleOverlapLiningTemperature.Text = string.Format("{0:f2} °C", Math.Round(_chamberState.ChamberOverlap.t5, 2));
            }
        }

        private unsafe void CmbboxOverlapFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_chamberState.ChamberOverlap.OverlapFireproofs == null) return;

            _chamberState.ChangeOverlapFireproof(_chamberState.ChamberOverlap.OverlapFireproofs[cmbboxDoubleOverlapFireproof.SelectedIndex]);

            UpdateOverlapData();
        }

        private unsafe void CmbboxOverlapInsulation_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (_chamberState.ChamberOverlap.OverlapInsulations == null) return;

            _chamberState.ChangeOverlapInsulation(_chamberState.ChamberOverlap.OverlapInsulations[cmbboxDoubleOverlapInsulation.SelectedIndex]);

            UpdateOverlapData();
        }

        private unsafe void TxtboxOverlapFireproofWidth_TextChanged(object sender, EventArgs e)
        {

            _chamberState.ChangeOverlapFireproofWidth(txtboxDoubleOverlapFireproofWidth.Text.ToDouble());

            UpdateOverlapData();
        }

        private unsafe void TxtboxOverlapInsulationWidth_TextChanged(object sender, EventArgs e)
        {
            _chamberState.ChangeOverlapInsulationWidth(txtboxDoubleOverlapInsulationWidth.Text.ToDouble());

            UpdateOverlapData();
        }

        private void CmbboxSingleOverlapFireproof_SelectedIndexChanged(object sender, EventArgs e)
        {
            _chamberState.ChangeOverlapFireproofWidth(txtboxDoubleOverlapFireproofWidth.Text.ToDouble());

            UpdateOverlapData();
        }

        private void TxtboxSingleOverlapFireproofWidth_TextChanged(object sender, EventArgs e)
        {
            _chamberState.ChangeOverlapInsulationWidth(txtboxDoubleOverlapInsulationWidth.Text.ToDouble());

            UpdateOverlapData();
        }

        private void BtnStopOverlapCalculation_Click(object sender, EventArgs e)
        {
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
            if (
                _chamberState.ChamberLining.CurrentLiningFireproof == null ||
                _chamberState.ChamberLining.CurrentLiningInsulation == null
                || _chamberState.ChamberOverlap.CurrentOverlapFireproof == null
                || _chamberState.ChamberOverlap.CurrentOverlapInsulation == null) return;

            if(_chamberState.ChamberOverlap.t4 > 70)
            {
                MessageBox.Show("Температура наружной поверхности футеровки не должна быть выше 70 градусов");
                return;
            }

            if (_inputData.IsDoubleLayer)
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

            label25.Text = string.Format("a1 = {0:f5}", Math.Round(_chamberState.ChamberLining.CurrentLiningFireproof.AValue, 5));
            label26.Text = string.Format("b1 = {0:f5}", Math.Round(_chamberState.ChamberLining.CurrentLiningFireproof.BValue, 5));
            label29.Text = string.Format("x1 = {0:f5}", Math.Round(_chamberState.ChamberLining.x1, 5));
            label28.Text = string.Format("h1 = {0:f5}", Math.Round(_chamberState.ChamberLining.h1, 5));
            label34.Text = string.Format("t6 = {0:f2}", Math.Round(_chamberState.ChamberLining.CurrentLiningFireproof.MaxTemperatureOfUse, 2));
            label33.Text = string.Format("F0 = {0:f5}", Math.Round(_chamberState.ChamberLining.F0, 5));

            label40.Text = string.Format("a2 = {0:f5}", Math.Round(_chamberState.ChamberLining.CurrentLiningInsulation.AValue, 5));
            label39.Text = string.Format("b2 = {0:f5}", Math.Round(_chamberState.ChamberLining.CurrentLiningInsulation.BValue, 5));
            label38.Text = string.Format("x2 = {0:f5}", Math.Round(_chamberState.ChamberLining.x2, 5));
            label37.Text = string.Format("h2 = {0:f5}", Math.Round(_chamberState.ChamberLining.h2, 5));
            label36.Text = string.Format("t7 = {0:f2}", Math.Round(_chamberState.ChamberLining.CurrentLiningInsulation.MaxTemperatureOfUse, 2));
            label35.Text = string.Format("Ft = {0:f5}", Math.Round(_chamberState.ChamberLining.Ft, 5));

            label46.Text = string.Format("a3 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.CurrentOverlapFireproof.AValue, 5));
            label45.Text = string.Format("b3 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.CurrentOverlapFireproof.BValue, 5));
            label44.Text = string.Format("x3 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.x3, 5));
            label43.Text = string.Format("h3 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.h3, 5));
            label42.Text = string.Format("t8 = {0:f2}", Math.Round(_chamberState.ChamberOverlap.CurrentOverlapFireproof.MaxTemperatureOfUse, 2));
            label41.Text = string.Format("F4 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.F4, 5));

            label52.Text = string.Format("a4 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.CurrentOverlapInsulation.AValue, 5));
            label51.Text = string.Format("b4 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.CurrentOverlapInsulation.BValue, 5));
            label50.Text = string.Format("x4 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.x4, 5));
            label49.Text = string.Format("h4 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.h4, 5));
            label48.Text = string.Format("t9 = {0:f2}", Math.Round(_chamberState.ChamberOverlap.CurrentOverlapInsulation.MaxTemperatureOfUse, 2));
            label47.Text = string.Format("F4 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.F4, 5));

            label58.Text = string.Format("F1 = {0:f5}", Math.Round(_chamberState.ChamberLining.F1, 5));
            label57.Text = string.Format("t2 = {0:f2}", Math.Round(_chamberState.ChamberLining.t2, 2));
            label56.Text = string.Format("y1 = {0:f5}", Math.Round(_chamberState.ChamberLining.y1, 5));
            label55.Text = string.Format("q1 = {0:f5}", Math.Round(_chamberState.ChamberLining.q1, 5));
            label54.Text = string.Format("F2 = {0:f5}", Math.Round(_chamberState.ChamberLining.F2, 5));
            label53.Text = string.Format("F3 = {0:f5}", Math.Round(_chamberState.ChamberLining.F3, 5));
            label60.Text = string.Format("t3 = {0:f2}", Math.Round(_inputData.t3, 2));
            label59.Text = string.Format("Q1 = {0:f5}", Math.Round(_chamberState.ChamberLining.Q1, 5));

            label64.Text = string.Format("t4 = {0:f2}", Math.Round(_chamberState.ChamberOverlap.t4, 2));
            label63.Text = string.Format("y2 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.y2, 5));
            label62.Text = string.Format("q2 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.q2, 5));
            label61.Text = string.Format("t5 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.t5, 2));
            label65.Text = string.Format("Q2 = {0:f5}", Math.Round(_chamberState.ChamberOverlap.Q2, 5));

            label72.Text = string.Format("L1 = {0:f2}", Math.Round(_inputData.L1, 2));
            label69.Text = string.Format("L2 = {0:f2}", Math.Round(_inputData.L2, 2));
            label70.Text = string.Format("L3 = {0:f2}", Math.Round(_inputData.L3, 2));
            label71.Text = string.Format("L4 = {0:f5}", Math.Round(_chamberState.ChamberLining.L4, 2));
            label73.Text = string.Format("t0 = {0:f2}", Math.Round(_inputData.t0, 2));
            label74.Text = string.Format("t1 = {0:f2}", Math.Round(_inputData.t1, 2));

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
            if (_inputData.IsDoubleLayer)
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

        private void iconButton3_Click(object sender, EventArgs e)
        {
            panel11.Visible = true;
            iconButton3.Visible = false;
            iconButton4.Visible = false;

            comboBox1.SelectedIndex = 1;

            try
            {
                _chamberState.CarborundHeater.UpdateHeater();


                if (_chamberState.CarborundHeater.CarborundumHeaters == null) return;

                foreach (CarborundumHeater heater in _chamberState.CarborundHeater.CarborundumHeaters)
                {
                    comboBox2.Items.Add(heater.Name);
                }

                comboBox2.SelectedIndex = 0;
                comboBox3.SelectedIndex = 0;

                CarborunbumHeaterCalc();


                panel11.Visible = true;
                panel11.BringToFront();


            }
            catch (ArgumentOutOfRangeException)
            {
                MessageBox.Show("Не один карборундовый нагреватель не подойдет");
            }
        }

        private void CarborunbumHeaterCalc()
        {
            label67.Text = string.Format("{0:f2} Дж", Math.Round(_chamberState.CarborundHeater.Q3, 2));
            label68.Text = string.Format("{0:f2} Дж", Math.Round(_chamberState.CarborundHeater.Q, 2));
            label78.Text = string.Format("{0:f2} кВ", Math.Round(_chamberState.CarborundHeater.P, 2));
            label80.Text = string.Format("{0:f2} кВт/м^2", Math.Round(_chamberState.CarborundHeater.Wn, 2));
            label85.Text = string.Format("{0:f2} кВт", Math.Round(_chamberState.CarborundHeater.P1, 2));
            label88.Text = string.Format("{0:f2} кВт/м^2", Math.Round(_chamberState.CarborundHeater.W, 2));
            label86.Text = string.Format("{0:f2} шт", Math.Ceiling(_chamberState.CarborundHeater.N));
            label94.Text = string.Format("{0:f2} В", Math.Round(_chamberState.CarborundHeater.U, 2));
            label95.Text = string.Format("{0:f2} А", Math.Round(_chamberState.CarborundHeater.I, 2));
            label96.Text = string.Format("{0:f2} В", Math.Round(_chamberState.CarborundHeater.Up, 2));
            label97.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.n, 2));
            label108.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Il0, 3));
            label109.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Ift0, 3));
            label110.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Ifz0, 3));
            label113.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Ul0, 3));
            label112.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Uft0, 3));
            label111.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Ufz0, 3));
            label119.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Il1, 3));
            label118.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Ift1, 3));
            label117.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Ifz1, 3));
            label116.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Ul1, 3));
            label115.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Uft1, 3));
            label114.Text = string.Format("{0:f2}", Math.Round(_chamberState.CarborundHeater.Ufz1, 3));
        }

        private void MolybdeniumHeaterCalc()
        {
            label144.Text = string.Format("{0:f2} Дж", Math.Round(_chamberState.MolybdenHeater.Q3, 2));
            label142.Text = string.Format("{0:f2} Дж", Math.Round(_chamberState.MolybdenHeater.Q, 2));
            label140.Text = string.Format("{0:f2} кВ", Math.Round(_chamberState.MolybdenHeater.P, 2));
            label137.Text = string.Format("{0:f2} кВт/м^2", Math.Round(_chamberState.MolybdenHeater.Wn, 2));
            label128.Text = string.Format("{0:f2} кВт/м^2", Math.Round(_chamberState.MolybdenHeater.W, 2));
            label139.Text = string.Format("{0:f2} кВт", Math.Round(_chamberState.MolybdenHeater.Pp, 2));
            label124.Text = string.Format("{0:f2} кВт", Math.Round(_chamberState.MolybdenHeater.P1, 2));
            label126.Text = string.Format("{0:f2} шт", Math.Ceiling(_chamberState.MolybdenHeater.N));
            label133.Text = string.Format("{0:f2} В", Math.Round(_chamberState.MolybdenHeater.U, 2));
            label147.Text = string.Format("{0:f2} Ом", Math.Round(_chamberState.MolybdenHeater.R, 2));
            label134.Text = string.Format("{0:f2} А", Math.Round(_chamberState.MolybdenHeater.I, 2));
            label135.Text = string.Format("{0:f2} В", Math.Round(_chamberState.MolybdenHeater.Up, 2));
            label136.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.n, 2));
            label159.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Il0, 3));
            label158.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Ift0, 3));
            label157.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Ifz0, 3));
            label156.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Ul0, 3));
            label155.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Uft0, 3));
            label154.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Ufz0, 3));
            label153.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Il1, 3));
            label152.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Ift1, 3));
            label151.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Ifz1, 3));
            label150.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Ul1, 3));
            label149.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Uft1, 3));
            label148.Text = string.Format("{0:f2}", Math.Round(_chamberState.MolybdenHeater.Ufz1, 3));
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.SelectedIndex == 2)
            {
                try
                {
                    _chamberState.MolybdenHeater.UpdateHeater();

                    if (_chamberState.MolybdenHeater.MolybdenHeaters == null) return;


                    foreach (MolybdenumHeaters heater in _chamberState.MolybdenHeater.MolybdenHeaters)
                    {
                        comboBox4.Items.Add(heater.Name);
                    }

                    comboBox4.SelectedIndex = 0;

                    panel11.Visible = true;
                    panel12.Visible = true;
                    panel12.BringToFront();
                }
                catch (ArgumentOutOfRangeException)
                {
                    MessageBox.Show("Не один молибденовый нагреватель не подойдет");
                }
            }
            else if (comboBox1.SelectedIndex == 1)
            {
                _chamberState.CarborundHeater.UpdateHeater();

                if (_chamberState.CarborundHeater.CarborundumHeaters == null) return;

                foreach (CarborundumHeater heater in _chamberState.CarborundHeater.CarborundumHeaters)
                {
                    comboBox2.Items.Add(heater.Name);
                }

                comboBox2.SelectedIndex = 0;

                panel11.Visible = true;
                panel12.Visible = false;
                panel11.BringToFront();
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            _chamberState.MolibdenuimHeaterChanget(comboBox4.SelectedIndex);
            MolybdeniumHeaterCalc();
        }

        private void comboBox2_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _chamberState.CarborundumHeaterChanget(comboBox2.SelectedIndex);
            CarborunbumHeaterCalc();
        }

        private void comboBox3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            _chamberState.MoveTChanged(comboBox3.SelectedIndex);
            CarborunbumHeaterCalc();
        }
    }
}
