using Gnostice.Documents.PDF;
using SkiaSharp;
using Stove_Calculator.Models;
using System;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Security.Permissions;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;
using RSAExtensions;
using System.Runtime.Intrinsics.X86;
using Stove_Calculator.Furnaces;
using Stove_Calculator.Analyzers;
using System.Windows.Media.Animation;
using Stove_Calculator.Constans;
using System.Security.Cryptography;
using Syncfusion.Pdf.Barcode;

namespace Stove_Calculator.Calculators
{
    public class ChamberFurnace : Furnace
    {
        public unsafe static double CalculateLiningFireproofSurfaceTemperature(
            Fireproof liningFireproof, double t3,
            double t0, double t1, double h1, double* x1, 
            double* y1, double* q1)
        {
            *y1 = Constant.I + Constant.J * t3;
            *q1 = *y1 * (t3 - t0);

            double sqrtExpression = Math.Pow(2 * liningFireproof.AValue, 2) - 4 * liningFireproof.BValue *
                (2 * h1 * *q1 - 2 * liningFireproof.AValue * t1 - liningFireproof.BValue * 
                Math.Pow(t1, 2));

            double liningFireproofSurfaceTemperature = (-2 * liningFireproof.AValue + Math.Sqrt(sqrtExpression)) / (2 * liningFireproof.BValue);
            *x1 = liningFireproof.AValue + (liningFireproof.BValue * (t1 + liningFireproofSurfaceTemperature) / 2);

            return liningFireproofSurfaceTemperature;        
        }

        public unsafe static double CalculateInsulationWidth(
            ThermalInsulation liningInsulation, double t2,
            double t3, double t0, double y1, double q1,
            double* x2)
        {
            *x2 = liningInsulation.AValue + (liningInsulation.BValue * ((t2 + t3) / 2));

            double liningInsulationWidth = (*x2 * (t2 - t3) / q1);

            return liningInsulationWidth;
        }

        public unsafe static void CalculateParameters(
            bool isDoor, bool isDoubleLayer, double L1, double L2, 
            double L3, double h1, double h2, double h3, double h4,
            double x1, double x2, double y1, double t1, double t0,
            double q2,
            double* L4, double* F0, double* F1, double* F2, double* F3, double* F4, double* Ft,
            double *Q1, double* Q2
            )
        {
            if (isDoor) 
            {
                *L4 = L3;
            }
            else if(isDoubleLayer)
            {
                *L4 = L3 - h3 - h4;
            }
            else
            {
                *L4 = L3 - h3;
            }

            *F1 = L1 * L2 + 2 * L1 * *L4 + 2 * L2 * *L4;
            *F2 = (L1 + 2 * h1) * (L2 + 2 * h1) + 2 * (L1 + 2 * h1) * (*L4 + h1) + 2 * (L2 + 2 * h1) * (*L4 + h1);
            *F3 = (L1 + 2 * h1 + 2 * h2) * (L2 + 2 * h1 + 2 * h2) + 2 * (L1 + 2 * h1 + 2 * h2) * (*L4 + h1 + h2) +
                2 * (L2 + 2 * h1 + 2 * h2) * (*L4 + h1 + h2);

            
            if(*F2 / *F1 <= 2)
            {
                *F0 = (*F1 + *F2) / 2;
            }
            else
            {
                *F0 = Math.Sqrt(*F1 * *F2);
            }

            if (*F3 / *F2 <= 2)
            {
                *Ft = (*F3 + *F2) / 2;
            }
            else
            {
                *Ft = Math.Sqrt(*F3 * *F2);
            }

            *Q1 = (t1 - t0) / (h1 / (x1 * *F0) + h2 / (x2 * *Ft) + 1 / (y1 * *F3));

            *F4 = L1 * L2;

            *Q2 = *F4 * q2;
        }
    }
}
