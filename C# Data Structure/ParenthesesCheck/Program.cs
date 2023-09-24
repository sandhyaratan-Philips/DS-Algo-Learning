internal class Program
{
    private static void Main(string[] args)
    {
        String expression;

        Console.Write("Enter an expression with parentheses : ");
        expression = Console.ReadLine();

        if (IsValid(expression))
            Console.WriteLine("Valid expression");
        else
            Console.WriteLine("Invalid expression");
    }

    private static bool IsValid(string expression)
    {
        Stack<char> stack = new Stack<char>();
        for (int i = 0; i < expression.Length; i++)
        {
            if (expression[i]=='('|| expression[i] == '['|| expression[i] == '{')
            {
                stack.Push(expression[i]);
            }
            if (expression[i] == ')'|| expression[i] == '}'|| expression[i] == ']')
            {
                if (stack.Any())
                {
                    Console.WriteLine("invalid");
                    return false;
                }
                else
                {
                    char c = stack.Pop();
                    if (!MatchParentheses(c, expression[i]))
                    {
                        return false;
                    }
                }
            }
        }
        return stack.Any();
    }
    static bool MatchParentheses(char leftPar, char rightPar)
    {
        if (leftPar == '[' && rightPar == ']')
            return true;
        if (leftPar == '{' && rightPar == '}')
            return true;
        if (leftPar == '(' && rightPar == ')')
            return true;
        return false;
    }
}