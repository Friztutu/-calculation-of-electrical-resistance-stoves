using FontAwesome.Sharp;

namespace Stove_Calculator
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private Form active;

        private Validator validator = new();

        private Color activeBackgroundButton = Color.FromArgb(0, 192, 0);
        private Color defaultBackgroundButton = Color.FromArgb(255, 255, 0);

        bool dragging = false;
        Point dragCursorPoint;
        Point dragFormPoint;

        private void SetButtonColors(Panel panel, Color backColor)
        {
            panel6.BackColor = defaultBackgroundButton;
            panel8.BackColor = defaultBackgroundButton;
            panel10.BackColor = defaultBackgroundButton;
            panel12.BackColor = defaultBackgroundButton;
            panel14.BackColor = defaultBackgroundButton;
            panel15.BackColor = defaultBackgroundButton;

            panel.BackColor = backColor;
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void iconButton1_Click(object sender, EventArgs e)
        {
            SetButtonColors(panel6, activeBackgroundButton);

            PanelForm(new ChamberFurnaceForm());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            SetButtonColors(panel8, activeBackgroundButton);

            PanelForm(new TubeFurnaceForm());
        }

        private void iconButton3_Click(object sender, EventArgs e)
        {
            SetButtonColors(panel10, activeBackgroundButton);

            PanelForm(new TheoryPage());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            SetButtonColors(panel12, activeBackgroundButton);

            PanelForm(new UserGuideForm());
        }

        private void iconButton5_Click(object sender, EventArgs e)
        {
            SetButtonColors(panel14, activeBackgroundButton);

            PanelForm(new AboutForm());
        }

        private void iconButton11_Click_1(object sender, EventArgs e)
        {
            SetButtonColors(panel15, activeBackgroundButton);

            PanelForm(new TableForms());
        }

        private void iconButton7_Click_1(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton6_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void iconButton9_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void iconButton8_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void panel16_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel10_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_DoubleClick(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Maximized)
            {
                this.WindowState = FormWindowState.Normal;
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            else
            {
                this.WindowState = FormWindowState.Maximized;
            }
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            dragging = true;
            dragCursorPoint = Cursor.Position;
            dragFormPoint = this.Location;
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            dragging = false;
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            if (dragging)
            {
                Point dif = Point.Subtract(Cursor.Position, new Size(dragCursorPoint));
                this.Location = Point.Add(dragFormPoint, new Size(dif));
            }
        }

        private void PanelForm(Form form)
        {
            if (active != null)
            {
                active.Close();
            }

            active = form;
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            this.panel4.Controls.Add(form);
            this.panel4.Tag = form;
            form.BringToFront();
            form.Show();
        }
    }
}
