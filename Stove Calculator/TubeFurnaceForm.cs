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

namespace Stove_Calculator
{
    public partial class TubeFurnaceForm : Form
    {
        public TubeFurnaceForm()
        {
            InitializeComponent();
        }

        private readonly Validator validator = new();

        private void StoveLengthTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(StoveLengthTextBox.Text, e.KeyChar) == false)
                e.Handled = true;
        }

        private void StoveDiameterTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(StoveDiameterTextBox.Text, e.KeyChar) == false)
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

        private void CalculateButton_Click(object sender, EventArgs e)
        {
            try
            {
                float stoveDiameter = float.Parse(StoveDiameterTextBox.Text);
                float stoveLength = float.Parse(StoveLengthTextBox.Text);
                float maximumSampleTemperature = float.Parse(MaximumSampleTemperature.Text);
                float ambientGasTemperature = float.Parse(AmbientGasTemperature.Text);
                float outerSurfaceTemperature = float.Parse(TemperatureOuterSurface.Text);
            }
            catch(FormatException error)
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
    }
}
