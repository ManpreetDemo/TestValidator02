using System;
using System.Collections.Generic;

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

        private static void DisplayScenario(string scenarioTitle, string scenarioDescription, List<string> scenarioList)
        {
            Console.WriteLine(scenarioTitle);
            Console.WriteLine(scenarioDescription);

            Console.WriteLine(formatScenario, "InputString Test Value", "IsValidSedol", "IsUserDefined", "ValidationDetails");
            Console.WriteLine(new String('-', 100));

            foreach (var scenario in scenarioList)
            {
                var sArr = scenario.Split('|');
                var result = new ValidationResult(sArr[0], Convert.ToBoolean(sArr[1]), Convert.ToBoolean(sArr[2]), sArr[3]);
                Console.WriteLine(formatScenario, result.InputString, result.IsValidSedol, result.IsUserDefined, result.ValidationDetails);
            }

        }

        private static void Scenario1()
        {
            List<string> scenarioList = new List<string>
            {
                "Null|False|False|Input string was not 7-characters long",
                "\"\"|False|False|Input string was not 7-characters long",
                "12|False|False|Input string was not 7-characters long",
                "123456789|False|False|Input string was not 7-characters long"
            };

            DisplayScenario(scenarioTitle: "*** Scenario 1 ***\n", scenarioDescription: "Null, empty string or string other than 7 characters long\n", scenarioList: scenarioList);
        }      

        private static void Scenario2()
        {            
            List<string> scenarioList = new List<string>
            {
                "1234567|False|False|Checksum digit does not agree with the rest of the input"
            };
            DisplayScenario(scenarioTitle: "*** Scenario 2 ***\n", scenarioDescription: "Invalid Checksum non user defined SEDOL\n", scenarioList: scenarioList);
        }

        private static void Scenario3()
        {            
            List<string> scenarioList = new List<string>
            {
                "0709954|True|False|Null",
                "B0YBKJ7|True|False|Null"
            };
            DisplayScenario(scenarioTitle: "*** Scenario 3 ***\n", scenarioDescription: "Valid non user define SEDOL\n", scenarioList: scenarioList);
        }

        private static void Scenario4()
        {
            List<string> scenarioList = new List<string>
            {
                "9123451|False|True|Checksum digit does not agree with the rest of the input",
                "9ABCDE8|False|True|Checksum digit does not agree with the rest of the input"
            };
            DisplayScenario(scenarioTitle: "*** Scenario 4 ***\n", scenarioDescription: "Invalid Checksum user defined SEDOL\n", scenarioList: scenarioList);
        }

        private static void Scenario5()
        {            
            List<string> scenarioList = new List<string>
            {
                "9123_51|False|False|SEDOL contains invalid characters",
                "VA.CDE8|False|False|SEDOL contains invalid characters"
            };
            DisplayScenario(scenarioTitle: "*** Scenario 5 ***\n", scenarioDescription: "Invaid characters found\n", scenarioList: scenarioList);
        }

        private static void Scenario6()
        {
            List<string> scenarioList = new List<string>
            {
                "9123458|True|True|Null",
                "9ABCDE1|True|True|Null"
            };
            DisplayScenario(scenarioTitle: "*** Scenario 6 ***\n", scenarioDescription: "Valid user defined SEDOL\n", scenarioList: scenarioList);
        }
       
    }
}
