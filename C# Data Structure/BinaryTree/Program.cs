using BinaryTree;

internal class Program
{
    private static void Main(string[] args)
    {
        BinaryTre bt = new BinaryTre();

        bt.CreateTree();

        bt.Display();
        Console.WriteLine();

        Console.WriteLine("Preorder : ");
        bt.Preorder();
        Console.WriteLine("");

        Console.WriteLine("Inorder : ");
        bt.Inorder();
        Console.WriteLine();

        Console.WriteLine("Postorder : ");
        bt.Postorder();
        Console.WriteLine();

        Console.WriteLine("Level order : ");
        bt.LevelOrder();
        Console.WriteLine();

        Console.WriteLine("Height of tree is " + bt.Height());
    }
}