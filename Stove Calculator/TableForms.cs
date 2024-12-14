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
        private CarborundumHeatersContext? dbContext3;
        private ElectricMachinesContext? dbContext4;
        private HeaterMaterialContext? dbContext5;
        private MetalHeatersContext? dbContext6;
        private MolybdenumHeatersContext? dbContext7;
        private TransformersContext? dbContext8;
        private WireContext? dbContext9;

        public TableForms()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);

            this.dbContext1 = new();
            this.dbContext2 = new();
            this.dbContext3 = new();
            this.dbContext4 = new();
            this.dbContext5 = new();
            this.dbContext6 = new();
            this.dbContext7 = new();
            this.dbContext8 = new();
            this.dbContext9 = new();

            this.dbContext1.Database.EnsureCreated();
            this.dbContext2.Database.EnsureCreated();
            this.dbContext3.Database.EnsureCreated();
            this.dbContext4.Database.EnsureCreated();
            this.dbContext5.Database.EnsureCreated();
            this.dbContext6.Database.EnsureCreated();
            this.dbContext7.Database.EnsureCreated();
            this.dbContext8.Database.EnsureCreated();
            this.dbContext9.Database.EnsureCreated();

            this.dbContext1.Fireproof.Load();
            this.dbContext2.ThermalInsulation.Load();
            this.dbContext3.CarborundumHeaters.Load();
            this.dbContext4.ElectricMachines.Load();
            this.dbContext5.HeaterMaterial.Load();
            this.dbContext6.MetalHeaters.Load();
            this.dbContext7.MolybdenumHeaters.Load();
            this.dbContext8.Transformers.Load();
            this.dbContext9.Wire.Load();

            this.fireproofBindingSource.DataSource = dbContext1.Fireproof.Local.ToBindingList();
            this.thermalInsulationBindingSource.DataSource = dbContext2.ThermalInsulation.Local.ToBindingList();
            //this.carborondumHeatersBindingSource.DataSource = dbContext3.CarborundumHeaters.Local.ToBindingList();
            //this.electricMachinesBindingSource.DataSource = dbContext4.ElectricMachines.Local.ToBindingList();
            //this.heaterMaterialBindingSource.DataSource = dbContext5.HeaterMaterial.Local.ToBindingList();
            //this.metalHeaterBindingSource.DataSource = dbContext6.MetalHeaters.Local.ToBindingList();
            //this.molybdenumHeatersBindingSource.DataSource = dbContext7.MolybdenumHeaters.Local.ToBindingList();
            //this.transformersBindingSource.DataSource = dbContext8.Transformers.Local.ToBindingList();
            //this.wireBindingSource.DataSource = dbContext9.Wire.Local.ToBindingList();
        }
        
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);

            this.dbContext1?.Dispose();
            this.dbContext1 = null;
            this.dbContext2?.Dispose();
            this.dbContext2 = null;
            this.dbContext3?.Dispose();
            this.dbContext3 = null;
            this.dbContext4?.Dispose();
            this.dbContext4 = null;
            this.dbContext5?.Dispose();
            this.dbContext5 = null;
            this.dbContext6?.Dispose();
            this.dbContext6 = null;
            this.dbContext7?.Dispose();
            this.dbContext7 = null;
            this.dbContext8?.Dispose();
            this.dbContext8 = null;
            this.dbContext9?.Dispose();
            this.dbContext9 = null;
        }
    }
}
