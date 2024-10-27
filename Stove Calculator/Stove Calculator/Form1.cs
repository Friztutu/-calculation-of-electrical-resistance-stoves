namespace Stove_Calculator
{
    public partial class Form1 : Form
    {

        private Validator validator = new();
        public Form1()
        {
            InitializeComponent();
        }

        private void textBoxL1Size_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(textBoxL1Size.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void textBoxL2Size_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(textBoxL2Size.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void textBoxL3Size_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(textBoxL3Size.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void textBoxLimTemperatureSample_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(textBoxLimTemperatureSample.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void textBoxAmbientGasTemperature_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(textBoxAmbientGasTemperature.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void textBoxTemperatureOuterSurface_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (validator.isCorrectSymbol(textBoxTemperatureOuterSurface.Text, e.KeyChar) == false)
            {
                e.Handled = true;
            }
        }

        private void buttonCalculate_Click(object sender, EventArgs e)
        {
            double stoveHeight = double.Parse(textBoxL1Size.Text);
            double stoveWidth = double.Parse(textBoxL2Size.Text);
            double stoveLength = double.Parse(textBoxL3Size.Text);

            double sampleHeatingTemperatureLimit = double.Parse(textBoxLimTemperatureSample.Text);
            double ambientGasTemperature = double.Parse(textBoxAmbientGasTemperature.Text);
            double outerSurfaceTemperature = double.Parse(textBoxTemperatureOuterSurface.Text);
        }
    }
}
