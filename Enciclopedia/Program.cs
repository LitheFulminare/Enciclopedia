using Enciclopedia;

string wikiPath = "data/wiki.txt";

List<string?> wikiList = FileReader.CreateList(wikiPath);

TreeNode<string> homeNode = HierarchyManager.CreateHierarchyFromList(wikiList);

homeNode.ProcessPreOrder(PrintNode);

//foreach (string? wiki in wikiList)
//{
//    Console.WriteLine(wiki);
//}

//TreeNode<string> a = new TreeNode<string>("A");

//a.AddChild("B");
//TreeNode<string> c = a.AddChild("C");
//c.AddChild("D");
//c.AddChild("E");
//a.AddChild("F");

//a.ProcessPreOrder(PrintStringNode);
//a.ProcessPostOrder(PrintStringNode);
//a.ProcessBreadthFirst(PrintStringNode);

void PrintNode(TreeNode<String> node)
{
    Console.WriteLine(node.value);
}
