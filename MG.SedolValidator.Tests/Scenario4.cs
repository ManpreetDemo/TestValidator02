using Microsoft.VisualStudio.TestTools.UnitTesting;
using MG.SedolValidator;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.SedolValidator.Tests
{
    [TestClass()]
    public class Scenario4
    {
        [TestInitialize]
        public void Initialize()
        {
        }


        [DataTestMethod]
        [DataRow("9123451", false, true, "Checksum digit does not agree with the rest of the input")]
        [DataRow("9ABCDE8", false, true, "Checksum digit does not agree with the rest of the input")]
        public void Criteria_InputString_InvalidChecksumUserDefinedSedol(string input, bool isValid, bool isUserDefined, string validationDetails)
        {
            //{Arrange}}
            var expected = new ValidationResult(input, isValid, isUserDefined, validationDetails);

            //{Act}}
            var actual = new SedolValidator().ValidateSedol(input);

            //{{Assert}}
            Assert.AreEqual(expected.InputString, actual.InputString, "InputString");
            Assert.AreEqual(expected.IsValidSedol, actual.IsValidSedol, "IsValidSedol");
            Assert.AreEqual(expected.IsUserDefined, actual.IsUserDefined, "IsUserDefined");
            Assert.AreEqual(expected.ValidationDetails, actual.ValidationDetails, "ValidationDetails");
            Assert.AreEqual(expected, actual, "Object-ValidationResult");
        }

    }
}