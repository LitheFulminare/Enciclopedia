using Enciclopedia;

string wikiPath = "data/wiki.txt";
string logPath = "data/log.txt";

List<string> wikiList = FileReader.CreateList(wikiPath);
List<string> logList = FileReader.CreateList(logPath);

TreeNode<string> homeNode = HierarchyManager.CreateHierarchyFromList(wikiList);

LogManager.ComputeData(logList, homeNode);

void PrintNode(TreeNode<String> node)
{
    Console.WriteLine(node.value);
}
