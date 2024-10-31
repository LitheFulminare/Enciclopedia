using Enciclopedia;

string wikiPath = "data/wiki.txt";

TreeNode<string> homeNode = new TreeNode<string>("Home");

List<string?> wikiList = FileReader.CreateList(wikiPath);

foreach (string? wiki in wikiList)
{
    Console.WriteLine(wiki);
}

// LOGICA 
// primeiro cria a Home
// procura por '.'
// se tem 1 ponto a mais do que o anterior, adiciona como filho
// se tem igual, adiciona como irmão (filho do último pai encontrado)

// ou

// vai realizando a lógica por número de pontos
// 1 ponto -> filho do home
// 2 pontos -> filho do ultimo filho do home
// 3 pontos -> filho do ultimo filho do filho


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
