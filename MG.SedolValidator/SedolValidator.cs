using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.SedolValidator
{
    public class SedolValidator : ISedolValidator
    {
        public ISedolValidationResult ValidateSedol(string input)
        {
            return new Sedol(input).GetValidationResult();
        }
    }
}
