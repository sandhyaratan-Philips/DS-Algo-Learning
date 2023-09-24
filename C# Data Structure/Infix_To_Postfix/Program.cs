using Infix_To_Postfix;

internal class Program
{
    private static void Main(string[] args)
    {
        String infix;

        Console.Write("Enter infix expression : ");
        infix = Console.ReadLine();

        String postfix = infixToPostfix(infix);

        Console.WriteLine("Postfix expression is : " + postfix);

        Console.WriteLine("Value of expression : " + evaluatePostfix(postfix));
    }

    private static string infixToPostfix(string? infix)
    {
        string postfix = "";

        StackChar st = new StackChar(20);

        char next, symbol;
        for (int i = 0; i < infix.Length; i++)
        {
            symbol = infix[i];

            if (symbol == ' ' || symbol == '\t')
                continue;
            switch(symbol)
            {
                case '(':
                    st.Push(symbol);
                    break;
                case ')':
                    while((next=st.Pop()) != '(')
                    {
                        postfix += next;
                    }
                    break;
                case '+':
                case '-':
                case '*':
                case '/':
                case '%':
                case '^':
                    while(!st.IsEmpty()&& Precedence(st.Peek()) >= Precedence(symbol))
                    {
                        postfix += st.Pop();
                    }
                    st.Push(symbol);
                    break;
                default:
                    postfix += symbol; 
                    break;
            }
        }

        while (!st.IsEmpty())
        {
            postfix += st.Pop();
        }

        return postfix;
    }
    private static int evaluatePostfix(string postfix)
    {
       StackInt st = new StackInt(20);

        int x,y;
        for (int i = 0;i < postfix.Length;i++)
        {
            if (char.IsDigit(postfix[i]))
                st.Push(Convert.ToInt32(Char.GetNumericValue(postfix[i])));
            else
            {
                x=st.Pop();
                y = st.Pop();

                switch(postfix[i])
                {
                    case '+':
                        st.Push(y+x); 
                        break;
                    case '-':
                        st.Push( y-x);
                        break;
                    case '*':
                        st.Push(y * x);
                        break;
                    case '/':
                        st.Push(y / x);
                        break;
                    case '%':
                        st.Push(y % x);
                        break;
                    case '^':
                        st.Push(power(x,y));
                        break;
                }
            }
        }
        return st.Pop();
    }

    public static int Precedence(char symbol)
    {
        switch (symbol)
        {
            case '(':
                return 0;
            case '+':
            case '-':
                return 1;
            case '*':
            case '/':
            case '%':
                return 2;
            case '^':
                return 3;
            default:
                return 0;
        }
    }

    public static int power(int a, int b)
    {
        int i, x = 1;
        for (i = 1; i <= a; i++)
            x = x * b;
        return x;
    }
}