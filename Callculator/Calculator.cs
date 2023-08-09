using System.Text.RegularExpressions;
using System.Xml;
using System.Xml.XPath;

namespace Callculator;

public static partial class Calculator
{
    public static double Calculate(string expression)
    {
        expression = MyRegex().Replace(expression, "GetFactorial($1)");

        XPathNavigator navigator = new XPathDocument(new StringReader("<r/>")).CreateNavigator();
        XmlNamespaceManager manager = new XmlNamespaceManager(navigator.NameTable);
        manager.AddNamespace("user", "http://user-functions");

        return (double)navigator.Evaluate(string.Format("number({0})", new Regex(@"([\+\-\*])").Replace(
            expression, " ${1} ").Replace("/", " div ").Replace("%", " mod ").Replace("GetFactorial", "user:GetFactorial")), manager);

    }

    private static double GetFactorial(int number)
    {
        double result = 1;

        for (int i = 1; i <= number; i++)
        {
            result *= i;
        }

        return result;
    }

    [GeneratedRegex("(\\d+)\\s*\\!")]
    private static partial Regex MyRegex();
}