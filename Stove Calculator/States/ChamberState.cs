using log4net.Core;
using Microsoft.EntityFrameworkCore.Query.Internal;
using Stove_Calculator.Analyzers;
using Stove_Calculator.Calculators;
using Stove_Calculator.Errors;
using Stove_Calculator.Models;
using Syncfusion.Pdf.Barcode;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Policy;
using System.Security.RightsManagement;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.States
{
    public class ChamberState
    {
        // Input Data
        private bool isDoor;
        public bool IsDoor => isDoor;
        private bool isDoubleLayer;
        public bool IsDoubleLayer => isDoubleLayer;
        private double l1;
        public double L1 => l1;
        private double l2;
        public double L2 => l2;
        private double l3;
        public double L3 => l3;
        private double t0;
        public double T0 => t0;
        private double t1;
        public double T1 => t1;
        private double t3;
        public double T3 => t3;

        // All possible lining fireproof and insulations
        private List<Fireproof>? liningFireproofs;
        public List<Fireproof>? LiningFireproofs => liningFireproofs;
        private List<ThermalInsulation>? liningInsulations;
        public List<ThermalInsulation>? LiningInsulations => liningInsulations;
        // Lining parameters data
        private Fireproof? currentLiningFireproof;
        public Fireproof? CurrentLiningFireproof => currentLiningFireproof;
        private ThermalInsulation? currentLiningInsulation;
        public ThermalInsulation? CurrentLiningInsultion => currentLiningInsulation;
        private double h1;
        public double H1 => h1;
        private double t2;
        public double T2 => t2;
        private double h2;
        public double H2 => h2;
        private bool isLiningCalcFinished;

        // All possible overlap fireproof and insulations
        private List<Fireproof>? overlapFireproofs;
        public List<Fireproof>? OverlapFireproofs => overlapFireproofs;
        private List<ThermalInsulation>? overlapInsulations;
        public List<ThermalInsulation>? OverlapInsulations => overlapInsulations;

        // Overlap parameters data
        private Fireproof? currentOverlapFireproof;
        public Fireproof? CurrentOverlapFireproof => currentOverlapFireproof;
        private ThermalInsulation? currentOverlapInsualtion;
        public ThermalInsulation? CurrentOverlapInsulation => currentOverlapInsualtion;
        private double h3;
        public double H3 => h3;
        private double h4;
        public double H4 => h4;
        private double t4;
        public double T4 => t4;
        private double t5;
        public double T5 => t5;

        // Result thermal calculations result
        private double y1;
        public double Y1 => y1;
        private double y2;
        public double Y2 => y2;
        private double q1;
        public double Q11 => q1;
        private double q2;
        public double Q22 => q2;
        private double Q1;
        public double Q111 => Q1;
        private double Q2;
        public double Q222 => Q2;
        private double Q3;
        public double Q333 => Q3;
        private double Q;
        public double Q000 => Q;
        private double P;
        public double P0 => P;
        private double l4;
        public double L4 => l4;
        private double x1;
        public double X1 => x1;
        private double x2;
        public double X2 => x2;
        private double x3;
        public double X3 => x3;
        private double x4;
        public double X4 => x4;
        private double F0;
        public double F00 => F0;
        private double F1;
        public double F11 => F1;
        private double F2;
        public double F22 => F2;
        private double F3;
        public double F33 => F3;
        private double F4;
        public double F44 => F4;
        private double Ft;
        public double Ftt => Ft;

        public void GetInpuData(
            double L1, double L2, double L3,
            double t0, double t1, double t3,
            bool isDoor, bool isDoubleLayer
            )
        {
            if (L1 <= 0 || L2 <= 0 || L3 <= 0 || t0 <= 0 || t1 <= 0 || t3 <= 0)
            {
                throw new NotCorrectInputDataException("Начальные данные не могу быть меньше или равны нулю");
            } else if(t1 > 2500)
            {
                throw new NotCorrectInputDataException("Слишком высокая рабочая температура печи");
            } else if (t3 > 70)
            {
                throw new NotCorrectInputDataException("По ТБ температура поверхности печи должна быть меньше или равна 70");
            } 

            this.l1 = L1;
            this.l2 = L2;
            this.l3 = L3;
            this.t0 = t0;
            this.t1 = t1;
            this.t3 = t3;
            this.isDoor = isDoor;
            this.isDoubleLayer = isDoubleLayer;

            this.liningFireproofs = FireproofAnalyzer.GetSuitableLiningFireproofs(t1);
            this.currentLiningFireproof = liningFireproofs[0];
            this.h1 = 0;
            this.t2 = 0;
            this.h2 = 0;

            this.isLiningCalcFinished = false;

            UpdateLiningData();
        }

        private unsafe void UpdateLiningData()
        {
            double x1 = 0, y1 = 0, q1 = 0;

            if (this.currentLiningFireproof == null) throw new Exception();

            this.t2 = ChamberFurnace.CalculateLiningFireproofSurfaceTemperature(
                currentLiningFireproof, t3, t0, t1, h1, &x1, &y1, &q1);

            this.x1 = x1;
            this.y1 = y1;
            this.q1 = q1;
            
            if (t2 > 1100)
            {
                this.liningInsulations = null;
                this.currentLiningInsulation = null;
                this.h2 = 0;
                return;
            }

            this.liningInsulations = ThermalInsulationAnalyzer.GetSuitableLiningThermalInsulation(t2, t1);
            this.currentLiningInsulation = this.liningInsulations[0];

            double x2 = 0;
            this.h2 = ChamberFurnace.CalculateInsulationWidth(
                currentLiningInsulation, t2, t3, t0, y1, q1, &x2);

            this.x2 = x2;
        }
        public void ChangeLiningFireroofWidth(double h1)
        {
            this.h1 = h1;
            UpdateLiningData();
        }
        public void ChangeLiningFireproof(Fireproof liningFireproof)
        {
            this.currentLiningFireproof = liningFireproof;
            UpdateLiningData();
        }

        public unsafe void ChangeLiningInsulation(ThermalInsulation liningInsultion)
        {
            this.currentLiningInsulation = liningInsultion;

            double x2 = 0;
            this.h2 = ChamberFurnace.CalculateInsulationWidth(
                currentLiningInsulation, t2, t3, t0, y1, q1, &x2);

            this.x2 = x2;
        }

        public unsafe void UpdateFullThermalData()
        {
            double L4 = 0, F0 = 0, F1 = 0, F2 = 0, F3 = 0, F4 = 0, Ft = 0, Q1 = 0, Q2 = 0;

            ChamberFurnace.CalculateParameters(
                isDoor, isDoubleLayer, L1, L2, L3, h1, h2, h3,
                h4, x1, x2, y1, t1, t0, q2, &L4, &F0, &F1, &F2,
                &F3, &F4, &Ft, &Q1, &Q2
                );

            this.l4 = L4;
            this.F0 = F0;
            this.F1 = F1;
            this.F2 = F2;
            this.F3 = F3;
            this.F4 = F4;
            this.Ft = Ft;
            this.Q1 = Q1;
            this.Q2 = Q2;
        }

        public void StartOverlapCalcultions()
        {
            this.overlapFireproofs = FireproofAnalyzer.GetSuitableOverlapFireproofs(t1);

            if(this.isDoubleLayer)
            {
                this.overlapInsulations = ThermalInsulationAnalyzer.GetSuitableOverlapThermalInsulation(1000);
                this.currentOverlapInsualtion = overlapInsulations[0];
                this.h4 = 0;
                this.t5 = 0;
            }

            this.currentOverlapFireproof = overlapFireproofs[0];
            this.h3 = 0;
            this.t4 = 0;

            this.isLiningCalcFinished = true;
        }

        public void ChangeOverlapFireproofWidth(double h3)
        {
            this.h3 = h3;
            UpdateOverlapData();
        }

        public void ChangeOverlapInsulationWidth(double h4)
        {
            this.h4 = h4;
            UpdateOverlapData();
        }

        public void ChangeOverlapFireproof(Fireproof overlapFireproof)
        {
            this.currentOverlapFireproof = overlapFireproof;
            UpdateOverlapData();
        }

        public void ChangeOverlapInsulation(ThermalInsulation overlapInsulation)
        {
            this.currentOverlapInsualtion = overlapInsulation;
            UpdateOverlapData();
        }

        private void UpdateOverlapData()
        {
            if(this.isDoubleLayer)
            {
                UpdateDoubleOverlapData();
            } else
            {
                UpdateSingleOverlapData();
            }
        }

        private unsafe void UpdateDoubleOverlapData()
        {

            if (currentOverlapFireproof == null || currentOverlapInsualtion == null) throw new Exception();

            double t4 = 0, t5 = 0, x3 = 0, x4 = 0, q2 = 0, y2 = 0;
            ChamberFurnace.CalculateDoubleLayerOverlapSurfaceTemperature(
                currentOverlapFireproof, currentOverlapInsualtion, h4, h3, t1, t0, &t4, &t5, &x3, &q2, &x4, &y2);

            this.t4 = t4;
            this.t5 = t5;
            this.x3 = x3; 
            this.x4 = x4;
            this.q2 = q2;
            this.y2 = y2;
        }

        private void UpdateSingleOverlapData() 
        {
            if (currentOverlapFireproof == null) throw new Exception();

            this.t4 = ChamberFurnace.CalculateOneLayerOverlapSurfaceTemperature(
                currentOverlapFireproof, t0, t1, h3);
        }

        public void ResetOverlapData()
        {
            this.overlapFireproofs = null;
            this.overlapInsulations = null;
            this.currentOverlapFireproof = null;
            this.currentOverlapInsualtion = null;
            this.t4 = 0;
            this.t5 = 0;
            this.h3 = 0;
            this.h4 = 0;
        }

        public void ResetLiningData()
        {
            this.liningFireproofs = null;
            this.liningInsulations = null;
            this.currentLiningFireproof = null;
            this.currentLiningInsulation = null;
            this.h1 = 0;
            this.h2 = 0;
            this.t2 = 0;
        }
    }
}
