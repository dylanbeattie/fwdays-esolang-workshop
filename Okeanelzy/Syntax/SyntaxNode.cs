using System.Text;

public abstract class SyntaxNode {
    public abstract string ToString(int depth = 0);
}

public abstract class BinaryNode : SyntaxNode {

    public BinaryNode(SyntaxNode lhs, SyntaxNode rhs) {
        LHS = lhs;
        RHS = rhs;
    }

    public SyntaxNode LHS { get; set; }
    public SyntaxNode RHS { get; set; }    
}

public class AdditionNode : BinaryNode {
    public AdditionNode(SyntaxNode lhs, SyntaxNode rhs) : base(lhs, rhs) { }
    public override string ToString() => this.ToString(0);
    public override string ToString(int depth = 0) {
        var sb = new StringBuilder();
        sb.AppendLine(String.Empty.PadRight(depth * 2) + "addition:");
        sb.AppendLine(this.LHS.ToString(depth+1));
        sb.Append(this.RHS.ToString(depth+1));
        return sb.ToString();
    }
}

public class MultiplicationNode : BinaryNode {
    public MultiplicationNode(SyntaxNode lhs, SyntaxNode rhs) : base(lhs, rhs) { }
    public override string ToString() => this.ToString(0);
    public override string ToString(int depth = 0) {
        var sb = new StringBuilder();
        sb.AppendLine(String.Empty.PadRight(depth * 2) + "multiplication:");
        sb.AppendLine(this.LHS.ToString(depth+1));
        sb.Append(this.RHS.ToString(depth+1));
        return sb.ToString();
    }
}


public class NumberNode : SyntaxNode {
    public decimal Value { get; } = 0.0m;
    public NumberNode(decimal value) {
        this.Value = value;
    }
    
    public override string ToString(int depth = 0) => $"{String.Empty.PadRight(depth * 2)}number: {Value}";    
}

