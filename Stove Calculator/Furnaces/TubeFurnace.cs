using Stove_Calculator.Furnaces;
using Syncfusion.Drawing;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Media3D;
using Stove_Calculator.Constans;
using Constant = Stove_Calculator.Constans.Constant;
using Microsoft.EntityFrameworkCore.Storage.Json;

namespace Stove_Calculator.Calculators
{
    public class TubeFurnace : Furnace
    {
        protected double _furnaceDiameter;
        protected double _liningFireproofDiameter;
        protected double _liningInsulationDiameter;

        public TubeFurnace(
            double furnanceLength, double furnanceDiameter,
            double maxSampleTemperature, double ambientGasTemperature, double outerSurfaceTemperature,
            bool isWithDoor, bool isDoubleLayer)
            : base(furnanceLength, maxSampleTemperature, ambientGasTemperature, outerSurfaceTemperature, isWithDoor, isDoubleLayer)
        {
            this._furnaceDiameter = furnanceDiameter;
        }

        protected override void CalculateLiningFireproofSurfaceTemperature()
        {
            double dz, x1, q1, t2;

            double i = Constant.I;
            double j = Constant.J;
            double h1 = _liningFireproofWidth;
            double a1 = _liningFireproof.AValue;
            double b1 = _liningFireproof.BValue;
            double a2 = _liningInsulation.AValue;
            double b2 = _liningInsulation.BValue;
            double d0 = _furnaceDiameter;
            double d1 = d0 + 2 * h1;
            double t1 = _workTemperature;
            double d2 = d1;
            double t3 = _liningFireproofSurfaceTemperature;
            double t0 = _ambientGasTemperature;

            do
            {
                d2 += 0.01;

                double firstBracket = b1 * Math.Log(d2 / d1) + b2 * Math.Log(d1 / d0);
                double secondBracket = 2 * a1 * Math.Log(d2 / d1) + 2 * a2 * Math.Log(d1 / d0);
                double thirdBracket = 2 * a1 * t1 + b1 * Math.Pow(t1, 2) * Math.Log(d2 / d1);
                double fourthBracket = (2 * a2 * t3 + b2 * Math.Pow(t3, 2)) * Math.Log(d1 / d0);

                t2 = (1 / (2 * firstBracket)) * (-secondBracket + (Math.Pow(secondBracket, 2) + firstBracket * Math.Sqrt(thirdBracket + fourthBracket)));

                x1 = a1 + (b1 * (t1 + t2) / 2);
                q1 = (2 * Math.PI * x1 * (t1 - t2)) / Math.Log(d1 / d0);
                dz = q1 / (Math.PI * (i + j * t3) * (t3 - t0));
            } while (Math.Round(dz, 2) != Math.Round(d2,2) && d2 < 50 * dz);

            this._liningFireproofSurfaceTemperature = t2;
        }

        protected override void CalculateInsulationWidth()
        {
            throw new NotImplementedException();
        }
    }
}
