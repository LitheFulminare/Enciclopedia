using Enciclopedia;

string wikiPath = "data/wiki.txt";
string logPath = "data/log.txt";

List<string> wikiList = FileReader.CreateList(wikiPath);
List<string> logList = FileReader.CreateList(logPath);

TreeNode<string> homeNode = HierarchyManager.CreateHierarchyFromList(wikiList);

// lê input e para decidir se printa linhas de debug ou nao
bool validInput = false;
while (!validInput)
{
    Console.WriteLine("Pritar linhas de debug para a leitura do log?");
    Console.WriteLine("1 - Sim");
    Console.WriteLine("2 - Não\n");
    string? userInputStr = Console.ReadLine();

    if (userInputStr == "1")
    {
        validInput = LogManager.isDebug = true;
    }

    else if (userInputStr == "2")
    {
        validInput = true;
    }

    else
    {
        Console.WriteLine($"\n'{userInputStr}' não é uma opção válida\n");
    }
}

LogManager.ComputeLog(logList, homeNode);

homeNode.ProcessPreOrder(LogManager.SetMostAccessedMonster);
homeNode.ProcessPreOrder(LogManager.SetMostAccessedCard);

Console.WriteLine($"\nCarta mais acessada: {LogManager.MostAccessedCard.pageName} com {LogManager.MostAccessedCard.Access} acessos");
Console.WriteLine($"Monstro mais acessado: {LogManager.MostAccessedMonster.pageName} com {LogManager.MostAccessedMonster.Access} acessos.");
