using System;
using System.Collections.Generic;

namespace MG.SedolValidator
{
    public class ValidationResult : ISedolValidationResult
    {
        public ValidationResult(string inputString, bool isValidSedol, bool isUserDefined, string validationDetails)
        {
            this.InputString = inputString;
            this.IsValidSedol = isValidSedol;
            this.IsUserDefined = isUserDefined;
            this.ValidationDetails = validationDetails;
        }

        public string InputString { get; private set; }

        public bool IsValidSedol { get; private set; }

        public bool IsUserDefined { get; private set; }

        public string ValidationDetails { get; private set; }

        public override bool Equals(object obj)
        {
            return Equals(obj as ValidationResult);
        }

        public bool Equals(ValidationResult other)
        {
            return other != null &&
                   InputString == other.InputString &&
                   IsValidSedol == other.IsValidSedol &&
                   IsUserDefined == other.IsUserDefined &&
                   ValidationDetails == other.ValidationDetails;
        }

        public override int GetHashCode()
        {
            var hashCode = -1100762955;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(InputString);
            hashCode = hashCode * -1521134295 + IsValidSedol.GetHashCode();
            hashCode = hashCode * -1521134295 + IsUserDefined.GetHashCode();
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(ValidationDetails);
            return hashCode;
        }
    }
}
