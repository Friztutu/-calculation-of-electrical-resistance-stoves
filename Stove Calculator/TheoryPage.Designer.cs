namespace Stove_Calculator
{
    partial class TheoryPage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            panel1 = new Panel();
            panel2 = new Panel();
            iconButton1 = new FontAwesome.Sharp.IconButton();
            documentPrinter1 = new Gnostice.Printer.DocumentPrinter();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(panel2);
            panel1.Dock = DockStyle.Fill;
            panel1.ForeColor = SystemColors.Control;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1264, 845);
            panel1.TabIndex = 0;
            // 
            // panel2
            // 
            panel2.Controls.Add(iconButton1);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(0, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1264, 89);
            panel2.TabIndex = 0;
            // 
            // iconButton1
            // 
            iconButton1.Anchor = AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            iconButton1.FlatAppearance.BorderSize = 0;
            iconButton1.FlatStyle = FlatStyle.Flat;
            iconButton1.Font = new Font("Times New Roman", 16F);
            iconButton1.IconChar = FontAwesome.Sharp.IconChar.Book;
            iconButton1.IconColor = Color.White;
            iconButton1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconButton1.Location = new Point(405, 12);
            iconButton1.Name = "iconButton1";
            iconButton1.Size = new Size(444, 58);
            iconButton1.TabIndex = 0;
            iconButton1.Text = "Тепловой расчёт камерной печи";
            iconButton1.TextImageRelation = TextImageRelation.ImageBeforeText;
            iconButton1.UseVisualStyleBackColor = true;
            // 
            // documentPrinter1
            // 
            documentPrinter1.AutoRotate = true;
            documentPrinter1.OffsetHardMargins = false;
            documentPrinter1.PagePositioning.Horizontal = Gnostice.Core.Printer.HPagePosition.Left;
            documentPrinter1.PagePositioning.Vertical = Gnostice.Core.Printer.VPagePosition.Top;
            documentPrinter1.PageScaling = Gnostice.Core.Printer.PageScalingOptions.Original;
            documentPrinter1.PageSelection.CurrentPageNumber = 1;
            documentPrinter1.PageSelection.CustomRange = "";
            documentPrinter1.PageSelection.SelectionType = Gnostice.Core.Printer.PageSelectionType.All;
            // 
            // TheoryPage
            // 
            AutoScaleDimensions = new SizeF(11F, 22F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(52, 52, 52);
            ClientSize = new Size(1264, 845);
            Controls.Add(panel1);
            Font = new Font("Times New Roman", 12F);
            ForeColor = SystemColors.Control;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "TheoryPage";
            Text = "TheoryPage";
            panel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private Syncfusion.Windows.Forms.PdfViewer.PdfDocumentView pdfDocumentView1;
        private Panel panel1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton iconButton1;
        private Gnostice.Printer.DocumentPrinter documentPrinter1;
    }
}