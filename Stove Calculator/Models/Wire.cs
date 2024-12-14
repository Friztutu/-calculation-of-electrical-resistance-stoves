using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator.Models
{
    public class Wire
    {
        [Key]
        public required int WireId { get; set; }
        public required double Diameter { get; set; }
        public required double Thickness { get; set; }
        public required bool IsRecommenderWidth1 { get; set; }
        public required bool IsRecommenderWidth2 { get; set; }
        public required bool IsRecommenderWidth4 { get; set; }
        public required bool IsRecommenderWidth6 { get; set; }
        public required bool IsRecommenderWidth8 { get; set; }
        public required bool IsRecommenderWidth10 { get; set; }
        public required bool IsRecommenderWidth12 { get; set; }
        public required bool IsRecommenderWidth14 { get; set; }
        public required bool IsRecommenderWidth16 { get; set; }
        public required bool IsRecommenderWidth18 { get; set; }
        public required bool IsRecommenderWidth20 { get; set; }
        public required bool IsRecommenderWidth25 { get; set; }
        public required bool IsRecommenderWidth30 { get; set; }
    }
}
