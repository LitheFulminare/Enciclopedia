using Enciclopedia;

string wikiPath = "data/wiki.txt";
string logPath = "data/log.txt";

List<string> wikiList = FileReader.CreateList(wikiPath);
List<string> logList = FileReader.CreateList(logPath);

// cria a arvore a partir da lista
TreeNode<string> homeNode = HierarchyManager.CreateHierarchyFromList(wikiList);

// faz o usuario escolher se quer printar a leitura do log para fazer debug
LogManager.isDebugEnabled = GetUserInput();

// calcula o acesso das paginas baseado no log
LogManager.RegisterLog(logList, homeNode);

// pega nó por nó e pega os q tiveram mais acessos
homeNode.ProcessPreOrder(LogManager.SetMostAccessedPages);

Console.WriteLine($"\nCarta mais acessada: {LogManager.MostAccessedCard?.pageName} com {LogManager.MostAccessedCard?.Access} acessos");
Console.WriteLine($"Monstro mais acessado: {LogManager.MostAccessedMonster?.pageName} com {LogManager.MostAccessedMonster?.Access} acessos");

// lê input e para decidir se printa linhas de debug ou nao
bool GetUserInput()
{
    while (true)
    {
        Console.WriteLine("Deseja printar todas as linhas da leitura do log de acessos?");
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
