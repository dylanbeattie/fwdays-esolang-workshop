namespace OkeanElzy;

public class Evaluator {
    public object Evaluate(SyntaxNode node) => node switch {
        NumberNode n => n.Value,
        BinaryNode b => Binary(b),
        _ => throw new Exception($"Unrecognized node type {node.GetType()}")
    };


    public object Binary(BinaryNode b) {
        var tuple = (lhs: Evaluate(b.LHS), rhs: Evaluate(b.RHS), op: b.Operator);
        return tuple switch { 
            { lhs: decimal l, rhs: decimal r, op: Operator.Addition } => l + r, 
            { lhs: decimal l, rhs: decimal r, op: Operator.Multiplication } => l * r,
            { lhs: decimal l, rhs: decimal r, op: Operator.Subtraction } => l - r,
            { lhs: decimal l, rhs: decimal r, op: Operator.Division } => l / r,
            _ => throw new InvalidOperationException("I don't know how evaluate that binary node!")
        };
    }
}