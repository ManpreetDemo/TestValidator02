using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MG.SedolValidator.Tests
{
    [TestClass()]
    public class Scenario1
    {
        [TestInitialize]
        public void Initialize()
        {
        }

        [DataTestMethod]
        [DataRow(null, false, false, "Input string was not 7-characters long")]
        [DataRow("", false, false, "Input string was not 7-characters long")]
        [DataRow("12", false, false, "Input string was not 7-characters long")]
        [DataRow("123456789", false, false, "Input string was not 7-characters long")]
        public void Criteria_InputString_NullOrEmptyOrNot7Chars(string input, bool isValid, bool isUserDefined, string validationDetails)
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