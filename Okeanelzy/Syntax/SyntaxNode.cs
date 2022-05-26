using System.Text;

public abstract class SyntaxNode {
    public abstract string ToString(int depth = 0);
}

public abstract class BinaryNode : SyntaxNode {

    public BinaryNode(SyntaxNode lhs, SyntaxNode rhs, Operator op) {
        LHS = lhs;
        RHS = rhs;
        this.Operator = op;
    }
    public Operator Operator { get; }
    public SyntaxNode LHS { get; }
    public SyntaxNode RHS { get; }

    public override string ToString() => this.ToString(0);
    public override string ToString(int depth = 0) {
        var sb = new StringBuilder();
        sb.AppendLine(String.Empty.PadRight(depth * 2) + $"{Operator}:");
        sb.AppendLine(this.LHS.ToString(depth + 1));
        sb.Append(this.RHS.ToString(depth + 1));
        return sb.ToString();
    }

}

public enum Operator {
    Addition,
    Multiplication,
    Division,
    Subtraction
}
public class AdditionNode : BinaryNode {
    public AdditionNode(SyntaxNode lhs, SyntaxNode rhs) : base(lhs, rhs, Operator.Addition) { }
}

public class MultiplicationNode : BinaryNode {
    public MultiplicationNode(SyntaxNode lhs, SyntaxNode rhs) : base(lhs, rhs, Operator.Multiplication) { }
}

public class DivisionNode : BinaryNode {
    public DivisionNode(SyntaxNode lhs, SyntaxNode rhs) : base(lhs, rhs, Operator.Division) { }
}

public class SubtractionNode : BinaryNode {
    public SubtractionNode(SyntaxNode lhs, SyntaxNode rhs) : base(lhs, rhs, Operator.Subtraction) { }
}

public class NumberNode : SyntaxNode {
    public decimal Value { get; } = 0.0m;
    public NumberNode(decimal value) {
        this.Value = value;
    }

    public override string ToString(int depth = 0) => $"{String.Empty.PadRight(depth * 2)}number: {Value}";
}

