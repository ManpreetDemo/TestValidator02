using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MG.SedolValidator
{
    class Program
    {
        const string formatScenario = "{0,25} | {1,12} | {2,14} | {3,30}";

        static void Main(string[] args)
        {
            Console.WriteLine("\n");
            Scenario1();
            Console.WriteLine("\n");
            Scenario2();
            Console.WriteLine("\n");
            Scenario3();
            Console.WriteLine("\n");
            Scenario4();
            Console.WriteLine("\n");
            Scenario5();
            Console.WriteLine("\n");
            Scenario6();

            Console.ReadKey();
        }

        private static void Scenario1()
        {
            Console.WriteLine("*** Scenario 1 ***\n");
            Console.WriteLine("Null, empty string or string other than 7 characters long\n");
            List<string> scenarioList = new List<string>
            {
                "Null|False|False|Input string was not 7-characters long",
                "\"\"|False|False|Input string was not 7-characters long",
                "12|False|False|Input string was not 7-characters long",
                "123456789|False|False|Input string was not 7-characters long"
            };
            Console.WriteLine(formatScenario, "InputString Test Value", "IsValidSedol", "IsUserDefined", "ValidationDetails");
            Console.WriteLine(new String('-', 100));

            foreach (var scenario in scenarioList)
            {
                var sArr = scenario.Split('|');
                var result = new ValidationResult(sArr[0], Convert.ToBoolean(sArr[1]), Convert.ToBoolean(sArr[2]), sArr[3]);
                Console.WriteLine(formatScenario, result.InputString, result.IsValidSedol, result.IsUserDefined, result.ValidationDetails);
            }
        }

        private static void Scenario2()
        {            
            Console.WriteLine("*** Scenario 2 ***\n");
            Console.WriteLine("Invalid Checksum non user defined SEDOL\n");
            List<string> scenarioList = new List<string>
            {
                "1234567|False|False|Checksum digit does not agree with the rest of the input"
            };
            Console.WriteLine(formatScenario, "InputString Test Value", "IsValidSedol", "IsUserDefined", "ValidationDetails");
            Console.WriteLine(new String('-', 100));

            foreach (var scenario in scenarioList)
            {
                var sArr = scenario.Split('|');
                var result = new ValidationResult(sArr[0], Convert.ToBoolean(sArr[1]), Convert.ToBoolean(sArr[2]), sArr[3]);
                Console.WriteLine(formatScenario, result.InputString, result.IsValidSedol, result.IsUserDefined, result.ValidationDetails);
            }

        }

        private static void Scenario3()
        {
            Console.WriteLine("*** Scenario 3 ***\n");
            Console.WriteLine("Valid non user define SEDOL\n");
            List<string> scenarioList = new List<string>
            {
                "0709954|True|False|Null",
                "B0YBKJ7|True|False|Null"
            };
            Console.WriteLine(formatScenario, "InputString Test Value", "IsValidSedol", "IsUserDefined", "ValidationDetails");
            Console.WriteLine(new String('-', 100));

            foreach (var scenario in scenarioList)
            {
                var sArr = scenario.Split('|');
                var result = new ValidationResult(sArr[0], Convert.ToBoolean(sArr[1]), Convert.ToBoolean(sArr[2]), sArr[3]);
                Console.WriteLine(formatScenario, result.InputString, result.IsValidSedol, result.IsUserDefined, result.ValidationDetails);
            }
        }

        private static void Scenario4()
        {
            Console.WriteLine("*** Scenario 4 ***\n");
            Console.WriteLine("Invalid Checksum user defined SEDOL\n");
            List<string> scenarioList = new List<string>
            {
                "9123451|False|True|Checksum digit does not agree with the rest of the input",
                "9ABCDE8|False|True|Checksum digit does not agree with the rest of the input"
            };
            Console.WriteLine(formatScenario, "InputString Test Value", "IsValidSedol", "IsUserDefined", "ValidationDetails");
            Console.WriteLine(new String('-', 100));

            foreach (var scenario in scenarioList)
            {
                var sArr = scenario.Split('|');
                var result = new ValidationResult(sArr[0], Convert.ToBoolean(sArr[1]), Convert.ToBoolean(sArr[2]), sArr[3]);
                Console.WriteLine(formatScenario, result.InputString, result.IsValidSedol, result.IsUserDefined, result.ValidationDetails);
            }
        }

        private static void Scenario5()
        {
            Console.WriteLine("*** Scenario 5 ***\n");
            Console.WriteLine("Invaid characters found\n");
            List<string> scenarioList = new List<string>
            {
                "9123_51|False|False|SEDOL contains invalid characters",
                "VA.CDE8|False|False|SEDOL contains invalid characters"
            };
            Console.WriteLine(formatScenario, "InputString Test Value", "IsValidSedol", "IsUserDefined", "ValidationDetails");
            Console.WriteLine(new String('-', 100));

            foreach (var scenario in scenarioList)
            {
                var sArr = scenario.Split('|');
                var result = new ValidationResult(sArr[0], Convert.ToBoolean(sArr[1]), Convert.ToBoolean(sArr[2]), sArr[3]);
                Console.WriteLine(formatScenario, result.InputString, result.IsValidSedol, result.IsUserDefined, result.ValidationDetails);
            }
        }

        private static void Scenario6()
        {
            Console.WriteLine("*** Scenario 6 ***\n");
            Console.WriteLine("Valid user defined SEDOL\n");
            List<string> scenarioList = new List<string>
            {
                "9123458|True|True|Null",
                "9ABCDE1|True|True|Null"
            };
            Console.WriteLine(formatScenario, "InputString Test Value", "IsValidSedol", "IsUserDefined", "ValidationDetails");
            Console.WriteLine(new String('-', 100));

            foreach (var scenario in scenarioList)
            {
                var sArr = scenario.Split('|');
                var result = new ValidationResult(sArr[0], Convert.ToBoolean(sArr[1]), Convert.ToBoolean(sArr[2]), sArr[3]);
                Console.WriteLine(formatScenario, result.InputString, result.IsValidSedol, result.IsUserDefined, result.ValidationDetails);
            }
        }
       
    }
}
