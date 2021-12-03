using System;
using System.IO;
using System.Diagnostics;
using Newtonsoft.Json;


namespace CalculatorLibrary
{
    public class Calculator
    {

        JsonWriter writer;
        public Calculator()
        {
            var logFile = File.CreateText(@"F:\Dmitrij\CSharp\Calculator\calculatorLog.json");
            logFile.AutoFlush = true;
            writer = new JsonTextWriter(logFile);
            writer.Formatting = Formatting.Indented;
            writer.WriteStartObject();
            writer.WritePropertyName("Operations");
            writer.WriteStartArray();
        }
        public double DoOperation(double number1, double number2, string option)
        {
            double result = double.NaN;
            writer.WriteStartObject();
            writer.WritePropertyName("Operand1");
            writer.WriteValue(number1);
            writer.WritePropertyName("Operand2");
            writer.WriteValue(number2);
            writer.WritePropertyName("Operation");

            switch (option)
            {
                case "a":
                    result = number1 + number2;
                    writer.WriteValue("Add");
                    break;
                case "s":
                    result = number1 - number2;
                    writer.WriteValue("Subtract");
                    break;
                case "m":
                    result = number1 * number2;
                    writer.WriteValue("Multiply");
                    break;
                case "d":
                    if (number2 is not 0)
                    {
                        result = number1 / number2;
                    }
                    writer.WriteValue("Divide");
                    break;
                default:
                    break;
            }
            writer.WritePropertyName("Result");
            writer.WriteValue(result);
            writer.WriteEndObject();

            return result;
        }
        public void Finish()
        {
            writer.WriteEndArray();
            writer.WriteEndObject();
            writer.Close();
        }
    }
}
