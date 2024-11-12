using Enciclopedia;

string wikiPath = "data/wiki.txt";
string logPath = "data/log.txt";

List<string> wikiList = FileReader.CreateList(wikiPath);
List<string> logList = FileReader.CreateList(logPath);

TreeNode<string> homeNode = HierarchyManager.CreateHierarchyFromList(wikiList);

LogManager.ComputeLog(logList, homeNode);

homeNode.ProcessPreOrder(PrintNode);

homeNode.ProcessPreOrder(LogManager.SetMostAccessedMonster);
homeNode.ProcessPreOrder(LogManager.SetMostAccessedCard);

Console.WriteLine($"\nCarta mais acessada: {LogManager.MostAccessedCard.value} com {LogManager.MostAccessedCard.Access} acessos");
Console.WriteLine($"Monstro mais acessado: {LogManager.MostAccessedMonster.value} com {LogManager.MostAccessedMonster.Access} acessos.");

void PrintNode(TreeNode<String> node)
{
    Console.WriteLine($"PAGE: {node.value} TYPE: {node.pageType}");
}
