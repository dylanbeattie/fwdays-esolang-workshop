// See https://aka.ms/new-console-template for more information
var parser = new PegExamples.MathExpressionParser();
var result = parser.Parse(@"123 + 456");
Console.WriteLine(result);
Console.WriteLine(result.GetType());
