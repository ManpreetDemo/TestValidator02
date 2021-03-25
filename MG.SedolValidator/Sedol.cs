using System;
using System.Globalization;
using System.Linq;
namespace MG.SedolValidator
{
    public sealed class Sedol
    {
        public readonly string Value;
        public readonly int[] CharWeights;
        private ISedolValidationResult _validationResult = null;

        public Sedol(string value)
        {
            Value = value;

            _validationResult = null;
        }

        public ISedolValidationResult GetValidationResult()
        {
            if (_validationResult == null)
            {                 
                _validationResult = new ValidationResult(Value, IsValid(out string validationDetails, out bool skipIsUserDefinedValidation), IsUserDefined(ref validationDetails, ref skipIsUserDefinedValidation), validationDetails);
            }
            return _validationResult;
        }

        private bool IsValid(out string validationDetails, out bool skipIsUserDefinedValidation)
        {
            validationDetails = null;
            skipIsUserDefinedValidation = true;
            if (string.IsNullOrEmpty(Value))
            {
                validationDetails = SedolConstants.ExceptionInvalidLength;
                return false;
            }

            if (Value.Length != SedolConstants.Length)
            {
                validationDetails = SedolConstants.ExceptionInvalidLength;
                return false;
            }

            foreach (char c in Value)
            {
                if (SedolConstants.AllowedChars.IndexOf(c) < 0)
                {
                    validationDetails = SedolConstants.ExceptionInvalidCharacters;
                    return false;
                }
            }

            skipIsUserDefinedValidation = false;
            var checksumDigitChar = GetChecksumDigit();
            var lastChar = Value.Last();
            if (lastChar != checksumDigitChar)
            {
                validationDetails = SedolConstants.ExceptionChecksumDigitDoesNotAgree;
                return false;
            }

            return true;
        }

        private bool IsUserDefined(ref string validationDetails, ref bool skipIsUserDefinedValidation)
        {
            if (string.IsNullOrEmpty(Value) || skipIsUserDefinedValidation) return false;
            bool result = Value[SedolConstants.UserDefinedCharIndex] == SedolConstants.UserDefinedCharPrefix;
            return result;
        }

        private char GetChecksumDigit()
        {
            string valuePart1 = Value.Substring(0, 6);
            //string valuePart2 = Value.Substring(Value.Length - 1);
            int weightedSum = 0;
            for (int i = 0; i < valuePart1.Length; i++)
            {
                int w = SedolConstants.CharWeights[i]; //weight
                char c = valuePart1[i]; //char
                int m = 0; //multiplier

                if (Char.IsDigit(c)) m = (int)(c - '0');
                else m = SedolConstants.AllowedChars.IndexOf(c); // char index

                weightedSum += w * m;
            }
            var checksum = (10 - (weightedSum % 10)) % 10;
            var checksumDigitChar = Convert.ToChar(checksum.ToString(CultureInfo.InvariantCulture));
            return checksumDigitChar;
        }
    }

    public class SedolConstants
    {
        public const char UserDefinedCharPrefix = '9';
        public const int UserDefinedCharIndex = 0;
        public const int Length = 7;
        public const string AllowedChars = "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZ";
        public static readonly int[] CharWeights = new int[] { 1, 3, 1, 7, 3, 9, 1 };
        public const string ExceptionNullOrEmpty = "Sedol was null or empty.";
        public static readonly string ExceptionInvalidLength = $"Input string was not {Length}-characters long";
        public const string ExceptionInvalidCharacters = "SEDOL contains invalid characters";
        public const string ExceptionChecksumDigitDoesNotAgree = "Checksum digit does not agree with the rest of the input";

    }
}
