using Enciclopedia;

string wikiPath = "data/wiki.txt";
string logPath = "data/log.txt";

List<string> wikiList = FileReader.CreateList(wikiPath);
List<string> logList = FileReader.CreateList(logPath);

TreeNode<string> homeNode = HierarchyManager.CreateHierarchyFromList(wikiList);

LogManager.ComputeData(logList, homeNode);

//homeNode.ProcessPreOrder(PrintNode);

//Console.WriteLine($"{homeNode.GetChild(0).value}");
//if (homeNode.Parent == null) Console.WriteLine("Não tem pai");

void PrintNode(TreeNode<String> node)
{
    Console.WriteLine(node.value);
}
