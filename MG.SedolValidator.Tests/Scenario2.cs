using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MG.SedolValidator.Tests
{
    [TestClass()]
    public class Scenario2
    {
        [TestInitialize]
        public void Initialize()
        {
        }


        [TestMethod]
        public void Criteria_InputString_InvalidChecksumNonUserDefinedSedol()
        {
            //{Arrange}}
            var expected = new ValidationResult("1234567", false, false, "Checksum digit does not agree with the rest of the input");

            //{Act}}
            var actual = new SedolValidator().ValidateSedol("1234567");

            //{{Assert}}
            Assert.AreEqual(expected.InputString, actual.InputString, "InputString");
            Assert.AreEqual(expected.IsValidSedol, actual.IsValidSedol, "IsValidSedol");
            Assert.AreEqual(expected.IsUserDefined, actual.IsUserDefined, "IsUserDefined");
            Assert.AreEqual(expected.ValidationDetails, actual.ValidationDetails, "ValidationDetails");
            Assert.AreEqual(expected, actual, "Object-ValidationResult");
        }

    }
}