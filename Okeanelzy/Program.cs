var parser = new OkeanElzy.RockstarParser();
var evaluator = new OkeanElzy.Evaluator();
var program = @"4/2+8/4+10/5";
var ast = parser.Parse(program);
Console.WriteLine(ast);
var result = evaluator.Evaluate(ast);
Console.WriteLine(result);
