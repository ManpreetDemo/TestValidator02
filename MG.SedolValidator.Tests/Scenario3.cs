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
    public class Scenario3
    {
        [TestInitialize]
        public void Initialize()
        {
        }


        [DataTestMethod]
        [DataRow("0709954", true, false, null)]
        [DataRow("B0YBKJ7", true, false, null)]
        public void Criteria_InputString_ValidNonUserDefineSedol(string input, bool isValid, bool isUserDefined, string validationDetails)
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