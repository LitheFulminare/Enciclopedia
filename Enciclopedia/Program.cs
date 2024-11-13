using Enciclopedia;

string wikiPath = "data/wiki.txt";
string logPath = "data/log.txt";

List<string> wikiList = FileReader.CreateList(wikiPath);
List<string> logList = FileReader.CreateList(logPath);

TreeNode<string> homeNode = HierarchyManager.CreateHierarchyFromList(wikiList);

// determina se printa a leitura do log para fazer debug
LogManager.isDebugEnabled = GetUserInput();

// calcula o acesso das paginas baseado no log
LogManager.RegisterLog(logList, homeNode);

homeNode.ProcessPreOrder(LogManager.SetMostAccessedPage);

Console.WriteLine($"\nCarta mais acessada: {LogManager.MostAccessedCard.pageName} com {LogManager.MostAccessedCard.Access} acessos");
Console.WriteLine($"Monstro mais acessado: {LogManager.MostAccessedMonster.pageName} com {LogManager.MostAccessedMonster.Access} acessos.");

// lê input e para decidir se printa linhas de debug ou nao
bool GetUserInput()
{
    while (true)
    {
        Console.WriteLine("Pritar linhas de debug da leitura do log?");
        Console.WriteLine("1 - Sim");
        Console.WriteLine("2 - Não\n");
        string? userInputStr = Console.ReadLine();

        if (userInputStr == "1")
        {
            return true;
        }

        else if (userInputStr == "2")
        {
            return false;
        }

        else
        {
            Console.WriteLine($"\n'{userInputStr}' não é uma opção válida\n");
        }
    }
}
