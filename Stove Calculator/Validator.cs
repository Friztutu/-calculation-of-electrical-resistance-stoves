using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Stove_Calculator
{
    public class Validator
    {
        public bool isCorrectSymbol(string text ,int symbolCode)
        {
            bool isCorrect = true;

            if (symbolCode == 46 && text == "")
                isCorrect = false;
            else if(symbolCode != 46 && (symbolCode > 57 || symbolCode < 48) && symbolCode != 8)
                isCorrect = false;
            
            return isCorrect;
        }
    }
}
