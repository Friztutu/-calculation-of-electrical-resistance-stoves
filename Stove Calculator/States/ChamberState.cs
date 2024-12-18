using Stove_Calculator.Calculators;
using Stove_Calculator.Models;
using Constant = Stove_Calculator.Constans.Constant;
using Stove_Calculator.Furnace_parts;

namespace Stove_Calculator.States
{
    public class ChamberState
    {
        private InputData _inputData;
        private ChamberLining _chamberLining;
        private Overlap _chamberOverlap;
        private CarborundHeater _carborundHeater;
        private MolybdenHeater _molybdenHeater;
        private MetalHeaters _metalHeaters;

        public ChamberLining ChamberLining => _chamberLining;
        public Overlap ChamberOverlap => _chamberOverlap;
        public CarborundHeater CarborundHeater => _carborundHeater;
        public MolybdenHeater MolybdenHeater => _molybdenHeater;
        public MetalHeaters MetalHeaters => _metalHeaters;

        public ChamberState(InputData inputData)
        {
            _inputData = inputData;
            _chamberLining = new(inputData);
            _chamberOverlap = new(inputData);
            _carborundHeater = new(inputData, _chamberLining, _chamberOverlap);
            _molybdenHeater = new(inputData, _chamberLining, _chamberOverlap);
        }

        public void ChangeLiningFireroofWidth(double h1)
        {
            _chamberLining.h1 = h1;
        }
        public void ChangeLiningFireproof(Fireproof liningFireproof)
        {
            _chamberLining.CurrentLiningFireproof = liningFireproof;
        }

        public unsafe void ChangeLiningInsulation(ThermalInsulation liningInsultion)
        {
            _chamberLining.CurrentLiningInsulation = liningInsultion;
        }

        public void ChangeOverlapFireproofWidth(double h3)
        {
            this._chamberOverlap.h3 = h3;
        }

        public void ChangeOverlapInsulationWidth(double h4)
        {
            this._chamberOverlap.h4 = h4;
        }

        public void ChangeOverlapFireproof(Fireproof overlapFireproof)
        {
            this._chamberOverlap.CurrentOverlapFireproof = overlapFireproof;
        }

        public void ChangeOverlapInsulation(ThermalInsulation overlapInsulation)
        {
            this._chamberOverlap.CurrentOverlapInsulation = overlapInsulation;
        }

        public void MoveTChanged(int index)
        {
            _carborundHeater.MoveT = Constant.T[index];
        }

        public void CarborundumHeaterChanget(int index)
        {
            if (_carborundHeater.CarborundumHeaters == null) return;

            this._carborundHeater.CurrentCarborundumHeaters = _carborundHeater.CarborundumHeaters[index];
        }

        public void MolibdenuimHeaterChanget(int index)
        {
            if (_molybdenHeater.MolybdenHeaters == null) return;

            this._molybdenHeater.CurrentMolybdenHeater = _molybdenHeater.MolybdenHeaters[index];
        }
    }
}
