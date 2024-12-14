using Gnostice.Documents.DOM;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class Transformers
    {
        [Key]
        public required int TransformersId { get; set; }
        public required string Name { get; set; }
        public required int NumberOfPhases {  get; set; }
        public required int[] MainsVoltage { get; set; }
        public required int[] Power {  get; set; }
        public required int[] AdjustableVoltage { get; set; }
        public required int[] MinimumLoadCurrent {  get; set; }
    }
}
