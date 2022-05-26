namespace OkeanElzy;

public class Evaluator {
    private Dictionary<string, object> variables = new();
    private Action<object> stdout;

    public Evaluator(Action<object> output) {
        this.stdout = output;
    }

    public object Evaluate(SyntaxNode node) => node switch {
        NumberNode n => n.Value,
        BinaryNode b => Binary(b),
        BlockNode b => Block(b),
        OutputNode n => Output(n),
        AssignNode a => Assign(a),
        LookupNode l => LookupVariable(l),
        _ => throw new Exception($"Unrecognized node type {node.GetType()}")
    };

    private object LookupVariable(LookupNode l) {
        var name = l.Variable.Name;
        if (variables.TryGetValue(name, out var result)) return result;
        throw new Exception($"Unknown variable {name}");
    }

    private object Assign(AssignNode a) {
        var name = a.Variable.Name;
        var value = Evaluate(a.Expression);
        variables[name] = value;
        return value;
    }



    public object Block(BlockNode b) {
        object? result = null;
        foreach (var s in b.Statements) result = Evaluate(s);
        return result;
    }

    public object Output(OutputNode n) {
        var result = Evaluate(n.Expression);
        stdout(result);
        return result;
    }

    public object Binary(BinaryNode b) {
        var tuple = (lhs: Evaluate(b.LHS), rhs: Evaluate(b.RHS), op: b.Operator);
        return tuple switch { { lhs: decimal l, rhs: decimal r, op: Operator.Addition } => l + r, { lhs: decimal l, rhs: decimal r, op: Operator.Multiplication } => l * r, { lhs: decimal l, rhs: decimal r, op: Operator.Subtraction } => l - r, { lhs: decimal l, rhs: decimal r, op: Operator.Division } => l / r,
            _ => throw new InvalidOperationException("I don't know how evaluate that binary node!")
        };
    }
}