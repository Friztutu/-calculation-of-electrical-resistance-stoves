using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using Microsoft.EntityFrameworkCore;
using SkiaSharp;
using Stove_Calculator.Models;

namespace Stove_Calculator
{
    public partial class TableForms : Form
    {

        private FireproofContext? dbContext1;
        private ThermalInsulationContext? dbContext2;
        public TableForms()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dbContext1 = new FireproofContext();
            this.dbContext2 = new ThermalInsulationContext();

            this.dbContext1.Database.EnsureCreated();
            this.dbContext2.Database.EnsureCreated();

            this.dbContext1.Fireproof.Load();
            this.dbContext2.ThermalInsulation.Load();

            this.fireproofBindingSource.DataSource = dbContext1.Fireproof.Local.ToBindingList();
            this.thermalInsulationBindingSource.DataSource = dbContext2.ThermalInsulation.Local.ToBindingList();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext1?.Dispose();
            this.dbContext1 = null;
        }
    }
}
