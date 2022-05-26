// See https://aka.ms/new-console-template for more information
var parser = new PegExamples.MathExpressionParser();
Run("12 + 34 * 56 + 78 + 1  + 2 + 3 + 4 + 5");
Run("1 + 2 + 3 + 4 + 34 * 56 + 78 + 12 + 5");

void Run(string expression) {
    Console.WriteLine(String.Empty.PadLeft(60, '-'));
    Console.WriteLine(expression);
    var result = parser.Parse(expression);
    Console.WriteLine(result);
    Console.WriteLine(result.GetType());
}
