using Enciclopedia;

TreeNode<char> a = new TreeNode<char>('A');

a.AddChild('B');
TreeNode<char> c = a.AddChild('C');
c.AddChild('D');
c.AddChild('E');
a.AddChild('F');

a.ProcessPreOrder(PrintNode);
a.ProcessPostOrder(PrintNode);
a.ProcessBreadthFirst(PrintNode);

void PrintNode(TreeNode<char> node)
{
    Console.WriteLine(node.value);
}
