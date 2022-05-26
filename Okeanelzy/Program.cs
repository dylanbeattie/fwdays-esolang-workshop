var parser = new OkeanElzy.RockstarParser();
var evaluator = new OkeanElzy.Evaluator();
var program = File.ReadAllText("program.rock");
var ast = parser.Parse(program);
Console.WriteLine(ast);
var result = evaluator.Evaluate(ast);
Console.WriteLine(result);
